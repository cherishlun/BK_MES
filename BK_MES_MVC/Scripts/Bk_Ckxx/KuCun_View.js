$(function () {

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();
  
    //查询
    $('#btn_find').click(function () {
        $("#ArbetTable").bootstrapTable('selectPage', 1);
    });

});


var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {
        $('#ArbetTable').bootstrapTable({
            height: tableHeight(),              //高度调整
            url: '/BK_Ckxx/KuCun_Find',         //请求后台的URL（*）
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
                    field: 'ckmc',
                    title: '仓库名称',
                    width: 200
                }, {
                    field: 'kwmc',
                    title: '库位名称',
                    width: 200
                },
                {
                    field: 'cpmc',
                    title: '产品名称',
                    width: 100,
                },
                {
                    field: 'ph',
                    title: '批号',
                    width: 200
                },
                {
                    field: 'zl',
                    title: '重量',
                    witdh: 200,
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
                    field: 'gc',
                    title: '公差',
                    width: 200
                }, {
                    field: 'crrq',
                    title: '生产日期',
                    width: 100,
                    formatter: function (value, row, index) {
                        //if (value.length > 10)
                        //    return value.substring(0, 10);
                        //else
                            return value;
                    }
                }, {
                    field: 'rkrq',
                    title: '入库日期',
                    width: 100,
                    formatter: function (value, row, index) {
                        //if (value.length > 10)
                        //    return value.substring(0, 10);
                        //else
                            return value;
                    }
                }, {
                    field: 'czymc',
                    title: '入库员',
                    width: 200
                },{
                    field: 'rkfsbm',
                    title: '入库方式',
                    width: 200
                },
                {
                    field: 'sdsj',
                    title: '锁定时间',
                    width: 200
                },
                {
                    field: 'zdbh',
                    title: '自动编号',
                    visible: false
                },
            ],
        });
    };

    //得到查询的参数
    oTableInit.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset,  //页码
            srkfs: $("#srkfs").val(),
            scpmc: $("#scpmc").val(),
            scpkw: $("#scpkw").val(),
            srkrq1: $("#srkrq1").val(),
            srkrq2: $("#srkrq2").val(),
            sph: $("#sph").val(),
        };
        return temp;
    };
    return oTableInit;
};

$('#srkfs').selectpicker({});

function tableHeight() {
    return $(window).height() - 10;
}
