﻿var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == "Enable") {
                        btn.text('Enable');
                    }
                    else {
                        btn.text('Disable');
                    }
                }
            });
        });
    }
}
user.init();