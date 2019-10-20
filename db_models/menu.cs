using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_models
{
    public class Menus
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { private set; get; }

        /// <summary>
        /// 主键
        /// </summary>
        public int ID { private set; get; }

        /// <summary>
        /// 菜单目录
        /// </summary>
        public string MenuTag { private set; get; }


    }
}
