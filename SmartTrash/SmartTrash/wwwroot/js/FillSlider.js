function Slider(sliderFill) {

            var xhr = new XMLHttpRequest();

			xhr.open("GET", "areas?minFill="+sliderFill+"&"+"?maxFill="+100, true);

            xhr.send();

        }