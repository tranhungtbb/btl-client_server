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

    var chLine = document.getElementById("chLine");
    var chartData = {  
        labels: a,
        datasets: [{
            data: aa,
            backgroundColor: 'transparent',
            borderColor: colors[0],
            borderWidth: 4,
            pointBackgroundColor: colors[0]
        }
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

    var chLine1 = document.getElementById("chLine1");
    var chartData = {
        labels: a,
        datasets: [{
            data: aaa,
            backgroundColor: 'transparent',
            borderColor: colors[1],
            borderWidth: 4,
            pointBackgroundColor: colors[1]
        }
        ]
    };
    if (chLine1) {
        new Chart(chLine1, {
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
        $('table.tb tr').removeClass('active');
         
        $(this).addClass('active');
       
        var thang = $("h2#id-thang").attr("id-thang");
        var ngay = $(this).find('td').attr('id-ngay');
        var idKhachHang = $(this).find('td').attr('id-kh');
        $.ajax({
            url: '/Statistic/XemChiTietThongTin',
            type: "get",
            data: {
                page: 1,
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
    $('button.btn.btn-banchay').click(function () {
        var input = $("input#thang-sp").val();
        if (input == null) {
            alert("Mời bạn nhập tháng");
        }
        $.ajax({
            url: '/Statistic/XemSanPhamBanChayTrongThang',
            type: "get",
            data: {
                page: 1,
                thang: input
            },
            success: function (res) {
                $('body').empty();
                $('body').html(res);
            }
        });
        console.log("xong");

    });
    $('button.btn.btn-khongban').click(function () {
        
        var input = $("input#thang-sp").val();
        if (input == null) {
            alert("Mời bạn nhập tháng");
        }
        $.ajax({
            url: '/Statistic/XemSanPhamKhongBanTrongThang',
            type: "get",
            data: {
                page: 1,
                thang: input
            },
            success: function (res) {
                $('div#result').empty();
                $('div#result').html(res);
            }
        });
    });

});
