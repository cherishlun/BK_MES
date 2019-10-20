using BK_MES_MVC.Areas.APP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BK_MES_MVC.Areas.APP.Controllers
{
    public class APP_BK_CkxxController : Controller
    {

        // GET: APP/BK_Ckxx
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 根据前台所选择的排号查询该排号下的空闲库位 返回前台解析成table
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        public ActionResult Select_FreePool(string ph)
        {

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            if (string.IsNullOrEmpty(ph))
            {
                return Content("");
            }
            else
            {
                if (Request.IsAjaxRequest())
                {

                    BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                    //数据显示

                    List<Models.PwModels> _pwModels = new List<Models.PwModels>();

                    _pwModels = _rs.FindList<Models.PwModels>(@"select C.排名称 as pmc,A.层号 as ch,A.位号 as wh, A.自动编号 as zdbh, A.间距 as jj, A.容量-ISNULL(B._c,0) as rl 
                                                                               from 仓库库位配置表 A left join (select 库位编号, Count(1) as _c from[成品库位表] 
                                                                               group by 库位编号) B on a.自动编号 = b.库位编号 
                                                                               inner join[BK_MES].[dbo].[仓库库位排号表] C on C.自动编号=A.排编号 
                                                                               where(A.容量-isnull(B._c,0))>0 and 状态 = 1 and 排编号 = " + ph + " order by 层号,位号");

                    string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.PwModels>(_pwModels);
                    string _json = "{\"total\":1000" + ",\"rows\":" + _datajson + "}";
                    return Content(_datajson);

                }
            }
            return View();
        }


        /// <summary>
        /// 成品入库视图控制器
        /// </summary>
        /// <returns></returns>
        public ActionResult CP_rk_kg(string id,string type)
        {

            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
            ViewBag.user = user;
            ViewBag.type = type;
            ViewBag._id = id;

            //数据显示
            List<SelectListItem> _a = new List<SelectListItem>();

            if (!string.IsNullOrEmpty(type))
            {

                if (type.Equals("1"))
                {
                    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                    string _ckbh = "";
                    var _ck = _rs.FindEntity<db_models.ckxxb>(x => x.cklx == db_models.db_enum.enum_cklx.成品库);
                    if (_ck != null)
                    {
                        _ckbh = _ck.zdbh.ToString();
                    }



                    //第一步 动态获取指定仓库的所有排
                    List<PwModels> list1 = _rs.FindList<PwModels>("select 排名称 as pmc,自动编号 as zdbh from [BK_MES].[dbo].[仓库库位排号表] where 仓库编号="+_ckbh);
                    foreach (var i in list1)
                    {
                        _a.Add(new SelectListItem { Text = i.pmc.ToString(), Value = i.zdbh.ToString(), Selected = false });
                    }
                }
            }
            ViewBag.Ph = _a;


            return View(new PwModels());
        }


        /// <summary>
        /// 成品信息查询
        /// </summary>
        /// <param name="barcode">成品条形码</param>
        /// <param name="mark">入库标识（判断是初始入库还是移位 1为初始入库  2为转库）</param>
        /// <returns></returns>
        public ActionResult CP_Select(string CP_barcode, string mark)
        {
            try
            {

                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                DataSet ds = _rs.GetDataSet(@"select 结束日期 FROM [BK_MES].[dbo].[成品盘库信息表] where 结束日期 is null");

                if (ds!=null) {
                    /**
                    1：表示成品入库
                    2：表示成品移位
                 */
                    if (mark.Equals("1"))
                    {

                        //可优化 两张表关联查询便可只连接数据一次

                        //cp = _rs.FindEntity<db_models.cpxxb_4>(x => x.ph == CP_barcode);

                        IQueryable<db_models.cpxxb_4> cp = _rs.IQueryable<db_models.cpxxb_4>(x => x.ph == CP_barcode);
                        //取出成品信息表中的自动编号去成品库位表中查询该批号是否存在  若存在则返回前台提示该批号已入库
                        cpxxb_Model model = new cpxxb_Model();

                        model.ph = cp.First().ph;
                        model.gg = cp.First().gg;
                        model.gh = cp.First().gh;
                        model.zb = cp.First().zb;
                        model.khdm = cp.First().khdm;
                        model.jh = cp.First().jh;

                        List<cpxxb_Model> list_cp = new List<cpxxb_Model>();
                        list_cp.Add(model);

                        /**
                        //var v = _rs.FindEntity<db_models.cpkwb>(x => x.cpbh == cp.zdbh);
                        //IQueryable<db_models.cpkwb> v = _rs.IQueryable<db_models.cpkwb>(x => x.cpbh == cp.zdbh);
                            两种方式均可查询出
                            区别在于    FindEntity查出来的是对象字符串 ps:{}
                                        IQueryable查出来的是JSON格式的对象 ps:[{}]
                         */

                        //成品库位表中不存在该批号 则返回[] 反之该批号已入库
                        /**
                            lambda表达式 不能写成 x=>x.cpbh==cp.First().zdbh
                            只能分开写  先获取cp.First().zdbh的值  再将值赋给x.cpbh
                         */
                        int? i = cp.First().zdbh;
                        IQueryable<db_models.cpkwb> v = _rs.IQueryable<db_models.cpkwb>(x => x.cpbh == i);

                        if (JsonConvert.SerializeObject(v) == "[]")
                        {
                            //string _json = JsonConvert.SerializeObject(cp);
                            string _json = JsonConvert.SerializeObject(list_cp);

                            return Json(_json, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(0, JsonRequestBehavior.AllowGet);
                        }

                    }
                    else if (mark.Equals("2"))
                    {

                        DbRawSqlQuery<Select_CP_xx> query = _rs.IQueryable<Select_CP_xx>(@"select   批号 as ph,
                                                                                                规格 as gg,
                                                                                                钢号 as gh,
                                                                                                组别 as zb,
                                                                                                客户代码 as khdm,
                                                                                                卷号 as jh,
                                                                                                ISNULL(库位编号,0) as kw_old 
                                                                                    from [BK_MES].[dbo].[成品信息表_4] A 
                                                                                    left join (select 库位编号,成品编号  
                                                                                    from [BK_MES].[dbo].[成品库位表]) B  
                                                                                    on A.自动编号 = B.成品编号 where A.批号 = '" + CP_barcode + "'");

                        /**
                            备注 库位信息错误时仍可查出成品信息盘库保存
                         */
                        //DbRawSqlQuery<Select_CP_xx> query1 = _rs.IQueryable<Select_CP_xx>("select 批号 as ph,规格 as cpgg,标准 as bzhun,钢丝名称 as gsmc,公差 as gc,净重 as jz,库位编号 as kw_old " +
                        //                                            "from [BK_MES].[dbo].[成品信息表_4] A left join (select 成品编号,库位编号 from [BK_MES].[dbo].[成品库位表])B " +
                        //                                            "on A.自动编号 = B.成品编号 where A.批号 = '" + CP_barcode + "'");

                        string _json = JsonConvert.SerializeObject(query);

                        if (_json == "[]")
                        {
                            //该批号未查到库位信息
                            return Json(1, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {

                            return Json(_json, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {

                        return Json(1, JsonRequestBehavior.AllowGet);
                    }

                } else {

                    //返回前台提示当前盘库未结束  不能执行其他操作
                    return Json(2,JsonRequestBehavior.AllowGet);
                }
                
            }
            catch (Exception ex)
            {

                return Json(1, JsonRequestBehavior.AllowGet);
            }

        }


        /// <summary>
        /// 查询空闲层数
        /// </summary>
        /// <returns></returns>
        public ActionResult Ph_empty(string ph, string wh)
        {

            List<Models.wh_Models> list = new List<wh_Models>();
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            //var v = _rs.FindList<Models.PwModels>("select distinct C.排名称 as pmc " +
            //                                                "from [BK_MES].[dbo].[仓库库位配置表] A left join (select 库位编号, Count(1) as _c " +
            //                                                "from [BK_MES].[dbo].[成品库位表] group by 库位编号) B on a.自动编号 = b.库位编号 inner join[BK_MES].[dbo].[仓库库位排号表] C " +
            //                                                "on C.自动编号=A.排编号 where(A.容量-isnull(B._c,0))>0 and 状态 = 1").Select(s => new { s.pmc }).First();


            ///查询空闲库位
            //if (string.IsNullOrEmpty(wh))
            //{

            //    list = _rs.FindList<Models.wh_Models>(@"select A.位号 as wh 
            //                                    from [BK_MES].[dbo].[仓库库位配置表] A left join (select 库位编号, Count(1) as _c 
            //                                    from [BK_MES].[dbo].[成品库位表] group by 库位编号) B on a.自动编号 = b.库位编号 inner join[BK_MES].[dbo].[仓库库位排号表] C 
            //                                    on C.自动编号=A.排编号 where(A.容量-isnull(B._c,0))>0 and 状态 = 1 and A.排编号=" + ph + " order by A.位号");


            //}
            //else
            //{

            //    list = _rs.FindList<Models.wh_Models>("select A.层号 as ch,A.自动编号 as zdbh " +
            //                                    "from [BK_MES].[dbo].[仓库库位配置表] A left join (select 库位编号, Count(1) as _c " +
            //                                    "from [BK_MES].[dbo].[成品库位表] group by 库位编号) B on a.自动编号 = b.库位编号 inner join[BK_MES].[dbo].[仓库库位排号表] C " +
            //                                    "on C.自动编号=A.排编号 where(A.容量-isnull(B._c,0))>0 and 状态 = 1 and A.排编号=" + ph + " and A.位号=" + wh + " order by A.层号");

            //}


            ///查询库位
            if (string.IsNullOrEmpty(wh))
            {

                list = _rs.FindList<Models.wh_Models>(@"select A.位号 as wh 
                                                from [BK_MES].[dbo].[仓库库位配置表] A  inner join[BK_MES].[dbo].[仓库库位排号表] C 
                                                on C.自动编号=A.排编号 where 状态 = 1 and A.排编号='"+ph+"' group by  A.位号 order by A.位号");


            }
            else
            {

                list = _rs.FindList<Models.wh_Models>("select A.层号 as ch,A.自动编号 as zdbh " +
                                                "from [BK_MES].[dbo].[仓库库位配置表] A inner join[BK_MES].[dbo].[仓库库位排号表] C " +
                                                "on C.自动编号=A.排编号 where 状态 = 1 and A.排编号=" + ph + " and A.位号=" + wh + " order by A.层号");

            }

            return Json(JsonConvert.SerializeObject(list), JsonRequestBehavior.AllowGet);
        }




        public ActionResult APP()
        {

            return View();
        }




        /// <summary>
        /// 入库保存
        /// </summary>
        /// <param name="parm1">入库的仓库库位自动编码</param>
        /// <param name="parm2">入库的成品编码信息（一维码）</param>
        /// <returns></returns>
        public ActionResult WareHousing(string parm1, string parm2)
        {
            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));

            char[] c = { '[', ']', ',', '"' };

            //解析前台传来的成品信息编码 得到的成品编码个数与该库位对应的容量是否足够
            var s2 = parm2.Split(new string[] { "," }, StringSplitOptions.None);

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                var _v = _rs.FindList<Models.PwModels>("select A.自动编号,A.容量-isnull(_c,0) as rl " +
                    "                                       from [BK_MES].[dbo].[仓库库位配置表] A " +
                    "                                       left join (select 库位编号,count(1) as _c from [BK_MES].[dbo].[成品库位表] where 库位编号 = " + parm1 + " group by 库位编号) B " +
                    "                                       on A.自动编号=B.库位编号 where A.自动编号=" + parm1 + "").Select(s => new { s.rl }).First();

                if (s2.Length > Convert.ToInt32(_v.rl))
                {

                    return Json(0, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    //初始化成品入库表类
                    ObjectToJson json = new ObjectToJson();
                    List<ObjectToJson> list = new List<ObjectToJson>();

                    foreach (var i in s2.Where(s => !string.IsNullOrEmpty(s)))
                    {

                        //去除不需要的字符
                        string s1 = i.Trim(c);

                        try
                        {

                            //入库信息插入数据库
                            //每次循环执行数据库插入时 都要实例化一次
                            _rs = new SD.Data.RepositoryBase();
                            _rs.BeginTrans();

                            //根据前台传来的成品编码对应着成品信息表中的成品条形码查询出自动编号 通过成品的自动编号与库位号的自动编号关联起来
                            var v = _rs.IQueryable<db_models.cpxxb_4>(x => x.ph == s1).Select(s => new { s.zdbh }).First();
                            _rs.Insert<db_models.cprkb>(new db_models.cprkb() { cpxxbh = Convert.ToInt32(v.zdbh), kwh = Convert.ToInt32(parm1), rkfsm = 1 ,rkrq=DateTime.Now,czrbm=user});
                            _rs.Insert<db_models.cpkwb>(new db_models.cpkwb() { cpbh = Convert.ToInt32(v.zdbh), kwbh = Convert.ToInt32(parm1) });
                            _rs.Commit();
                            list.Add(new ObjectToJson() { back_success = s1 });

                        }
                        catch (Exception ex)
                        {
                            list.Add(new ObjectToJson() { back_error = s1 });
                        }

                    }

                    string _json = JsonConvert.SerializeObject(list);

                    return Json(_json, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }


        }



        /// <summary>
        /// 移位
        /// </summary>
        /// <param name="parm1">库位自动编号</param>
        /// <param name="parm2">批号</param>
        /// <returns></returns>
        public ActionResult CP_yw(string parm1, string parm2)
        {

            char[] c = { '[', ']', ',', '"' };

            var s2 = parm2.Split(new string[] { "," }, StringSplitOptions.None);

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                var _v = _rs.FindList<Models.PwModels>("select A.自动编号,A.容量-isnull(_c,0) as rl " +
                    "                                       from [BK_MES].[dbo].[仓库库位配置表] A " +
                    "                                       left join (select 库位编号,count(1) as _c from [BK_MES].[dbo].[成品库位表] where 库位编号 = " + parm1 + " group by 库位编号) B " +
                    "                                       on A.自动编号=B.库位编号 where A.自动编号=" + parm1 + "").Select(s => new { s.rl }).First();

                if (s2.Length > Convert.ToInt32(_v.rl))
                {

                    return Json(0, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    ObjectToJson json = new ObjectToJson();
                    List<ObjectToJson> list = new List<ObjectToJson>();

                    foreach (var i in s2.Where(s => !string.IsNullOrEmpty(s)))
                    {
                        string s1 = i.Trim(c);

                        try
                        {

                            _rs = new SD.Data.RepositoryBase();
                            _rs.BeginTrans();

                            //var v = _rs.IQueryable<db_models.cpxxb_4>(x => x.ph == s1).Select(s => new { s.zdbh }).First();
                            var v = _rs.FindEntity<db_models.cpxxb_4>(x => x.ph == s1);

                            //出库方式码=1表示移位
                            //_rs.Delete<db_models.cpkwb>(new db_models.cpkwb() { cpbh=Convert.ToInt32(v.zdbh)});
                            _rs.Insert<db_models.cprkb>(new db_models.cprkb() { cpxxbh = Convert.ToInt32(v.zdbh), kwh = Convert.ToInt32(parm1), rkfsm = 2,rkrq=DateTime.Now });
                            var _var = _rs.FindEntity<db_models.cpkwb>(x => x.cpbh == v.zdbh);
                            _var.kwbh = Convert.ToInt32(parm1);

                            _rs.Update<db_models.cpkwb>(_var, new List<string>() { "kwbh" });
                            _rs.Commit();
                            list.Add(new ObjectToJson() { back_success = s1 });

                        }
                        catch (Exception ex)
                        {
                            list.Add(new ObjectToJson() { back_error = s1 });
                        }

                    }

                    string _json = JsonConvert.SerializeObject(list);

                    return Json(_json, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }

        }


        /// <summary>
        /// 成品盘库
        /// </summary>
        /// <returns></returns>
        public ActionResult CP_pk_kg(string type)
        {
            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
            ViewBag.user = user;
            ViewBag.type = type;

            //数据显示
            List<SelectListItem> _a = new List<SelectListItem>();

            if (!string.IsNullOrEmpty(type)) {

                if (type.Equals("1")) {
                    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                    string _ckbh = "";
                    var _ck = _rs.FindEntity<db_models.ckxxb>(x => x.cklx == db_models.db_enum.enum_cklx.成品库);
                    if (_ck != null)
                    {
                        _ckbh = _ck.zdbh.ToString();
                    }


                    //第一步 动态获取指定仓库的所有排
                    List<PwModels> list1 = _rs.FindList<PwModels>("select 排名称 as pmc,自动编号 as zdbh from [BK_MES].[dbo].[仓库库位排号表] where 仓库编号=" + _ckbh);
                    foreach (var i in list1)
                    {
                        _a.Add(new SelectListItem { Text = i.pmc.ToString(), Value = i.zdbh.ToString(), Selected = false });
                    }


                } 
            }
                    ViewBag.Ph = _a;

            return View(new PwModels());
        }

        /// <summary>
        /// 成品盘库提交保存
        /// </summary>
        /// <param name="parm1">库位号</param>
        /// <param name="parm2">扫描的批号</param>
        /// <returns></returns>
        public ActionResult CP_pk_save(string parm1, string parm2)
        {

            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));

            char[] c = { '[', ']', ',', '"' };

            var s2 = parm2.Split(new string[] { "," }, StringSplitOptions.None);

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                ObjectToJson json = new ObjectToJson();
                List<ObjectToJson> list = new List<ObjectToJson>();

                foreach (var i in s2.Where(s => !string.IsNullOrEmpty(s)))
                {

                    //去除不需要的字符
                    string s1 = i.Trim(c);

                    _rs = new SD.Data.RepositoryBase();
                    _rs.BeginTrans();

                    //根据前台传来的成品编码对应着成品信息表中的成品条形码查询出自动编号 通过成品的自动编号与库位号的自动编号关联起来
                    var v = _rs.IQueryable<db_models.cpxxb_4>(x => x.ph == s1).Select(s => new { s.zdbh }).First();
                    _rs.Insert<db_models.cppklsb>(new db_models.cppklsb() { pkbh=0,cpbh = Convert.ToInt32(v.zdbh), kwbm = Convert.ToInt32(parm1), czrbm = user ,czrq=DateTime.Now, pkzt="1"});
                    _rs.Commit();


                }

                string _json = JsonConvert.SerializeObject(list);

                return Json(_json, JsonRequestBehavior.AllowGet);
                 
            }
            catch (Exception ex)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>
        /// 成品盘库结束
        /// </summary>
        /// <returns></returns>
        public ActionResult CP_pk_over(string s) {

            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));

            try {

                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                _rs.BeginTrans();
                //List<db_models.cppklsb> list=_rs.FindList<db_models.cppklsb>(@"SELECT [状态] FROM [BK_MES].[dbo].[成品盘库临时表] where 操作人编码 = 0");
                //List<db_models.cppklsb> l =list.FindAll(x => x.pkzt == "2");
                List<db_models.cppklsb> list = _rs.IQueryable<db_models.cppklsb>(x =>x.czrbm==user).ToList();
                if (list.Count == 0)
                {
                    return Json(0,JsonRequestBehavior.AllowGet);
                }
                else {

                    foreach(db_models.cppklsb i in list)
                    {
                        i.pkzt = "2";
                    }

                    _rs.Update<db_models.cppklsb>(list, new List<string>() { "pkzt" });
                    _rs.Commit();
                    return Json(5,JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex) {

                return Json(1,JsonRequestBehavior.AllowGet);
            }

        }



        /// <summary>
        /// 成品出库
        /// </summary>
        /// <returns></returns>
        public ActionResult CP_ck_kg()
        {
            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
            ViewBag.user = user;

            return View();
        }

        /// <summary>
        /// 成品出库保存
        /// </summary>
        /// <param name="parm1"></param>
        /// <returns></returns>
        public ActionResult CP_ck_save(string parm1)
        {

            char[] c = { '[', ']', ',', '"' };

            var s2 = parm1.Split(new string[] { "," }, StringSplitOptions.None);

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                ObjectToJson json = new ObjectToJson();
                List<ObjectToJson> list = new List<ObjectToJson>();

                foreach (var i in s2.Where(s => !string.IsNullOrEmpty(s)))
                {

                    //去除不需要的字符
                    string s1 = i.Trim(c);

                    try
                    {
                        _rs = new SD.Data.RepositoryBase();
                        _rs.BeginTrans();

                        //根据前台传来的成品编码对应着成品信息表中的成品条形码查询出自动编号 通过成品的自动编号与库位号的自动编号关联起来
                        //var v = _rs.IQueryable<db_models.cpxxb_4>(x => x.ph == s1).Select(s => new { s.zdbh }).First();
                        var v = _rs.FindEntity<db_models.cpxxb_4>(x => x.ph == s1);
                        _rs.Insert<db_models.cpckb>(new db_models.cpckb() { cpxxbh = Convert.ToInt32(v.zdbh), czrbm = 0, ckfsm = 1, ckrq = DateTime.Now, xsddbh = 0, bz = "" });
                        var _v1 = _rs.FindEntity<db_models.cpkwb>(x => x.cpbh == v.zdbh);
                        if (_v1 != null) {
                            _rs.Delete<db_models.cpkwb>(_v1);
                        }
                        //_rs.Delete<db_models.cpxxb_4>(v);
                        _rs.Commit();
                        list.Add(new ObjectToJson() { back_success = s1 });

                    }
                    catch (Exception ex)
                    {
                        list.Add(new ObjectToJson() { back_error = s1 });

                    }

                }

                string _json = JsonConvert.SerializeObject(list);

                return Json(_json, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 根据订单头出库
        /// </summary>
        /// <returns></returns>
        public ActionResult CP_ck_dd() {

            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
            ViewBag.user = user;

            return View();
        }

        /// <summary>
        /// 根据订单头查询订单信息
        /// </summary>
        /// <param name="dd"></param>
        /// <returns></returns>
        public ActionResult select_dd(string dd) {

            string _dd = dd;
            try {

                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                var v = Convert.ToInt32(_dd);
                var dingdan = _rs.FindEntity<db_models.dingdan_t_zt>(x => x.ddtbm == v && x.ddzt>=db_models.db_enum.enum_ddzt.完成配货记录);
                //var zt = dingdan.ddzt;

                //if (zt.ToString().Equals("完成配货记录")) {
                if(dingdan!=null)
                { 
                    DbRawSqlQuery<Select_CP_xx> list = _rs.IQueryable<Select_CP_xx>(@"select 
                                                                    批号 as ph, 
		                                                            规格 as gg,
                                                                    钢号 as gh,
                                                                    组别 as zb,
                                                                    客户代码 as khdm,
                                                                    卷号 as jh,
                                                                    ISNULL(库位编号,0) as kw_old 
		                                                            from [BK_MES].[dbo].[成品信息表_4]  C 
		                                                            inner join (
		                                                            select 成品库存编号  from [BK_MES].[dbo].[成品库存锁定表] A 
		                                                            inner join (select 自动编号 from [BK_MES].[dbo].[订货明细表] where 订货头编号='1011') B 
		                                                            on  A.销售订单编号 = B.自动编号) D on C.自动编号= D.成品库存编号 
		                                                            left join (select 库位编号,成品编号 from [BK_MES].[dbo].[成品库位表]) E on E.成品编号=D.成品库存编号");

                    string _json = JsonConvert.SerializeObject(list);
                    return Json(_json,JsonRequestBehavior.AllowGet);

                }

                return Json(0, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex) {
                return Json(1,JsonRequestBehavior.AllowGet);
            }

        }
    }
}