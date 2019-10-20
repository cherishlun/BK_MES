$(function () {

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();

    $('#btn_js').click(function () {

        $("#Arbet_PeiHuo_Table").bootstrapTable('removeAll');
        $("#myModal_PeiHuo").modal({
            show: true,
            backdrop: "static"
        });

    });

    //查询
    $('#btn_find').click(function () {
        $("#ArbetTable").bootstrapTable('selectPage', 1);
    });


    $('#myModal').on('hide.bs.modal', function () {
        $('#table_2').bootstrapTable('refresh', {
            url: '/BK_Ckxx/DingDan_Find_M?ddbh=' + $("#id_2").val()
        });
    })

});


var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {
        $('#ArbetTable').bootstrapTable({
            // height: tableHeight(),              //高度调整
            url: '/BK_Ckxx/DingDan_Find',         //请求后台的URL（*）
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
                    field: 'dhrq',
                    title: '订单日期',
                    width: 100,
                    formatter: function (value, row, index) {
                        return value.substring(0, 10);
                    }
                }, {
                    field: 'khmc',
                    title: '客户名称',
                    witdh: 200,
                    formatter: function (value, row, index) {
                        return value + (row.khhz == "" ? "" : "_" + row.khhz);
                    }
                }, {
                    field: 'bz',
                    title: '备注',
                    width: 200
                },
                {
                    field: 'jlrq',
                    title: '操作日期',
                    width: 100,
                    formatter: function (value, row, index) {
                        return value.substring(0, 10);
                    }
                }, {
                    field: 'ddzt',
                    title: '订单状态',
                    width: 150
                }, {
                    field: 'zdbh',
                    title: '订单编号',
                    visible: true
                }, {
                    field: 'ddztm',
                    title: '订单状态码',
                    visible: false
                }, {
                    field: 'operate',
                    title: '操作',
                    formatter: operateFormatter //自定义方法，添加操作按钮\
                    , width: 100
                },
            ],
            onExpandRow: function (value, row, $Subdetail) {
                $("#id_2").val(row.zdbh);
                oTableInit.InitSubTable_2(row.ddztm, row, $Subdetail);
            },
        });
    };

    //得到查询的参数
    oTableInit.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset,  //页码
            ddzt: $('#ddzt').val(),
            search_dd: $("#search_dd").val(),
            search_kh: $("#search_kh").val()
        };
        return temp;
    };

    //初始化子表格
    oTableInit.InitSubTable_2 = function (value, row, $detai2) {
        var _value2 = value;
        //row是父表的值
        var cur_table_2 = $detai2.html('<table id="table_2"></table>').find('table');

        $(cur_table_2).bootstrapTable({
            url: '/BK_Ckxx/DingDan_Find_M?ddbh=' + row.zdbh,
            method: 'get',
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            contentType: "application/json",
            dataType: "json",
            clickToSelect: true,
            pagination: true,                   //是否显示分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            uniqueId: "zdbh",
            pageSize: 10,
            pageList: [10, 25],
            contentType: "application/x-www-form-urlencoded",
            detailView: true,                   //是否显示父子表
            columns: [
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
                    field: 'bzfs',
                    title: '包装方式'
                },
                {
                    field: 'yjl',
                    title: '应交量'
                },
                {
                    field: 's_zl',
                    title: '配货量'
                },
                {
                    field: 's_bl',
                    title: '比例'
                },
                {
                    field: 's_sl',
                    title: '配货件数'
                },
                {
                    field: 'bz1',
                    title: '备注1'
                },
                {
                    field: 'bz2',
                    title: '备注2'
                },
                {
                    field: 'czrq',
                    title: '操作日期'
                },
                {
                    field: 'zdbh',
                    title: '明细编号',
                    visible: false
                },
            ],
            onExpandRow: function (value, row, $Subdetail) {
                oTableInit.InitSubTable_3(_value2, row, $Subdetail);
            },
            onLoadError: function () {
                swal("数据加载失败！");
            },
        });
    };



    //初始化子表格
    oTableInit.InitSubTable_3 = function (value, row, $detai3) {
        //row是InitSubTable_2  表的值
        var _value3 = value;    //InitSubTable_2  表的值
        var cur_table_3 = $detai3.html('<table id="table_3"></table>').find('table');

        $(cur_table_3).bootstrapTable({
            url: '/BK_Ckxx/PeiHuo_Find?ddbh=' + row.zdbh,
            method: 'get',
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            contentType: "application/json",
            dataType: "json",
            clickToSelect: true,
            uniqueId: "zdbh",
            contentType: "application/x-www-form-urlencoded",
            columns: [
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
                    field: 'scrq',
                    title: '生产日期'
                },
                {
                    field: 'zl',
                    title: '重量'
                },
                {
                    field: 'zdbh',
                    title: '自动编号',
                    visible: true
                }
            ],
        });
    };



    return oTableInit;
};

function operateFormatter(value, row, index) {//赋予的参数
    var PySheDingID = row.zdbh; //;
    // 利用 row 获取点击这行的ID
    if (row.ddztm == 4) {
        return [
            "<div class='btn-group btn-group-xs'>" +
            "<button type='button' class='btn btn-info' onclick='btnCk(" + PySheDingID + ")' >输入出库信息</button>" +
            "</div>"
        ].join('');
    }
    else
        return;
}

//function btnFp(id) {
//    //ws = new WebSocket("ws://localhost:59461/api/WSChat?user=Server");
//    //ws.onopen = function () {
//    //    $("#messageSpan").append("Connected!</br>");
//    //    ws.send("*|" + id +"|false");
//    //}
//    //});
//    $.ajax({
//        url: "/Bk_Ckxx/JianHuo_Receive?id=" + id
//        , contentType: 'application/json;charset=utf-8'
//        , success: function (data) {
//             swal(data.info, "", data.status == 1 ? "success" : "error");
//            if (data.status == 1) {
//                $('#ArbetTable').bootstrapTable('refresh', { 'url': '/BK_Ckxx/DingDan_Find' });
//            }
//        }
//        , error: function (result) {
//            swal("接收失败！", result.responseText.substring(0, 100), "error");
//        }
//    });
//}

function btnCk(id) {

}

$('#ddzt').selectpicker({});