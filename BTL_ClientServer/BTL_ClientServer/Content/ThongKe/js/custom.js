$(document).ready(function () {

    var a = [];
    var aa = [];
    var aaa = [];
    $('li.g').each(function () {
        a.push($(this).attr("u"));
    });
    $('li.h').each(function () {
        aa.push($(this).attr("uu"));
    });
    $('li.k').each(function () {
        aaa.push($(this).attr("uuu"));
    });
    var colors = ['red', '#28a745', '#333333', '#c3e6cb', '#dc3545', '#6c757d'];

    /* large line chart */
    var chLine = document.getElementById("chLine");
    var chartData = {
        //  labels: ["S", "M", "T", "W", "T", "F", "S"],
        labels: a,
        datasets: [{
            // data: [589, 445, 483, 900, 689, 692, 634,54,656,55,65,323,554,233,88,434,455],
            // data: [14000000, 0, 0, 0, 0, 20000000, 30000000, 0, 12000000, 50000000],
            data: aa,
            backgroundColor: 'transparent',
            borderColor: colors[0],
            borderWidth: 4,
            pointBackgroundColor: colors[0]
        }
            //   {
            //     data: [639, 465, 493, 478, 589, 632, 674],
            //     backgroundColor: colors[3],
            //     borderColor: colors[1],
            //     borderWidth: 4,
            //     pointBackgroundColor: colors[1]
            //   }
        ]
    };
    if (chLine) {
        new Chart(chLine, {
            type: 'line',
            data: chartData,
            options: {
                scales: {
                    xAxes: [{
                        ticks: {
                            beginAtZero: false
                        }
                    }]
                },
                legend: {
                    display: false
                },
                responsive: true
            }
        });
    }

    var chBar = document.getElementById("chBar");
    if (chBar) {
        new Chart(chBar, {
            type: 'bar',
            data: {
                labels: a,
                datasets: [{
                    data: aaa,
                    backgroundColor: colors[0]
                },
                {
                    data: aaa,
                    backgroundColor: colors[1]
                }]
            },
            options: {
                legend: {
                    display: false
                },
                scales: {
                    xAxes: [{
                        barPercentage: 0.4,
                        categoryPercentage: 0.5
                    }]
                }
            }
        });
    }

    $('button.nut-tim-kiem').click(function () {
        var search = $('#search').val();
        alert(search);
        $.ajax({
            url: '/Test/tk',
            type: "post",
            data: { name: search },
            success: function (res) {
                $('div#result').empty();
                $('div#result').html(res);
            }
        });

    });

    $("table.tb tr.tr").click(function () {
        var thang = $("h2#id-thang").attr("id-thang");
        var ngay = $(this).find('td').attr('id-ngay');
        var idKhachHang = $(this).find('td').attr('id-kh');
        $.ajax({
            url: '/Statistic/XemChiTietThongTin',
            type: "get",
            data: {
                thang: thang,
                day: ngay,
                idKhachHang: idKhachHang
            },
            success: function (res) {
                $('div#result1').empty();
                $('div#result1').html(res);
            }
        });
    });

    $('button.btn-xem-kh').click(function () {
        $.ajax({
            url: '/Statistic/XemKhachHangTiemNang',
            type: "get",
            success: function (res) {
                $('div#result').empty();
                $('div#result').html(res);
            }
        });

    });

    $('button.btn-xem-khtt').click(function () {
        $.ajax({
            url: '/Statistic/XemKhachHangTiemNangTT',
            type: "get",
            success: function (res) {
                $('div#result').empty();
                $('div#result').html(res);
            }
        });
    });
    $('#kh1').click(function () {
        var input = $("input#thang").val();
        $.ajax({
            url: '/Statistic/XemKhachHangTiemNangTrongThang',
            type: "get",
            data: { thang: input },
            success: function (res) {
                $('div#result').empty();
                $('div#result').html(res);
            }
        });

    });

    $('#kh2').click(function () {
        var input = $("input#thang").val();
        $.ajax({
            url: '/Statistic/XemKhachHangTiemNangTrongThangTongTien',
            type: "get",
            data: { thang: input },
            success: function (res) {
                $('div#result').empty();
                $('div#result').html(res);
            }
        });

    });

    //phần snar phẩm
    $('button.btn-banchay').click(function () {
        var input = $("input#thang-sp").val();
        $.ajax({
            url: '/Statistic/XemSanPhamBanChayTrongThang',
            type: "get",
            data: { thang: input },
            success: function (res) {
                $('div#result').empty();
                $('div#result').html(res);
            }
        });

    });
    $('button.btn-khongban').click(function () {
        var input = $("input#thang-sp").val();
        $.ajax({
            url: '/Statistic/XemSanPhamKhongBanTrongThang',
            type: "get",
            data: { thang: input },
            success: function (res) {
                $('div#result').empty();
                $('div#result').html(res);
            }
        });
    });

});
