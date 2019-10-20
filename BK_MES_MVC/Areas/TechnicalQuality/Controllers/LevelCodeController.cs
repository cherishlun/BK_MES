using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BK_MES_MVC.Areas.TechnicalQuality.Controllers
{
    public class LevelCodeController : Controller
    {
        // GET: TechnicalQuality/LevelCode


        #region(等级代码)
        //等级代码界面
        public ActionResult Index()
        {
            return View();
        }

        //模态框
        public ActionResult Modal_djdm(int? zdbh) {

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            Models.djdm_common entity = new Models.djdm_common();
            List<SelectListItem> list1 = new List<SelectListItem>();
            List<SelectListItem> list2 = new List<SelectListItem>();

            try
            {

                if (zdbh != null)
                {
                    var Class_djdm = _rs.FindEntity<db_models.djdmb>(x => x.zdbh == zdbh);
                
                    //前台产品名称下拉框默认值
                    int zdbh_cpmc = Class_djdm.cpmcbh;
                    var Class_cpmc = _rs.FindEntity<db_models.cpmcb>(x => x.zdbh == zdbh_cpmc);
                    entity.cpmcbh = Class_cpmc.zdbh;
                    List<db_models.cpmcb> _list1 = _rs.IQueryable<db_models.cpmcb>().ToList();
                    foreach (db_models.cpmcb i in _list1) {

                        list1.Add(new SelectListItem { Text = i.cpmc.ToString(), Value = i.zdbh.ToString() });
                    }

                    //前台组别下拉框默认值
                    int zdbh_zb = Class_djdm.zbbh;
                    var Class_zb = _rs.FindEntity<db_models.zbb>(x => x.zdbh == zdbh_zb);
                    entity.zbbh = Class_zb.zdbh;
                    List<db_models.zbb> _list2 = _rs.IQueryable<db_models.zbb>().ToList();
                    foreach (db_models.zbb i in _list2) {

                        list2.Add(new SelectListItem { Text = i.zb.ToString(), Value = i.zdbh.ToString() });
                    }

                    //前台产品质量标准下拉框默认值
                    //int zdbh_cpzlbz = Class_zb.ckbzbh;
                    //var Class_ckzlbz = _rs.FindEntity<db_models.cpzlbzb>(x=>x.zdbh==zdbh_cpzlbz);
                    //entity.ckbz = Class_ckzlbz.ckbz;
                    //List<SelectListItem> list3 = new List<SelectListItem>();
                    //List<db_models.cpzlbzb> _list3 = _rs.IQueryable<db_models.cpzlbzb>().ToList();
                    //foreach (db_models.cpzlbzb i in _list3) {

                    //    list3.Add(new SelectListItem { Text=i.ckbz.ToString(),Value=i.zdbh.ToString()});
                    //}
                    //ViewBag.cpzlbz = list3;

                    //其他默认值
                    entity.gh = Class_djdm.gh;
                    entity.djdm = Class_djdm.djdm;
                    entity.zdbh = Convert.ToInt32(zdbh);
                }
                else {

                    List<db_models.cpmcb> _list1 = _rs.IQueryable<db_models.cpmcb>().ToList();
                    foreach (db_models.cpmcb i in _list1)
                    {
                        list1.Add(new SelectListItem { Text = i.cpmc.ToString(), Value = i.zdbh.ToString() });
                    }

                    List<db_models.zbb> _list2 = _rs.IQueryable<db_models.zbb>().ToList();
                    foreach (db_models.zbb i in _list2)
                    {
                        list2.Add(new SelectListItem { Text = i.zb.ToString(), Value = i.zdbh.ToString() });
                    }

                }
            } catch (Exception ex) {

            }

            ViewBag.cpmcb = list1;
            ViewBag.zbb = list2;

            return View(entity);
        }

        //查
        public ActionResult Select_djdm() {

            string str = "";

            try {

                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                var v = _rs.IQueryable<Models.djdm_common>(@"select A.自动编号 as zdbh,产品名称 as cpmc,Product as cpmc_eng,钢号 as gh,组别 as zb,参考标准 as ckbz,等级代码 as djdm,加入人编码 as add_people,添加时间 as add_time from 等级代码表 A 
                                                                        inner join(select 产品名称,Product,自动编号 from 产品名称表) B on A.产品名称编号=B.自动编号 
																		inner join (select 组别,参考标准,C.自动编号 from 组别表 C 
                                                                        inner join (select 参考标准,自动编号 from 产品质量标准表) D on D.自动编号=C.参考标准编号) E 
                                                                        on E.自动编号=A.组别编号");
                str = JsonConvert.SerializeObject(v);

            } catch (Exception ex) {

            }
            return Content(str);
        }

        //增或改
        public ActionResult Insert_djdm()
        {
            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            string zdbh = Request.Form["zdbh"];
            string cpmcbh = Request.Form["cpmcbh"];
            string djdm = Request.Form["djdm"];
            string gh = Request.Form["gh"];
            string zbbh = Request.Form["zbbh"];

            int _zdbh = Convert.ToInt32(zdbh);
            try
            {
                if (_zdbh != 0)
                {
                    //修改
                    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                    var v = _rs.FindEntity<db_models.djdmb>(x=>x.zdbh==_zdbh);
                    v.cpmcbh = Convert.ToInt16(cpmcbh);
                    v.djdm = djdm;
                    v.gh = gh;
                    v.zbbh = Convert.ToInt16(zbbh);
                    v.update_people_bm = user.ToString();
                    v.update_time = DateTime.Now;
                    _rs.Update<db_models.djdmb>(v);
                }
                else {

                    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                    int _cpmcbh = Convert.ToInt32(cpmcbh);
                    int _zbbh = Convert.ToInt32(zbbh);
                    _rs.Insert<db_models.djdmb>(new db_models.djdmb() { djdm=djdm,cpmcbh=_cpmcbh,gh=gh,zbbh=_zbbh,add_time=DateTime.Now,add_people_bm=user.ToString()});
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
        public ActionResult Delete_djdm(int zdbh)
        {

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                _rs.Delete<db_models.djdmb>(x=>x.zdbh==zdbh);
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

        #region(组别)
        //组别界面
        public ActionResult zb()
        {
            return View();
        }

        //模态框
        public ActionResult Modal_zb(int? zdbh) {

            Models.zb_common zb = new Models.zb_common();
            List<SelectListItem> list = new List<SelectListItem>();

            try
            {

                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                if (zdbh != null)
                {
                    var zbb = _rs.FindEntity<db_models.zbb>(x => x.zdbh == zdbh);
                    var zlbz = _rs.FindEntity<db_models.cpzlbzb>(x => x.zdbh == zbb.ckbzbh);
                    zb.zb = zbb.zb;
                    zb.ckbzbh = zlbz.zdbh;
                    zb.zdbh = zbb.zdbh;
                    List<db_models.cpzlbzb> _list = _rs.IQueryable<db_models.cpzlbzb>().ToList();
                    foreach (db_models.cpzlbzb i in _list) {

                        list.Add(new SelectListItem() { Text = i.ckbz.ToString(), Value = i.zdbh.ToString() });
                    }
                }
                else {

                    List<db_models.cpzlbzb> _list = _rs.IQueryable<db_models.cpzlbzb>().ToList();
                    foreach (db_models.cpzlbzb i in _list)
                    {
                        list.Add(new SelectListItem() { Text = i.ckbz.ToString(), Value = i.zdbh.ToString() });
                    }
                }

            } catch (Exception ex) {

            }
            ViewBag.ckbz = list;

            return View(zb);
        }

        //查
        public ActionResult Select_zb() {

            string str = "";
            try {

                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                var v = _rs.IQueryable<Models.zb_common>(@"select A.自动编号 as zdbh,组别 as zb,B.参考标准 as ckbz from 组别表 A 
                                                            inner join (select 自动编号,参考标准 from 产品质量标准表)B on A.参考标准编号=B.自动编号");
                str = JsonConvert.SerializeObject(v);

            } catch (Exception ex) {

            }
            return Content(str);
        }

        //增或改
        public ActionResult Insert_zb()
        {
            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            string zdbh = Request.Form["zdbh"];
            string zb = Request.Form["zb"];
            string ckbzbh = Request.Form["ckbzbh"];

            int _zdbh = Convert.ToInt32(zdbh);
            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                if (_zdbh != 0)
                {
                    //修改
                    var v = _rs.FindEntity<db_models.zbb>(x => x.zdbh == _zdbh);
                    v.zb = zb;
                    v.ckbzbh = Convert.ToInt32(ckbzbh);
                    v.update_people_bm = user.ToString();
                    v.update_time = DateTime.Now;
                    _rs.Update<db_models.zbb>(v);
                }
                else {

                    //增添
                    _rs.Insert<db_models.zbb>(new db_models.zbb() { zb=zb,ckbzbh=Convert.ToInt32(ckbzbh),add_people_bm=user.ToString(),add_time=DateTime.Now});
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
        public ActionResult Delete_zb(int zdbh)
        {
            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                _rs.Delete<db_models.zbb>(x => x.zdbh == zdbh);
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                msg = ex.ToString();
            }
            return Json(new { Result = isSavedSuccessfully, Message = msg, Count = count }, JsonRequestBehavior.AllowGet);
        }
      
        #endregion

        #region(产品名称)
        //产品名称界面
        public ActionResult cpmc() {

            return View();
        }

        //模态框
        public ActionResult Modal_cpmc(int? zdbh) {

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.cpmcb cpmc = new db_models.cpmcb();

            try {

                if (zdbh!=null) {

                    cpmc=_rs.FindEntity<db_models.cpmcb>(x => x.zdbh == zdbh);
                      
                } else {

                }


            } catch (Exception ex) {

            }
            return View(cpmc);
        }

        //查看
        public ActionResult Select_cpmc() {

            string str = "";

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                var v = _rs.IQueryable<db_models.cpmcb>();
                str = JsonConvert.SerializeObject(v);
            }
            catch (Exception ex)
            {

            }
            return Content(str);
        }

        //增或改
        public ActionResult Insert_cpmc()
        {
            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            string zdbh = Request.Form["zdbh"];
            string cpmc = Request.Form["cpmc"];
            string cpmc_eng = Request.Form["cpmc_eng"];
            int _zdbh = Convert.ToInt32(zdbh);

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                if (_zdbh == 0) 
                {
                    _rs.Insert<db_models.cpmcb>(new db_models.cpmcb() { cpmc=cpmc,cpmc_eng=cpmc_eng,add_people_bm=user.ToString(),add_time=DateTime.Now});
                }
                else {

                    var v = _rs.FindEntity<db_models.cpmcb>(x => x.zdbh == _zdbh);
                    v.cpmc = cpmc;
                    v.cpmc_eng = cpmc_eng;
                    v.update_people_bm = user.ToString();
                    v.update_time = DateTime.Now;
                    _rs.Update<db_models.cpmcb>(v);
                }

                count += 1;
            }
            catch (Exception ex)
            {

                isSavedSuccessfully = false;
                msg = ex.ToString();
            }
            return Json(new { Result = isSavedSuccessfully, Message = msg, Count = count }, JsonRequestBehavior.AllowGet);
        }

        //删
        public ActionResult Delete_cpmc(int zdbh)
        {
            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                _rs.Delete<db_models.cpmcb>(x=>x.zdbh==zdbh);
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

        #region(质量标准)
        //质量标准界面
        public ActionResult zlbz() {

            return View();
        }

        //模态框
        public ActionResult Modal_zlbz(int? zdbh) {

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.cpzlbzb cpzlbz = new db_models.cpzlbzb();

            try {
                
                if (zdbh != null)
                {
                    cpzlbz = _rs.FindEntity<db_models.cpzlbzb>(x => x.zdbh == zdbh);
                }

            } catch (Exception ex) {

            }
            return View(cpzlbz);
        }

        //查
        public ActionResult Select_zlbz() {

            string str = "";
            try {

                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                var v = _rs.IQueryable<db_models.cpzlbzb>();
                str = JsonConvert.SerializeObject(v);

            } catch (Exception ex) {

            }

            return Content(str);
        }

        //增或改
        public ActionResult Insert_zlbz()
        {
            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;
            string fileName = "";
            string fileExtension = "";
            string filePath = "";
            string fileNewName = "";

            string zdbh = Request.Form["zdbh"];
            string ckbz = Request.Form["ckbz"];
           // string klqd = Request.Form["klqd"];
            //string nz = Request.Form["nz"];
            //string wq = Request.Form["wq"];
            HttpPostedFileBase file = Request.Files["file"];

            int _zdbh = Convert.ToInt32(zdbh);

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                string directoryPath = Server.MapPath("~/Content/photos");

                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
                

                if (_zdbh == 0) {

                    if (file != null && file.ContentLength > 0)
                    {
                        fileName = file.FileName;
                        fileExtension = Path.GetExtension(fileName);
                        fileNewName = Guid.NewGuid().ToString() + fileExtension;
                        filePath = Path.Combine(directoryPath, fileNewName);
                        file.SaveAs(filePath);
                    }
                    //_rs.Insert<db_models.cpzlbzb>(new db_models.cpzlbzb() { ckbz=ckbz,add_people_bm=user.ToString(),add_time=DateTime.Now,klqd=klqd,nz=nz,wq=wq,fileName=fileNewName,filePath=filePath});
                    _rs.Insert<db_models.cpzlbzb>(new db_models.cpzlbzb() { ckbz=ckbz,add_people_bm=user.ToString(),add_time=DateTime.Now,fileName=fileNewName,filePath=filePath});

                } else {

                    var v = _rs.FindEntity<db_models.cpzlbzb>(x => x.zdbh == _zdbh);
                    System.IO.File.Delete(v.filePath);
                    v.ckbz = ckbz;
                    //v.klqd = klqd;
                    //v.nz = nz;
                    //v.wq = wq;
                    v.update_people_bm = user.ToString();
                    v.update_time = DateTime.Now;

                    if (file != null && file.ContentLength > 0)
                    {
                        fileName = file.FileName;
                        fileExtension = Path.GetExtension(fileName);
                        fileNewName = Guid.NewGuid().ToString() + fileExtension;
                        filePath = Path.Combine(directoryPath, fileNewName);
                        file.SaveAs(filePath);
                        v.fileName = fileNewName;
                        v.filePath = filePath;
                    }
                    _rs.Update<db_models.cpzlbzb>(v);
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
        public ActionResult Delete_zlbz(int zdbh)
        {
            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                _rs.Delete<db_models.cpzlbzb>(x => x.zdbh == zdbh);
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                msg = ex.ToString();
            }
            return Json(new { Result = isSavedSuccessfully, Message = msg, Count = count }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region(工艺控制标准)
        //首页
        public ActionResult gybz() {

            List<SelectListItem> list = new List<SelectListItem>();

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                List<db_models.cpzlbzb> _list = _rs.IQueryable<db_models.cpzlbzb>().ToList();
                foreach (db_models.cpzlbzb i in _list) {

                    list.Add(new SelectListItem() { Text = i.ckbz.ToString(), Value = i.zdbh.ToString() });
                }
            } catch (Exception ex) {

            }
            ViewBag.ckbz = list;
            return View();
        }

        //首页显示
        public ActionResult Select_gybz(int? zdbh) {

            string str = "";
            try {

                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                var v = _rs.IQueryable<db_models.gykzbz>(x => x.ckbzbh == zdbh);
                str = JsonConvert.SerializeObject(v);

            } catch (Exception ex) {

            }
            return Content(str);
        }

        //模态框
        public ActionResult Modal_gybz(int? zdbh) {

            db_models.gykzbz gykzbz = new db_models.gykzbz();
            List<SelectListItem> list = new List<SelectListItem>();

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                if (zdbh != null) {

                    gykzbz = _rs.FindEntity<db_models.gykzbz>(x => x.zdbh == zdbh);

                    List<db_models.cpzlbzb> _list = _rs.IQueryable<db_models.cpzlbzb>().ToList();
                    foreach (db_models.cpzlbzb i in _list)
                    {
                        list.Add(new SelectListItem() { Text = i.ckbz.ToString(), Value = i.zdbh.ToString() });
                    }

                } else {

                    List<db_models.cpzlbzb> _list = _rs.IQueryable<db_models.cpzlbzb>().ToList();
                    foreach (db_models.cpzlbzb i in _list)
                    {
                        list.Add(new SelectListItem() { Text = i.ckbz.ToString(), Value = i.zdbh.ToString() });
                    }
                }

            } catch (Exception ex) {

            }
            ViewBag.ckbz = list;
            return View(gykzbz);
        }

        //增或改
        public ActionResult Insert_gybz() {

            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            string zdbh = Request.Form["zdbh"];
            string ckbzbh = Request.Form["ckbzbh"];
            string gc = Request.Form["gc"];
            string tyd = Request.Form["tyd"];
            string ggsx = Request.Form["ggsx"];
            string ggxx = Request.Form["ggxx"];

            int _zdbh = Convert.ToInt32(zdbh);
            try
            {
                if (_zdbh != 0)
                {
                    //修改
                    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                    var v = _rs.FindEntity<db_models.gykzbz>(x => x.zdbh == _zdbh);
                    v.ckbzbh = Convert.ToInt32(ckbzbh);
                    v.gc = gc;
                    v.tyd = tyd;
                    v.ggsx = Convert.ToDecimal(ggsx);
                    v.ggxx = Convert.ToDecimal(ggxx);
                    _rs.Update<db_models.gykzbz>(v);
                }
                else
                {
                    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                    int _ckbzbh = Convert.ToInt32(ckbzbh);
                    _rs.Insert<db_models.gykzbz>(new db_models.gykzbz() { gc = gc, tyd = tyd, ggsx = Convert.ToDecimal(ggsx), ggxx = Convert.ToDecimal(ggxx), ckbzbh = _ckbzbh });
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
        public ActionResult Delete_gybz(int zdbh) {

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                _rs.Delete<db_models.gykzbz>(x => x.zdbh == zdbh);
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

        #region(抗拉强度)
        //首页
        public ActionResult klqd()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                List<db_models.zbb> _list = _rs.IQueryable<db_models.zbb>().ToList();
                foreach (db_models.zbb i in _list)
                {
                    list.Add(new SelectListItem() { Text = i.zb.ToString(), Value = i.zdbh.ToString() });
                }
            }
            catch (Exception ex)
            {

            }
            ViewBag.zb = list;
            return View();
        }

        //首页显示
        public ActionResult Select_klqd(int? zdbh)
        {
            string str = "";
            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                var v = _rs.IQueryable<db_models.klqd>(x => x.zbbh == zdbh);
                str = JsonConvert.SerializeObject(v);
            }
            catch (Exception ex)
            {
            }
            return Content(str);
        }

        //模态框
        public ActionResult Modal_klqd(int? zdbh)
        {
            db_models.klqd klqd = new db_models.klqd();
            List<SelectListItem> list = new List<SelectListItem>();

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                if (zdbh != null)
                {
                    klqd = _rs.FindEntity<db_models.klqd>(x => x.zdbh == zdbh);
                }
                else
                {
          
                }

                List<db_models.zbb> _list = _rs.IQueryable<db_models.zbb>().ToList();
                foreach (db_models.zbb i in _list)
                {
                    list.Add(new SelectListItem() { Text = i.zb, Value = i.zdbh.ToString() });
                }
            }
            catch (Exception ex)
            {

            }
            ViewBag.zb = list;
            return View(klqd);
        }

        //增或改
        public ActionResult Insert_klqd()
        {
            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            string zdbh = Request.Form["zdbh"];
            string klqdsx = Request.Form["klqdsx"];
            string klqdxx = Request.Form["klqdxx"];
            string zbbh = Request.Form["zbbh"];
            string ggsx = Request.Form["ggsx"];
            string ggxx = Request.Form["ggxx"];

            int _zdbh = Convert.ToInt32(zdbh);
            decimal _ggsx = Convert.ToDecimal(ggsx);
            decimal _ggxx = Convert.ToDecimal(ggxx);
            decimal _klqdsx = Convert.ToDecimal(klqdsx);
            decimal _klqdxx = Convert.ToDecimal(klqdxx);
            int _zb = Convert.ToInt32(zbbh);

            try
            {
                if (_zdbh != 0)
                {
                    //修改
                    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                    var v = _rs.FindEntity<db_models.klqd>(x => x.zdbh == _zdbh);
                    v.zbbh = _zb;
                    v.ggsx = _ggsx;
                    v.ggxx = _ggxx;
                    v.klqdsx = _klqdsx;
                    v.klqdxx = _klqdxx;
                    _rs.Update<db_models.klqd>(v);
                }
                else
                {
                    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                    _rs.Insert<db_models.klqd>(new db_models.klqd() { klqdsx = _klqdsx, klqdxx = _klqdxx, ggsx = _ggsx, ggxx = _ggxx, zbbh = _zb });
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
        public ActionResult Delete_klqd(int zdbh)
        {

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                _rs.Delete<db_models.klqd>(x => x.zdbh == zdbh);
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

        #region(扭转)
        //首页
        public ActionResult nz()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                List<db_models.zbb> _list = _rs.IQueryable<db_models.zbb>().ToList();
                foreach (db_models.zbb i in _list)
                {
                    list.Add(new SelectListItem() { Text = i.zb.ToString(), Value = i.zdbh.ToString() });
                }
            }
            catch (Exception ex)
            {

            }
            ViewBag.zb = list;
            return View();
        }

        //首页显示
        public ActionResult Select_nz(int? zdbh)
        {
            string str = "";
            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                var v = _rs.IQueryable<db_models.nz>(x => x.zbbh == zdbh);
                str = JsonConvert.SerializeObject(v);
            }
            catch (Exception ex)
            {
            }
            return Content(str);
        }

        //模态框
        public ActionResult Modal_nz(int? zdbh)
        {
            db_models.nz nz = new db_models.nz();
            List<SelectListItem> list = new List<SelectListItem>();

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                if (zdbh != null)
                {
                    nz = _rs.FindEntity<db_models.nz>(x => x.zdbh == zdbh);
                }
                else
                {

                }

                List<db_models.zbb> _list = _rs.IQueryable<db_models.zbb>().ToList();
                foreach (db_models.zbb i in _list)
                {
                    list.Add(new SelectListItem() { Text = i.zb, Value = i.zdbh.ToString() });
                }
            }
            catch (Exception ex)
            {

            }
            ViewBag.zb = list;
            return View(nz);
        }

        //增或改
        public ActionResult Insert_nz()
        {
            var user = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            string zdbh = Request.Form["zdbh"];
            string nzcs = Request.Form["nzcs"];
            string zbbh = Request.Form["zbbh"];
            string ggsx = Request.Form["ggsx"];
            string ggxx = Request.Form["ggxx"];

            int _zdbh = Convert.ToInt32(zdbh);
            decimal _ggsx = Convert.ToDecimal(ggsx);
            decimal _ggxx = Convert.ToDecimal(ggxx);
            int _nzcs = Convert.ToInt32(nzcs);
            int _zb = Convert.ToInt32(zbbh);

            try
            {
                if (_zdbh != 0)
                {
                    //修改
                    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                    var v = _rs.FindEntity<db_models.nz>(x => x.zdbh == _zdbh);
                    v.zbbh = _zb;
                    v.ggsx = _ggsx;
                    v.ggxx = _ggxx;
                    v.nzcs = _nzcs;
                    _rs.Update<db_models.nz>(v);
                }
                else
                {
                    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                    _rs.Insert<db_models.nz>(new db_models.nz() { nzcs = _nzcs, ggsx = _ggsx, ggxx = _ggxx, zbbh = _zb });
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
        public ActionResult Delete_nz(int zdbh)
        {

            bool isSavedSuccessfully = true;
            string msg = "";
            int count = 0;

            try
            {
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                _rs.Delete<db_models.nz>(x => x.zdbh == zdbh);
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