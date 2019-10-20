using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_models
{
    public class RowColor
    {
        /// <summary>
        /// 变色条件
        /// </summary>
        public string ColorWhere { set; get; }
        /// <summary>
        /// 背景色
        /// </summary>
        public string ColorBack { set; get; }
        /// <summary>
        /// 文字色
        /// </summary>
        public string ColorText { set; get; }
        /// <summary>
        /// 对应表
        /// </summary>
        public string ColorTable { set; get; }
        /// <summary>
        /// 关键字
        /// </summary>
        public Int32 ID { set; get; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        public Int32 ColorOrder { set; get; }
    }
}
