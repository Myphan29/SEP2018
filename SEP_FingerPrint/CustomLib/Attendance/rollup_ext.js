var editor = {
    init: function () {
        editor.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Lecturer/EditAtd",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == '0') {
                        btn.text('Vắng');
                    }
                    else {
                        btn.text('Hiện diện');
                    }
                }
            });
        });
    }
}
editor.init();