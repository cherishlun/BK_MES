//今天
function showToDay() {
    var Nowdate = new Date();
    M = Number(Nowdate.getMonth()+1)
    //alert(Nowdate.getMonth() + "月," + Nowdate.getDate() + "号,星期" + Nowdate.getDay());
    return Nowdate.getFullYear() + "-" + M + "-" + Nowdate.getDate();
    //return new Date(Nowdate.getFullYear() , M , Nowdate.getDate());
}

//明天
function showTomorrow() {
    var tom = new Date();
    tom.setDate(tom.getDate() + 1);
    M = Number(tom.getMonth()) 
    return tom.getFullYear() + "-" + M + "-" + tom.getDate();
   // return new Date(tom.getFullYear(), M, tom.getDate());
}

//本周第一天
function showWeekFirstDay() {
    var Nowdate = new Date();
    var WeekFirstDay = new Date(Nowdate - (Nowdate.getDay() - 1) * 86400000);
    M = Number(WeekFirstDay.getMonth()+1)
    return WeekFirstDay.getFullYear() + "-" + M + "-" + WeekFirstDay.getDate();
    //return new Date(WeekFirstDay.getFullYear(), M, WeekFirstDay.getDate());
}

//本周最后天
function showWeekLastDay() {
    var Nowdate = new Date();
    var WeekFirstDay = new Date(Nowdate - (Nowdate.getDay() - 1) * 86400000);
    var WeekLastDay = new Date((WeekFirstDay / 1000 + 6 * 86400) * 1000);
    M = Number(WeekLastDay.getMonth()+1) 
    return WeekLastDay.getFullYear() + "-" + M + "-" + WeekLastDay.getDate();
    //return new Date(WeekLastDay.getFullYear(), M, WeekLastDay.getDate());
}

//本月第一天
function showMonthFirstDay() {
    var Nowdate = new Date();
    var MonthFirstDay = new Date(Nowdate.getFullYear(), Nowdate.getMonth(), 1);
    M = Number(MonthFirstDay.getMonth()+1)
    return MonthFirstDay.getFullYear() + "-" + M + "-" + MonthFirstDay.getDate();
    //return new Date(MonthFirstDay.getFullYear(), M, MonthFirstDay.getDate());
}

//本月最后一天
function showMonthLastDay() {
    var Nowdate = new Date();
    var MonthNextFirstDay = new Date(Nowdate.getFullYear(), Nowdate.getMonth() +1, 1);
    var MonthLastDay = new Date(MonthNextFirstDay - 86400000);
    M = Number(MonthLastDay.getMonth()+1)
    return MonthLastDay.getFullYear() + "-" + M + "-" + MonthLastDay.getDate();
   // return new Date(MonthLastDay.getFullYear(), M, MonthLastDay.getDate());
}

