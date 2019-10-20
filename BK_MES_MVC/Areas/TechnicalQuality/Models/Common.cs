using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_MES_MVC.Areas.TechnicalQuality.Models
{
    public class Common
    {
    }

    //产品详细信息
    public class PM_View
    {
        public int zdbh { get; set; }
        public string cpmc_eng { get; set; }
        //成品名称
        public string cpmc { get; set; }
        //等级代码
        public string djdm { get; set; }
        //钢号
        public string gh { get; set; }
        //成品规格
        public string cpgg { get; set; }
        //成品编码
        public string cpbm { get; set; }
        //盘条规格
        public string ptgg { get; set; }
        //组别
        public string zb { get; set; }
        //参考标准
        public string ckbz { get; set; }
        //文件名
        public string wjm { get; set; }
        //文件路径
        public string wjlj { get; set; }
        public string gc { get; set; }
        public string tyd { get; set; }
        public string nzcs { get; set; }
        public string pz { get; set; }
        //包装
        public string bzhuang { get; set; }
        //单重
        public string dz { get; set; }
        //标准强度
        public string klqd { get; set; }
        //特殊公差
        public string tsgc { get; set; }
        //特殊强度
        public string tsqd { get; set; }
        //特殊单重
        public string tsdz { get; set; }
        //特殊备注
        public string tsbz { get; set; }
        //特殊包装
        public string tsbzhuang { get; set; }

    }


    #region(审核)
    public class Review_class{

        public int zdbh { get; set; }
        public string bz { get; set; }
        public decimal gg { get; set; }
        public string qdyq { get; set; }
        public string gh { get; set; }
        public string pz { get; set; }
        public string zb { get; set; }
        public string khmc { get; set; }
        public string bzhu { get; set; }
    }


    public class cpxx {

        public int zdbh { get; set; }
        public string cpdm { get; set; }
        public string cpgg { get; set; }
        public string klqdsx { get; set; }
        public string klqdxx { get; set; }
        public string bzyq { get; set; }
        public string zb { get; set; }
        public string bzhun { get; set; }
        public string gh { get; set; }
        public string gcyq { get; set; }
    }

    #endregion

    #region(工艺路线)
    public class mx {
        public string sbmc { get; set; }
        public int zdbh { get; set; }
        public string ml { get; set; }
        public int mlbh { get; set; }
        public int lbsb { get; set; }
        public decimal jxzj { get; set; }
        public decimal cxzj { get; set; }
        public decimal mxcs { get; set; }
        //public string Num_one { get; set; }
        //public string Num_two { get; set; }
        //public string Num_three { get; set; }
        //public string Num_four { get; set; }
        //public string Num_five { get; set; }
        //public string Num_six { get; set; }
        //public string Num_seven { get; set; }
        //public string Num_eight { get; set; }
        //public string Num_nine { get; set; }
        //public string Num_ten { get; set; }
        //public string Num_eleven { get; set; }
        //public string Num_twelve { get; set; }
        //public string Num_thirteen { get; set; }
        //public string Num_fourteen { get; set; }
        //public string Num_fifteen { get; set; }
    }

    //模序数量
    public class mx_count {
        public int total { get; set; }
    }

    //模链添加
    public class mx_add {
        public int Num_ml { get; set; }
    }
    #endregion

    #region(产品包装)
    public class cpbz {

        public int zdbh { get; set; }
        public string bzmc { get; set; }
        public int bzdm { get; set; }
        public string sbmc { get; set; }
        //直接上限
        public decimal zjsx { get; set; }
        //直径下限
        public decimal zjxx { get; set; }
        public int? bzzl { get; set; }
        public string bz { get; set; }
        public string add_people_bm { get; set; }
        public string update_people_bm { get; set; }
        public DateTime? add_time { get; set; }
        public DateTime? update_time { get; set; }
    }
    #endregion

}