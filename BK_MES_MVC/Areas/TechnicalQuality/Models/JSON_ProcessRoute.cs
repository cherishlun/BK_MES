using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_MES_MVC.Areas.TechnicalQuality.Models
{
    //工艺路线保存模型
    public class JSON_ProcessRoute
    {
        public string Step { get; set; }
        public string Process { get; set; }
        public int a { get; set; }
        public int b { get; set; }
    }

    //工艺路线读取模型  
    public class ReadProcessRoute
    {
        //工艺名称
        public string gymc { get; set; }
        //工艺设备（5#，7#，TT1，机台名字。。。）
        public string gysb { get; set; }
        //工艺自动编号（酸洗，热处理的自动编号，模链序号）
        public int gyzdbh { get; set; }
        //模链
        public string ml { get; set; }
        //机台的自动编号
        public int machine_zdbh { get; set; }
    }

}