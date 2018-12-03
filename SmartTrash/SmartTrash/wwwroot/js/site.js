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
}