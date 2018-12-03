// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
feather.replace();

function applyFilters() {
    var table = $("#trashpoints").DataTable();
    var url = "/areas?minFill=" + $("#fillFilter").data().from + "&maxFill=" + $("#fillFilter").data().to;
    table.ajax.url(url);
    table.ajax.reload();
}

function resetFilters() {
    var slider = $("#fillFilter").data("ionRangeSlider");
    slider.reset();
    var table = $("#trashpoints").DataTable();
    var url = "/areas";
    table.ajax.url(url);
    table.ajax.reload();
}