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
            arrayScheduledAreas[j] = [countRounds, points[i].latitude, points[i].longitude, _points[i].filledVolume];
            j++;
        } else {
            countRounds += 1;
            totalVolume = 0;
            i--;
        }
    }
    console.log(arrayScheduledAreas);
    
    return {
        countRounds: countRounds,
        scheduledAreas: arrayScheduledAreas
    };
}

function doReport(_points) {
    var reportArray = new Array;
    var totalVolume = 0;
    var timeWasteAreas = _points.length * TRASH_LOAD_TIME;
    var costRout = arrayRouteInfo['lengthRoute'] * COST_ONE_KM / 1000;
    var objCalculateRounds = calculateRounds(_points);

    // Строим маршрут и получаем его данные
    // createRoute();

    totalVolume = calculateTotalVolume(_points);

    reportArray['totalVolume'] = totalVolume;
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
    document.querySelector('.reportTime').innerHTML = reportArray['timeTotal'] + ' мин.';
    document.querySelector('.reportTimeRoute').innerHTML = reportArray['timeRoute'] + ' мин.';
    document.querySelector('.reportTimeWasteAreas').innerHTML = reportArray['timeWasteAreas'] + ' мин.';
    document.querySelector('.reportCost').innerHTML = reportArray['costRoute'] + ' руб.';
    document.querySelector('.reportCountRounds').innerHTML = reportArray['countRounds'] + ' шт.';
}

