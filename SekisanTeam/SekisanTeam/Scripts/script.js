

$('.dropdown-toggle').dropdown();


function addFigure(str) {
    var num = new String(str).replace(/,/g, "");
    while (num != (num = num.replace(/^(-?\d+)(\d{3})/, "$1,$2")));
    return num;
}