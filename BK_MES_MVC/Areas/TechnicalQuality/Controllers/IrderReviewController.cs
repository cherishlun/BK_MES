using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace BK_MES_MVC.Areas.TechnicalQuality.Controllers
{
    public class IrderReviewController : Controller
    {
        // GET: TechnicalQuality/IrderReview

        public ActionResult Index()
        {
            return View();
        }

        #region(审核)
        //审核界面
        public ActionResult IrderReview()
        {

            return View();
        }

        //查询等待审核
        public ActionResult selectWaitForReview()
        {
            string str = "";

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                List<Models.Review_class> list = _rs.IQueryable<Models.Review_class>(@"select 自动编号 as zdbh,备注 as bzhu,标准 as bz,规格 as gg,强度要求 as qdyq,钢号 as gh,品种 as pz,组别 as zb,B.客户名称 as khmc 
                                                                                    from 客户特殊要求表 A inner join (
                                                                                    select 客户编码,客户名称 from 客户基础信息表)B 
                                                                                    on A.客户编码=B.客户编码 where 审核标志=0").ToList();
                str = JsonConvert.SerializeObject(list);
            }
            catch (Exception ex)
            {

            }
            return Content(str);
        }

        ////等级代码验证
        //public ActionResult check_djdm() {


        //}

        //审核通过
        public ActionResult ReviewPass()
        {
            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;
            int _zdbh = 0;
            db_models.khtsyqb v = new db_models.khtsyqb(); 

            string zdbh = Request.Form["zdbh"];
            string djdm = Request.Form["djdm"];
            string cllx = Request.Form["cllx"];
            string cpgg = Request.Form["cpgg"];
            string khmc = Request.Form["khmc"];


            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                if (string.IsNullOrEmpty(zdbh))
                {
                    try
                    {
                        var djdmb = _rs.FindEntity<db_models.djdmb>(x => x.djdm == djdm);
                        string _cpdm = djdm + cllx + cpgg + khmc;

                        _rs.Insert<db_models._cpxxb>(new db_models._cpxxb { cpdm = _cpdm, cpgg = cpgg, djdmbh = djdmb.zdbh, add_people_bm = user.ToString(), add_time = DateTime.Now });
                    }
                    catch (Exception ex)
                    {
                        string s = ex.ToString();
                        isSavedSuccessfully = false;
                        msg = "该等级代码不存在，请重新输入";
                    }
                }
                else {

                    _zdbh = Convert.ToInt32(zdbh);

                    v = _rs.FindEntity<db_models.khtsyqb>(x => x.zdbh == _zdbh);
                    v.shbz = 1;
                    try
                    {
                        var djdmb = _rs.FindEntity<db_models.djdmb>(x => x.djdm == djdm);
                        string _cpdm = djdm + cllx + cpgg + khmc;

                        _rs = new SD.Data.RepositoryBase();
                        _rs.BeginTrans();
                        _rs.Update<db_models.khtsyqb>(v);
                        _rs.Insert<db_models._cpxxb>(new db_models._cpxxb {cpdm=_cpdm,cpgg=cpgg,khtsyqbh=_zdbh,djdmbh=djdmb.zdbh,add_people_bm=user.ToString(),add_time=DateTime.Now});
                        _rs.Commit();
                    }
                    catch (Exception ex) {
                        isSavedSuccessfully = false;
                        msg = "该等级代码不存在，请重新输入";
                    }
                }
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                msg = ex.ToString();
            }
            return Json(new { Result = isSavedSuccessfully, Message = msg, Count = count }, JsonRequestBehavior.AllowGet);
        }

        //审核拒绝
        public ActionResult RefuseReview(int zdbh)
        {
            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                var v = _rs.FindEntity<db_models.khtsyqb>(x => x.zdbh == zdbh);
                v.shbz = 2;
                _rs.Update<db_models.khtsyqb>(v);
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                msg = ex.ToString();
            }
            return Json(new { Result = isSavedSuccessfully, Message = msg, Count = count }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region(路线制定)
        public ActionResult RoutePlan() {

            List<SelectListItem> customReview = new List<SelectListItem>();
            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                //List<Models.Review_class> list = _rs.IQueryable<Models.Review_class>(@"select B.客户名称 as khmc,自动编号 as zdbh 
                //                                                                    from 客户特殊要求表 A inner join (
                //                                                                    select 客户编码,客户名称 from 客户基础信息表)B 
                //                                                                    on A.客户编码=B.客户编码 where 审核标志=0").ToList();
                //foreach (Models.Review_class i in list) {

                //    customReview.Add(new SelectListItem { Text = i.khmc, Value = i.zdbh.ToString() });
                //}

                //只显示已审核但未制定工艺路线的成品代码
                List<Models.cpxx> cpxx = _rs.IQueryable<Models.cpxx>(@"select 产品编码 as cpdm,自动编号 as zdbh  from 产品信息表").ToList();
                foreach (Models.cpxx i in cpxx) {
                    customReview.Add(new SelectListItem { Text = i.cpdm, Value = i.zdbh.ToString() });
                }

            } catch (Exception ex) { }

            ViewBag.custom = customReview;
            return View();
        }
        

        #endregion

        #region(酸洗制定)

        //模态框
        public ActionResult Modal_Enact_sx(string sxh, int col)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            db_models.sxcxb sxcxb = new db_models.sxcxb();
            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                if (!string.IsNullOrEmpty(sxh)) {
                    string s = sxh + "#";
                    var v = _rs.FindEntity<db_models.sxcxb>(x => x.sxcxh == s);
                    sxcxb.zdbh = v.zdbh;
                }
                List<db_models.sxcxb> sx = _rs.IQueryable<db_models.sxcxb>().ToList();
                foreach (db_models.sxcxb i in sx) {

                    list.Add(new SelectListItem { Text = i.sxcxh, Value = i.zdbh.ToString() });
                }

            } catch (Exception ex) {

            }
            ViewBag.sxcx = list;
            ViewBag.column = col;

            return View(sxcxb);
        }

        //临时保存
        public ActionResult TemporarySave() {

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            try
            {

            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                msg = ex.ToString();
            }
            return Json(new { Result = isSavedSuccessfully, Message = msg, Count = count }, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region(热处理制定)
        //模态框
        public ActionResult Modal_Enact_rcl(string rcl,int col)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            db_models.rclb rclb = new db_models.rclb();
            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                if (!string.IsNullOrEmpty(rcl))
                {
                    var v = _rs.FindEntity<db_models.rclb>(x => x.sbmc == rcl);
                    rclb.zdbh = v.zdbh;
                }
                List<db_models.rclb> rc = _rs.IQueryable<db_models.rclb>().ToList();
                foreach (db_models.rclb i in rc)
                {

                    list.Add(new SelectListItem { Text = i.sbmc, Value = i.zdbh.ToString() });
                }

            }
            catch (Exception ex)
            {

            }
            ViewBag.rclb = list;
            ViewBag.hot = col;

            return View(rclb);
        }
        #endregion

        #region(拉拔制定)
        //模态框
        public ActionResult Modal_Enact_lb(int? machine, int? mlbh, int col)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            List<SelectListItem> list = new List<SelectListItem>();
            Models.mx mx = new Models.mx();
            string ml = "";

            try
            {
                if (machine != null && mlbh != null)
                {
                    List<Models.mx> list_mx = _rs.IQueryable<Models.mx>(@"select 进线直径 as jxzj,出线直径 as cxzj,模序参数 as mxcs from 模序表 where 设备编号=" + machine + " and 模链=" + mlbh + "").ToList();

                    foreach (Models.mx i in list_mx)
                    {
                        ml += (i.mxcs + "--");
                    }

                    //给前台模态框赋值
                    mx.ml = ml;
                    mx.jxzj = Convert.ToDecimal(list_mx.First().jxzj);
                    mx.cxzj = Convert.ToDecimal(list_mx.First().cxzj);
                    mx.mlbh = Convert.ToInt32(mlbh);
                    mx.lbsb = Convert.ToInt32(machine);
                }

                List<Models.machine_class> _machine = _rs.FindList<Models.machine_class>(@"select 设备名称 as sbmc,自动编号 as zdbh from 机器设备表 A 
                                                                inner join (select distinct 设备编号 from 模序表) B on A.自动编号=B.设备编号").ToList();
                foreach (Models.machine_class i in _machine)
                {
                    list.Add(new SelectListItem() { Text = i.sbmc, Value = i.zdbh.ToString() });
                }
            }
            catch (Exception ex)
            {
            }
            ViewBag.machine = list;
            ViewBag.lb_col = col;
            return View(mx);
        }
        #endregion

        #region(开坯制定)
        //模态框
        public ActionResult Modal_Enact_kp(int? machine, int? mlbh, int col)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            List<SelectListItem> list = new List<SelectListItem>();
            Models.mx mx = new Models.mx();
            string ml = "";

            try
            {
                if (machine != null && mlbh != null)
                {
                    List<Models.mx> list_mx = _rs.IQueryable<Models.mx>(@"select 进线直径 as jxzj,出线直径 as cxzj,模序参数 as mxcs from 模序表 where 设备编号=" + machine + " and 模链=" + mlbh + "").ToList();

                    foreach (Models.mx i in list_mx)
                    {
                        ml += (i.mxcs + "--");
                    }

                    //给前台模态框赋值
                    mx.ml = ml;
                    mx.jxzj = Convert.ToDecimal(list_mx.First().jxzj);
                    mx.cxzj = Convert.ToDecimal(list_mx.First().cxzj);
                    mx.mlbh = Convert.ToInt32(mlbh);
                    mx.lbsb = Convert.ToInt32(machine);
                }

                List<Models.machine_class> _machine = _rs.FindList<Models.machine_class>(@"select 设备名称 as sbmc,自动编号 as zdbh from 机器设备表 A 
                                                                inner join (select distinct 设备编号 from 模序表) B on A.自动编号=B.设备编号").ToList();
                foreach (Models.machine_class i in _machine)
                {
                    list.Add(new SelectListItem() { Text = i.sbmc, Value = i.zdbh.ToString() });
                }
            }
            catch (Exception ex)
            {
            }
            ViewBag.machine = list;
            ViewBag.kp_col = col;
            return View(mx);
        }

        #endregion

        #region(Common)
        //查询模链
        public ActionResult select_ml(int sbbh, decimal jxzj, decimal cxzj)
        {
            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;
            int mlbh = 0;

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            List<SelectListItem> list = new List<SelectListItem>();
            string ml = "";

            try
            {
                if (sbbh != 0 && jxzj != 0 && cxzj != 0)
                {
                    List<Models.mx> list_mx = _rs.IQueryable<Models.mx>(@"select 模链 as mlbh,模序参数 as mxcs from 模序表 where 设备编号=" + sbbh + " and 进线直径=" + jxzj + " and 出线直径=" + cxzj + "").ToList();

                    foreach (Models.mx i in list_mx)
                    {
                        ml += (i.mxcs + "--");
                    }

                    mlbh = list_mx.First().mlbh;
                }
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                msg = ex.ToString();
            }
            return Json(new { Result = isSavedSuccessfully, Message = msg, Ml = ml, Mlbh = mlbh, Count = count }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region(路线保存)
        [HttpPost]
        public ActionResult RouteSave(int cpdm, Models.JSON_ProcessRoute[] Arr_data) {

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;
            int step = 0;

            List<db_models.gylxb> gylxbs = new List<db_models.gylxb>();

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            try
            {
                foreach (Models.JSON_ProcessRoute obj in Arr_data)
                {
                    step += 1;

                    if (obj.Process.Equals("开坯") || obj.Process.Equals("拉拔"))
                    {
                        //int sbbh = Convert.ToInt32(obj.a);
                        //int mlbh = Convert.ToInt32(obj.b);
                        db_models.lbgxb lbgxb = _rs.FindEntity<db_models.lbgxb>(x => x.sbbh == obj.a && x.mlxh == obj.b);
                        gylxbs.Add(new db_models.gylxb { gymc = obj.Process, sx = step, gydybh = lbgxb.zdbh, cpzdbh = cpdm });
                    }
                    else
                    {
                        gylxbs.Add(new db_models.gylxb { gymc = obj.Process, sx = step, gydybh = obj.a, cpzdbh = cpdm });
                    }
                }
                //根据产品代码在工艺路线表中查询 以便判断是更新还是新增
                //List<db_models.gylxb> Entity = _rs.IQueryable<db_models.gylxb>(x => x.cpzdbh == cpdm).ToList();
                var Entity = _rs.FindEntity<db_models.gylxb>(x => x.cpzdbh == cpdm);
                if (Entity == null)
                {
                    _rs.Insert<db_models.gylxb>(gylxbs);
                }
                else {
                    _rs.BeginTrans();
                    _rs.Delete<db_models.gylxb>(x => x.cpzdbh == cpdm);
                    _rs.Insert<db_models.gylxb>(gylxbs);
                    _rs.Commit();
                }


            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                msg = ex.ToString();
            }
            return Json(new { Result = isSavedSuccessfully, Message = msg, Count = count }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region(查询产品信息与工艺路线)
        /// <summary>
        /// 查看产品代码详细(产品名称、组别、钢号、规格、参考标准、抗拉强度、公差)
        /// </summary>
        /// <param name="cpdm"></param>
        /// <returns></returns>
        public ActionResult select_Prodcut(int cpdm)
        {
            string str = "";
            Models.PM_View pm = new Models.PM_View();
            db_models.ProductMessage_View pcm = new db_models.ProductMessage_View();
            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                pcm = _rs.FindEntity<db_models.ProductMessage_View>(x => x.zdbh == cpdm);
                pm.ckbz = pcm.ckbz;
                pm.cpgg = pcm.cpgg.ToString();
                pm.tsbzhuang = pcm.tsbzhuang;
                pm.tsdz = pcm.tsdz;
                pm.tsgc = pcm.tsgc;
                pm.tsqd = pcm.tsqd;
                pm.zb = pcm.zb;
                pm.klqd = pcm.klqd;
                pm.pz = pcm.cpmc;
                pm.gc = pcm.gc;
                pm.gh = pcm.gh;
                //PropertyInfo[] properties = pcm.GetType().GetProperties();
                //foreach (PropertyInfo p in properties) {
                //    string s = p.Name;

                //    object o = p.GetValue(pcm);
                //}

                str = JsonConvert.SerializeObject(pm);
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }

            return Content(str);
        }

        /// <summary>
        /// 查询产品的工艺路线
        /// </summary>
        /// <param name="cpdm"></param>
        /// <returns></returns>
        public ActionResult SelectProcessRoute(int cpdm) {

            bool isSavedSuccessfully = true;
            string msg = "";

            db_models.sxcxb sxcxb = new db_models.sxcxb();
            db_models.rclb rclb = new db_models.rclb();
            db_models.lbgxb lbgxb = new db_models.lbgxb();

            List<Models.ReadProcessRoute> model = new List<Models.ReadProcessRoute>();
            db_models.machine_Table machine = new db_models.machine_Table();

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                List<db_models.gylxb> gylxbs = _rs.IQueryable<db_models.gylxb>(x => x.cpzdbh == cpdm).ToList();
                foreach (db_models.gylxb obj in gylxbs) {

                    switch (obj.gymc) {

                        case "酸洗":
                            sxcxb = _rs.FindEntity<db_models.sxcxb>(x => x.zdbh == obj.gydybh);
                            model.Add(new Models.ReadProcessRoute { gymc = obj.gymc, gysb = sxcxb.sxcxh, gyzdbh = obj.gydybh });
                            break;
                        case "热处理":
                            rclb = _rs.FindEntity<db_models.rclb>(x => x.zdbh == obj.gydybh);
                            model.Add(new Models.ReadProcessRoute { gymc = obj.gymc, gysb = rclb.sbmc, gyzdbh = obj.gydybh });
                            break;
                        case "开坯":
                            lbgxb = _rs.FindEntity<db_models.lbgxb>(x => x.zdbh == obj.gydybh);
                            machine = _rs.FindEntity<db_models.machine_Table>(x => x.zdbh == lbgxb.sbbh);
                            model.Add(new Models.ReadProcessRoute { gymc = obj.gymc, gysb = machine.sbmc, gyzdbh = lbgxb.mlxh, ml = lbgxb.ml, machine_zdbh = lbgxb.sbbh });
                            break;
                        case "拉拔":
                            lbgxb = _rs.FindEntity<db_models.lbgxb>(x => x.zdbh == obj.gydybh);
                            machine = _rs.FindEntity<db_models.machine_Table>(x => x.zdbh == lbgxb.sbbh);
                            model.Add(new Models.ReadProcessRoute { gymc = obj.gymc, gysb = machine.sbmc, gyzdbh = lbgxb.mlxh, ml = lbgxb.ml, machine_zdbh = lbgxb.sbbh });
                            break;
                    }
                }

                msg = JsonConvert.SerializeObject(model);
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                msg = ex.ToString();
            }
            return Content(msg); 
        }
        
        #endregion


    }
}