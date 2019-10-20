using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_MES_MVC.Areas.TechnicalQuality.Models
{
    public class djdm_common
    {

        public string djdm { get; set; }
        public string cpmc { get; set; }
        public string cpmc_eng { get; set; }
        public string gh { get; set; }
        public string zb { get; set; }
        public string ckbz { get; set; }
        public string add_people { get; set; }
        public DateTime? add_time { get; set; }
        public string update_people { get; set; }
        public DateTime? update_time { get; set; }

        public int zdbh { get; set; }
        public int cpmcbh { get; set; }
        public int zbbh { get; set; }
        public int ckbzbh { get; set; }

    }
}