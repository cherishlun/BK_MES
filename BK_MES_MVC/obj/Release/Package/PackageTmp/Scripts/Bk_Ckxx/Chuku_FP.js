//叉车任务分配
var ws;
$(function () {
    if ('WebSocket' in window) {
            ws.onmessage = function (result) {
                //$("#messageSpan").append(result.data + "</br>");
            };
            ws.onerror = function (error) {
                //$("#messageSpan").append(error.data + "</br>");
            };
            ws.onclose = function () {
                //$("#messageSpan").append("Disconnected!</br>");
            };
            ws.onbeforeunload = function () {
                ws.close();
            };
        }
    else {
            alert('当前浏览器不支持WebSocket');
        }
    }
);