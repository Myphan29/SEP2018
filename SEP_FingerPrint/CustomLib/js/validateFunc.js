var check = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('#SaveChanges').click(function () {
            if ($('#thu2').css('display') == 'show') {
                alert('Yes!');
            }
            //if ($('#thu2').is(':checked')) {
            //    var data = {
            //        Absent: '#e74c3c',
            //        Attend: '#2ecc71',
            //    }
            //}
            //GatherScheduleData(data);
        });
        function GatherScheduleData(data) {
            $.ajax({
                type: "POST",
                url: '/Lecturer/GatherScheduleData/@Model.ID',
                data: data,
                success: function (data) {
                    if (data.status) {
                        alert('Lưu thành công');
                    }
                },
                error: function () {
                    alert('fail');
                }
            })
        }
    }
}
check.init();