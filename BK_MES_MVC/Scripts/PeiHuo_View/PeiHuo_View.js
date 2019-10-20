    $(function () {

            //1.初始化Table
            var oTable = new TableInit();
    oTable.Init();

            $('#btn_js').click(function () {
        swal({
            title: "订单接收确认"
            , text: "是否接收订单？"
            , type: "info"
            , cancelButtonText: "取消"
            , confirmButtonText: "接收！"
            , showCancelButton: true
            , closeOnConfirm: false
            , showLoaderOnConfirm: true,
        }, function () {
            $.ajax({
                url: "/Bk_Ckxx/PeiHuo_Receive"
                , success: function (data) {
                    swal(data.info, "", data.status == 1 ? "success" : "error");
                    if (data.status == 1) {
                        $('#ArbetTable').bootstrapTable('refresh', { 'url': "/BK_Ckxx/DingDan_Find?ddzt=2" });
                    }
                }
                , error: function (result) {
                    //alert(result.responseText);
                    swal("接收失败！", result.responseText.substring(0, 100), "error");
                }
            });
        });

    });

    //查询
            $('#btn_find').click(function () {
        $('#ArbetTable').bootstrapTable('refresh');
    });

            $("#myModal").on("hidden.bs.modal", function () {
        $(this).removeData("bs.modal");
    $(this).find(".modal-content").children().remove();
});

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
                    field: 'dhrq',
                    title: '订单日期',
                    width: 400,
                }, {
                    field: 'khmc',
                    title: '客户名称',
                    witdh: 50
                }, {
                    field: 'khhz',
                    title: '客户后缀',
                    width: 200
                }, {
                    field: 'czrq',
                    title: '操作日期',
                    width: 50,
                }, {
                    field: 'zdbh',
                    title: '订单编号',
                    visible: false
                }, {
                    field: 'ddztm',
                    title: '订单状态码',
                    visible: true
                }, {
                    field: 'operate',
                    title: '操作',
                    formatter: operateFormatter //自定义方法，添加操作按钮\
                    , width: 100
                },
            ],
            rowStyle: function (row, index) {
                var classesArr = ['success', 'info'];
                var strclass = "";
                if (row.ddzt == "可用") {
                    strclass = classesArr[0];
                } else {
                    strclass = classesArr[1];
                }
                return { classes: strclass };
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
    search: $("#searchText").val()
};
return temp;
};

