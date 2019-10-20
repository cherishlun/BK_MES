using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_MES_MVC.App_Code
{
    public class Menu
    {

        public void MenuString()
        {
            #region 定义的格式模板
            // javascript:;
            // {0}?tid={1}
            var firstTemplate = @"
            <li id='{3}'>
                <a href='{0}'>
                    <i class='{1}'></i>
                    <span class='title'>{2}</span>
                    <span class='selected'></span>
                    <span class='arrow open'></span>
                </a>";

            var secondTemplate = @"
                <li class='heading' style='font-size:14px;color:yellow'>
                    <i class='{0}'></i>
                    {1}
                </li>";

            var thirdTemplate = @"
                <li id='{3}'>
                    <a href='{0}'>
                        <i class='{1}'></i>
                        {2}
                    </a>
                </li>";
            var firstTemplateEnd = "</li>";
            var secondTemplateStart = "<ul class='sub-menu'>";
            var secondTemplateEnd = "</ul>";
            #endregion

            ////三级
            //icon = subNodeInfo.WebIcon;
            ////tid 为顶级分类id，sid 为第三级菜单id
            //tmpUrl = string.Format("{0}{1}tid={2}&sid={3}", subNodeInfo.Url, GetUrlJoiner(subNodeInfo.Url), info.ID, subNodeInfo.ID);
            //url = (!string.IsNullOrEmpty(subNodeInfo.Url) && subNodeInfo.Url.Trim() != "#") ? tmpUrl : "javascript:;";
            //sb = sb.AppendFormat(thirdTemplate, url, icon, subNodeInfo.Name, subNodeInfo.ID);

        }
    }
}