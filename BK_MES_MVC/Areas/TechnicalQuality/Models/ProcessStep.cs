using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_MES_MVC.Areas.TechnicalQuality.Models
{
    public class ProcessStep
    {
        public string ProcessName { get; set; }
        public int Sequence { get; set; }
        public int ProcessNum { get; set; }
        public int ProductNum { get; set; }
        public string IntervalTime { get; set; }
    }
}