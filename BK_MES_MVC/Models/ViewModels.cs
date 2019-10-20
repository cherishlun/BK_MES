using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_MES_MVC.Models
{
    public class ViewModels
    {
    }

    /// <summary>
    /// 只返回一条记录的模式
    /// </summary>
    public class One
    {
        public int iu { get; set; }
    }

    public class DingDan_t
    {
        public DateTime dhrq { set; get; }
        public string khmc { set; get; }
        public int khbm { set; get; }
        public DateTime jlrq { set; get; }
        public int jlr { set; get; }
        public int zdbh{ set; get; }
        public string khhz { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public db_models.db_enum.enum_ddzt ddzt { set; get; }

        public int ddztm { set; get; }

        public string bz { set; get; }

        
        public string zdr { set; get; }
        public string ch { set; get; }
        public string thr { set; get; }

    }

    public class DingDan_m
    {
        public int ddtbh { set; get; }
        public int cpbm { set; get; }
        public string gh { set; get; }
        public decimal? gg { set; get; }
        public string zb { set; get; }
        public string bzmc { set; get; }
        public decimal? yjl { set; get; }

        public int? jrrbm { set; get; }
        public DateTime? jrrq { set; get; }

        public int zdbh { set; get; }

        public string kh_bm { set; get; }
        public string kh_ddh { set; get; }
        public string kh_wlbm { set; get; }

        public string bz1 { set; get; }
        public string bz2 { set; get; }
        public string bz3 { set; get; }

        public int? xgrbm { set; get; }
        public DateTime? xgrq { set; get; }

        public string cpmc { set; get; }
        public string khdm { set; get; }


        public int? s_sl { set; get; }
        public decimal? s_zl { set; get; }
        public decimal? s_bl { set; get; }

        public string khmc2 { set; get; }
    }

    public class DingDan_t_m
    {
        public DateTime dhrq { set; get; }
        public string khmc { set; get; }
        public string khhz { set; get; }
        public int ddtbh { set; get; }
        public int cpbm { set; get; }
        public string gh { set; get; }
        public decimal? gg { set; get; }
        public string zb { set; get; }
        public string bzmc { set; get; }
        public decimal yjl { set; get; }
        public string bz { set; get; }
        public DateTime czrq { set; get; }
        public int ddzdbh { set; get; }
        public string cpmc { set; get; }
    }

    public class PeiHuo
    {
        public DateTime phrq { set; get; }
        public string cpmc { set; get; }
        public string gh { set; get; }
        public decimal? gg { set; get; }
        public string zb { set; get; }
        public string bzmc { set; get; }
        public decimal zl { set; get; }
        public DateTime? scrq { set; get; }
        public int cpbh { set; get; }

        public string xxdbh { set; get; }

        public int zdbh { set; get; }

        public string ph { set; get; }
        public string khbm { set; get; }
        public string kwmc { set; get; }
    }


    public class AnQuanKuCun
    {
        public string cpmc { set; get; }
        public string gh { set; get; }
        public decimal? gg { set; get; }
        public string zb { set; get; }
        public decimal aqkczl { set; get; }
        public string sdr { set; get; }
        public DateTime sdrq { set; get; }
        public int zdbh { set; get; }

        public int kcsl { set; get; }
        public decimal kczl { set; get; }
    }

    public class PanKu_Mx
    {
        public string ph { set; get; }
        public string cpmc { set; get; }
        public string ckmc { set; get; }
        public string wzmc { set; get; }
        public string yhxm { set; get; }
        public DateTime? czrq { set; get; }
        public string gh { set; get; }
        public decimal? gg { set; get; }
        public string zb { set; get; }
        public decimal? zl { set; get; }
    }

    public class KuCun_Mx
    {
        public string cpmc { set; get; }
        public decimal? zl { set; get; }
        public string gh { set; get; }
        public decimal? gg { set; get; }
        public string zb { set; get; }
        public string gc { set; get; }

        public DateTime? ckrq { set; get; }
        public string ckmc { set; get; }
        public string kwmc { set; get; }
        public DateTime? rkrq { set; get; }

        public string czymc { set; get; }
        [JsonConverter(typeof(StringEnumConverter))]
        public db_models.db_enum.enum_rkfs rkfsbm { set; get; }
        public string ph { set; get; }
        public DateTime? sdsj { set; get; }

    }

    public class FaHuoX_Mx
    {
        public DateTime dhrq { set; get; }
        public string khmc { set; get; }
        public DateTime jlrq { set; get; }
        public int zdbh { set; get; }
        public string khhz { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
       public db_models.db_enum.enum_ddzt ddzt { set; get; }
        public int ddztm { set; get; }
        public string bz { set; get; }
        public string zcxx { set; get; }
        public string pjxx { set; get; }

    }

    public class RuKu_Mx
    {
        public string cpmc { set; get; }
        public string ph { set; get; }
        public decimal? zl { set; get; }
        public string gh { set; get; }
        public decimal? gg { set; get; }
        public string zb { set; get; }
        public string gc { set; get; }

        public string ckmc { set; get; }
        public DateTime? rkrq { set; get; }

        public string czymc { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public db_models.db_enum.enum_rkfs rkfsbm { set; get; }
        public string kwmc { set; get; }

        public int? sl { set; get; }
        public string khdm { set; get; }

        public int? ssl { get; set; }
        public decimal? szl { set; get; }

        public int? sdzt { set; get; }
        public DateTime? scrq { set; get; }

        //拣货报表用
        public int m3 { set; get; }
        public string p2 { set; get; }
        public string p3 { set; get; }
    

    }

    public class ChuKu_Mx
    {
        public string cpmc { set; get; }
        public string ph { set; get; }
        public decimal? zl { set; get; }
        public string gh { set; get; }
        public decimal? gg { set; get; }
        public string zb { set; get; }
        public string gc { set; get; }

        public string ckmc { set; get; }
        public DateTime? ckrq { set; get; }

        public string czymc { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public db_models.db_enum.enum_ckfs ckfsbm { set; get; }
    }

    public class Ckxx_Mx
    {
        public string sjbh { set; get; }
        public string ph { set; get; }
        public string gsmc { set; get; }
        public DateTime? scrq { set; get; }
        public string bc { set; get; }
        public string scpc { set; get; }
        public string jt { set; get; }
        public decimal? gg { set; get; }
        public string zb { set; get; }
        public string khdm { set; get; }
        public string gh { set; get; }
        public string lh { set; get; }
        public string jh { set; get; }
        public decimal zl { set; get; }
        public string ylcd { set; get; }
        public DateTime? bzrq { set; get; }
        public DateTime? ckrq { set; get; }
        public string bzlb { set; get; }
        public string cpbz { set; get; }
        public string bz { set; get; }
        public string yhxm { set; get; }
        public DateTime? jrsj { set; get; }
        public int? zdbh { set; get; }
        public string kw { set; get; }
        public DateTime? rksj { set; get; }
        public DateTime? cksj { set; get; }

    }

  public class FaHuo_Mx2
    {
        public string cpmc { set; get; }
        public string ph { set; get; }
        public string lh { set; get; }
        public decimal? gg { set; get; }
        public string zb { set; get; }
        public decimal zl { set; get; }
        public DateTime? ckrq { set; get; }
        public string zt { set; get; }

    }

    public class KuCun_PanKu_Hz
    {
        public string pkr { set; get; }
        public DateTime pksj { set; get; }
        public int pksl { set; get; }
        public string pkzt { set; get; }

    }

    /// <summary>
    /// 锁定表
    /// </summary>
    public class SuoDing
    {
        public string sjbh { set; get; }
        public string cpmc { set; get; }
        public string ph { set; get; }
        public decimal? zl { set; get; }
        public string gh { set; get; }
        
        public decimal? gg { set; get; }
        public string zb { set; get; }
        public string khdm { set; get; }
        public string kw { set; get; }
        public DateTime? sdrq { set; get; }
        public int? sdr { set; get; }
        public string sdyy { set; get; }
    }

    /// <summary>
    /// 呆库
    /// </summary>
    public class DaiKu
    {
        public string sjbh { set; get; }
        public string cpmc { set; get; }
        public string ph { set; get; }
        public decimal? zl { set; get; }
        public string gh { set; get; }
        public decimal? gg { set; get; }
        public string zb { set; get; }

        public string kw { set; get; }
        public DateTime? rkrq { set; get; }
        public int dkday { set; get; }

    }


    public class ck_0
    {
        public List<Ck_1> t1 { set; get; }
        public List<CK_2> t2 { set; get; }
    }
    public class Ck_1
    {
        public int a1 { set; get; }

    }
    public class CK_2
    {
        public int a2 { set; get; }

     
    }



}