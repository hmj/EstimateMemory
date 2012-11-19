

var MitsumoriForm = {
    UpdateKingaku: function () {
        var hour = $("#hour").val();
        var ratio = $("#ratio").val();
        $("#money").val(addFigure(hour * ratio * 8800));
    },
};
