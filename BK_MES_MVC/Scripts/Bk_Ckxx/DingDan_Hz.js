$(function () {

    var isRefresh = false;

    ////打印
    //$('#btn_print').click(function () {

    //    $('#btn_print').attr('disabled', "true");
    //    window.location.href = "/Bk_Ckxx/KuCun_Hz_Print?gh=" + gh + "&gg=" + gg + "&zb=" + zb + "&khbm=" + khbm + "&hz=" + hz ;
    //    $('#btn_print').removeAttr("disabled");
    //});


    //动态列
    mycolumn = []
    mycolumn.push(
        {
            "title": "序号",
            align: "center",
            formatter: function (value, row, index) {
                var options = $('#ArbetTable').bootstrapTable('getOptions');
                return options.pageSize * (options.pageNumber - 1) + index + 1;
            },
            footerFormatter: function () {
                return '汇总'
            }
        },
        {
            "title": "钢号",
            field: 'gh',
            align: "center",
        },
        {
            "title": "规格",
            field: 'gg',
            align: "center",
        },
        {
            "title": "组别",
            field: 'zb',
            align: "center",
        },
        {
            "title": "客户代码",
            field: 'khdm',
            align: "center",
        },
        {
            "title": "数量",
            field: 'ssl',
            align: "right",
            footerFormatter: function (data) {
                var _sum = 0;
                for (var rows in data) {
                    _sum += data[rows].ssl;
                }
                return _sum;

            }

        },
        {
            "title": "重量(Kg)",
            field: 'szl',
            align: "right",
            footerFormatter: function (data) {
                var _sum = 0;
                for (var rows in data) {
                    _sum += data[rows].szl;
                }
                return _sum.toFixed(2);//保留两位小数;
            }

        },
    );

    //动态参数
    myqueryparams = []

    //汇总
    mytables_showfooter = true;
    //Url
    myTables_url = '/Bk_ckxx/DingDan_Hz?id='+$('#ddid').val();
    //分页
    mytables_pagination = false;

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();

    //$('#ArbetTable').bootstrapTable({ 'url': '/' });

});


function queryParams(params) {
    var tmp = {
    };
    return tmp;
}


