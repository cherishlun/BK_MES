using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BK_MES_MVC.Areas.TechnicalQuality.Controllers
{
    public class MachineManageController : Controller
    {
        // GET: TechnicalQuality/MachineManage

        #region(机器设备)
        //首页
        public ActionResult Index()
        {
            return View();
        }

        //模态框
        public ActionResult Modal_machine(int? zdbh)
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
        public ActionResult Select_machine()
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
        public ActionResult Insert_machine()
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
                    v.sbmc = sbmc;
                    v.jj_jt = jj_jt;
                    v.jj_dls = jj_dls;
                    v.sl_jt = sl_jt;
                    v.sl_dls = sl_dls;
                    v.sxsd_jj = Convert.ToInt32(sxsd_jj);
                    v.sxsd_dls = Convert.ToInt32(sxsd_dls);
                    v.cpgg = cpgg;
                    v.jtlb = jtlb;
                    v.bz = bz;
                    v.scs = scs;
                    v.azwz = azwz;
                    v.gdzcbh = Convert.ToInt32(gdzcbh);
                    v.sbbh = sbbh;
                    v.update_people_bm = user.ToString();
                    v.update_time = DateTime.Now;
                    _rs.Update<db_models.machine_Table>(v);
                }
                else
                {
                    int _gdzcbh ;
                    if(!Int32.TryParse(gdzcbh, out _gdzcbh))
                    { _gdzcbh = 0; }

                    _rs.Insert<db_models.machine_Table>(new db_models.machine_Table()
                    {
                        sbmc = sbmc,
                        jj_jt = jj_jt,
                        jj_dls = jj_dls,
                        sl_jt = sl_jt,
                        sl_dls = sl_dls,
                        sxsd_jj = Convert.ToInt32(sxsd_jj),
                        sxsd_dls = Convert.ToInt32(sxsd_dls),
                        cpgg = cpgg,
                        jtlb = jtlb,
                        bz = bz,
                        scs = scs,
                        azwz = azwz,
                        gdzcbh = _gdzcbh,
                        sbbh = sbbh,
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
        public ActionResult Delete_machine(int zdbh)
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



    }
}