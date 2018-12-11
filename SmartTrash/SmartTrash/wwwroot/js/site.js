// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
feather.replace();

// Время, затрачиваемое на 1 мусорную площадку в секундах
var TRASH_LOAD_TIME = 10 * 60;
// Стоимость 1 км
var COST_ONE_KM = 15;

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

function doReport(_points) {
    var reportArray = new Array;
    var totalVolume = 0;
    var timeWasteAreas = _points.length * TRASH_LOAD_TIME;
    var costRout = arrayRouteInfo['lengthRoute'] * COST_ONE_KM / 1000;

    // Строим маршрут и получаем его данные
    // createRoute();
    
    _points.forEach(function (elem) {
        totalVolume += elem.volume;

    });

    reportArray['totalVolume'] = totalVolume;
    reportArray['count'] = _points.length;
    reportArray['costRoute'] = Math.round(costRout);
    reportArray['lengthHuman'] = arrayRouteInfo['lengthHuman'];
    // Время маршрута + время на загрузку мусора, округленное до минут
    reportArray['timeTotal'] = Math.round(arrayRouteInfo['time'] / 60) + Math.round(timeWasteAreas / 60);
    reportArray['timeRoute'] = Math.round(arrayRouteInfo['time'] / 60);
    reportArray['timeWasteAreas'] = Math.round(timeWasteAreas / 60);
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
}

