$(function () {

    //1.初始化Table
    var oTable_Mx = new TableInit_Mx();
    oTable_Mx.Init();
 
});


var TableInit_Mx = function () {
    var oTable_MxInit = new Object();
    //初始化Table
    oTable_MxInit.Init = function () {
        $('#Arbet_JianHuo_Table').bootstrapTable({
            height: 300,              //高度调整
            url: '',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: false,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            queryParams: TableInit_Mx.queryParams,
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
            searchOnEnterKey: true, //ENTER键搜索 ,
            contentType: "application/x-www-form-urlencoded",
            strictSearch: true,
            clickToSelect: true,                //是否启用点击选中行
            uniqueId: "zdbh",                     //每一行的唯一标识，一般为主键列
            showFooter: true,
            columns: [
                {
                    field: 'index',
                    title: '序号',
                    align: "center",
                    formatter: function (value, row, index) {
                        var options = $('#Arbet_JianHuo_Table').bootstrapTable('getOptions');
                        return options.pageSize * (options.pageNumber - 1) + index + 1;
                    },
                    witdh: 10,
                    footerFormatter: function (data) {
                        return '汇总';
                    }
                },
                {
                    field: 'cpmc',
                    title: '产品名称',
                    width: 100,
                }, {
                    field: 'ph',
                    title: '批号',
                    witdh: 200,
                }, {
                    field: 'gh',
                    title: '钢号',
                    width: 200
                },
                {
                    field: 'gg',
                    title: '规格',
                    width: 200
                },
                {
                    field: 'zb',
                    title: '组别',
                    width: 200
                },
                {
                    field: 'zl',
                    title: '重量',
                    width: 200,
                    footerFormatter: function (data) {
                        //统计
                        var _sum = 0;
                        for (var rows in data) {
                            _sum += data[rows].zl;
                        }
                        return _sum.toFixed(2);//保留两位小数;
                    }
                },
                {
                    field: 'ckrq',
                    title: '出库日期',
                    width: 100,
                    formatter: function (value, row, index) {
                        if(value!=null)
                            return value.substring(0, 10);
                        return value;
                    }
                }, {
                    field: 'zt',
                    title: '拣货状态',
                    width: 150
                }, {
                    field: 'zdbh',
                    title: '订单编号',
                    visible: false
                }
            ],
            rowStyle: function (row, index) {
                var classesArr = ['success', 'info'];
                var strclass = "";
                if (row.zt == "计划拣货" && row.ckrq != null) {
                    strclass = classesArr[0];
                } else if (row.zt == "未按计划拣货") { 
                    strclass = classesArr[1];
                }
                return { classes: strclass };
            },
        });
    };

    //得到查询的参数
    TableInit_Mx.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset,  //页码
        };
        return temp;
    };

    return oTable_MxInit;
};

