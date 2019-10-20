$(function () {

    $('#btn_find').click(function () {
        var _ph = $("#txt_ph").val();
        var _gsmc = $("#txt_gsmc").val();
        var _gg = $("#txt_gg").val();
        var _zb = $("#txt_zb").val();
        var _khbm = $("#txt_khbm").val();
        var _gz = $("#txt_gz").val();
        if (_ph == "" && _gsmc == "" && _gg == "" && _zb == "" && _khbm == "" && _gz == "") {
            swal("请输入查询信息!");
            return;
        }

        parent.addMenuTab('/Bk_Ckxx/KuWeiTu_Details_Find_View?ph=' + _ph + '&gsmc=' + _gsmc + '&gg=' + _gg + '&zb=' + _zb + '&khbm=' + _khbm + '&gz=' + _gz, '仓库展示图');
    });


    var pieChart = echarts.init(document.getElementById("echarts-pie-chart"));
    var pieoption = {
        title: {
            text: '库位图表',
            x: 'center'
        },
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },
        legend: {
            orient: 'vertical',
            x: 'left',
            data: ['未用量', '占用量']
        },
        calculable: false,
        series: [
            {
                name: '库位信息',
                type: 'pie',
                radius: '80%',
                center: ['50%', '60%'],
                data: [
                    { value: _KcWyl, name: '未用量' },
                    { value: _KcZyl, name: '占用量' },
                ]
            }
        ]
    };
    pieChart.setOption(pieoption);
    $(window).resize(pieChart.resize);

})

