using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BK_MES_MVC.Controllers
{
    public class BK_ChaCheController : Controller
    {
        // GET: BK_ChaChe
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 叉货
        /// </summary>
        /// <returns></returns>
        public ActionResult ChaHuo_View()
        {


            return View();
        }
    }
}