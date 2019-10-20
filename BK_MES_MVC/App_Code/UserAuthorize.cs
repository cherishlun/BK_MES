using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BK_MES_MVC.App_Code
{
    /// <summary>
    /// 不启用压缩特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class NoCompress : Attribute
    {
        public NoCompress()
        {
        }
    }

    public class UserAuthorize : AuthorizeAttribute
    {
        /// <summary>
        /// 授权失败时呈现的视图
        /// </summary>
        public string AuthorizationFailView { get; set; }
        public bool IsCheck { get; set; }
        /// <summary>
        /// 请求授权时执行
        /// </summary>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!IsCheck)
            {
                this.Roles = "1";
                return;
            }

            object[] actionFilter = filterContext.ActionDescriptor.GetCustomAttributes(typeof(NoCompress), false);
            object[] controllerFilter = filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(NoCompress), false);
            if (controllerFilter.Length == 1 || actionFilter.Length == 1)
            {
                return;
            }



            //获得url请求里的controller和action：
            string controllerName = filterContext.RouteData.Values["controller"].ToString().ToLower();
            string actionName = filterContext.RouteData.Values["action"].ToString().ToLower();
            //string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //string actionName = filterContext.ActionDescriptor.ActionName;

            //根据请求过来的controller和action去查询可以被哪些角色操作:
            //        Models.RoleWithControllerAction roleWithControllerAction =
            //base.SampleData.roleWithControllerAndAction.Find(r => r.ControllerName.ToLower() == controllerName &&
            //tionName.ToLower() == actionName);
            //        if (roleWithControllerAction != null)
            //        {
            // this.Roles = roleWithControllerAction.RoleIds;     //有权限操作当前控制器和Action的角色id

            // }

            //根据用户ID 获取权限
            db_models.YongHu _yh = WebHelper.GetCookie();
            if (_yh.yhbm == 0)
                this.Roles = "0";
            else
            {
                //生成表格列（使用全部的列)
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                //表格属性

                var tFindEntity = _rs.IQueryable<Models.One>(string.Format("SELECT 1 as iu FROM v_UserToCa a inner join v_ca b on a.caid = b.id where userid = {0} and controllername = '{1}' and actionName = '{2}'"
                                                    , _yh.yhbm.ToString(), controllerName, actionName)).FirstOrDefault();
                if (tFindEntity == null)
                    this.Roles = "0";
                else
                    this.Roles = "1";
            }
            base.OnAuthorization(filterContext);   //进入AuthorizeCore
        }

        /// <summary>
        /// 自定义授权检查（返回False则授权失败）
        /// </summary>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //if (httpContext.User.Identity.IsAuthenticated)
            //{
            //    string userName = httpContext.User.Identity.Name;    //当前登录用户的用户名
            //                                                         // Models.User user = Database.SampleData.users.Find(u => u.UserName == userName);   //当前登录用户对象

            //    //    if (user != null)
            //    //    {
            //    //        Models.Role role = Database.SampleData.roles.Find(r => r.Id == user.RoleId);  //当前登录用户的角色
            //    //        foreach (string roleid in Roles.Split(','))
            //    //        {
            //    //            if (role.Id.ToString() == roleid)
            //    //                return true;
            //    //        }
            //    //        return false;
            //    //    }
            //    //    else
            //    //        return false;
            //    //}
            //    //else
            //    //    return false;     //进入HandleUnauthorizedRequest 
            //}

            if (Roles == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 处理授权失败的HTTP请求
        /// </summary>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //filterContext.Result = new ViewResult { ViewName = AuthorizationFailView };
            filterContext.Result = new ViewResult { ViewName = "Error" };


        }
    }
 
}