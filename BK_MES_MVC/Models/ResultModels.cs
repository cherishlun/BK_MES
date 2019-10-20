using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_MES_MVC.Models
{
    public class JsonSuccess
    {
        public int status { get; set; }
        public string info { get; set; }
        public string mess { get; set; }
        public System.Web.Mvc.JsonResult json { get; set; }

    }

    public class ResultModels
    {
        private bool bError;
        private string cMessage;
        private string cResult;

        public string Result
        {
            get
            {
                return cResult;
            }

            set
            {
                cResult = value;
            }
        }

        public bool isError
        {
            get
            {
                return bError;
            }

            set
            {
                bError = value;
            }
        }

        public string Message
        {
            get
            {
                return cMessage;
            }

            set
            {
                cMessage = value;
            }
        }
    }
}