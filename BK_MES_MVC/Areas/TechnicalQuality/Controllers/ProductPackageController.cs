using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BK_MES_MVC.Areas.TechnicalQuality.Controllers
{
    public class ProductPackageController : Controller
    {
        // GET: TechnicalQuality/ProductPackage

        #region(成品包装)
        //等级代码界面
        public ActionResult Index()
        {
            return View();
        }

        //模态框
        public ActionResult Modal_cpbz(int? zdbh)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.cpbz entity = new db_models.cpbz();
            List<SelectListItem> list1 = new List<SelectListItem>();

            try
            {
                if (zdbh != null)
                {
                    entity = _rs.FindEntity<db_models.cpbz>(x => x.zdbh == zdbh);
                }

                List<db_models.machine_Table> _list1 = _rs.IQueryable<db_models.machine_Table>().ToList();
                foreach (db_models.machine_Table i in _list1)
                {
                    list1.Add(new SelectListItem { Text = i.sbmc, Value = i.zdbh.ToString() });
                }
            }
            catch (Exception ex)
            {

            }

            ViewBag.machine = list1;

            return View(entity);
        }

        //查
        public ActionResult Select_cpbz()
        {
            string str = "";

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                var v = _rs.IQueryable<Models.cpbz>(@"select 包装名称 as bzmc,A.自动编号 as zdbh,包装代码 as bzdm,B.设备名称 as sbmc,标准重量 as bzzl,
                                                        直径上限 as zjsx,直径下限 as zjxx,备注 as bz 
                                                        from 产品包装表 A inner join (select 自动编号,设备名称 from 机器设备表)B on A.设备编码=B.自动编号");
                str = JsonConvert.SerializeObject(v);
            }
            catch (Exception ex)
            {

            }
            return Content(str);
        }

        //增或改
        public ActionResult Insert_cpbz()
        {
            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            string zdbh = Request.Form["zdbh"];
            string bzdm = Request.Form["bzdm"];
            string bzmc = Request.Form["bzmc"];
            string sbbm = Request.Form["sbbm"];
            string zjsx = Request.Form["zjsx"];
            string zjxx = Request.Form["zjxx"];
            string bzzl = Request.Form["bzzl"];
            string bz = Request.Form["bz"];

            int _zdbh = Convert.ToInt32(zdbh);
            int _bzdm = Convert.ToInt32(bzdm);
            int _sbbm = Convert.ToInt32(sbbm);
            decimal _zjsx = Convert.ToDecimal(zjsx);
            decimal _zjxx = Convert.ToDecimal(zjxx);
            int _bzzl = Convert.ToInt32(bzzl);

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                if (_zdbh != 0)
                {
                    //修改
                    var v = _rs.FindEntity<db_models.cpbz>(x => x.zdbh == _zdbh);
                    v.bzmc = bzmc;
                    v.bzdm = _bzdm;
                    v.sbbm = _sbbm;
                    v.zjsx = _zjsx;
                    v.zjxx = _zjxx;
                    v.bzzl = _bzzl;
                    v.bz = bz;
                    v.update_people_bm = user.ToString();
                    v.update_time = DateTime.Now;
                    _rs.Update<db_models.cpbz>(v);
                }
                else
                {
                    _rs.Insert<db_models.cpbz>(new db_models.cpbz()
                    {
                        bzmc = bzmc,
                        bzdm = _bzdm,
                        sbbm = _sbbm,
                        zjsx = _zjsx,
                        zjxx = _zjxx,
                        bzzl = _bzzl,
                        bz = bz,
                        add_time = DateTime.Now,
                        add_people_bm = user.ToString()
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
        public ActionResult Delete_cpbz(int zdbh)
        {

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                _rs.Delete<db_models.cpbz>(x => x.zdbh == zdbh);
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

    }
}