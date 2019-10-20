using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace BK_MES_MVC.App_Code
{
    public class ClassOne
    {
        public List<SelectListItem> abc<T,T1>(T1 tEntity)
        {
           string _value = "";
            foreach (PropertyInfo pi in typeof(T1).GetProperties())
            {
                if(pi.PropertyType == typeof(T))
                {
                    _value = pi.GetValue(tEntity, null).ToString();
                    break;
                }
            }

            List<SelectListItem> _a = new List<SelectListItem>();
            Array _s1 = Enum.GetValues(typeof(T));

            foreach (T _x in _s1)
            {
                bool _selected = false;

                if (_value == _x.ToString())
                {
                    _selected = true;
                }
                _a.Add(new SelectListItem { Text = _x.ToString(), Value = _x.GetHashCode().ToString(), Selected = _selected });
            }


            /*
            IEnumerable<db_models.db_enum.enum_zt> _s2 = Enum.GetValues(typeof(db_models.db_enum.enum_zt)).Cast<db_models.db_enum.enum_zt>();
            foreach (db_models.db_enum.enum_zt _x in _s2)
            {
                bool _selected = false;
                if (tFindEntity.ckzt == _x)
                {
                    _selected = true;
                }
                _b.Add(new SelectListItem { Text = _x.ToString(), Value = ((int)_x).ToString(), Selected = _selected });
            }
            ViewBag.from_zt = _b;
            */


            return _a;

        }

    }
}