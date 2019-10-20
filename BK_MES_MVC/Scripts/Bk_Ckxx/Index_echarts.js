$(function () {
    

    var pieChart = echarts.init(document.getElementById("echarts-pie-chart"));
    var pieoption = {
        title: {
            text: '库位图表',
            x: 'center'
        },
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },
        legend: {
            orient: 'vertical',
            x: 'left',
            data: ['未用量', '占用量']
        },
        calculable: false,
        series: [
            {
                name: '库位信息',
                type: 'pie',
                radius: '80%',
                center: ['50%', '60%'],
                data: [
                    { value: _KcWyl, name: '未用量' },
                    { value: _KcZyl, name: '占用量' },
                ]
            }
        ]
    };
    pieChart.setOption(pieoption);
    $(window).resize(pieChart.resize);
	
	var barChart = echarts.init(document.getElementById("echarts-bar-chart"));
	var baroption = {
	    title : {
	        text: '仓库安全库存量'
	    },
	    tooltip : {
	        trigger: 'axis'
	    },
	    legend: {
	        data:['设定值','当前值']
	    },
	    grid:{
	        x:30,
	        x2:40,
	        y2:24
        },
        calculable: false,
	    xAxis : [
	        {
                type: 'category',
                data: _AqKc_Mc.split(",")
	        }
	    ],
	    yAxis : [
	        {
	            type : 'value'
	        }
	    ],
	    series : [
	        {
	            name:'设定值',
                type: 'bar',
                data: _AqKc_Sdzl.split(",")
	        },
	        {
	            name:'当前值',
	            type:'bar',
                data: _AqKc_Kczl.split(",")
	            },
	        
	    ]
	};
	barChart.setOption(baroption);
	
	window.onresize = barChart.resize;
	
	
	


});
