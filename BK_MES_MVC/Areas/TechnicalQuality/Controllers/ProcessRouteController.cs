using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BK_MES_MVC.Areas.TechnicalQuality.Controllers
{
    public class ProcessRouteController : Controller
    {
        // GET: TechnicalQuality/ProcessRoute
        public ActionResult Index()
        {
            return View();
        }

        #region(酸洗程序)
        //首页
        public ActionResult sxcx()
        {
            return View();
        }

        //模态框
        public ActionResult Modal_sxcx(int? zdbh)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.sxcxb sxcx = new db_models.sxcxb();

            try
            {
                if (zdbh != null)
                {
                    sxcx = _rs.FindEntity<db_models.sxcxb>(x => x.zdbh == zdbh);
                }
            }
            catch (Exception ex)
            {
                
            }
            return View(sxcx);
        }

        //查
        public ActionResult Select_sxcx()
        {
            string str = "";

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                var v = _rs.IQueryable<db_models.sxcxb>();
                str = JsonConvert.SerializeObject(v);
            }
            catch (Exception ex)
            {

            }
            return Content(str);
        }

        //增或改
        public ActionResult Insert_sxcx()
        {
            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            string zdbh = Request.Form["zdbh"];
            string sxcxh = Request.Form["sxcxh"];
            string sxsj = Request.Form["sxsj"];

            int _zdbh = Convert.ToInt32(zdbh);
            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                if (_zdbh != 0)
                {
                    //修改
                    var v = _rs.FindEntity<db_models.sxcxb>(x => x.zdbh == _zdbh);
                    v.sxcxh = sxcxh;
                    v.sxsj = sxsj;
                    v.update_people_bm = user.ToString();
                    v.update_time = DateTime.Now;
                    _rs.Update<db_models.sxcxb>(v);
                }
                else
                {
                    _rs.Insert<db_models.sxcxb>(new db_models.sxcxb()
                    {
                        sxcxh = sxcxh,
                        sxsj = sxsj,
                        add_people_bm = user.ToString(),
                        add_time = DateTime.Now
                    });
                }
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                msg = ex.ToString();
            }
            return Json(new { Result = isSavedSuccessfully, Message = msg, Count = count }, JsonRequestBehavior.AllowGet);
        }

        //删
        public ActionResult Delete_sxcx(int zdbh)
        {
            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                _rs.Delete<db_models.sxcxb>(x => x.zdbh == zdbh);
                count += 1;
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                msg = ex.ToString();
            }
            return Json(new { Result = isSavedSuccessfully, Message = msg, Count = count }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region(热处理)
        public ActionResult rcl() {

            return View();
        }

        //模态框
        public ActionResult Modal_rcl(int? zdbh)
        {

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.rclb rcl = new db_models.rclb();

            try
            {
                if (zdbh != null)
                {
                    rcl = _rs.FindEntity<db_models.rclb>(x => x.zdbh == zdbh);
                }
            }
            catch (Exception ex)
            {
            }
            return View(rcl);
        }

        //查
        public ActionResult Select_rcl()
        {

            string str = "";

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                var v = _rs.IQueryable<db_models.rclb>();
                str = JsonConvert.SerializeObject(v);
            }
            catch (Exception ex)
            {

            }
            return Content(str);
        }

        //增或改
        public ActionResult Insert_rcl()
        {
            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            string zdbh = Request.Form["zdbh"];
            string sbmc = Request.Form["sbmc"];
            string bz = Request.Form["bz"];

            int _zdbh = Convert.ToInt32(zdbh);
            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                if (_zdbh != 0)
                {
                    //修改
                    var v = _rs.FindEntity<db_models.rclb>(x => x.zdbh == _zdbh);
                    v.sbmc = sbmc;
                    v.bz = bz;
                    v.update_people_bm = user.ToString();
                    v.update_time = DateTime.Now;
                    _rs.Update<db_models.rclb>(v);
                }
                else
                {
                    _rs.Insert<db_models.rclb>(new db_models.rclb()
                    {
                        sbmc = sbmc,
                        bz = bz,
                        add_people_bm = user.ToString(),
                        add_time = DateTime.Now
                    });
                }
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                msg = ex.ToString();
            }
            return Json(new { Result = isSavedSuccessfully, Message = msg, Count = count }, JsonRequestBehavior.AllowGet);
        }

        //删
        public ActionResult Delete_rcl(int zdbh)
        {
            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                _rs.Delete<db_models.rclb>(x => x.zdbh == zdbh);
                count += 1;
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                msg = ex.ToString();
            }
            return Json(new { Result = isSavedSuccessfully, Message = msg, Count = count }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region(拉拔)
        public ActionResult lb() {

            return View();
        }

        //模态框
        public ActionResult Modal_lb(int? zdbh)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.machine_Table machine = new db_models.machine_Table();

            try
            {
                if (zdbh != null)
                {
                    machine = _rs.FindEntity<db_models.machine_Table>(x => x.zdbh == zdbh);
                }
            }
            catch (Exception ex)
            {
            }
            return View(machine);
        }

        //查
        public ActionResult Select_lb()
        {

            string str = "";

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                var v = _rs.IQueryable<db_models.machine_Table>();
                str = JsonConvert.SerializeObject(v);
            }
            catch (Exception ex)
            {

            }
            return Content(str);
        }

        //增或改
        public ActionResult Insert_lb()
        {
            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            string zdbh = Request.Form["zdbh"];
            string sbmc = Request.Form["sbmc"];
            string jj_jt = Request.Form["jj_jt"];
            string jj_dls = Request.Form["jj_dls"];
            string sl_jt = Request.Form["sl_jt"];
            string sl_dls = Request.Form["sl_dls"];
            string sxsd_jj = Request.Form["sxsd_jj"];
            string sxsd_dls = Request.Form["sxsd_dls"];
            string cpgg = Request.Form["cpgg"];
            string jtlb = Request.Form["jtlb"];
            string bz = Request.Form["bz"];
            string scs = Request.Form["scs"];
            string azwz = Request.Form["azwz"];
            string gdzcbh = Request.Form["gdzcbh"];
            string sbbh = Request.Form["sbbh"];

            int _zdbh = Convert.ToInt32(zdbh);
            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                if (_zdbh != 0)
                {
                    //修改
                    var v = _rs.FindEntity<db_models.machine_Table>(x => x.zdbh == _zdbh);

                    _rs.Update<db_models.machine_Table>(v);
                }
                else
                {
                    int _gdzcbh;
                    if (!Int32.TryParse(gdzcbh, out _gdzcbh))
                    { _gdzcbh = 0; }

                    _rs.Insert<db_models.machine_Table>(new db_models.machine_Table()
                    {

                    });
                }
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                msg = ex.ToString();
            }
            return Json(new { Result = isSavedSuccessfully, Message = msg, Count = count }, JsonRequestBehavior.AllowGet);
        }

        //删
        public ActionResult Delete_lb(int zdbh)
        {
            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                _rs.Delete<db_models.machine_Table>(x => x.zdbh == zdbh);
                count += 1;
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                msg = ex.ToString();
            }
            return Json(new { Result = isSavedSuccessfully, Message = msg, Count = count }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region(模链)
        public ActionResult ml() {

            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                List<Models.machine_class> machine = _rs.FindList<Models.machine_class>(@"select 设备名称 as sbmc,自动编号 as zdbh from 机器设备表 A 
                                                                inner join (select distinct 设备编号 from 模序表) B on A.自动编号=B.设备编号").ToList();
                foreach (Models.machine_class i in machine) {

                    list.Add(new SelectListItem() { Text = i.sbmc, Value = i.zdbh.ToString() });
                }

            } catch (Exception ex) {

            }
            ViewBag.machine = list;
            return View();
        }

        //模态框
        public ActionResult Modal_ml(int? sbbh,int? mlbh)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            List<SelectListItem> list = new List<SelectListItem>();
            Models.mx mx = new Models.mx();
            string ml = "";

            try
            {
                if (sbbh != null && mlbh != null)
                {
                    List<Models.mx> list_mx = _rs.IQueryable<Models.mx>(@"select 进线直径 as jxzj,出线直径 as cxzj,模序参数 as mxcs from 模序表 where 设备编号=" + sbbh + " and 模链=" + mlbh + "").ToList();

                    foreach (Models.mx i in list_mx) {

                        ml += (i.mxcs + "--");
                    }

                    //给前台模态框赋值
                    mx.ml = ml;
                    mx.jxzj = Convert.ToDecimal(list_mx.First().jxzj);
                    mx.cxzj = Convert.ToDecimal(list_mx.First().cxzj);
                    mx.mlbh = Convert.ToInt32(mlbh);
                    mx.lbsb = Convert.ToInt32(sbbh);
                }

                List<db_models.machine_Table> machine = _rs.IQueryable<db_models.machine_Table>().ToList();
                foreach (db_models.machine_Table i in machine) {

                    list.Add(new SelectListItem() { Text = i.sbmc, Value = i.zdbh.ToString() });
                }
                
            }
            catch (Exception ex)
            {

            }
            ViewBag.machine = list;
            return View(mx);
        }

        //前端动态列
        public ActionResult DynamicColumn(int? sbbh) {

            string str = "";
            int temp = 0;

            try
            {
                if (sbbh != null)
                {
                    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                    List<Models.mx_count> mx_Counts = _rs.FindList<Models.mx_count>(@"select count(1) as total from 模序表 where 设备编号=" + sbbh + " group by 模链");
                    
                    foreach (Models.mx_count i in mx_Counts) {

                        int c = Convert.ToInt32(i.total);
                        temp = c > temp ? c : temp;
                    }

                    List<string> list = new List<string>();
                    //list.Add("sbbh");
                    //list.Add("进线直径");
                    //list.Add("出线直径");
                    for (int i = 1; i <= temp; i++) {
                        list.Add("第" + i + "道");
                    }
                  
                    str = JsonConvert.SerializeObject(list);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
            return Json(str, JsonRequestBehavior.AllowGet);
        }


        //查
        public ActionResult Select_ml(int? sbbh)
        {
            string str = "";
            string serial = "";

            try
            {
                if (sbbh != null)
                {
                    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                    List<Models.mx_count> mx_Counts = _rs.FindList<Models.mx_count>(@"select count(1) as total from 模序表 where 设备编号=" + sbbh + " group by 模链");
                    int temp = 0;
                    foreach (Models.mx_count i in mx_Counts)
                    {

                        int c = Convert.ToInt32(i.total);
                        temp = c > temp ? c : temp;
                    }

                    for (int i = 1; i <= temp; i++) {
                        if (i == temp)
                        {
                            serial += "[" + i + "]";
                        }
                        else {
                            serial += "[" + i + "],";
                        }
                    }
                    //进线直径,出线直径,[1] as 第1道,[2] as 第2道,[3] as 第3道,[4] as 第4道,[5] as 第5道,[6] as 第6道,[7] as 第7道,[8] as 第8道,[9] as 第9道
                    DataSet ds = _rs.GetDataSet(@"select * from (select 设备编号,进线直径,出线直径,模链,模序,模序参数 from [模序表]) 
                                                as ord pivot(max(模序参数) for 模序 in(" + serial + "))as p left join (select 设备名称,自动编号 from 机器设备表)A on A.自动编号=设备编号 where 设备编号=" + sbbh + " order by 模链");

                    str = JsonConvert.SerializeObject(ds.Tables[0]);
                    
                }
                else {

                }
            }
            catch (Exception ex)
            {

            }
            return Content(str);
        }

        //增或改
        public ActionResult Insert_ml()
        {
            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            string mlbh = Request.Form["mlbh"];
            //拉拔设备的自动编号
            string lbsb = Request.Form["lbsb"];
            string jxzj = Request.Form["jxzj"];
            string cxzj = Request.Form["cxzj"];
            string ml = Request.Form["ml"];

            int _mlbh = Convert.ToInt32(mlbh);
            decimal _jxzj = Convert.ToDecimal(jxzj);
            decimal _cxzj = Convert.ToDecimal(cxzj);
            int _lbsb = Convert.ToInt32(lbsb);

            List<db_models.mxb> insert_mxb = new List<db_models.mxb>();

            try
            {
                string[] str = ml.Split(new string[] { "--" }, StringSplitOptions.RemoveEmptyEntries);

                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                if (_mlbh != 0)
                {
                    //修改

                    //List<Models.mx> mb = _rs.IQueryable<Models.mx>(@"select 自动编号 as zdbh from 模序表 where 设备编号=" + lbsb + " and 模链=" + mlbh + "").ToList();
                    //int j = 0;
                    //foreach (Models.mx i in mb) {
                    //    j++;
                    //    var eneity = _rs.FindEntity<db_models.mxb>(x => x.zdbh == i.zdbh);
                    //    eneity.mxcs = Convert.ToDecimal(str[j]);
                    //}

                    //for (int i = 0; i < mb.Count(); i++) {

                    //    int mx_zdbh = mb[i].zdbh;
                    //    var eneity = _rs.FindEntity<db_models.mxb>(x => x.zdbh == mx_zdbh);
                    //    if (i > str.Length) {

                    //        eneity.mxcs = Convert.ToDecimal(str[i]);
                    //    }
                    //}
                    
                    List<db_models.mxb> mxb = _rs.IQueryable<db_models.mxb>(x => x.sbbh == _lbsb && x.ml == _mlbh).ToList();
                    db_models.lbgxb lbgxbs = _rs.FindEntity<db_models.lbgxb>(x => x.sbbh == _lbsb && x.mlxh == _mlbh);
                    lbgxbs.ml = ml;
                    lbgxbs.mlxh = _mlbh;
                    List<db_models.mxb> delete_mxb = new List<db_models.mxb>();
                    
                    //重新实例化一遍，因为之前做过查询操作  具体原因不详
                    _rs = new SD.Data.RepositoryBase();
                    _rs.BeginTrans();

                    foreach (db_models.mxb i in mxb) {

                        delete_mxb.Add(new db_models.mxb { zdbh = i.zdbh });
                    }
                    //先删除(拉拔工序表需与模序表保持一致)
                    _rs.Delete<db_models.mxb>(delete_mxb);
                    //更新拉拔工序表的信息
                    _rs.Update<db_models.lbgxb>(lbgxbs);

                    for (int i = 0; i < str.Length; i++) {

                        insert_mxb.Add(new db_models.mxb { sbbh = _lbsb, mxcs = Convert.ToDecimal(str[i]), mx = i + 1, ml = _mlbh, jxzj = _jxzj, cxzj = _cxzj });
                    }
                    //再插入  算做更新
                    _rs.Insert<db_models.mxb>(insert_mxb);
                    _rs.Commit();
                }
                else
                {
                    //模链编号
                    int N_ml = 0;
                    //int j = 0;

                    try
                    {
                        List<Models.mx_add> list = _rs.IQueryable<Models.mx_add>(@"select distinct 模链 as Num_ml from 模序表 where 设备编号=" + _lbsb + " group by 模链").ToList<Models.mx_add>();
                        N_ml = list.Last().Num_ml;
                    }
                    catch (Exception ex)
                    {
                        N_ml = 0;
                    }

                    //新模链序号
                    N_ml += 1;

                    for (int i = 0; i < str.Length; i++)
                    {
                        insert_mxb.Add(new db_models.mxb { sbbh = _lbsb, mxcs = Convert.ToDecimal(str[i]), mx = i + 1, ml = N_ml, jxzj = _jxzj, cxzj = _cxzj });
                    }

                    _rs.BeginTrans();
                    //模序表和拉拔工序表需保持一致操作
                    //批量插入
                    _rs.Insert<db_models.mxb>(insert_mxb);
                    _rs.Insert<db_models.lbgxb>(new db_models.lbgxb()
                    {
                        sbbh = _lbsb,
                        mlxh = N_ml,
                        ml = ml
                    });
                    _rs.Commit();

                    //_rs.BeginTrans();
                    //foreach (string s in str) {
                        
                    //    decimal mxcs = Convert.ToDecimal(s);
                    //    j += 1;
                    //    _rs.Insert<db_models.mxb>(new db_models.mxb()
                    //    {
                    //        sbbh = _lbsb,
                    //        mxcs = mxcs,
                    //        mx = j,
                    //        ml = i,
                    //        jxzj = _jxzj,
                    //        cxzj = _cxzj
                    //    });
                    //}
                    //_rs.Commit();
                }
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                msg = ex.ToString();
            }
            return Json(new { Result = isSavedSuccessfully, Message = msg, Count = count }, JsonRequestBehavior.AllowGet);
        }

        //删
        public ActionResult Delete_ml(int sbbh,int mlbh)
        {
            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                // List<Models.mx> mb = _rs.IQueryable<Models.mx>(@"select 自动编号 as zdbh from 模序表 where 设备编号=" + sbbh + " and 模链=" + mlbh + "").ToList();

                //_rs.BeginTrans();
                //foreach (Models.mx i in mb) {

                //    _rs.Delete<db_models.mxb>(x => x.zdbh == i.zdbh);
                //    count += 1;
                //}
                //_rs.Commit();

                List<db_models.mxb> mxb = _rs.IQueryable<db_models.mxb>(x => x.sbbh == sbbh && x.ml == mlbh).ToList();
                db_models.lbgxb lbgxbs = _rs.FindEntity<db_models.lbgxb>(x => x.sbbh == sbbh && x.mlxh == mlbh);

                List<db_models.mxb> delete_mxb = new List<db_models.mxb>();

                _rs = new SD.Data.RepositoryBase();
                foreach (db_models.mxb i in mxb) {

                    delete_mxb.Add(new db_models.mxb { zdbh = i.zdbh });
                }

                _rs.BeginTrans();
                //模序表和拉拔工序表需保持一致
                //批量删除
                _rs.Delete<db_models.mxb>(delete_mxb);
                _rs.Delete<db_models.lbgxb>(new db_models.lbgxb { zdbh = lbgxbs.zdbh });
                _rs.Commit();
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                msg = ex.ToString();
            }
            return Json(new { Result = isSavedSuccessfully, Message = msg, Count = count }, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}