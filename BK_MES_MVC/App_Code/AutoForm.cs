using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Reflection;
using System.Web.Routing;

namespace BK_MES_MVC.App_Code
{
    public static class AutoForm
    {
        public static String CreateForm(List<db_models.Propertys> tFindEntity)
        {
            StringBuilder _sform = new StringBuilder();

            foreach (var _t in tFindEntity)
            {
                //长度等于0 跳过
                if (_t.ShowLenght == 0)
                    continue;

                //为空验证，自定义验证
                //string _vt = (_t.IsAllowableEmpty ? "" : "required:true,") + (_t.ValidateType.Length == 0 || _t.ValidateType== "NOGRID" ? "" : "validType = '" + _t.ValidateType + "',");
                string _vt = (_t.IsAllowableEmpty ? "" : "required:true,");
                _vt = _vt.Length > 0 ? _vt.Substring(0, _vt.Length - 1) : "title:'input_'";
                //string _name = _t.ShowType + _t.CorrVar;
                string _name = _t.CorrVar;    //与AutoGrid定义相同的Name，在修改时可以直接显示表格的值到Form中

                _sform.AppendLine("<div>");
                _sform.AppendLine(" <label for= \"name\"  > " + _t.ShowName + ":</label>");

                switch (_t.ShowType)
                {
                    case "D":   //日期
                    case "T":   //日期时间
                        _sform.AppendLine(" <input class=\"easyui-datebox\" type=\"text\" name=\"" + _name + "\" data-options=\" " + _vt + "\" style=\"width:60%\" />");
                        break;
                    case "I":   //整型
                        _sform.AppendLine(" <input class=\"easyui-numberbox\" type=\"text\" name=\"" + _name + "\" data-options=\"" + _vt + ",min: 0, precision: 0\" style=\"width:60%\" />");
                        break;
                    case "N":   //小数
                        _sform.AppendLine(" <input class=\"easyui-numberbox\" type=\"text\" name=\"" + _name + "\" data-options=\"" + _vt + ",min: 0, precision: " + _t.DecimalDigits + "\" style=\"width:60%\" />");
                        break;
                    case "S":   //下拉选择
                        _sform.AppendLine(" <select name=\"" + _name + "\" class=\"easyui-combotree\"  data-options = \"" + _vt + ", url:'" +"/Jxaqbgs/"+ _t.ShowDataItem + "',onBeforeSelect:function(node){ if(node.flag=='0') { $.messager.alert('警告','['+node.text+']这个不能选择！'); return false;};}\" style=\"width:60%\"></select>  ");
                        break;
                    case "F":   //文件上传
                        break;
                    default:    //其他按 字符
                        if (_t.ShowLenght > 50)
                        {
                            //多行字符
                            _sform.AppendLine(" <input class=\"easyui-textbox\" type=\"text\" name=\"" + _name + "\" data-options=\" " + _vt + ",multiline:true\" style=\"height:100px;width:60%;white-space: pre-wrap;\" />");
                        }
                        else
                        {
                            _sform.AppendLine(" <input class=\"easyui-textbox\" type=\"text\" name=\"" + _name + "\" data-options=\" " + _vt + "\" style=\"width:60%\" />");
                        }
                        break;
                }
                _sform.AppendLine("</div>");
            }

            return _sform.ToString();
        }

        /// <summary>
        /// 提交表单（单条记录）
        /// </summary>
        /// <param name="tFindEntity"></param>
        public static TEntity SubmitForm<TEntity>(List<db_models.Propertys> tFindEntity, HttpContext context,string cKey)
            where TEntity : new()
        {
            TEntity _tentity = new TEntity();

            db_models.Propertys _p = tFindEntity.Find(i => i.ValidateType.ToLower() == "key");
            if (_p != null)
            {
                if (!string.IsNullOrEmpty(cKey))
                {
                    _tentity.GetType().GetProperty(_p.CorrVar).SetValue(_tentity, Int32.Parse(cKey));
                }
            }


            foreach (db_models.Propertys _t in tFindEntity)
            {
                //长度等于0 跳过
                if (_t.ShowLenght == 0)
                    continue;

                //string _name = _t.ShowType + _t.CorrVar;
                string _name =  _t.CorrVar;    //与AutoGrid定义相同的Name，在修改时可以直接显示表格的值到Form中



                switch (_t.ShowType)
                {
                    case "S":   //下拉选择
                        if (context.Request[_name] != null)
                        {
                            object _value;
                            switch (_tentity.GetType().GetProperty(_t.CorrVar).PropertyType.Name)
                            {
                                case "Int32":
                                    _value = Int32.Parse(context.Request[_name]);
                                    break;
                                default:
                                    _value = context.Request[_name];
                                    break;
                            }
                            _tentity.GetType().GetProperty(_t.CorrVar).SetValue(_tentity, _value);
                        }
                        break;
                    case "F":   //文件上传
                        break;
                    case "D":
                    case "T":
                        if (context.Request[_name] != null)
                        {
                            _tentity.GetType().GetProperty(_t.CorrVar).SetValue(_tentity,DateTime.Parse(context.Request[_name].ToString()));
                        }
                        break;
                    case "I":
                        if (context.Request[_name] != null)
                        {
                            _tentity.GetType().GetProperty(_t.CorrVar).SetValue(_tentity, Int32.Parse(context.Request[_name].ToString()));
                        }
                        break;
                    case "N":
                        if (context.Request[_name] != null)
                        {
                            _tentity.GetType().GetProperty(_t.CorrVar).SetValue(_tentity, decimal.Parse(context.Request[_name].ToString()));
                        }
                        break;
                    default:    //其他按 字符
                        if (context.Request[_name] != null)
                        {
                            string _s = context.Request[_name].ToString();
                            _s = _s.Replace("\n\r", "<br>").Replace("\r", "<br>").Replace("\t", "　　");
                            _tentity.GetType().GetProperty(_t.CorrVar).SetValue(_tentity, _s);
                            //_sf.Name = _t.CorrVar;
                            //_sf.Value = context.Request[_name].ToString();
                        }
                        break;
                }
            }

            return _tentity;
        }

        //public static string To<T>(this IEnumerable<T> source, string field, Type type)
        //{
        //    var t = typeof(T);
        //    var result = "";
        //    if (type == typeof(PropertyInfo))
        //    {
        //        var p = t.GetProperty(field);
        //        if (p != null)
        //        {
        //            foreach (var item in source)
        //            {
        //                result += p.GetValue(item, null) + ",";
        //            }
        //        }
        //    }
        //    else if (type == typeof(FieldInfo))
        //    {
        //        var f = t.GetField(field);
        //        if (f != null)
        //        {
        //            foreach (var item in source)
        //            {
        //                result += f.GetValue(item) + ",";
        //            }
        //        }
        //    }
        //    return result;
        //}
    }

   


}

 
