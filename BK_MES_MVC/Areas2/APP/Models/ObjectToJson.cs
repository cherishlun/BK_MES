using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_MES_MVC.Areas.APP.Models
{
    public class ObjectToJson
    {
        public ObjectToJson() {

        }

        [JsonProperty("back_success")]
        public string back_success { get; set; }

        [JsonProperty("back_error")]
        public string back_error { get; set; }

    }
}