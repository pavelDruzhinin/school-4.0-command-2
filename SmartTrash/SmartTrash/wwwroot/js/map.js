var myMap;
// Координаты Автопарка мусоровозов и Полигона ТБО
var cordBaseStation = [61.757534, 34.417469];
var cordWasteLandfill = [61.699688, 34.453655];
// Массив меток для построения маршрута
var pinsArray = new Array;
// Массив ID из отсортированных меток
var arraySortIds = new Array;
// Массив для составления отчета
var arrayRouteInfo = new Array;

ymaps.ready(init);

function init() {
    myMap = new ymaps.Map('map', {
        center: [61.775018, 34.419220], 
        zoom: 12
    }, {
        searchControlProvider: 'yandex#search'
    });

    addGeoPoints(points);
}

function addGeoPoints(_points) {
    removeGeoPoints();
    pinsArray.length = 0;

    _points.forEach(function (elem) {
        var colorPie;
        var colorPieEmpty = '#f5f5f5';
        if (elem.percentOfFill < 30) {
            colorPie = 'green';
        }
        if (elem.percentOfFill >= 30 && elem.percentOfFill < 70) {
            colorPie = 'yellow';
        }
        if (elem.percentOfFill >= 70) {
            colorPie = 'red';
        }
        if (elem.percentOfFill == 0) {
            colorPie = '#f5f5f5';
        }
        
        myPieChart = new ymaps.Placemark([
            elem.latitude, elem.longitude // dynamic
        ], {
                // Данные для построения диаграммы.
                data: [
                    { weight: elem.percentOfFill, color: colorPie }, // dynamic
                    { weight: (100 - elem.percentOfFill), color: colorPieEmpty }, // dynamic
                ],
                balloonContent: elem.name, // dynamic
                iconContent: Math.round(elem.percentOfFill), // dynamic
                idPoint: elem.id // id мусорной площадки
            }, {
                // Зададим произвольный макет метки.
                iconLayout: 'default#pieChart',
                // Радиус диаграммы в пикселях.
                iconPieChartRadius: 25,
                // Радиус центральной части макета.
                iconPieChartCoreRadius: 15,
                // Стиль заливки центральной части.
                iconPieChartCoreFillStyle: '#ffffff',
                // Cтиль линий-разделителей секторов и внешней обводки диаграммы.
                iconPieChartStrokeStyle: '#ffffff',
                // Ширина линий-разделителей секторов и внешней обводки диаграммы.
                iconPieChartStrokeWidth: 3,
                // Максимальная ширина подписи метки.
                iconPieChartCaptionMaxWidth: 200
            });

        // Добавляем метку в массив для дальнейшей сортировки
        pinsArray.push(myPieChart);
        // Добавляем метку на карту.
        myMap.geoObjects
            .add(myPieChart);
    })

    // Создаем метку для Автопарка мусоровозов
    var pinBaseStation = new ymaps.Placemark(
        cordBaseStation,
        {
            balloonContent: 'Автопарк мусоровозов'
        },
        {
            preset: 'islands#blueDeliveryIcon',
            iconColor: 'blue'
        }
    );
    // Создаем метку для Полигонга ТБО
    var pinWasteLandfill = new ymaps.Placemark(
        cordWasteLandfill,
        {
            balloonContent: 'Полигон ТБО'
        },
        {
            preset: 'islands#redWasteIcon',
            iconColor: 'red'
        }
    );
    // Добавляем эти 2 метки на карту
    myMap.geoObjects
        .add(pinBaseStation)
        .add(pinWasteLandfill);
}

function removeGeoPoints() {
    myMap.geoObjects.removeAll();
}

function getSelectedTruck() {
    var selected_truck = $('input[name=choosedTruck]:checked').val();
    truck.numberPlate = deleteDirty($('.' + selected_truck + ' .truckNumberPlate').html());
    truck.model = deleteDirty($('.' + selected_truck + ' .truckModel').html());
    truck.volume = convertFloat($('.' + selected_truck + ' .truckVolume').html());
    truck.cost = convertFloat($('.' + selected_truck + ' .truckCost').html());
    
    console.log(selected_truck);
    console.log(truck);
}

function createRoute() {
    // Сортируем метки относительно Автопарка мусоровозов
    var pinsGeoQuery = ymaps.geoQuery(pinsArray);
    var arraySortCords = new Array;
    var pin = cordBaseStation;
    do {
        pin = pinsGeoQuery.getClosestTo(pin);
        if (pin) {
            // Формируем массив координат из отсортированных меток
            arraySortCords.push(pin.geometry.getCoordinates());
            // Формируем массив ID из отсортированных меток
            arraySortIds.push(pin.properties._data.idPoint);
            pinsGeoQuery = pinsGeoQuery.remove(pin);
        }
    } while (pin)
    console.log(arraySortCords);

    // Сортируем points относительно построенного маршрута
    points.sort(function (a, b) {
        return arraySortIds.indexOf(a.id) - arraySortIds.indexOf(b.id);
    });

    // Подсчитываем количество рейсов
    var objRounds = calculateRounds(points);
    // Формируем итоговый маршрут с учетом заезда на полигон ТБО между рейсами
    var finalCords = generateFinalRoute(objRounds.scheduledAreas);

    // Рисуем маршрут
    drawRoute(finalCords.arrayNewRouteCords, finalCords.arrayIndexRound);
}

function drawRoute(_cords, _index) {
    var defaultColor = getRandomValue(colors);
    ymaps.route(_cords, {
        mapStateAutoApply: true
    }).then(function (route) {
        route.getPaths().options.set({
            // в балуне выводим только информацию о времени движения с учетом пробок
            balloonContentBodyLayout: ymaps.templateLayoutFactory.createClass('$[properties.humanJamsTime]'),
            // можно выставить настройки графики маршруту
            strokeColor: defaultColor,
            opacity: 0.9
        });

        // Красим каждый рейс в свой цвет
        var countPath = route.getPaths().getLength();
        _index.push(countPath);
        var startIndex = 0;
        for (var m = 0; m < _index.length; m++) {
            var color = getRandomValue(colors);
            for (var i = startIndex; i < _index[m]; i++) {
                myRoute = route.getPaths().get(i);
                myRoute.options.set('strokeColor', color);
            }
            startIndex = _index[m];
        }

            arrayRouteInfo['lengthRoute'] = route.getLength();
            arrayRouteInfo['lengthHuman'] = route.getHumanLength();
            arrayRouteInfo['time'] = route.getJamsTime();
            arrayRouteInfo['timeHuman'] = route.getHumanJamsTime();
        
        // добавляем маршрут на карту
        myMap.geoObjects.add(route);
    });
}
