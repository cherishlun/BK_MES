$(function () {

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();


    $('#btn_js').click(function () {
        $("#myModal_DingDan").modal({
            show: true,
            backdrop: "static"
        });
    });

    //查询
    $('#btn_find').click(function () {
        $("#ArbetTable").bootstrapTable('selectPage', 1);
    });

    $("#myModal").on("hidden.bs.modal", function () {
        $(this).removeData("bs.modal");
        $(this).find(".modal-content").children().remove();
        $('#ArbetTable').bootstrapTable('refresh');
    });

});


var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {
        $('#ArbetTable').bootstrapTable({
            height: tableHeight(),              //高度调整
            url: '/BK_Ckxx/FaHuo_Find2',         //请求后台的URL（*）
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
                }, {
                    field: 'bz',
                    title: '备注',
                    width: 200
                },
                {
                    field: 'zdr',
                    title: '制单人',
                    width: 200
                },
                {
                    field: 'ch',
                    title: '车号',
                    width: 200
                },
                {
                    field: 'thr',
                    title: '提货人',
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
                },
                {
                    field: 'operate',
                    title: '操作',
                    formatter: operateFormatter //自定义方法，添加操作按钮\
                    , width: 100
                },
            ],
            onLoadSuccess: function () {
                $('.selectpicker').selectpicker({})
            },
            onExpandRow: function (value, row, $Subdetail) {
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
            search_ch: $("#search_ch").val(),
            search_kh: $("#search_kh").val(),
            search_dd: $("#search_dd").val()
        };
        return temp;
    };
    //

    //初始化子表格
    oTableInit.InitSubTable_2 = function (value, row, $detai2) {
        //row是父表的值
        var _html_bottom = '<div id="toolbar_m_bottom" class="btn-group"><button id = "btn_m_qr" type = "button" class= "btn btn-default" data - toggle="modal" onclick="btn_m_qr(\'' + row.zdbh + '\')" ></span>确认装车</button></div>';
        var cur_table_2 = $detai2.html('<table id="table_2"></table>' + (value == 4 ? _html_bottom : '')).find('table');

        $(cur_table_2).bootstrapTable({
            url: '/BK_Ckxx/FaHuo_Find_M?ddbh=' + row.zdbh,
            method: 'get',
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            contentType: "application/json",
            dataType: "json",
            queryParams: oTableInit.queryParams2,
            clickToSelect: true,
            pagination: true,                   //是否显示分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            uniqueId: "zdbh",
            pageSize: 1000,
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
                    field: 'bz3',
                    title: '备注3'
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
                {
                    field: 'operate',
                    title: '操作',
                    formatter: operateFormatter2 //自定义方法，添加操作按钮\
                    , width: 100
                },
            ],
            onExpandRow: function (index, row, $Subdetail) {
                oTableInit.InitSubTable_3(_value2, row, $Subdetail);
            },
        });
    };

    //得到查询的参数
    oTableInit.queryParams2 = function (params, row) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset,  //页码
        };
        return temp;
    };



    return oTableInit;
};

function operateFormatter(value, row, index) {//赋予的参数
    var PySheDingID = row.zdbh; //;

    if (row.ddztm == 5)
        return [
            "<div class='btn-group btn-group-xs'>" +
            "<button type='button' class='btn btn-info' onclick='btnCx_t(" + PySheDingID + ")' >撤销确认状态</button>" +
            "</div>"
        ].join('');

    if (row.ddztm == 4)
        return [
            "<div class='btn-group btn-group-xs'>" +
            "<button type='button' class='btn btn-info' onclick='btnZc(" + PySheDingID + ")' >输入装车信息</button>" +
            "</div>"
        ].join('');
    else
        return;
}

function operateFormatter2(value, row, index) {//赋予的参数
    var PySheDingID = row.zdbh; //;

        return [
            "<div class='btn-group btn-group-xs'>" +
            "<button type='button' class='btn btn-info' onclick='btnXx(" + PySheDingID + ")' >详细信息</button>" +
            "</div>"
        ].join('');
}

function btnZc(id) {
    $("#myModal").modal({
        remote: "/Bk_Ckxx/FaHuo_Input_Ch2?id="+id,
        backdrop: "static"
    });
}

function btnXx(id) {
    $('#Arbet_JianHuo_Table').bootstrapTable('refresh', { 'url': '/BK_Ckxx/FaHuo_Find_Mx2?id=' + id });

    $("#myModal_JianHuo").modal({
        show: true,
        backdrop: "static"
    });

  
}


function tableHeight() {
    return $(window).height() - 10;
}

function btnCx_t(key) {
    swal({
        title: "撤销发车确认状态"
        , text: "是否撤销发车确认状态？"
        , type: "info"
        , cancelButtonText: "取消"
        , confirmButtonText: "撤销！"
        , showCancelButton: true
        , closeOnConfirm: false
        , showLoaderOnConfirm: true,
    }, function () {
        $.ajax({
            url: "/Bk_Ckxx/DingDan_Qc_M?id=" + key + "&zt=5&fs=0"
            , success: function (data) {
                swal(data.info, "", data.status == 1 ? "success" : "error");
                if (data.status == 1) {
                    tablerefesh();
                }
            }
            , error: function (result) {
                //alert(result.responseText);
                swal("发车撤销处理失败！", result.responseText.substring(0, 100), "error");
            }
        });
    });
}

function btn_m_qr(key) {
    swal({
        title: "装车确认"
        , text: "是否确认发车状态？"
        , type: "info"
        , cancelButtonText: "取消"
        , confirmButtonText: "确认！"
        , showCancelButton: true
        , closeOnConfirm: false
        , showLoaderOnConfirm: true,
    }, function () {
        $.ajax({
            url: "/Bk_Ckxx/DingDan_Qc_M?id=" + key + "&zt=4&fs=1"
            , success: function (data) {
                swal(data.info, "", data.status == 1 ? "success" : "error");
                if (data.status == 1) {
                    tablerefesh();
                }
            }
            , error: function (result) {
                //alert(result.responseText);
                swal("发车确认失败！", result.responseText.substring(0, 100), "error");
            }
        });
    });
}


function tablerefesh() {
    $('#ArbetTable').bootstrapTable('refresh', { 'url': "/BK_Ckxx/FaHuo_Find2" });
}

//关闭弹出窗口
function ModalHide() {
    $("#myModal").modal('hide');
    tablerefesh();
}