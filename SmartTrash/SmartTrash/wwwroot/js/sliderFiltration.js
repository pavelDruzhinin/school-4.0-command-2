        function tableFiltred(minFill, maxFill) {
            var xhr = new XMLHttpRequest();

            xhr.open("GET", "areas?minFill=" + minFill + "&" + "?maxFill=" + maxFill, true);

            xhr.send();

            xhr.onload = function () {
			JSON.parse(xhr.response)
            };
        }