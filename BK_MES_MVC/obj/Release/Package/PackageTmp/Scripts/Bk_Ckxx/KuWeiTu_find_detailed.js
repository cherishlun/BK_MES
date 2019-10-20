$(function () {

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();
});

var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {
        $('#ArbetTable').bootstrapTable({
            height: tableHeight(),              //高度调整
            url: '',       //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '#toolbar',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: false,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: oTableInit.queryParams,//传递参数（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 100,                       //每页的记录行数（*）
            pageList: [100],        //可供选择的每页的行数（*）
            searchOnEnterKey: true, //ENTER键搜索 ,
            contentType: "application/x-www-form-urlencoded",
            strictSearch: true,
            clickToSelect: true,                //是否启用点击选中行
            uniqueId: "zdbh",                     //每一行的唯一标识，一般为主键列
            columns: [
                {
                    field: 'index',
                    title: '序号',
                    align: "center",
                    formatter: function (value, row, index) {
                        var options = $('#ArbetTable').bootstrapTable('getOptions');
                        return options.pageSize * (options.pageNumber - 1) + index + 1;
                    },
                    witdh: 10
                },
                {
                    field: 'cpmc',
                    title: '产品名称',
                    width: 100,
                },
                {
                    field: 'ph',
                    title: '生产批号',
                    width: 100,
                },
                {
                    field: 'gh',
                    title: '钢号',
                    witdh: 200,
                }, {
                    field: 'gg',
                    title: '规格',
                    width: 200
                }, {
                    field: 'zb',
                    title: '组别',
                    width: 200
                }, {
                    field: 'zl',
                    title: '重量(Kg)',
                    width: 200
                }
                , {
                    field: 'kwmc',
                    title: '库位',
                    width: 200
                }
            ],
            formatNoMatches: function () {
                return "请选择一个库位进行查看";
            }
        });
    };

    //得到查询的参数
    oTableInit.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            ph : $("#txt_ph").val(),
            gsmc : $("#txt_gsmc").val(),
            gg : $("#txt_gg").val(),
            zb : $("#txt_zb").val(),
            khbm : $("#txt_khbm").val(),
            gz : $("#txt_gz").val()
        };
        return temp;
    };
    //

    return oTableInit;
};



function detailed(kwh) {
    $('#ArbetTable').bootstrapTable('refresh', { 'url': '/Bk_ckxx/KuWeiTu_Row_Find_Details?Kwbh=' + kwh });
}

function tableHeight() {
    return $(window).height() - 10;
}
