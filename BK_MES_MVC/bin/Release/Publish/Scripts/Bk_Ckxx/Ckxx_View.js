$(function () {

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();


    $('#btn_add').click(function () {
        parent.addMenuTab('/Bk_Ckxx/Ckxx_Data_Input_Import', '成品信息导入')
    });

    //查询
    $('#btn_find').click(function () {
        $("#ArbetTable").bootstrapTable('selectPage', 1);
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
            url: '/BK_Ckxx/Ckxx_Find',         //请求后台的URL（*）
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
            onClickRow: function (row, $element) {
                $('.info').removeClass('info');
                $($element).addClass('info');
            },
            columns: [
                {
                    field: 'index',
                    title: '序号',
                    align: "center",
                    formatter: function (value, row, index) {
                        var options = $('#ArbetTable').bootstrapTable('getOptions');
                        return options.pageSize * (options.pageNumber - 1) + index + 1;
                    },
                    width: 50
                },
                {
                    field: 'sjbh',
                    title: '数据编号',
                    width: 70
                }, {
                    field: 'ph',
                    title: '批号',
                    width: 100
                },
                {
                    field: 'gsmc',
                    title: '产品名称',
                    width:180,
                },
                {
                    field: 'scrq',
                    title: '生产日期',
                    width: 90,
                    formatter: function (value, row, index) {
                        if (value != null && value.length > 10)
                            return value.substring(0, 10);
                        else
                            return value;
                    }
                },
                {
                    field: 'bc',
                    title: '班次',
                    width: 50,
                },
                {
                    field: 'scpc',
                    title: '生产批次',
                    width: 90,
                },
                {
                    field: 'jt',
                    title: '机台',
                    width: 50
                },
                {
                    field: 'gg',
                    title: '规格',
                    width: 50
                },{
                    field: 'zb',
                    title: '组别',
                    width: 50
                },{
                    field: 'khdm',
                    title: '客户代码',
                    width: 100
                }, {
                    field: 'gh',
                    title: '钢号',
                    width: 70
                }, {
                    field: 'lh',
                    title: '炉号',
                    width: 80
                }, {
                    field: 'jh',
                    title: '卷号',
                    width: 60
                },
                {
                    field: 'zl',
                    title: '重量(Kg)',
                    width: 80,
                },
                {
                    field: 'ylcd',
                    title: '原料产地',
                    width: 100,
                },
                {
                    field: 'bzrq',
                    title: '包装日期',
                    width: 90,
                    formatter: function (value, row, index) {
                        if (value != null && value.length > 10)
                            return value.substring(0, 10);
                        else
                            return value;
                    }
                },
                {
                    field: 'bzlb',
                    title: '包装类别',
                    width: 100,
                },
                {
                    field: 'ckrq',
                    title: '出库日期',
                    width: 90,
                    formatter: function (value, row, index) {
                        if (value != null && value.length > 10)
                            return value.substring(0, 10);
                        else
                            return value;
                    }
                },
                {
                    field: 'cpbz',
                    title: '标准',
                    width: 200,
                },
                {
                    field: 'bz',
                    title: '备注',
                    width: 100,
                },
                {
                    field: 'kw',
                    title: '库位',
                    width: 80,
                },
                {
                    field: 'rksj',
                    title: '入库时间',
                    width: 90,
                    formatter: function (value, row, index) {
                        if (value!=null && value.length > 10)
                            return value.substring(0, 10);
                        else
                            return value;
                    }
                },
                {
                    field: 'cksj',
                    title: '出库时间',
                    width: 90,
                },
                  {
                    field: 'jrrbm',
                    title: '操作员',
                    width: 80
                }, {
                    field: 'jrsj',
                    title: '操作时间',
                    width: 100
                }, {
                    field: 'zdbh',
                      title: '自动编号',
                      visible: false
                },
                 {
                    field: 'operate',
                    title: '操作',
                    formatter: operateFormatter //自定义方法，添加操作按钮\
                    , width: 100
                },
            ],
        });
    };

    //得到查询的参数
    oTableInit.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset,  //页码
            szt: $("#szt").val(),
            sjbh: $("#sjbh").val(),
            scpmc: $("#scpmc").val(),
            srkrq1: $("#srkrq1").val(),
            srkrq2: $("#srkrq2").val(),
            sph: $("#sph").val()
        };
        return temp;
    };
    return oTableInit;
};

$('#szt').selectpicker({});

function tableHeight() {
    return $(window).height() - 3;
}

function operateFormatter(value, row, index) {//赋予的参数
    var PySheDingID = row.zdbh; //;
    // 利用 row 获取点击这行的ID
    return [
        "<div class='btn-group btn-group-xs'>" +
        "<button type='button' class='btn btn-info' onclick='btn_edit(" + PySheDingID + ")' >编辑</button>" +
        "<button type='button' class='btn btn-info' onclick='btn_dele(" + PySheDingID + ")' >删除</button>" +
        "</div>"
    ].join('');
}


function btn_edit(id) {
    $("#myModal").modal({
        remote: "/Bk_Ckxx/Ckxx_Input?id=" + id,
        backdrop: "static"
    });
}

function btn_dele(key) {
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
            url: "/Bk_Ckxx/Ckxx_Dele"
            , type: "post"
            , data: { zdbh: key }
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