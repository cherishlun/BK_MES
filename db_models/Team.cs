using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_models
{
    public class TeamABC
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// 班组名称
        /// </summary>
        public string Bzmc { set; get; }
        /// <summary>
        /// 属于，0：主体，>0:ID的字体
        /// </summary>
        public int Sy { set; get; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        public int Sx { set; get; }

    }
}
