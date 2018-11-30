var slider = document.getElementById('slider');

noUiSlider.create(slider, {
    start: [30, 150],
	step: 2,
    range: {
        'min': [0],
        'max': [200]
    }
});
var snapValues = [
    document.getElementById('sliderValueLower'),
    document.getElementById('sliderValueUpper')
];

slider.noUiSlider.on('update', function (values, handle) {
    snapValues[handle].innerHTML = values[handle]/2;
});
slider.noUiSlider.on('update', function (values, handle) {
    snapValues[handle].value = values[handle]/2;
});