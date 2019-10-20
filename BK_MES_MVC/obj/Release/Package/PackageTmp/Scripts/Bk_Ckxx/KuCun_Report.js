$(function () {

    var isRefresh = false;

    //查询
    $('#btn_find').click(function () {

        if ($("#shz").val() == null) {
            swal("选择汇总信息!");
            return;
        }
 

        //$('#ArbetTable').bootstrapTable({ 'url': '/Bk_ckxx/RuKu_Report' });

        if (isRefresh) {
            $("#ArbetTable").bootstrapTable('selectPage', 1);
        }
        else {
            $('#ArbetTable').bootstrapTable('refresh', {
                url: '/BK_Ckxx/KuCun_Report?ishz=1'
            });
            isRefresh = true;
        }



        //$('#ArbetTable').bootstrapTable('refreshOptions', {
        //    showfoot: true,
        //    url: '/BK_Ckxx/RuKu_Report'
        //});
    });

    //打印
    $('#btn_print').click(function () {

        if ($("#shz").val() == null) {
            swal("选择汇总信息!");
            return;
        }

        var gh = $("#txt_gh").val();
        var gg = $("#txt_gg").val();
        var zb = $("#txt_zb").val();
        var khbm = $("#txt_khbm").val();
        var hz = $("#shz").val();

        $('#btn_print').attr('disabled', "true");
        window.location.href = "/Bk_Ckxx/KuCun_Hz_Print?gh=" + gh + "&gg=" + gg + "&zb=" + zb + "&khbm=" + khbm + "&hz=" + hz ;
        $('#btn_print').removeAttr("disabled");
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
            field: 'sl',
            align: "right",
            footerFormatter: function (data) {
                if (data.length > 0 && data[0]["ssl"] != null)
                    $("#txt_ssl").val(data[0]["ssl"]);

                return $("#txt_ssl").val();
            }

        },
        {
            "title": "重量(Kg)",
            field: 'zl',
            align: "right",
            footerFormatter: function (data) {
                if (data.length > 0 && data[0]["szl"] != null)
                    $("#txt_szl").val(data[0]["szl"]);

                return $("#txt_szl").val();
            }

        },
    );

    //动态参数
    myqueryparams = []
    myqueryparams.push({
        gh: $("#txt_gh").val(),
        gg: $("#txt_gg").val(),
        zb: $("#txt_zb").val(),
        khbm: $("#txt_khbm").val(),
        hz: $("#shz").val(),
    });

    //汇总
    mytables_showfooter = true;
    myTables_url = '';

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();



    $('#srq').selectpicker({});
    $('#shz').selectpicker({ noneSelectedText: '请选择汇总类别' });




});


function queryParams(params) {
    var tmp = {
        limit: params.limit,   //页面大小
        offset: params.offset,  //页码
        gh: $("#txt_gh").val(),
        gg: $("#txt_gg").val(),
        zb: $("#txt_zb").val(),
        khbm: $("#txt_khbm").val(),
        hz: $("#shz").val(),
        rq1: $("#drq1").val(),
        rq2: $("#drq2").val()
    };
    return tmp;
}


