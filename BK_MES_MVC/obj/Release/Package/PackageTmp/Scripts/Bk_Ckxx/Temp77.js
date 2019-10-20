$(function () {

    //var columnsArray = [];
    ////columnsArray.push({ field: "state", checkbox: true });
    //columnsArray.push({
    //    "title": "序号1",
    //    align: "center",
    //    formatter: function (value, row, index) {
    //        var options = $('#ArbetTable').bootstrapTable('getOptions');
    //        return options.pageSize * (options.pageNumber - 1) + index + 1;
    //    },
    //});
    //columnsArray.push({
    //    field: 'title',
    //    title: '产品名称',
    //    width: 100,
    //});

    //mycolumn = [[
    //    {
    //        field: 'title',
    //        title: '产品名称111',
    //        width: 100,
    //    }
    //    ,
    //    {
    //        "title": "序号2",
    //        align: "center",
    //        formatter: function (value, row, index) {
    //            var options = $('#ArbetTable').bootstrapTable('getOptions');
    //            return options.pageSize * (options.pageNumber - 1) + index + 1;
    //        }
    //    }
    //]];
    ouclosdf = []
    ouclosdf.push({
        field: 'title',
        title: '产品名称111',
        width: 100,
    }
        ,
        {
            "title": "序号23",
            align: "center",
            formatter: function (value, row, index) {
                var options = $('#ArbetTable').bootstrapTable('getOptions');
                return options.pageSize * (options.pageNumber - 1) + index + 1;
            }
        });

    mycolumn = [];
    mycolumn.push(ouclosdf);

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();
});