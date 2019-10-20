using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BK_MES_MVC.Controllers
{
    public class LoginController : Controller
    {
        
        // GET: Login
        [App_Code.NoCompress]
        public ActionResult Index()
        {
            if (App_Code.WebHelper.ExistsCookie())
                return RedirectToRoute(new { controller = "Home", action = "Index" });//可跳到其他controller
            return View();
        }

        [App_Code.NoCompress]
        [HttpPost]
        public ActionResult In()
        {
            string cUserName, cPassWord;
            cUserName = Request["UserName"].ToString();
            cPassWord = Request["md5_pwd"].ToString();
            //App_Code.WebHelper.MD5Encrypt32(Request["md5_pwd"].ToString());

            BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();
            _jsons.info = "失败!";
            _jsons.status = 0;
            _jsons.mess = "登录";

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            try
            {
                var tFindEntity = _rs.IQueryable<db_models.YongHu>(i => i.yhdlm == cUserName && i.yhmm == cPassWord).Single();
                if (tFindEntity != null)
                {
                    App_Code.WebHelper.SetCookie(tFindEntity);

                    _jsons.info = "成功!";
                    _jsons.status = 1;
                    //return RedirectToRoute(new { controller = "Home", action = "Index" });//可跳到其他controller
                }
            }
            catch (Exception ex) { }

            return Json(_jsons, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Out()
        {
            App_Code.WebHelper.DeleCookie();
            return RedirectToRoute(new { controller = "Login", action = "Index" });//可跳到其他controller

        }
    }
}