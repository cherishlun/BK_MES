 $(function () {

            //1.初始化Table
            var oTable_Top = new Table_Top_Init();
    oTable_Top.Init();

    var oTable_Bottom = new Table_Bottom_Init();
    oTable_Bottom.Init();


            $('#btn_save').click(function () {
        swal({
            title: "保存确认"
            , text: "是否保存配货信息？"
            , type: "info"
            , cancelButtonText: "取消"
            , confirmButtonText: "保存！"
            , showCancelButton: true
            , closeOnConfirm: false
            , showLoaderOnConfirm: true,
        }, function () {
            //循环Bottom表取出ckbh
            var _bh = [];
            var data = $('#Arbet_Bottom_Table').bootstrapTable("getData");
            for (var rows in data) {
                _bh.push({
                    cpbh: data[rows].cpbh
                    , xxdbh:1   //@ViewBag.xxdbh
            });
    }

                    $.ajax({
        url: "/Bk_Ckxx/PeiHuo_Save"
    , data: JSON.stringify(_bh)
    ,type: 'POST'
    ,contentType: 'application/json;charset=utf-8'
                        , success: function (data) {
        swal(data.info, "", data.status == 1 ? "success" : "error");
    if (data.status == 1) {

    }
    }
                        , error: function (result) {
        //alert(result.responseText);
        swal("数据增加失败！", result.responseText.substring(0, 100), "error");
    }
});
});

});


});

        var Table_Top_Init = function () {
            var oTable_Top_Init = new Object();
    //初始化Table
            oTable_Top_Init.Init = function () {
        $('#Arbet_Top_Table').bootstrapTable({
            url: '/BK_Ckxx/PeiHuo_Select_Find',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '#toolbar_model',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: false,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: oTable_Top_Init.queryParams,//传递参数（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 5,                       //每页的记录行数（*）
            contentType: "application/x-www-form-urlencoded",
            strictSearch: true,
            clickToSelect: true,                //是否启用点击选中行
            height: 350,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
            uniqueId: "cpbh",                     //每一行的唯一标识，一般为主键列
            detailView: false,                   //是否显示父子表
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
                    field: 'cpbh',
                    title: '成品编号',
                    visible: false
                },
                {
                    field: 'operate',
                    title: '操作',
                    formatter: operateFormatter_Top //自定义方法，添加操作按钮\
                    , width: 200
                },
            ],
            rowStyle: function (row, index) {
                var classesArr = ['success', 'info'];
                var strclass = "";
                if (row.ckzt == "可用") {
                    strclass = classesArr[0];
                } else {
                    strclass = classesArr[1];
                }
                return { classes: strclass };
            },
        });

    };

    //得到查询的参数
            oTable_Top_Init.queryParams = function (params) {
                var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
        limit: params.limit,   //页面大小
    offset: params.offset,  //页码
    filter: params.filter,   //查询条件
    search: params.search
};
return temp;
};
return oTable_Top_Init;
};

        var Table_Bottom_Init = function () {
            var oTable_Bottom_Init = new Object();
    //初始化Table
            oTable_Bottom_Init.Init = function () {
        $('#Arbet_Bottom_Table').bootstrapTable({
            height: 300,              //高度调整
            showFooter: true,
            uniqueId: "cpbh",                     //每一行的唯一标识，一般为主键列
            columns: [
                {
                    field: 'cpmc',
                    title: '成品名称'
                    , footerFormatter: function (data) {
                        var _icount = 0;
                        for (var rows in data) {
                            _icount += 1;
                        }
                        return "汇总-[" + _icount.toString() + "]条记录被加入!";
                    }

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
                    , footerFormatter: function (data) {
                        //统计
                        var _sum = 0;
                        for (var rows in data) {
                            _sum += data[rows].zl;
                        }
                        return _sum.toFixed(2);//保留两位小数;
                    }
                },
                {
                    field: 'cpbh',
                    title: '成品编号',
                    visible: false
                },
                {
                    field: 'operate',
                    title: '操作',
                    formatter: operateFormatter_Bottom //自定义方法，添加操作按钮\
                    , width: 200
                },
            ]
        });

    };
    return oTable_Bottom_Init;
};

        function tableHeight() {
            return $(window).height() - 10;
}

        function operateFormatter_Top(value, row, index) {//赋予的参数
            var PySheDingID = row.cpbh; //;
    // 利用 row 获取点击这行的ID
    return [
                "<div class='btn-group btn-group-xs'>" +
                "<button type='button' class='btn btn-info' onclick='btnSelect_Top(" + PySheDingID + ")' >选择</button>" +
                "</div>"
].join('');
}

        function operateFormatter_Bottom(value, row, index) {//赋予的参数
            var PySheDingID = row.cpbh; //;
    // 利用 row 获取点击这行的ID
    return [
                "<div class='btn-group btn-group-xs'>" +
                "<button type='button' class='btn btn-info' onclick='btnSelect_Bottom(" + PySheDingID + ")' >移除</button>" +
                "</div>"
].join('');
}

        function btnSelect_Top(id) {
        //alert(id);

        $table_top = $('#Arbet_Top_Table').bootstrapTable();
    $table_bottom = $('#Arbet_Bottom_Table').bootstrapTable();

    var selectedContent = $table_top.bootstrapTable('getRowByUniqueId',id);
    $table_bottom.bootstrapTable("append", selectedContent);
            $table_top.bootstrapTable('remove', {
        field: "cpbh", values: [parseInt(id)]
});
}


        function btnSelect_Bottom(id) {
        //alert(id);

        $table_top = $('#Arbet_Top_Table').bootstrapTable();
    $table_bottom = $('#Arbet_Bottom_Table').bootstrapTable();

    var selectedContent = $table_bottom.bootstrapTable('getRowByUniqueId', id);
    $table_top.bootstrapTable("append", selectedContent);
            $table_bottom.bootstrapTable('remove', {
        field: "cpbh", values: [parseInt(id)]
});
}


//关闭弹出窗口
        function ModalHide() {
        $("#myModal").modal('hide');
    tablerefesh();
}

        function tablerefesh() {
        $('#ArbetTable').bootstrapTable('refresh', { 'url': "/BK_Ckxx/DingDan_Find" });
    }

    $('#cpbm').selectpicker({});
    $('#ddzt21').selectpicker({});

