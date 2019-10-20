using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_models
{
    /// <summary>
    /// 不要设置0
    /// </summary>
    public class db_enum
    {
        /// <summary>
        /// 仓库类型
        /// </summary>
        public enum enum_cklx
        {
            原料库 = 1,
            半成品库 = 2,
            成品库 = 3,
        }

        /// <summary>
        /// 状态
        /// </summary>
        public enum enum_zt
        {
            可用 = 1,
            停用 = 2,
        }

        /// <summary>
        /// 库位大小
        /// </summary>
        public enum enum_kwdx
        {
            大=30,
            中=20,
            小=10,
        }

        /// <summary>
        /// 订单状态
        /// </summary>
        public enum enum_ddzt
        {
            未确认订单记录 = 0,
            已确认订单记录 = 1,
            正在配货记录 = 2,
            完成配货记录 = 3,
            未装车订单=4,
            已装车订单=5,

            //未分配拣货记录 = 4,
            //正在配拣货记录 = 5,
            //完成拣货记录 = 6,

        }

        public enum enum_rkfs
        {
            扫码入库=10,
            移库=11
        }

        public enum enum_ckfs
        {
            扫码出库=20,
        }
    }
    
}
