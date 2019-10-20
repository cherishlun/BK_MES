$(function () {


    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();

    $('#btn_find').click(function () {


        if ($("#ckmc").val() == '') {
            swal("请选择仓库!");
            return;
        }
        if ($("#pmc").val() == '') {
            swal("请选择排!");
            return;
        }
        if ($("#ceng1").val() == '') {
            swal("请输入层号!");
            return;
        }
        if ($("#col").val() == '') {
            swal("请输入每行的列数量!");
            return;
        }

        if ($("#col").val() > 10) {
            swal("每行的列数量不能大于10!");
            return;

        }

        for (i = 1; i < 10; i++) {
            $('#ArbetTable').bootstrapTable('hideColumn', 'ck' + i);
        }

        for (i = 1; i < $("#col").val(); i++) {
            $('#ArbetTable').bootstrapTable('showColumn', 'ck' + i);
        }

        $('#ArbetTable').bootstrapTable('refresh', { 'url': '/Bk_Ckxx/CangKu_Find' });
    });


    $('#btn_print').click(function () {

        if ($("#ArbetTable").bootstrapTable('getData')=='') {
            swal("没有记录!");
            return;
        }
        swal("没有记录11!");
        var printData = $("#ArbetTable").parent().html();
        window.document.body.innerHTML = printData;
        // 开始打印
        window.print();
        window.location.reload(true);
    });

    $("#ckmc").change(function () {
        
        var url = "/Bk_Ckxx/CangKu_Lie_List?id=" + $("#ckmc").val();
        //alert(url);
        $.getJSON(url, function (data) {
            $('#pmc').html('');
            //alert('hello');
            $("#pmc").append("<option value=''>请选择排</option>")
            $.each(data, function (i, item) {
                //alert(item.pmc);
                $('#pmc').append("<option value='" + item.zdbh + "'>" + item.pmc + "</option>").appendTo("#pmc");

            });
            $('#pmc').selectpicker( 'refresh');
        });
    });

});

mycolumn = []

var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {
        $('#ArbetTable').bootstrapTable({
            height: tableHeight(),              //高度调整
            url: '',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '#toolbar',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            sortable: false,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: oTableInit.queryParams,//传递参数（*）
            searchOnEnterKey: true, //ENTER键搜索 ,
            contentType: "application/x-www-form-urlencoded",
            clickToSelect: true,                //是否启用点击选中行
            columns: [
                {
                    field: 'index',
                    title: '序号',
                    align: "center",
                    formatter: function (value, row, index) {
                        var options = $('#ArbetTable').bootstrapTable('getOptions');
                        return options.pageSize * (options.pageNumber - 1) + index + 1;
                    },
                    width: 30
                },
                {
                    field: 'ck1',
                    title: '二维码',
                    align: "center",
                    formatter: function (value, row, index) {
                        
                        if (value == null)
                            return '';

                        return value.split(",")[1] + "</p><img src='/Bk_Ckxx/ShowImage?id=" + value.split(",")[0] + "'/></p>" + value.split(",")[2];
                    },
                    width: 100,
                    visible: $("#col").val() > 1 ? true : false
                },
                {
                    field: 'ck2',
                    title: '二维码',
                    align: "center",
                    formatter: function (value, row, index) {

                        if (value == null)
                            return '';

                        return value.split(",")[1] + "</p><img src='/Bk_Ckxx/ShowImage?id=" + value.split(",")[0] + "'/></p>" + value.split(",")[2];
                    },
                    width: 100,
                    visible: $("#col").val() > 2 ? true : false
                },
                {
                    field: 'ck3',
                    title: '二维码',
                    align: "center",
                    formatter: function (value, row, index) {

                        if (value == null)
                            return '';

                        return value.split(",")[1] + "</p><img src='/Bk_Ckxx/ShowImage?id=" + value.split(",")[0] + "'/></p>" + value.split(",")[2];
                    },
                    width: 100,
                    visible: $("#col").val() > 3 ? true : false
                },
                {
                    field: 'ck4',
                    title: '二维码',
                    align: "center",
                    formatter: function (value, row, index) {

                        if (value == null)
                            return '';

                        return value.split(",")[1] + "</p><img src='/Bk_Ckxx/ShowImage?id=" + value.split(",")[0] + "'/></p>" + value.split(",")[2];
                    },
                    width: 100,
                    visible: $("#col").val() > 4 ? true : false
                },
                {
                    field: 'ck5',
                    title: '二维码',
                    align: "center",
                    formatter: function (value, row, index) {

                        if (value == null)
                            return '';

                        return value.split(",")[1] + "</p><img src='/Bk_Ckxx/ShowImage?id=" + value.split(",")[0] + "'/></p>" + value.split(",")[2];
                    },
                    width: 100,
                    visible: $("#col").val() > 5 ? true : false
                },
                {
                    field: 'ck6',
                    title: '二维码',
                    align: "center",
                    formatter: function (value, row, index) {

                        if (value == null)
                            return '';

                        return value.split(",")[1] + "</p><img src='/Bk_Ckxx/ShowImage?id=" + value.split(",")[0] + "'/></p>" + value.split(",")[2];
                    },
                    width: 100,
                    visible: $("#col").val() > 6 ? true : false
                },
                {
                    field: 'ck7',
                    title: '二维码',
                    align: "center",
                    formatter: function (value, row, index) {

                        if (value == null)
                            return '';

                        return value.split(",")[1] + "</p><img src='/Bk_Ckxx/ShowImage?id=" + value.split(",")[0] + "'/></p>" + value.split(",")[2];
                    },
                    width: 100,
                    visible: $("#col").val() > 7 ? true : false
                },
                {
                    field: 'ck8',
                    title: '二维码',
                    align: "center",
                    formatter: function (value, row, index) {

                        if (value == null)
                            return '';

                        return value.split(",")[1] + "</p><img src='/Bk_Ckxx/ShowImage?id=" + value.split(",")[0] + "'/></p>" + value.split(",")[2];
                    },
                    width: 100,
                    visible: $("#col").val() > 8 ? true : false
                },
                {
                    field: 'ck9',
                    title: '二维码',
                    align: "center",
                    formatter: function (value, row, index) {

                        if (value == null)
                            return '';

                        return value.split(",")[1] + "</p><img src='/Bk_Ckxx/ShowImage?id=" + value.split(",")[0] + "'/></p>" + value.split(",")[2];
                    },
                    width: 100,
                    visible: $("#col").val() > 9 ? true : false
                },
                {
                    field: 'ck0',
                    title: '二维码',
                    align: "center",
                    formatter: function (value, row, index) {

                        if (value == null)
                            return '';

                        return value.split(",")[1] + "</p><img src='/Bk_Ckxx/ShowImage?id=" + value.split(",")[0] + "'/></p>" + value.split(",")[2];
                    },
                    width: 100
                },
            ],
        });
    };

    //得到查询的参数
    oTableInit.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            l1: $('#ceng1').val(),
            l2: ($("#ceng2").val() == "" ? $('#ceng1').val() : $('#ceng2').val()),
            h1: ($("#wei1").val() == "" ? 0 : $("#wei1").val()),
            h2: ($("#wei2").val() == "" ? ($("#wei1").val() == "" ? 0 : $("#wei1").val()) : $("#wei2").val()),
            ph: $("#pmc").val(),
            col: $("#col").val()
        };
        return temp;
    }

    return oTableInit;
}

function tableHeight() {
    return $(window).height() - 30;
}

$('#ckmc').selectpicker({});
$('#pmc').selectpicker({});