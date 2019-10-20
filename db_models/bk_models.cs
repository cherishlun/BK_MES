using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_models
{

    #region(技术质量)
    public class djdmb {
        public string djdm { get; set; }
        public int cpmcbh { get; set; }
        public string gh { get; set; }
        public int zbbh { get; set; }
        public string add_people_bm { get; set; }
        public string update_people_bm { get; set; }
        public DateTime? add_time { get; set; }
        public DateTime? update_time { get; set; }
        public int zdbh { get; set; }
    }

    public class cpmcb {

        public string cpmc { get; set; }
        public string cpmc_eng { get; set; }
        public string add_people_bm { get; set; }
        public string update_people_bm { get; set; }
        public DateTime? add_time { get; set; }
        public DateTime? update_time { get; set; }
        public int zdbh { get; set; }
    }

    public class zbb {

        public string zb { get; set; }
        public int ckbzbh { get; set; }
        public string add_people_bm { get; set; }
        public string update_people_bm { get; set; }
        public DateTime? add_time { get; set; }
        public DateTime? update_time { get; set; }
        public int zdbh { get; set; }
    }

    public class cpzlbzb {
        public string ckbz { get; set; }
        //public string klqd { get; set; }
        //public string nz { get; set; }
        //public string wq { get; set; }
        public string fileName { get; set; }
        public string filePath { get; set; }
        public string add_people_bm { get; set; }
        public string update_people_bm { get; set; }
        public DateTime? add_time { get; set; }
        public DateTime? update_time { get; set; }
        public int zdbh { get; set; }
    }

    public class gykzbz {
        public string gc { get; set; }
        public string tyd { get; set; }
        public decimal ggsx { get; set; }
        public decimal ggxx { get; set; }
        public int ckbzbh { get; set; }
        public int zdbh { get; set; }
    }

    public class machine_Table {

        public string add_people_bm { get; set; }
        public string update_people_bm { get; set; }
        public DateTime? add_time { get; set; }
        public DateTime? update_time { get; set; }
        public int zdbh { get; set; }
        public string sbmc { get; set; }
        public DateTime? scsj { get; set; }
        public string jj_jt { get; set; }
        public string jj_dls { get; set; }
        public string sl_jt { get; set; }
        public string sl_dls { get; set; }
        public int? sxsd_jj { get; set; }
        public int? sxsd_dls { get; set; }
        public int? gyyxsj { get; set; }
        public string cpgg { get; set; }
        public string jtlb { get; set; }
        public string bz { get; set; }
        public string scs { get; set; }
        public string azwz { get; set; }
        public int? gdzcbh { get; set; }
        public string sbbh { get; set; }
    }

    //public class lbgxb {

    //    public int jtbh { get; set; }
    //    public int gxh { get; set; }
    //    public decimal gxgg { get; set; }

    //    public string add_people_bm { get; set; }
    //    public string update_people_bm { get; set; }
    //    public DateTime? add_time { get; set; }
    //    public DateTime? update_time { get; set; }
    //    public int zdbh { get; set; }
    //}

    public class jrlsdb {

        public string add_people_bm { get; set; }
        public string update_people_bm { get; set; }
        public DateTime? add_time { get; set; }
        public DateTime? update_time { get; set; }
        public int zdbh { get; set; }
        public decimal ylggsx { get; set; }
        public decimal ylggxx { get; set; }
        public int sd { get; set; }
    }

    public class sxcxb {

        public string add_people_bm { get; set; }
        public string update_people_bm { get; set; }
        public DateTime? add_time { get; set; }
        public DateTime? update_time { get; set; }
        public int zdbh { get; set; }
        public string sxcxh { get; set; }
        public string sxsj { get; set; }
    }

    public class rclb {

        public string add_people_bm { get; set; }
        public string update_people_bm { get; set; }
        public DateTime? add_time { get; set; }
        public DateTime? update_time { get; set; }
        public int zdbh { get; set; }
        public string sbmc { get; set; }
        public string bz { get; set; }
    }

    /// <summary>
    /// 工艺路线表
    /// </summary>
    public class gylxb
    {
        public int zdbh { get; set; }
        public string jgsj { get; set; }
        public int sx { get; set; }
        public string gymc { get; set; }
        public int gydybh { get; set; }
        public int cpzdbh { get; set; }
    }

    public class mxb {

        public int sbbh { get; set; }
        public decimal? mxcs { get; set; }
        public int zdbh { get; set; }
        public decimal? jxzj { get; set; }
        public decimal? cxzj { get; set; }
        public int? mx { get; set; }
        public int? ml { get; set; }
    }

    /// <summary>
    /// 客户特殊要求表
    /// </summary>
    public class khtsyqb
    {
        public int khbm { get; set; }
        public int ylgysm { get; set; }
        public string bz { get; set; }
        public int zdbh { get; set; }
        public string khbzh { get; set; }
        public string pz { get; set; }
        public string gh { get; set; }
        public decimal gg { get; set; }
        public string zb { get; set; }
        public string zhyq { get; set; }
        public string qdyq { get; set; }
        public string gcyq { get; set; }
        public string dzyq { get; set; }
        public string bzyq { get; set; }
        public string beizhu { get; set; }
        public int shbz { get; set; }
        public string add_people_bm { get; set; }
        public string update_people_bm { get; set; }
        public DateTime? add_time { get; set; }
        public DateTime? update_time { get; set; }
    }


    public class klqd
    {
        public int zbbh { get; set; }
        public int zdbh { get; set; }
        public decimal ggsx { get; set; }
        public decimal ggxx { get; set; }
        public decimal klqdsx { get; set; }
        public decimal klqdxx { get; set; }
    }

    public class nz
    {
        public int zbbh { get; set; }
        public int zdbh { get; set; }
        public decimal ggsx { get; set; }
        public decimal ggxx { get; set; }
        public int nzcs { get; set; }
    }

    //产品信息表
    public class _cpxxb {

        public int zdbh { get; set; }
        public string cpdm { get; set; }
        public string ptgg { get; set; }
        public string cpgg { get; set; }
        public int? khtsyqbh { get; set; }
        public int? djdmbh { get; set; }
        //public int? gylxbh { get; set; }
        public string add_people_bm { get; set; }
        public string update_people_bm { get; set; }
        public DateTime? add_time { get; set; }
        public DateTime? update_time { get; set; }
    }

    //产品信息详情视图
    public class ProductMessage_View {
        public int zdbh { get; set; }
        public string cpmc_eng { get;set;}
        public string cpmc { get;set;}
        public string djdm { get;set;}
        public string gh { get;set;}
        public decimal? cpgg { get;set;}
        public string cpbm { get;set;}
        public decimal? ptgg { get;set;}
        public string zb { get;set;}
        public string ckbz { get;set;}
        public string wjm { get;set;}
        public string wjlj { get;set;}
        public string gc { get;set;}
        public string tyd { get;set;}
        public string nzcs { get;set;}
        public string tsbz { get;set;}
        public string tszb { get;set; }
        public string tspz { get;set; }
        public string tszh { get;set; }
        public string tsgh { get;set; }
        public string tsbzhuang { get;set; }
        public string tsdz { get;set; }
        public string tsgc { get;set; }
        public string tsqd { get;set; }
        public decimal? tsgg { get;set; }
        public string tsbzhun { get;set; }
        public string klqd { get;set; }

    }

    //成品包装
    public class cpbz
    {
        public int zdbh { get; set; }
        public int bzdm { get; set; }
        public string bzmc { get; set; }
        public int sbbm { get; set; }
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

    //拉拔工序表
    public class lbgxb
    {
        public int zdbh { get; set; }
        public int sbbh { get; set; }
        public int mlxh { get; set; }
        public string ml { get; set; }
        public string add_people_bm { get; set; }
        public string update_people_bm { get; set; }
        public DateTime? add_time { get; set; }
        public DateTime? update_time { get; set; }
    }

    #endregion


























    /// <summary>
    /// 成品入库撤销表
    /// </summary>
    public class cprkcxb
    {
        public int cpxxbh { get; set; }
        public DateTime? rksj { get; set; }
        public int kwh { get; set; }
        public int rkfsm { get; set; }
        public int rkr { get; set; }
        public string rkbz { get; set; }
        public DateTime? cxsj { get; set; }
        public string cxyy { get; set; }
        public int cxr { get; set; }
        public int? zdbh { get; set; }
    }
    /// <summary>
    /// 配货对应组别位号
    /// </summary>
    public class phzbdy
    {
        public int? zdbh { set; get; }
        public string phzb { set; get; }

        public string phgz { set; get; }
        public string dyzb { set; get; }
        public string dyph { set; get; }

    }


    /// <summary>
    /// 成品入库表
    /// </summary>
    public class cprkb
    {
        public int cpxxbh { get; set; }
        public DateTime? rkrq { get; set; }
        public int kwh { get; set; }
        public string bz { get; set; }
        public int zdbh { get; set; }
        public int czrbm { get; set; }
        public int rkfsm { get; set; }
    }
    /// <summary>
    /// 成品库位表
    /// </summary>
    public class cpkwb
    {
        public int cpbh { get; set; }
        public int kwbh { get; set; }
        public int zdbh { get; set; }
    }

    public class cpxxb_4
    {
        public string sjbh { set; get; }
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
        public int? jrrbm { set; get; }
        public int? xgrbm { set; get; }
        public DateTime? xgsj { set; get; }
        public int? zdbh { set; get; }
        public string kw { set; get; }

        public string ph { set; get; }

}

    public class cpxxb_temp
    {
        public string sjbh { set; get; }
        public string gsmc { set; get; }
        public DateTime? scrq { set; get; }
        public string bc { set; get; }
        public string scpc { set; get; }
        public string jt { set; get; }
        public string gg { set; get; }
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
        public int? jrrbm { set; get; }
        public int? xgrbm { set; get; }
        public DateTime? xgsj { set; get; }
        public int? zdbh { set; get; }
        public string kw { set; get; }

        public string ph { set; get; }

    }

    /// <summary>
    /// 成品盘库临时表
    /// </summary>
    public class cppklsb
    {
        public int pkbh { set; get; }
        public int cpbh { set; get; }
        public int kwbm { set; get; }
        public int czrbm { set; get; }
        public DateTime? czrq { set; get; }
        public int zdbh { set; get; }
        public string pkzt { set; get; }
        public string pkbz { set; get; }
    }

    public class t1
    {
        public int? zdbh { set; get; }
        public string cname { set; get; }
    }

    public class t2
    {
        public int? zdbh { set; get; }
        public int t1bh { set; get; }
        public string cname { set; get; }
    }

    /// <summary>
    /// 用户权限
    /// </summary>
    //public class YongHuQuanXian
    //{
    //    public 
    //}

    ///发货信息表
    public class fhxxb
    {
        public int? ddtbh { set; get; }
        public int? zclxbm { set; get; }
        public string zch { set; get; }
        public string bz { set; get; }
        public int? jrrbm { set; get; }
        public DateTime? jlsj { set; get; }
        public int? xgrbm { set; get; }
        public DateTime xgsj { set; get; }
        public int? qrrbm { set; get; }
        public DateTime? qrsj { set; get; }
        public int? jsrbm { set; get; }

        public DateTime? jssj { set; get; }
        public int? zdbh { set; get; }
    }

    public class fhxxpjb
    {
        public int? ddtbh { set; get; }
        public string pjmc { set; get; }
        public decimal? pjsl { set; get; }
        public string pjjldw { set; get; }
        public string sfhs { set; get; }
        public int? hsrbm { set; get; }
        public DateTime? hssj { set; get; }
        public int? zdbh { set; get; }
    }


    ///订单状态表
    public class dingdan_t_zt
    {
        public int ddtbm { set; get; }
        [JsonConverter(typeof(StringEnumConverter))]
        /// <summary>
        /// 订单状态
        /// </summary>
        public db_enum.enum_ddzt ddzt { get; set; }
        public int jlrbm { set; get; }
        public int? xgrbm { set; get; }
        public DateTime? xgrq { set; get; }
        public int? zdbh { set; get; }
    }

    /// <summary>
    /// 用户表_视图
    /// </summary>
    public class YongHu
    {
        public int yhbm { set; get; }
        public string yhdlm { set; get; }
        public string yhxm { set; get; }
        public string yhms { set; get; }
        public string yhmm { set; get; }
        public int yhqxm { set; get; }
    }


    /// <summary>
    /// 产品表_2 用于存储产品列表
    /// </summary>
    public class ChanPinMingCheng
    {
        public int? zdbh { set; get; }
        public string cpmc { set; get; }
        public string ywmc { set; get; }
    }

    /// <summary>
    /// 订单头
    /// </summary>
    public class dingdan_t
    {
        public int?  zdbh { set; get; }
        public DateTime dhrq { set; get; }
        public int khbm { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string bz { set; get; }

        public string khmc { set; get; }
        public string ch { set; get; }
        public string zdr { set; get; }
        public string thr { set; get; }

    }

    /// <summary>
    /// 订单明细
    /// </summary>
    public class dingdan_m
    {
        public int? zdbh {set;get;}
        public int dhtbh { set; get; }
        public int cpbm { set; get; }
        public string gh { set; get; }
        public decimal? gg { set; get; }
        public string zb { set; get; }
        public int bzbm { set; get; }
        public decimal yjl { set; get; }
        public int? jrrbm { set; get; }
       // public DateTime jrrq { set; get; }


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

        public string khmc2 { set; get; }




    }


    public class ckxxb
    {
        public int? zdbh { set; get; }
        public string ckmc { set; get; }

        /// <summary>
        /// 使用枚举名称来显示
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public db_enum.enum_cklx cklx { set; get; }
       // public string cklx2 {  get { return Enum.GetName(typeof(db_enum.enum_cklx), cklx);  } }
        public string ckwz { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public db_enum.enum_zt ckzt { set; get; }
        public string ckbz { set; get; }

        public int? jrrbm { set; get; }
        public int? xgrbm { set; get; }
        public DateTime? xgsj { set; get; }
    }

    /// <summary>
    /// 仓库信息排位表
    /// </summary>
    public class ckxx_kwph
    {
        /// <summary>
        /// 仓库编号
        /// </summary>
        public int ckbh { get; set; }
        /// <summary>
        /// 排名称
        /// </summary>
        public string pmc { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public int gxr { get; set; }
        /// <summary>
        /// 自动编号
        /// </summary>

        public int? zdbh { get; set; }

    }



        /// <summary>
        /// 工艺流程对照表
        /// </summary>
        public class gylcdzb
    {

        /// <summary>
        /// 工艺流程编号
        /// </summary>
        public int gylcbh { get; set; }

        /// <summary>
        /// 成品代码
        /// </summary>
        public string cpdm { get; set; }

        /// <summary>
        /// 酸洗程序号
        /// </summary>
        public string sxcxh { get; set; }

        /// <summary>
        /// 自动编号
        /// </summary>
        public string zdbh { get; set; }

    }
   
    /// <summary>
    /// 质检名称表
    /// </summary>
    public class zjmcb
    {

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 对应标准文件码
        /// </summary>
        public int dybzwjm { get; set; }

        /// <summary>
        /// 对应质保书文件码
        /// </summary>
        public int dyzbswjm { get; set; }

        /// <summary>
        /// 检验类型
        /// </summary>
        public string jylx { get; set; }

        /// <summary>
        /// 检验名称
        /// </summary>
        public string jymc { get; set; }

    }
    /// <summary>
    /// 质检项目表
    /// </summary>
    public class zjxmb
    {

        /// <summary>
        /// 检验名称编号
        /// </summary>
        public int jymcbh { get; set; }

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 检验项目
        /// </summary>
        public string jyxm { get; set; }

        /// <summary>
        /// 判定标准
        /// </summary>
        public string pdbz { get; set; }

        /// <summary>
        /// 判定级别
        /// </summary>
        public string pdjb { get; set; }

    }
    /// <summary>
    /// sysdiagrams
    /// </summary>

    /// <summary>
    /// 检定数值表
    /// </summary>
    public class jdszb
    {

        /// <summary>
        /// 检定项目编号
        /// </summary>
        public int jdxmbh { get; set; }

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 检定数值
        /// </summary>
        public string jdsz { get; set; }

    }
    /// <summary>
    /// 成品_半成品质检对应表
    /// </summary>
    public class cpbcpzjdyb
    {

        /// <summary>
        /// 检验名称编号
        /// </summary>
        public int jymcbh { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        public string cpbm { get; set; }

    }
    /// <summary>
    /// 成品_半成品条码对应表
    /// </summary>
    public class cpbcptmdyb
    {

        /// <summary>
        /// 生产计划号
        /// </summary>
        public int scjhh { get; set; }

        /// <summary>
        /// 打印次数
        /// </summary>
        public int dycs { get; set; }

        /// <summary>
        /// 打印时间
        /// </summary>
        public DateTime dysj { get; set; }

        /// <summary>
        /// 条形码
        /// </summary>
        public string txm { get; set; }

    }
    /// <summary>
    /// 客户信息表
    /// </summary>
    public class khxxb
    {

        /// <summary>
        /// 发展日期
        /// </summary>
        public DateTime? fzrq { get; set; }

        /// <summary>
        /// 停用日期
        /// </summary>
        public DateTime? tyrq { get; set; }

        /// <summary>
        /// 建档日期
        /// </summary>
        public DateTime? jdrq { get; set; }

        /// <summary>
        /// 变更日期
        /// </summary>
        public DateTime? bgrq { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public int? khbm { get; set; }

        /// <summary>
        /// 所属地区码
        /// </summary>
        public int? ssdqm { get; set; }

        /// <summary>
        /// 所属分类码
        /// </summary>
        public int? ssflm { get; set; }

        /// <summary>
        /// 所属行业码
        /// </summary>
        public int? ssxym { get; set; }

        /// <summary>
        /// 建档人码
        /// </summary>
        public int? jdrm { get; set; }

        /// <summary>
        /// 变更人码
        /// </summary>
        public int? bgrm { get; set; }

        /// <summary>
        /// 结算方式码
        /// </summary>
        public int? jsfsm { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string khmc { get; set; }

        /// <summary>
        /// 客户代码_U8
        /// </summary>
        public string khdmu8 { get; set; }

        /// <summary>
        /// 客户后缀
        /// </summary>
        public string khhz { get; set; }

        /// <summary>
        /// 客户总公司
        /// </summary>
        public string khzgs { get; set; }

        /// <summary>
        /// 对应供应商
        /// </summary>
        public string dygys { get; set; }

        /// <summary>
        /// 客户种类
        /// </summary>
        public string khzl { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        public string bizhong { get; set; }

        /// <summary>
        /// 法人
        /// </summary>
        public string fr { get; set; }

        /// <summary>
        /// 客户管理类型
        /// </summary>
        public string khgllx { get; set; }

        /// <summary>
        /// 税号
        /// </summary>
        public string sh { get; set; }

        /// <summary>
        /// 专营业务员
        /// </summary>
        public string zyywy { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string bz { get; set; }

        /// <summary>
        /// 零售
        /// </summary>
        public string ls { get; set; }

    }
    /// <summary>
    /// 客户其他信息表
    /// </summary>
    public class khqtxxb
    {

        /// <summary>
        /// 客户编码
        /// </summary>
        public int khbm { get; set; }

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 属性
        /// </summary>
        public string sx { get; set; }

        /// <summary>
        /// 数值
        /// </summary>
        public string sz { get; set; }

    }
    /// <summary>
    /// 标准文件表
    /// </summary>
    public class bzwjb
    {

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 标准文件名称
        /// </summary>
        public string bzwjmc { get; set; }

        /// <summary>
        /// 标准文件链接
        /// </summary>
        public string bzwjlj { get; set; }

    }
    /// <summary>
    /// 成品库位配置表
    /// </summary>
    public class cpkwpzb
    {

        /// <summary>
        /// 自动编号
        /// </summary>
        public int? zdbh { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public db_enum.enum_zt kwzt { get; set; }

        /// <summary>
        /// 仓库库位号 排编号号
        /// </summary>
        public int ph { get; set; }
        /// <summary>
        /// 层号
        /// </summary>
        public int ch { get; set; }
        /// <summary>
        /// 位号
        /// </summary>
        public int wh { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        public string qt { get; set; }

        /// <summary>
        /// 间距
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public db_enum.enum_kwdx? jj { get; set; }
     

    }
    /// <summary>
    /// 成品出库表
    /// </summary>
    public class cpckb
    {

        /// <summary>
        /// 成品信息编号
        /// </summary>
        public int cpxxbh { get; set; }

        /// <summary>
        /// 操作人编码
        /// </summary>
        public int czrbm { get; set; }

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 出库方式码
        /// </summary>
        public int ckfsm { get; set; }

        /// <summary>
        /// 出库日期
        /// </summary>
        public DateTime ckrq { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string bz { get; set; }

        public int xsddbh { get; set; }

    }
    /// <summary>
    /// 客户信用等级表
    /// </summary>
    public class khxydjb
    {

        /// <summary>
        /// 客户编号
        /// </summary>
        public int khbh { get; set; }

        /// <summary>
        /// 信用额度金额
        /// </summary>
        public int xyedje { get; set; }

        /// <summary>
        /// 信用额度货物量
        /// </summary>
        public int xyedhwl { get; set; }

        /// <summary>
        /// 信用等级
        /// </summary>
        public string xydj { get; set; }

    }
    /// <summary>
    /// 成品库存表
    /// </summary>
    public class cpkcb
    {

        /// <summary>
        /// 成品信息编号
        /// </summary>
        public int cpxxbh { get; set; }

        /// <summary>
        /// 库位号
        /// </summary>
        public int kwh { get; set; }

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 操作人编码
        /// </summary>
        public int czrbm { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime rkrq { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string bz { get; set; }

    }
    /// <summary>
    /// 原料供应商表
    /// </summary>
    public class ylgysb
    {

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string mc { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string dz { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string dh { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string bz { get; set; }

    }
    /// <summary>
    /// 地区编码表
    /// </summary>
    public class dqbmb
    {

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string mc { get; set; }

    }
    /// <summary>
    /// 行业编码表
    /// </summary>
    public class xybmb
    {

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string mc { get; set; }

    }
    /// <summary>
    /// 客户分类表
    /// </summary>
    public class khflb
    {

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string mc { get; set; }

    }
    /// <summary>
    /// 成品质检结果
    /// </summary>
    public class cpzjjg
    {

        /// <summary>
        /// 生产计划号
        /// </summary>
        public int scjhh { get; set; }

        /// <summary>
        /// 确认人编码
        /// </summary>
        public int qrrbm { get; set; }

        /// <summary>
        /// 检定结果
        /// </summary>
        public string jdjg { get; set; }

    }
    /// <summary>
    /// 成品质检调整表
    /// </summary>
    public class cpzjdzb
    {

        /// <summary>
        /// 原始日期
        /// </summary>
        public DateTime ysrq { get; set; }

        /// <summary>
        /// 更改日期
        /// </summary>
        public DateTime ggrq { get; set; }

        /// <summary>
        /// 生产计划号
        /// </summary>
        public int scjhh { get; set; }

        /// <summary>
        /// 确认人编码
        /// </summary>
        public int qrrbm { get; set; }

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 原始结果
        /// </summary>
        public string ysjg { get; set; }

        /// <summary>
        /// 更改结果
        /// </summary>
        public string ggjg { get; set; }

    }
    /// <summary>
    /// 原料库位配置表
    /// </summary>
    public class ylkwpzb
    {

        /// <summary>
        /// 状态
        /// </summary>
        public string zt { get; set; }

        /// <summary>
        /// 排号
        /// </summary>
        public string ph { get; set; }

        /// <summary>
        /// 层号
        /// </summary>
        public string ch { get; set; }

        /// <summary>
        /// 位号
        /// </summary>
        public string wh { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string ckmc { get; set; }

        /// <summary>
        /// 自动编号
        /// </summary>
        public string zdbh { get; set; }

    }
    /// <summary>
    /// 企业基础信息表
    /// </summary>
    public class qyjcxxb
    {

        /// <summary>
        /// 名称
        /// </summary>
        public string mc { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string dz { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string dh { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string cz { get; set; }

        /// <summary>
        /// 税务登记号
        /// </summary>
        public string swdjh { get; set; }

        /// <summary>
        /// 开户银行
        /// </summary>
        public string khyx { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string zh { get; set; }

    }
    /// <summary>
    /// 原料表
    /// </summary>
    public class ylb
    {

        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime rksj { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        public int gysbm { get; set; }

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 入库人编码
        /// </summary>
        public int rkrbm { get; set; }

        /// <summary>
        /// 出库人编码
        /// </summary>
        public int ckrbm { get; set; }

        /// <summary>
        /// 出库时间
        /// </summary>
        public DateTime cksj { get; set; }

        /// <summary>
        /// 钢种
        /// </summary>
        public string gz { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string gg { get; set; }

        /// <summary>
        /// 炉号
        /// </summary>
        public string lh { get; set; }

        /// <summary>
        /// 库位号
        /// </summary>
        public string kwh { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string zt { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string bz { get; set; }

    }
    /// <summary>
    /// 合同头表
    /// </summary>
    public class httb
    {

        /// <summary>
        /// 客户编码
        /// </summary>
        public int khbm { get; set; }

        /// <summary>
        /// 签订时间
        /// </summary>
        public DateTime qdsj { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string htbh { get; set; }

    }
    /// <summary>
    /// 质保书文件表
    /// </summary>
    public class zbswjb
    {

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 加入人
        /// </summary>
        public int jrr { get; set; }

        /// <summary>
        /// 更改人
        /// </summary>
        public int ggr { get; set; }

        /// <summary>
        /// 加入时间
        /// </summary>
        public DateTime jrsj { get; set; }

        /// <summary>
        /// 更改时间
        /// </summary>
        public DateTime ggsj { get; set; }

        /// <summary>
        /// 质保书文件路径
        /// </summary>
        public string zbswjlj { get; set; }

    }
    /// <summary>
    /// 合同尾表
    /// </summary>
    public class htwb
    {

        /// <summary>
        /// 合同总值
        /// </summary>
        public decimal htzz { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string htbh { get; set; }

        /// <summary>
        /// 合同履行地
        /// </summary>
        public string htlxd { get; set; }

        /// <summary>
        /// 交货装运期限
        /// </summary>
        public string jhzyqx { get; set; }

        /// <summary>
        /// 装运方式
        /// </summary>
        public string zyfs { get; set; }

        /// <summary>
        /// 收货单位
        /// </summary>
        public string shdw { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        public string shdz { get; set; }

        /// <summary>
        /// 付款条件
        /// </summary>
        public string fktj { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        public string qt { get; set; }

    }
    /// <summary>
    /// 生产数据表
    /// </summary>
    public class scsjb
    {

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime scrq { get; set; }

        /// <summary>
        /// 生产计划号
        /// </summary>
        public int scjhh { get; set; }

        /// <summary>
        /// 操作工编码
        /// </summary>
        public int czgbm { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public decimal zl { get; set; }

        /// <summary>
        /// 卷号
        /// </summary>
        public string jh { get; set; }

        /// <summary>
        /// 生产班次
        /// </summary>
        public string scbc { get; set; }

        /// <summary>
        /// 生产班组
        /// </summary>
        public string scbz { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string bz { get; set; }

    }
    /// <summary>
    /// 成品盘库日志表
    /// </summary>
    public class cppkrzb
    {
        public int pkbh { set; get; }
        public int cpbh { set; get; }
        public int kwbm { set; get; }
        public int czrbm { set; get; }
        public DateTime czrq { set; get; }
        public int? zdbh { set; get; }
    }

    /// <summary>
    /// 成品盘库信息表
    /// </summary>
    public class cppkxxb
    {
        public DateTime pkrq { set; get; }
        public int pksl { set; get; }
        public decimal? pkzl { set; get; }
        public string pkxx { set; get; }
        public string pkbz { set; get; }

        public string pkzt { set; get; }
        public DateTime? pkjsrq { set; get; }

        public int? zdbh { set; get; }


    }

    /// <summary>
    /// 成品安全库存表
    /// </summary>
    public class cpaqkcb
    {
        public int cpbm { set; get; }
        public string gh { set; get; }
        public decimal? gg { set; get; }
        public string zb { set; get; }

        /// <summary>
        /// 安全库存数量
        /// </summary>
        public decimal aqkczl { get; set; }

        /// <summary>
        /// 设定人
        /// </summary>
        public int sdrbm { get; set; }

        /// <summary>
        /// 设定日期
        /// </summary>
        public DateTime sdrq { get; set; }

        /// <summary>
        /// 自动编号
        /// </summary>
        public int? zdbh { get; set; }

    }

    /// <summary>
    /// 成品库存锁定表
    /// </summary>
    public class cpkcsdb
    {

        /// <summary>
        /// 成品库存编号
        /// </summary>
        public int cpkcbh { get; set; }

        /// <summary>
        /// 锁定人
        /// </summary>
        public int sdr { get; set; }

        /// <summary>
        /// 锁定日期
        /// </summary>
        public DateTime sdrq { get; set; }

        /// <summary>
        /// 锁定原因
        /// </summary>
        public string sdyy { get; set; }

        /// <summary>
        /// 销售单编号
        /// </summary>
        public string xxdbh { get; set; }

        public int? zdbh { get; set; }




    }
    /// <summary>
    /// 出库方式表
    /// </summary>
    public class ckfsb
    {

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 出库方式
        /// </summary>
        public string ckfs { get; set; }

    }
    /// <summary>
    /// 产品表
    /// </summary>
    public class cpb
    {

        /// <summary>
        /// 参考标准码
        /// </summary>
        public int ckbzm { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        public string cpbm { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string cpmc { get; set; }

        /// <summary>
        /// 钢号
        /// </summary>
        public string gh { get; set; }

        /// <summary>
        /// 组别
        /// </summary>
        public string zb { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public decimal? gg { get; set; }

        /// <summary>
        /// 质量等级
        /// </summary>
        public string zldj { get; set; }

        /// <summary>
        /// 公差
        /// </summary>
        public string gc { get; set; }

        /// <summary>
        /// 抗拉强度
        /// </summary>
        public string klqd { get; set; }

        /// <summary>
        /// 等级代码
        /// </summary>
        public string djdm { get; set; }

        /// <summary>
        /// 产品类别
        /// </summary>
        public string cplb { get; set; }

        /// <summary>
        /// 其它
        /// </summary>
        public string qt { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string bz { get; set; }

    }
    /// <summary>
    /// 合同尾基础信息表
    /// </summary>
    public class htwjcxxb
    {

        /// <summary>
        /// 单证
        /// </summary>
        public string dz { get; set; }

        /// <summary>
        /// 装运通知
        /// </summary>
        public string zytz { get; set; }

        /// <summary>
        /// 货物验收
        /// </summary>
        public string hwys { get; set; }

        /// <summary>
        /// 不可抗力
        /// </summary>
        public string bkkl { get; set; }

        /// <summary>
        /// 争议处理
        /// </summary>
        public string zycl { get; set; }

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

    }
    /// <summary>
    /// 成品信息表
    /// </summary>
    public class cpxxb
    {

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime scrq { get; set; }

        /// <summary>
        /// 包装日期
        /// </summary>
        public DateTime bzrq { get; set; }

        /// <summary>
        /// 生产计划号
        /// </summary>
        public int scjhh { get; set; }

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public decimal zl { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string bz { get; set; }

        /// <summary>
        /// 班次
        /// </summary>
        public string bc { get; set; }

        /// <summary>
        /// 班组
        /// </summary>
        public string banzu { get; set; }

        /// <summary>
        /// 成品编码
        /// </summary>
        public string cpbm { get; set; }

        /// <summary>
        /// 卷号
        /// </summary>
        public string jh { get; set; }

        /// <summary>
        /// 原料供应商
        /// </summary>
        public string ylgys { get; set; }

        /// <summary>
        /// 原料规格
        /// </summary>
        public string ylgg { get; set; }

        /// <summary>
        /// 原料钢号
        /// </summary>
        public string ylgh { get; set; }

        /// <summary>
        /// 原料炉号
        /// </summary>
        public string yllh { get; set; }

        /// <summary>
        /// 成品规格
        /// </summary>
        public string cpgg { get; set; }

        /// <summary>
        /// 包装类别
        /// </summary>
        public string bzlb { get; set; }

        /// <summary>
        /// 质检等级
        /// </summary>
        public string zjdj { get; set; }

    }
    /// <summary>
    /// 产品价格表
    /// </summary>
    public class cpjgb
    {

        /// <summary>
        /// 客户编码
        /// </summary>
        public int khbm { get; set; }

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal jg { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        public string cpbm { get; set; }

    }
    /// <summary>
    /// 价格调整表
    /// </summary>
    public class jgdzb
    {

        /// <summary>
        /// 订单编号
        /// </summary>
        public int ddbh { get; set; }

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 原始日期
        /// </summary>
        public DateTime ysrq { get; set; }

        /// <summary>
        /// 调价日期
        /// </summary>
        public DateTime djrq { get; set; }

        /// <summary>
        /// 原始价格
        /// </summary>
        public decimal ysjg { get; set; }

        /// <summary>
        /// 调价价格
        /// </summary>
        public decimal djjg { get; set; }

    }
    /// <summary>
    /// 生产计划状态表
    /// </summary>
    public class scjhztb
    {

        /// <summary>
        /// 生产计划号
        /// </summary>
        public int scjhh { get; set; }

        /// <summary>
        /// 扫码人
        /// </summary>
        public int smr { get; set; }

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime sj { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string zt { get; set; }

    }
    /// <summary>
    /// 发运方式表
    /// </summary>
    public class fyfsb
    {

        /// <summary>
        /// 发运方式名称
        /// </summary>
        public string fyfsmc { get; set; }

        /// <summary>
        /// 自动编号
        /// </summary>
        public string zdbh { get; set; }

    }
   
    /// <summary>
    /// 半成品库位配置表
    /// </summary>
    public class bcpkwpzb
    {

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 排号
        /// </summary>
        public string ph { get; set; }

        /// <summary>
        /// 层号
        /// </summary>
        public string ch { get; set; }

        /// <summary>
        /// 位号
        /// </summary>
        public string wh { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public int? ckmc { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string zt { get; set; }

    }
    /// <summary>
    /// 机器设备表
    /// </summary>
    public class jqsbb
    {

        /// <summary>
        /// 生产时间
        /// </summary>
        public DateTime scsj { get; set; }

        /// <summary>
        /// 收线速度_卷径
        /// </summary>
        public int sxsdjj { get; set; }

        /// <summary>
        /// 收线速度_倒立式
        /// </summary>
        public int sxsddls { get; set; }

        /// <summary>
        /// 工艺运行时间
        /// </summary>
        public int gyyxsj { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        public string sbbh { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string sbmc { get; set; }

        /// <summary>
        /// 卷径_卷筒
        /// </summary>
        public string jjjt { get; set; }

        /// <summary>
        /// 卷径_倒立式
        /// </summary>
        public string jjdls { get; set; }

        /// <summary>
        /// 矢量_卷筒
        /// </summary>
        public string sljt { get; set; }

        /// <summary>
        /// 矢量_倒立式
        /// </summary>
        public string sldls { get; set; }

        /// <summary>
        /// 产品规格
        /// </summary>
        public string cpgg { get; set; }

    }
    /// <summary>
    /// 半成品信息表
    /// </summary>
    public class bcpxxb
    {

        /// <summary>
        /// 生产计划号
        /// </summary>
        public int scjhh { get; set; }

        /// <summary>
        /// 原料编码
        /// </summary>
        public int ylbm { get; set; }

        /// <summary>
        /// 自动编号
        /// </summary>
        public int zdbh { get; set; }

        /// <summary>
        /// 库位号
        /// </summary>
        public int kwh { get; set; }

        /// <summary>
        /// 入库人编码
        /// </summary>
        public int rkrbm { get; set; }

        /// <summary>
        /// 出库人编码
        /// </summary>
        public int ckrbm { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime scrq { get; set; }

        /// <summary>
        /// 出库时间
        /// </summary>
        public DateTime cksj { get; set; }

        /// <summary>
        /// 质检等级
        /// </summary>
        public string zjdj { get; set; }

        /// <summary>
        /// 班次
        /// </summary>
        public string bc { get; set; }

        /// <summary>
        /// 班组
        /// </summary>
        public string bz { get; set; }

        /// <summary>
        /// 卷号
        /// </summary>
        public string jh { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public string zl { get; set; }

    }
    
    /// <summary>
    /// 生产计划表_a
    /// </summary>
    public class scjhba
    {

        /// <summary>
        /// 交货日期
        /// </summary>
        public DateTime jhrq { get; set; }

        /// <summary>
        /// 生产计划号
        /// </summary>
        public int scjhh { get; set; }

        /// <summary>
        /// 原料编号
        /// </summary>
        public int ylbh { get; set; }

        /// <summary>
        /// 半成品编号
        /// </summary>
        public int bcpbh { get; set; }

        /// <summary>
        /// 盘数
        /// </summary>
        public int ps { get; set; }

        /// <summary>
        /// 计划产能
        /// </summary>
        public decimal jhcn { get; set; }

        /// <summary>
        /// 成品编码
        /// </summary>
        public string cpbm { get; set; }

        /// <summary>
        /// 计划类别
        /// </summary>
        public string jhlb { get; set; }

    }
    /// <summary>
    /// 产品包装表
    /// </summary>
    public class cpbzb
    {

        /// <summary>
        /// 标准重量
        /// </summary>
        public int bzzl { get; set; }

        /// <summary>
        /// 包装代码
        /// </summary>
        public string bzdm { get; set; }

        /// <summary>
        /// 包装名称
        /// </summary>
        public string bzmc { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        public string sbbh { get; set; }

        /// <summary>
        /// 规格范围
        /// </summary>
        public string ggfw { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string bz { get; set; }

    }
   

    /// <summary>
    /// 订单表
    /// </summary>
    public class ddb
    {

        /// <summary>
        /// 下单日期
        /// </summary>
        public DateTime xdrq { get; set; }

        /// <summary>
        /// 要求交付日期
        /// </summary>
        public DateTime yqjfrq { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public int ddbh { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal dj { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        public decimal ddsl { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string htbh { get; set; }

        /// <summary>
        /// 客户订单号
        /// </summary>
        public string khddh { get; set; }

        /// <summary>
        /// 成品名称
        /// </summary>
        public string cpmc { get; set; }

        /// <summary>
        /// 成品编码
        /// </summary>
        public string cpbm { get; set; }

        /// <summary>
        /// 直径
        /// </summary>
        public string zj { get; set; }

        /// <summary>
        /// 公差
        /// </summary>
        public string gc { get; set; }

        /// <summary>
        /// 钢号
        /// </summary>
        public string gh { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string gg { get; set; }

        /// <summary>
        /// 组别
        /// </summary>
        public string zb { get; set; }

        /// <summary>
        /// 包装代码
        /// </summary>
        public string bzdm { get; set; }

        /// <summary>
        /// 发货仓库码
        /// </summary>
        public string fhckm { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string bz { get; set; }

    }
    /// <summary>
    /// 生产订单对应销售订单表
    /// </summary>
    public class scdddyxsddb
    {

        /// <summary>
        /// 生产计划号
        /// </summary>
        public int scjhh { get; set; }

        /// <summary>
        /// 销售订单号
        /// </summary>
        public int xsddh { get; set; }

    }
    /// <summary>
    /// 加热炉生产计划表
    /// </summary>
    public class jrlscjhb
    {

        /// <summary>
        /// 生产计划号
        /// </summary>
        public int scjhh { get; set; }

        /// <summary>
        /// 速度
        /// </summary>
        public decimal sd { get; set; }

        /// <summary>
        /// 线号
        /// </summary>
        public string xh { get; set; }

    }

}