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
            UpdateWasteCollectionAreasCache();

            _timer = new System.Timers.Timer(1000);

            _timer.Elapsed += UpdateFakeData;
            _timer.AutoReset = true;
            _timer.Enabled = true;

            Console.ReadLine();

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
                _newVolumeGenerator.SetNewVolume(waste, _currentVirtualDateTime, TimeSpan.Zero);
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

    public class RandomNewVolume : IVolumeFillStrategy
    {
        public RandomNewVolume() { _random = new Random(); }

        public void SetNewVolume(WasteCollectionArea waste, DateTime currentDateTime, TimeSpan timePassed)
        {
            decimal newVolume = waste.FilledVolume + (decimal)(_random.NextDouble() * 100);
            waste.FilledVolume = (newVolume > waste.Volume) ? waste.Volume : newVolume;
        }
        private Random _random;
    }
}
