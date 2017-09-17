
(function (race_display, $, undefined) {

    race_display.init = function () {

        $("#loadRaces").on("click", function () {
            $.ajax({
                type: "GET",
                url: "http://localhost:58862/api/races",
                accepts: {
                    json: "application/json"
                },
                success: function (data, textStatus, jqXHR) {
                    var $races = $("#race-results");
                    $races.empty();
                    $("#raceTemplate").tmpl(data).appendTo($races);
                },
                error: function (xhr, status, error) {
                    alert(xhr.responseText);
                }
            });
            return false;
        });
    };

}(window.race_display = window.race_display || {}, jQuery));
