using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Timers;
using SmartTrash.Data;
using SmartTrash.Models;


namespace Faker
{
    class DataFaker
    {
        public DataFaker(TrashContext trashContext, IVolumeFillStrategy fillStrategy)
        {
            _trashContext = trashContext ?? throw new ArgumentNullException(nameof(trashContext));
            _newVolumeGenerator = fillStrategy ?? throw new ArgumentNullException(nameof(fillStrategy));
            _currentVirtualDateTime = DateTime.Now;
            _cachedWasteCollectionAreas = new List<WasteCollectionArea>();
            TimeFactor = 1.0F;
        }

        public void Run()
        {
            char key;
            UpdateWasteCollectionAreasCache();

            _timer = new System.Timers.Timer(1000);

            _timer.Elapsed += UpdateFakeData;
            _timer.AutoReset = true;
            _timer.Enabled = true;

            do
            {
                key = Console.ReadKey().KeyChar;
                if (key == 'p')
                {
                    _timer.Enabled = !_timer.Enabled;
                    Console.WriteLine(_timer.Enabled ? "Faker resumed" : "Faker paused");
                }
            } while (key != 'q');

            _timer.Stop();
            _timer.Dispose();
            ClearWasteCollectionAreasCache();
        }

        private void UpdateWasteCollectionAreasCache()
        {
            _cachedWasteCollectionAreas = _trashContext.WasteCollectionAreas.ToList();
        }

        private void ClearWasteCollectionAreasCache()
        {
            _cachedWasteCollectionAreas.Clear();
        }

        private void UpdateFakeData(object sender, ElapsedEventArgs e)
        {
            _currentVirtualDateTime = _currentVirtualDateTime.AddSeconds(TimeFactor);

            foreach (WasteCollectionArea waste in _cachedWasteCollectionAreas)
            {
                // Here we will generate new volume value for concrete waste
                _newVolumeGenerator.SetNewVolume(
                    waste, _currentVirtualDateTime, new TimeSpan((long)(TimeFactor / 100e-9)));
                _trashContext.Update(waste);
            }

            _trashContext.SaveChanges();

            Console.WriteLine(
                "Current virtual time: {0:yyyy-MM-dd HH:mm:ss}", 
                _currentVirtualDateTime);
        }

        private List<WasteCollectionArea> _cachedWasteCollectionAreas;
        private System.Timers.Timer _timer;
        private readonly IVolumeFillStrategy _newVolumeGenerator;
        private readonly TrashContext _trashContext;
        private DateTime _currentVirtualDateTime;
        private double _timeFactor;

        // Time factor presents how many virtual 
        // seconds passed in one real second
        public double TimeFactor
        {
            get { return _timeFactor; }
            set { if (value > 0) { _timeFactor = value; } }
        }
    }

    public interface IVolumeFillStrategy
    {
        void SetNewVolume(WasteCollectionArea waste, DateTime currentDateTime, TimeSpan timePassed);
    }

    public class RandomFillVolume : IVolumeFillStrategy
    {
        public RandomFillVolume() { _random = new Random(); }

        public void SetNewVolume(WasteCollectionArea waste, DateTime currentDateTime, TimeSpan timePassed)
        {
            decimal newVolume = waste.FilledVolume + (decimal)(_random.NextDouble() * 100);
            waste.FilledVolume = (newVolume > waste.Volume) ? waste.Volume : newVolume;
        }
        private Random _random;
    }

    public class OnTimeBasedFillVolume : IVolumeFillStrategy
    {
        public OnTimeBasedFillVolume()
        {
            _random = new Random();
            _wasteFillFactors = new Dictionary<int, double>();
            _todayClearedWastes = new Dictionary<int, bool>();
        }

        public void SetNewVolume(WasteCollectionArea waste, DateTime currentDateTime, TimeSpan timePassed)
        {
            if (waste.Volume <= 0)
            {
                return;
            }

            if (!_todayClearedWastes.Keys.Contains(waste.Id))
            {
                _todayClearedWastes.Add(waste.Id, false);
            }

            if (!_wasteFillFactors.Keys.Contains(waste.Id))
            {
                // Assumes that some of wastes filles more quickly than others
                _wasteFillFactors.Add(waste.Id, 1.0 + _random.NextDouble() * 4.0);
            }

            bool wasteClearedToday = _todayClearedWastes[waste.Id];
            double wasteFillFactor = _wasteFillFactors.GetValueOrDefault(waste.Id, 1.0F);

            int hoursToSeconds(int x) => x * 3600;

            int currentHour = currentDateTime.TimeOfDay.Hours;
            double currentTimeTotalSeconds = currentDateTime.TimeOfDay.TotalSeconds;

            bool isDay() => _beginWorkHour <= currentHour && currentHour <= _endWorkHour;
            if (isDay())
            {
                double garbageCollectProbability = (1 * timePassed.TotalSeconds) / 
                    (hoursToSeconds(_endWorkHour) - hoursToSeconds(_beginWorkHour)); 
                
                // 90 % Filled wastes has more garbage collect probability (+20%)
                if ((double)(waste.FilledVolume / waste.Volume) >= 0.9)
                {
                    garbageCollectProbability += (0.20 * timePassed.TotalSeconds) /
                        (hoursToSeconds(_endWorkHour) - hoursToSeconds(_beginWorkHour)); 
                }

                if (_random.NextDouble() < garbageCollectProbability && 
                    !wasteClearedToday)
                {
                    Console.WriteLine($"Waste {waste.Name} was cleared. Filled volume was {waste.FilledVolume}");
                    waste.FilledVolume = 0;
                    _todayClearedWastes[waste.Id] = true;
                }
            }

            if (currentTimeTotalSeconds <= (2 * timePassed.TotalSeconds))
            {
                _todayClearedWastes[waste.Id] = false;
            }

            // Once a mounth somebody throws out a granmother's case
            if ((timePassed.TotalSeconds / (3600 * 24 * 30)) > _random.NextDouble())
            {
                waste.FilledVolume = waste.Volume; 
            }

            decimal newVolume = waste.FilledVolume + 
                (decimal)(((isDay() ? _wasteFillFactors[waste.Id] : 1.0) * 
                timePassed.TotalSeconds * ((double)waste.Volume / (7.5 * _secondsInDay))) + 
                _random.NextDouble() * timePassed.TotalMinutes);

            waste.FilledVolume = (newVolume > waste.Volume) ? waste.Volume : newVolume;
        }

        private const int _secondsInDay = 3600 * 24;
        private const int _beginWorkHour = 7;
        private const int _endWorkHour = 22;
        private readonly Random _random;
        private Dictionary<int, bool> _todayClearedWastes;
        private Dictionary<int, double> _wasteFillFactors;
    }
}
