var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#txtKeyWord").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/DienThoai/ListName",
                    dataType: "jsonp",
                    data: {
                        q: request.term
                    },
                    success: function (data) {
                        response(data.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtKeyWord").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#project").val(ui.item.label);
                //$("#project-id").val(ui.item.value);
                //$("#project-description").html(ui.item.desc);
                //$("#project-icon").attr("src", "images/" + ui.item.icon);

                return false;
            }
        })
            .autocomplete("instance")._renderItem = function (ul, item) {
                return $("<li>")
                    .append("<div>" + item.label  + "</div>")
                    .appendTo(ul);
            };
    }
}
common.init();