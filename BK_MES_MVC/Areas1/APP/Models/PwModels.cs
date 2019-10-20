using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_MES_MVC.Areas.APP.Models
{
    public class PwModels
    {
        //A.排名称,B.自动编号,B.层号,B.位号,B.其他,B.状态,B.间距  容量
        public string pmc { set; get; }
        public int zdbh { set; get; }
        public int ch { set; get; }
        public int wh { set; get; }
        public string qt { set; get; }
        public int ?rl { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public db_models.db_enum.enum_zt zt { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public db_models.db_enum.enum_kwdx jj { set; get; }

        public int maxwh { set; get; }
        public int maxch { set; get; }
    }

    public class Select_CP_xx {

        //显示内容
        public string ph { set; get; }
        public string gg { set; get; }
        public string gh { set; get; }
        public string zb { set; get; }
        public string khdm { set; get; }
        public string jh { set; get; }


        /// <summary>
        /// 重量
        /// </summary>
        public Decimal? zl { get; set; }

        /// <summary>
        /// 钢丝名称
        /// </summary>
        public string gsmc { get; set; }

        /// <summary>
        /// 公差
        /// </summary>
        public string gc { get; set; }

        /// <summary>
        /// 净重
        /// </summary>
        public Decimal jz { get; set; }

        /// <summary>
        /// 旧的库位号
        /// </summary>
        public int kw_old { get; set; }
        
        /// <summary>
        /// 毛重
        /// </summary>
        public Decimal mz { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public char zt { get; set; }

    }


    /// <summary>
    /// 公用类
    /// </summary>
    public class Share {

        /// <summary>
        /// 判断
        /// </summary>
        //public int User_Login_Judge() {

        //    var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
            
        //}

    }



    public class wh_Models {
        public int wh { get; set; }
        public int ch { get; set; }
        public int zdbh { get; set; }
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

    public class cpxxb_Model
    {
        //显示内容
        public string ph { set; get; }
        public string gg { set; get; }
        public string gh { set; get; }
        public string zb { set; get; }
        public string khdm { set; get; }
        public string jh { set; get; }

        //暂不显示内容
        public string gsmc { set; get; }
        public string cpbz { set; get; }
        public string sjbh { set; get; }
        public DateTime? scrq { set; get; }
        public string bc { set; get; }
        public string scpc { set; get; }
        public string jt { set; get; }
        public string lh { set; get; }
        public decimal zl { set; get; }
        public string ylcd { set; get; }
        public DateTime? bzrq { set; get; }
        public DateTime? ckrq { set; get; }
        public string bzlb { set; get; }
        public string bz { set; get; }
        public int? jrrbm { set; get; }
        public int? xgrbm { set; get; }
        public DateTime? xgsj { set; get; }
        public int? zdbh { set; get; }
        public string kw { set; get; }

    }
}