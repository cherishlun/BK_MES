using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BK_MES_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
             db_models.YongHu _yh = App_Code.WebHelper.GetCookie();
            if(_yh.yhbm==0)
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });//可跳到其他controller
            }

            return View(_yh);
        }

        public ActionResult Main()
        {
            return View();
        }

        public ActionResult GetGs()
        {

            //[{
            // "id": "001",
            // "text": "菜单",
            // "url":"",
            // "children": [{
            //     "id": "001001",
            //     "text": "学生信息",
            //     "url":"/Test/doshow"

            //    }]
            //   },
            //   {
            //        "id": "001003",
            //        "text": "MyHtml",
            //        "url": "basic.html"
            // }]

            BK_MES_MVC.App_Code.GetData _gs = new App_Code.GetData();

            List<BK_MES_MVC.App_Code.TreeJsonModels> _list = BK_MES_MVC.App_Code.TreeNode.initTree(_gs.getgs());
            var json = JsonConvert.SerializeObject(_list); //把对象集合转换成Json
            return Content(json);

        }
    }
}