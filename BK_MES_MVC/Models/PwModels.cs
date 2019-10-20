using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_MES_MVC.Models
{
    public class PwModels
    {
        //A.排名称,B.自动编号,B.层号,B.位号,B.其他,B.状态,B.间距
        public string pmc { set; get; }
        public int zdbh { set; get; }
        public int ch { set; get; }
        public int wh { set; get; }
        public string qt { set; get; }
        public db_models.db_enum.enum_zt zt { set; get; }
        public db_models.db_enum.enum_kwdx jj { set; get; }

        public int maxwh { set; get; }
        public int maxch { set; get; }

        public string ckmc { set; get; }

        //该库位装了什么货物
        public string kwxx { set; get; }
    }

    public class CangKu_Print
    {
        public decimal xh3 { set; get; }
        public string ck0 { set; get; }
        public string ck1 { set; get; }
        public string ck2 { set; get; }
        public string ck3 { set; get; }
        public string ck4 { set; get; }
        public string ck5 { set; get; }
        public string ck6 { set; get; }
        public string ck7 { set; get; }
        public string ck8 { set; get; }
        public string ck9 { set; get; }
        public string ck10 { set; get; }

    }


    public class TwoTable
    {
        public List<A1> s1 { get; set; }
        public List<A2> s2 { set; get; }
    }

    public class A1
    {
        public string x1 { get; set; }
    }

    public class A2
    {
        public string z1 { get; set; }
    }


}