using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_MES_MVC.Models
{
    /// <summary>
    /// 分组显示
    /// </summary>
    public class GroupByModels
    {
        /// <summary>
        /// Group By 分组值
        /// </summary>
        public int gbKey { set; get; }

        /// <summary>
        /// Group By 总数
        /// </summary>
        public int gbCount { set; get; }

        public string gbName { set; get; }
    }
}