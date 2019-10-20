using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_models
{

    public class Propertys
    {
        /// <summary>
        /// 显示名称
        /// </summary>
        public string ShowName { private set; get; }
        /// <summary>
        /// 显示的类型
        /// </summary>
        public string ShowType { private set; get; }
        /// <summary>
        /// 显示的长度
        /// </summary>
        public Int32 ShowLenght { private set; get; }
        /// <summary>
        /// 数据项
        /// </summary>
        public string ShowDataItem { private set; get; }
        /// <summary>
        /// 允许空 true：false:不允许
        /// </summary>
        public bool IsAllowableEmpty
        {
            private set; get;
        }


        /// <summary>
        /// 验证类型类型
        /// </summary>
        public string ValidateType { private set; get; }

        /// <summary>
        /// 对应表名
        /// </summary>
        public string CorrTable { private set; get; }
        /// <summary>
        /// 对应字段
        /// </summary>
        public string CorrField { private set; get; }
        /// <summary>
        /// 关键字
        /// </summary>
        public Int32 ID { private set; get; }
        /// <summary>
        /// 对应变量
        /// </summary>
        public string CorrVar { private set; get; }
        /// <summary>
        /// 小数位
        /// </summary>
        public Int32 DecimalDigits { private set; get; }

        /// <summary>
        /// 顺序
        /// </summary>
        public int Order { private set; get; }

    }
}

