var myMap;
// Координаты Автопарка мусоровозов и Полигона ТБО
var cordBaseStation = [61.757534, 34.417469];
var cordWasteLandfill = [61.699688, 34.453655];
// Массив меток для построения маршрута
var pinsArray = new Array;

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
                iconContent: Math.round(elem.percentOfFill) // dynamic
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

function createRoute() {
    // Сортируем метки относительно Автопарка мусоровозов
    var pinsGeoQuery = ymaps.geoQuery(pinsArray);
    var pinsSorted = pinsGeoQuery.sortByDistance(cordBaseStation);
    // Формируем массив координат из отсортированных меток
    var arraySortCords = new Array;
    pinsSorted._objects.forEach(function (elem) {
        arraySortCords.push(elem.geometry._coordinates);
    });
    // Добавляем начальную, предполседнюю и последнюю точку для построения итогового маршрута
    arraySortCords.unshift(cordBaseStation);
    arraySortCords.push(cordWasteLandfill);
    arraySortCords.push(cordBaseStation);
    // Строим маршрут
    ymaps.route(arraySortCords, {
        mapStateAutoApply: true
    }).then(function (route) {
        route.getPaths().options.set({
            // в балуне выводим только информацию о времени движения с учетом пробок
            balloonContentBodyLayout: ymaps.templateLayoutFactory.createClass('$[properties.humanJamsTime]'),
            // можно выставить настройки графики маршруту
            strokeColor: '0000ffff',
            opacity: 0.9
        });
        // добавляем маршрут на карту
        myMap.geoObjects.add(route);
    });
}