//初始化子表格
            oTableInit.InitSubTable_2 = function (value, row, $detai2) {
                var _value2 = value;
    //row是父表的值
                var _html_top = '<div id="toolbar_m_top" class="btn-group"><button id="btn_add_m" type="button" class="btn btn-default" data - toggle="modal" onclick="btn_ph_auto(' + row.zdbh + ')" > <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>自动配货</button></div>';
var _html_bottom = '<div id="toolbar_m_bottom" class="btn-group"><button id = "btn_m_qr" type = "button" class= "btn btn-default" data - toggle="modal" onclick="btn_m_qr(\'' + row.zdbh + '\')" ></span>确认配货</button></div>';

var cur_table_2 = $detai2.html((value == 2 ? _html_top : '') + '<table id="table_2"></table>' + (value == 2 ? _html_bottom : '')).find('table');

$(cur_table_2).bootstrapTable({
    url: '/BK_Ckxx/DingDan_Find_M?ddbh=' + row.zdbh,
    method: 'get',
    sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
    contentType: "application/json",
    dataType: "json",
    queryParams: oTableInit.queryParams2,
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
            field: 'bz',
            title: '备注'
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
        //oTableInit.InitSubTable_3(_value2, row, $detai2);
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
    var html3 = '<div id="toolbar_3" class="btn-group"><button id = "btn_ph" type = "button" class= "btn btn-default" data - toggle="modal" onclick="btn_ph(\'' + row.zdbh + '\')" ></span>手工配货</button></div>';
    var cur_table_3 = $detai3.html('<table id="table_3"></table>' + (_value3 == 2 ? html3 : '')).find('table');

    $(cur_table_3).bootstrapTable({
        url: '/BK_Ckxx/PeiHuo_Find?ddbh=' + row.zdbh,
        method: 'get',
        sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
        contentType: "application/json",
        dataType: "json",
        queryParams: oTableInit.queryParams3,
        clickToSelect: true,
        pagination: true,                   //是否显示分页（*）
        pageNumber: 1,                       //初始化加载第一页，默认第一页
        uniqueId: "zdbh",
        pageSize: 10,
        pageList: [10, 25],
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
            },
            {
                field: 'operate',
                title: '操作',
                formatter: operateFormatter3(_value3, row),    //自定义方法，添加操作按钮\
                events: operateEvent3,
                width: 200
            },
        ],
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

//得到查询的参数
oTableInit.queryParams3 = function (params, row) {
    var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
        limit: params.limit,   //页面大小
        offset: params.offset,  //页码
    };
    return temp;
};

return oTableInit;
        };

//function tableHeight() {
//    return $(window).height() - 10;
//}

function operateFormatter(value, row, index) {//赋予的参数
    var PySheDingID = row.zdbh; //;
    // 利用 row 获取点击这行的ID

    if (row.ddztm == 3)
        return [
            "<div class='btn-group btn-group-xs'>" +
            "<button type='button' class='btn btn-info' onclick='btnCx_t(" + PySheDingID + ")' >撤销确认状态</button>" +
            "</div>"
        ].join('');
    else
        return '';
}
function operateFormatter2(value, row, index) {//赋予的参数
    return '';
}

function operateFormatter3(value, row) {//赋予的参数
    //alert(value);
    if (value == 2)
        return [
            "<div class='btn-group btn-group-xs'>" +
            "<button type='button' class='btn btn-info' id='btn_Dele_m' >删除</button>" +
            "</div>"
        ].join('');
    else
        return '';
}

window.operateEvent3 = {
    "click #btn_Dele_m": function (e, value, row, index) {
        // alert(row.zdbh);
        swal({
            title: "删除确认"
            , text: "是否删除这条数据？"
            , type: "info"
            , cancelButtonText: "取消"
            , confirmButtonText: "删除！"
            , showCancelButton: true
            , closeOnConfirm: false
            , showLoaderOnConfirm: true,
        }, function () {
            $.ajax({
                url: "/Bk_Ckxx/PeiHuo_Delete?id=" + row.zdbh
                , success: function (data) {
                    swal(data.info, "", data.status == 1 ? "success" : "error");
                    if (data.status == 1) {
                        $('#table_3').bootstrapTable('refresh');
                    }
                }
                , error: function (result) {
                    //alert(result.responseText);
                    swal("数据删除失败！", result.responseText.substring(0, 100), "error");
                }
            });
        });
    }
}

function btn_ph_auto(ddbh) {
    swal({
        title: "配货确认"
        , text: "是否开始自动配货？"
        , type: "info"
        , cancelButtonText: "取消"
        , confirmButtonText: "开始！"
        , showCancelButton: true
        , closeOnConfirm: false
        , showLoaderOnConfirm: true,
    }, function () {
        $.ajax({
            url: "/Bk_Ckxx/PeiHuo_Ph_Auto?iDdbh=" + ddbh
            , success: function (data) {
                swal(data.info, "", data.status == 1 ? "success" : "error");
                if (data.status == 1) {
                    $('#table_2').bootstrapTable('refresh', { 'url': '/BK_Ckxx/DingDan_Find_M?ddbh=' + ddbh, });
                }
            }
            , error: function (result) {
                //alert(result.responseText);
                swal("配货失败！", result.responseText.substring(0, 100), "error");
            }
        });
    });
}


function btnAdd(id) {

    $("#myModal").modal({
        remote: "/Bk_Ckxx/Data_PMC?ph=0&ckbh=" + id,
        backdrop: "static"
    });
}

function btnEdit_t(id) {
    $("#myModal").modal({
        remote: "/Bk_Ckxx/DingDan_Input_T?id=" + id,
        backdrop: "static"
    });
}

function btnEdit_m(id) {
    $("#myModal").modal({
        remote: "/Bk_Ckxx/DingDan_Input_M?id=" + id,
        backdrop: "static"
    });
}

function btnDele_m(key) {

    //alert(key);

    swal({
        title: "删除确认"
        , text: "是否删除这条数据？"
        , type: "info"
        , cancelButtonText: "取消"
        , confirmButtonText: "删除！"
        , showCancelButton: true
        , closeOnConfirm: false
        , showLoaderOnConfirm: true,
    }, function () {
        $.ajax({
            url: "/Bk_Ckxx/PeiHuo_Delete?id=" + key
            , success: function (data) {
                swal(data.info, "", data.status == 1 ? "success" : "error");
                if (data.status == 1) {
                    tablerefesh();
                }
            }
            , error: function (result) {
                //alert(result.responseText);
                swal("数据删除失败！", result.responseText.substring(0, 100), "error");
            }
        });
    });
}

function btn_ph(id) {
    // alert(id);
    $("#myModal").modal({
        remote: "/Bk_CKxx/PeiHuo_Select?ddbh=" + id,
        backdrop: "static"
    });
}

function btnCx_t(key) {
    swal({
        title: "撤销配货确认状态"
        , text: "是否撤销配货确认状态？"
        , type: "info"
        , cancelButtonText: "取消"
        , confirmButtonText: "撤销！"
        , showCancelButton: true
        , closeOnConfirm: false
        , showLoaderOnConfirm: true,
    }, function () {
        $.ajax({
            url: "/Bk_Ckxx/DingDan_Qc_M?id=" + key + "&zt=3&fs=0"
            , success: function (data) {
                swal(data.info, "", data.status == 1 ? "success" : "error");
                if (data.status == 1) {
                    tablerefesh();
                }
            }
            , error: function (result) {
                //alert(result.responseText);
                swal("数据处理失败！", result.responseText.substring(0, 100), "error");
            }
        });
    });
}

function btn_m_qr(key) {
    swal({
        title: "配货确认"
        , text: "是否确认配货状态？"
        , type: "info"
        , cancelButtonText: "取消"
        , confirmButtonText: "确认！"
        , showCancelButton: true
        , closeOnConfirm: false
        , showLoaderOnConfirm: true,
    }, function () {
        $.ajax({
            url: "/Bk_Ckxx/DingDan_Qc_M?id=" + key + "&zt=2&fs=1"
            , success: function (data) {
                swal(data.info, "", data.status == 1 ? "success" : "error");
                if (data.status == 1) {
                    tablerefesh();
                }
            }
            , error: function (result) {
                //alert(result.responseText);
                swal("订单确认失败！", result.responseText.substring(0, 100), "error");
            }
        });
    });
}

function btnEdit(id) {
    $("#myModal").modal({
        remote: "/Bk_Ckxx/Data_PMC?ph=" + id + '&ckbh=0',
        backdrop: "static"
    });
}

function btShow2(id) {

    //window.location.href = "/Bk_Ckxx/Ck_KwMc_GetData_ph_wz?id" = id;
}

//关闭弹出窗口
function ModalHide() {
    $("#myModal").modal('hide');
    tablerefesh();
}

function tablerefesh() {
    $('#ArbetTable').bootstrapTable('refresh', { 'url': "/BK_Ckxx/DingDan_Find" });
}

$('#ddzt').selectpicker({});