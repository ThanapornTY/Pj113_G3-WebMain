$(document).ready(function () {
    getData();
});
function getData() {
    var settings = {
        /*ตรงนี้ที่สงสัยว่าเราสามารถดึงจาก Table มาได้เลยหรือไม่โดยไม่ต้องใช่ Url */
        "url": "D:/Work/ปี2/เทอม2/1101113/FindPartyToPaly Pj113/dbo.RequestGameData.data.sql",
        "method": "GET",
        "timeout": 0

    };
    $.ajax(settings).done(function (response) {
        var rows = '';
        rows += "<table>"
        rows += "<tr>"
        rows += "<th>" + "Action Role-Playing" + "</th>"
        rows += "<th>" + "FPS)" + "</th>"
        rows += "</tr>"
        $.each(response, function (x, item) {
            rows += "<tr>"
            rows += "<td>" + item.RQGGame + "</td>"
            rows += "<td>" + item.RQGGame + "</td>"
            rows += "</tr>"
        });
        rows += "</table>";
        $("#RequestGameData").html(rows);
    });
}