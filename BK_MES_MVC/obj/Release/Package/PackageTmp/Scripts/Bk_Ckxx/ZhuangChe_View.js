$(function () {

  

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();

    //查询
    //$('#btn_find').click(function () {
    //    $('#ArbetTable').bootstrapTable('refresh');
    //});


    //$('#myModal').on('hide.bs.modal', function () {
    //    $('#table_2').bootstrapTable('refresh', {
    //        url: '/BK_Ckxx/DingDan_Find_M?ddbh=' + $("#id_2").val()
    //    });
    //})

 //$(document).keypress(function (e) {
 //    var curKey = e.which;
 //        if (curKey == 13) {
 //               //$("#submit").click();
 //            alert("ok");
 //           }
 //       });
  //焦点
    $("#searchText")[0].focus()
});


var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {
        $('#ArbetTable').bootstrapTable({
            // height: tableHeight(),              //高度调整
            url: '/BK_Ckxx/ZhuangChe_Find?id=' + $("#hidden").val(),         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '#toolbar',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            sortable: false,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            contentType: "application/x-www-form-urlencoded",
            strictSearch: true,
            clickToSelect: true,                //是否启用点击选中行
            uniqueId: "zdbh",                     //每一行的唯一标识，一般为主键列
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
                    title: '状态',
                    field:'zt'
                },

                {
                    field: 'zdbh',
                    title: '自动编号',
                    visible: true
                }
            ]
        });
    };

    return oTableInit;
};

function showMsg(value) {
    
    var code = event.keyCode;
    if (code == 13 && value != '') {
        //alert(value);
        var row = $('#ArbetTable').bootstrapTable('getRowByUniqueId', value);
        if (row != null) {
            //alert(value);
            //alert(row.zt);
            if (row.zt ==undefined) {
                row.zt = "匹配";
                $('#ArbetTable').bootstrapTable('updateByUniqueId', { id: value, row: row });
            }
        }
        else {
            $('#ArbetTable').bootstrapTable('insertRow', { index: 0, row: { cpmc: "错误:配货中没有此货物", zt: "错误", zdbh: value } });
        }
        $("#searchText").val("");
    }

}

function showMsg2() {

    var value = $("#searchText_d").val();
    var arr = value.split(/[(\r\n)\r\n]+/);
    for (i = 0; i < arr.length; i++) {
        if (arr[i] == "") continue;
        var row = $('#ArbetTable').bootstrapTable('getRowByUniqueId', arr[i]);
        if (row != null) {
            //alert(value);
            //alert(row.zt);
            if (row.zt == undefined) {
                row.zt = "匹配";
                $('#ArbetTable').bootstrapTable('updateByUniqueId', { id: arr[i], row: row });
            }
        }
        else {
            $('#ArbetTable').bootstrapTable('insertRow', { index: 0, row: { cpmc: "错误:配货中没有此货物", zt: "错误", zdbh: arr[i] } });
        }
    }
}


function btn_zc() {
    var allTableData = $('#ArbetTable').bootstrapTable('getData');//获取表格的所有内容行
    var _count=0;
    var _ok=0;
    var _error=0;
    
    for (i = 0; i < allTableData.length; i++) {

            if (allTableData[i].zt == "匹配")
                _ok += 1;
            if (allTableData[i].zt == "错误")
                _error += 1;

    }

    swal("共扫描"+ (_ok + _error) +"卷! 匹配 "+_ok+" 卷! 错误 "+_error+" 卷! 缺少 "+(allTableData.length-_ok-_error)+" 卷!");
}