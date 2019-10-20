$(function () {
    var oTable = new TableInit();
    oTable.Init();

    //查询
    $('#btn_find').click(function () {
        $("#ArbetTable").bootstrapTable('selectPage', 1);
    });

    $('#btn_add').click(function () {
        $("#myModal").modal({
            remote: "/Bk_Ckxx/AnQuanKuCun_Input",
            backdrop: "static"
        });
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
            height: tableHeight(),              //高度调整
            url: '/BK_Ckxx/AnQuanKuCun_Find',         //请求后台的URL（*）
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
                    title: '成品名称',
                    width: 100
                }, {
                    field: 'gh',
                    title: '钢号',
                    witdh: 200
                },{
                    field: 'gg',
                    title: '规格',
                    witdh: 200
                }, {
                    field: 'zb',
                    title: '组别',
                    witdh: 200
                }, {
                    field: 'aqkczl',
                    title: '安全库存重量',
                    witdh: 200
                },{
                    field: 'sdr',
                    title: '设定人',
                    witdh: 200

                },{
                    field: 'sdrq',
                    title: '设定日期',
                    witdh: 200,
                    formatter: function (value, row, index) {
                        return value.substring(0, 10);
                    }
                },{
                    field: 'zdbh',
                    title: '自动编号',
                    visible: false
                },{
                    field: 'operate',
                    title: '操作',
                    formatter: operateFormatter //自定义方法，添加操作按钮\
                    , width: 100
                }
            ]
        });

    };

    //得到查询的参数
    oTableInit.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset,  //页码
            search: $("#searchText").val()
        };
        return temp;
    };

    return oTableInit;
};


function tableHeight() {
    return $(window).height() - 10;
}

function operateFormatter(value, row, index) {//赋予的参数
    var PySheDingID = row.zdbh; //;
    // 利用 row 获取点击这行的ID
    return [
        "<div class='btn-group btn-group-xs'>" +
        "<button type='button' class='btn btn-info' onclick='btnEdit_t(" + PySheDingID + ")' >修改</button>" +
        "<button type='button' class='btn btn-warning' onclick='btnDele_t(" + PySheDingID + ")' >删除</button>" +
        "</div>"
    ].join('');
}


function btnEdit_t(id) {
    $("#myModal").modal({
        remote: "/Bk_Ckxx/AnQuanKuCun_Input?id=" + id,
        backdrop: "static"
    });
}

function btnDele_t(key) {
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
            url: "/Bk_Ckxx/AnQuanKuCun_Delete"
            , type: "post"
            , data: { zdbh: key}
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


//关闭弹出窗口
function ModalHide() {
    $("#myModal").modal('hide');
    tablerefesh();
}

function tablerefesh() {
    $('#ArbetTable').bootstrapTable('refresh');
}