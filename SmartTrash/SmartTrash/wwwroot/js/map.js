var myMap;

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
        // Создаем геообъект.
        myMap.geoObjects
            .add(myPieChart);
    })
}

function removeGeoPoints() {
    myMap.geoObjects.removeAll();
}