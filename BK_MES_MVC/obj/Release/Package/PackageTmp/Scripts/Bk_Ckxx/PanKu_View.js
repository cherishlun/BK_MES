$(function () {

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();

    $('#btn_find').click(function () {
        $('#ArbetTable').bootstrapTable('refresh', { 'url':'/Bk_Ckxx/PanKu_Find'});
    });

});

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
            pagination: true,                   //是否显示分页（*）
            sortable: false,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: oTableInit.queryParams,//传递参数（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
            searchOnEnterKey: true, //ENTER键搜索 ,
            contentType: "application/x-www-form-urlencoded",
            strictSearch: true,
            clickToSelect: true,                //是否启用点击选中行
            uniqueId: "zdbh",                     //每一行的唯一标识，一般为主键列
            detailView: true,                   //是否显示父子表
            columns: [
                {
                    field: 'pkrq',
                    title: '盘库日期',
                    width: 100,
                    formatter: function (value, row, index) {
                        return value.substring(0, 10);
                    }
                }, {
                    field: 'pksl',
                    title: '盘库数量',
                    witdh: 200,
                }, {
                    field: 'pkzl',
                    title: '盘库重量',
                    width: 200
                },
                {
                    field: 'pkxx',
                    title: '盘库信息',
                    width: 300,
                }, {
                    field: 'pkbz',
                    title: '盘库备注',
                    width: 150
                }, {
                    field: 'pkzt',
                    title: '盘库状态',
                    width: 150,
                    formatter: function (value, row, index) {
                        return value == "1" ? "完成" : "盘库中..";
                    }
                }, {
                    field: 'zdbh',
                    title: '盘库编号',
                    visible: false
                }
            ],
            onExpandRow: function (value, row, $Subdetail) {
                oTableInit.InitSubTable_2(value, row, $Subdetail);
            },
        });
    };

    oTableInit.InitSubTable_2 = function (value, row, $detai2) {
        var _pkbh = row.zdbh;
        //row是父表的值
        var cur_table_2 = $detai2.html('<table id="table_2"></table>').find('table');
        $(cur_table_2).bootstrapTable({
            data: [{ "pklx": "多了", "lxbm": "1", "pkbh": _pkbh }, { "pklx": "少了", "lxbm": "2", "pkbh": _pkbh }, { "pklx": "正常", "lxbm": "0", "pkbh": _pkbh }],
            clickToSelect: true,
            detailView: true,                   //是否显示父子表
            columns: [
                {
                    field: 'pklx',
                    title: '类型'
                }
                , {
                    field: 'lxbm',
                    title: '类型编码',
                    visible: false
                }
                , {
                    field: 'pkbh',
                    title: '库存编号',
                    visible: false,
                }
            ],
            onExpandRow: function (value, row, $Subdetail) {
                oTableInit.InitSubTable_3(value, row, $Subdetail);
            },
        });
    };

    oTableInit.InitSubTable_3 = function (value, row, $detai3) {
        //row是InitSubTable_2  表的值
        var cur_table_3 = $detai3.html('<table id="table_3"></table>').find('table');
        $(cur_table_3).bootstrapTable({
            url: '/BK_Ckxx/PanKu_Find_Mx?izt=' + row.lxbm + "&ipkbh=" + row.pkbh,
            method: 'get',
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            contentType: "application/json",
            dataType: "json",
            clickToSelect: true,
            pagination: true,                   //是否显示分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            queryParams: oTableInit.queryParams_3,//传递参数（*）
            uniqueId: "zdbh",
            contentType: "application/x-www-form-urlencoded",
            columns: [
                {
                    field: 'index',
                    title: '序号',
                    align: "center",
                    formatter: function (value, row, index) {
                        var options = $('#table_3').bootstrapTable('getOptions');
                        return options.pageSize * (options.pageNumber - 1) + index + 1;
                    },
                    witdh: 10
                },
                {
                    field: 'ph',
                    title: '批号'
                },
                {
                    field: 'cpmc',
                    title: '成品名称'
                },
                {
                    field: 'gh',
                    title: '钢号'
                },
                {
                    field: 'gg',
                    title: '规格'
                },
                {
                    field: 'zb',
                    title: '组别'
                },
                {
                    field: 'zl',
                    title: '重量'
                },
                {
                    field: 'ckmc',
                    title: '库位',
                     formatter: function (value, row, index) {
                         return value + "_" + row.wzmc
                    }
                },
                {
                    field: 'yhxm',
                    title: row.lxbm==1?'盘库操作人':'入库操作人'
                },
                {
                    field: 'czrq',
                    title: row.lxbm == 1 ? '盘库操作日期' :'入库操作日期',
                }
            ],
        });
    };


    //得到查询的参数
    oTableInit.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            pkrq: $("#pkrq").val()
        };
        return temp;
    };

    //得到查询的参数
    oTableInit.queryParams_3 = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset,  //页码
        };
        return temp;
    };




    return oTableInit;
}

function tableHeight() {
    return $(window).height() - 10;
}

$('#pkrq').selectpicker({});