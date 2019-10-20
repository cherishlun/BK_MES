$(function () {

    var isRefresh = false;

    ////打印
    //$('#btn_print').click(function () {

    //    $('#btn_print').attr('disabled', "true");
    //    window.location.href = "/Bk_Ckxx/KuCun_Hz_Print?gh=" + gh + "&gg=" + gg + "&zb=" + zb + "&khbm=" + khbm + "&hz=" + hz ;
    //    $('#btn_print').removeAttr("disabled");
    //});


    //查询
    $('#btn_find').click(function () {

        $("#ArbetTable").bootstrapTable('selectPage', 1);
        if ($('#ArbetTable').bootstrapTable('getData').length == 0)
            $('#ArbetTable').bootstrapTable('refresh', {
                url: '/Bk_ckxx/DaiKu_View'
            });
    });


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
        },
        {
            "title": "数据编号",
            field: 'sjbh',
            align: "center",
        },
        {
            "title": "批号",
            field: 'ph',
            align: "center",
        },
        {
            "title": "钢丝名称",
            field: 'cpmc',
            align: "center",
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
            "title": "重量(Kg)",
            field: 'zl',
            align: "right",
        },
        {
            "title": "库位",
            field: 'kw',
            align: "center",
        },
        {
            "title": "入库日期",
            field: 'rkrq',
            align: "center",
        },
        {
            "title": "呆库天数",
            field: 'dkday',
            align: "center",
        },
    );

    //动态参数
    myqueryparams = []

    //汇总
    mytables_showfooter = true;
    //Url
    myTables_url = '';

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();

    //$('#ArbetTable').bootstrapTable({ 'url': '/' });

});


function queryParams(params) {
    var tmp = {
        limit: params.limit,   //页面大小
        offset: params.offset,  //页码
        ph: $("#txt_ph").val(),
        sjbh: $("#txt_sjbh").val(),
        day: $("#txt_day").val(),
    };
    return tmp;
}


