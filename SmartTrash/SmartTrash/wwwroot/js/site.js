// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
feather.replace();

// Время, затрачиваемое на 1 мусорную площадку в секундах
var TRASH_LOAD_TIME = 10 * 60;
// Стоимость 1 км
var COST_ONE_KM = 15;
// Вместимость мусоровоза
var CAPACITY_TRUCK = 18000;

var colors = [
    '#0000c7',
    '#ff0a81',
    '#FF0000',
    '#ff7518',
    '#7ba05b',
    '#a14040',
    '#000080',
    '#88f000',
    '#FFFF00',
    '#e37134',
    '#5e3639',
    '#4fa1b0'
];

function getRandomValue(arr){
    return arr[Math.floor(Math.random() * arr.length)];
};

function getPoints(min = 0, max = 100) {
    var url = "/areas?minFill=" + min + "&maxFill=" + max;
    var result =
    $.ajax({
            url: url,
            async: false,
            success: function (data) {
                return data;
            }
        }).responseJSON;
    return result;
}

function applyFilters() {
    var table = $("#trashpoints").DataTable();
    var min = $("#fillFilter").data().from;
    var max = $("#fillFilter").data().to;
    points = getPoints(min, max);
    table.clear().draw();
    table.rows.add(points);
    table.columns.adjust().draw();
    addGeoPoints(points);
}

function resetFilters() {
    var slider = $("#fillFilter").data("ionRangeSlider");
    slider.reset();
    var table = $("#trashpoints").DataTable();
    var min = $("#fillFilter").data().from;
    var max = $("#fillFilter").data().to;
    points = getPoints(min, max);
    table.clear().draw();
    table.rows.add(points);
    table.columns.adjust().draw();
    addGeoPoints(points);
}

function getYandexKey() {
    var xhr = new XMLHttpRequest();
    var urlAPIYandex = "/api/key/yandex";
    xhr.open('GET', urlAPIYandex, false);
    xhr.send();
    var key = xhr.response;

    return key;
}

function calculateTotalVolume(_points) {
    var totalVolume = 0;

    _points.forEach(function (elem) {
        totalVolume += elem.filledVolume;
    });

    return totalVolume;
}

function calculateRounds(_points) {
    var totalVolume = 0;
    var countRounds = 1;
    var arrayScheduledAreas = new Array;
    var j = 0;

    for (var i = 0; i < _points.length; i++) {
        if ((_points[i].filledVolume + totalVolume) <= CAPACITY_TRUCK) {
            totalVolume += _points[i].filledVolume;
            arrayScheduledAreas[j] =
                [
                    countRounds,
                    _points[i].latitude,
                    _points[i].longitude, 
                    _points[i].filledVolume
                ];
            j++;
        } else {
            countRounds += 1;
            totalVolume = 0;
            i--;
        }
    }

    return {
        countRounds: countRounds,
        scheduledAreas: arrayScheduledAreas
    };
}

function generateFinalRoute(_arraySchdldAr) {
    var arrayNewRouteCords = new Array;
    var arrayIndexRound = new Array;

    for (var i = 0, j = 1; i < _arraySchdldAr.length; i++) {
        if (_arraySchdldAr[i][0] != j) {
            _arraySchdldAr.splice(i, 0, [999, cordWasteLandfill[0], cordWasteLandfill[1], 999]);
            arrayIndexRound.push(i);
            i++;
            j++;
        }
    }
    for (var i = 0; i < _arraySchdldAr.length; i++) {
        var tArSl = [];
        // вырезаем индекс рейса и объем, оставляя только координаты
        tArSl = _arraySchdldAr[i].slice(1, 3);
        // Формируем итоговый массив координат
        arrayNewRouteCords.push(tArSl);
    }
    arrayNewRouteCords.unshift(cordBaseStation);
    arrayNewRouteCords.push(cordWasteLandfill);
    arrayNewRouteCords.push(cordBaseStation);
    //console.log(arrayNewRouteCords);
    //console.log(arrayIndexRound);
    return {
        arrayNewRouteCords: arrayNewRouteCords,
        arrayIndexRound: arrayIndexRound
    };
}

function doReport(_points) {
    var reportArray = new Array;
    var totalVolume = 0;
    var timeWasteAreas = _points.length * TRASH_LOAD_TIME;
    var costRout = arrayRouteInfo['lengthRoute'] * COST_ONE_KM / 1000;
    var objCalculateRounds = calculateRounds(_points);

    totalVolume = calculateTotalVolume(_points);

    reportArray['totalVolume'] = Math.round(totalVolume);
    reportArray['count'] = _points.length;
    reportArray['costRoute'] = Math.round(costRout);
    reportArray['lengthHuman'] = arrayRouteInfo['lengthHuman'];
    // Время маршрута + время на загрузку мусора, округленное до минут
    reportArray['timeTotal'] = Math.round(arrayRouteInfo['time'] / 60) + Math.round(timeWasteAreas / 60);
    reportArray['timeRoute'] = Math.round(arrayRouteInfo['time'] / 60);
    reportArray['timeWasteAreas'] = Math.round(timeWasteAreas / 60);
    reportArray['countRounds'] = objCalculateRounds.countRounds;
    return reportArray;
}

function drawReport() {
    var reportArray = doReport(points);
    document.querySelector('.reportCount').innerHTML = reportArray['count'] + ' шт.';
    document.querySelector('.reportVolume').innerHTML = reportArray['totalVolume'] + ' л.';
    document.querySelector('.reportWay').innerHTML = reportArray['lengthHuman'];
    document.querySelector('.reportTime').innerHTML = humanTime(reportArray['timeTotal']);
    document.querySelector('.reportTimeRoute').innerHTML = humanTime(reportArray['timeRoute']);
    document.querySelector('.reportTimeWasteAreas').innerHTML = humanTime(reportArray['timeWasteAreas']);
    document.querySelector('.reportCost').innerHTML = reportArray['costRoute'] + ' руб.';
    document.querySelector('.reportCountRounds').innerHTML = reportArray['countRounds'] + ' шт.';
}

function humanTime(time) {
    var result;
    var mins = time % 60;
    var hours = (time - mins) / 60;
    var hoursText = '';
    if (mins < 10) mins = '0' + mins;
    if (hours) {
        hoursText = hours + ' ч. ';
    }
    result = hoursText + mins + ' мин.';
    return result;
}