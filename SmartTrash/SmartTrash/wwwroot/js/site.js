// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
feather.replace();

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
    var total = 0;
    
    _points.forEach(function (elem) {
        total += elem.volume;
    });

    reportArray['totalVolume'] = total;
    reportArray['count'] = _points.length;

    return reportArray;
}

function drawReport() {
    var reportArray = doReport(points);
    document.querySelector('.reportCount').innerHTML = reportArray['count'] + ' шт.';
    document.querySelector('.reportVolume').innerHTML = reportArray['totalVolume'] + ' л.';
}