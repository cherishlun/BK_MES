using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_MES_MVC.Areas.TechnicalQuality.Models
{
    public class zb_common
    {
        public int zdbh { get; set; }
        public string zb { get; set; }
        public string ckbz { get; set; }
        public DateTime add_time { get; set; }
        public DateTime update_time { get; set; }
        public string add_people_bh { get; set; }
        public string update_people_bh { get; set; }

        public int ckbzbh { get; set; }
    }
}