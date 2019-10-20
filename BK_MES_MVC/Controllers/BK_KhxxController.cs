using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BK_MES_MVC.Controllers
{
    public class BK_KhxxController : Controller
    {
        // GET: BK_Khxx
        public ActionResult Index()
        {
            //生成表格列（使用全部的列)
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            //表格属性
            var tFindEntity = _rs.IQueryable<db_models.Propertys>(i => i.CorrTable == "客户信息表").OrderBy(o => o.Order).ToList();
            //表格行颜色
            var tRowColor = _rs.IQueryable<db_models.RowColor>(i => i.ColorTable == "客户信息表").ToList();
            //创建表格
            List<string> _listjson = BK_MES_MVC.App_Code.AutoGrid.CreateGrid(tFindEntity, tRowColor);

            //前台界面显示
            ViewBag.Grid = _listjson[0];   //表格列表
            ViewBag.Filter = _listjson[1];//表格筛选
            ViewBag.RowColor = _listjson[2];//行颜色


            return View();
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public ActionResult doQuery()
        {
            //数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            ////当前用户ID
            //int _usid = Int32.Parse(SD.Data.WebHelper.GetCookie("NewTest2018", "userid"));
            ////获取可用班组ID信息
            //List<object> _listbzid = new List<object>();
            //var _tt = _rs.IQueryable<db_models.UsersMess>(i => i.ID == _usid);
            //foreach (var _t1 in _tt)
            //{
            //    foreach (string _s in _t1.LlBz.Split(','))
            //    {
            //        _listbzid.Add(Int32.Parse(_s));
            //    }
            //}


            string _json = "";

            //加入分页
            SD.Data.Pagination _p = new SD.Data.Pagination();
            if (Request["page"] == null)
            {
                _p.page = 1;
            }
            else
            {
                _p.page = Int32.Parse(Request["page"].ToString());
            }
            _p.rows = Int32.Parse(Request["rows"].ToString());
            _p.sidx = "khbm";
            _p.sord = "desc";
            bool _isFind = false;

            var t2 = _rs.IQueryable<db_models.Propertys>(i => i.CorrTable == "客户信息表").OrderBy(o => o.Order).ToList();

            var _jx = new SD.Data.LamadaExtention<db_models.khxxb>();
            List<db_models.khxxb> tFindEntity = new List<db_models.khxxb>();
            if (Request["filterRules"] != null && Request["filterRules"].Length > 0)
            {
                //查询
                List<fff> _fff = JsonConvert.DeserializeObject<List<fff>>(Request["filterRules"].ToString());
                if (_fff.Count > 0) //有查询
                {
                    foreach (fff _t in _fff)
                    {
                        //
                        var _a = t2.Find(i => i.CorrVar == _t.field && i.ValidateType != null && i.ValidateType != "" && i.ValidateType != "KEY" && i.ValidateType != "NOGRID");
                        if (_a != null)
                            _t.field = _a.ValidateType;

                        SD.Data.ExpressionType _et = 0;
                        switch (_t.op)
                        {
                            case "contains":
                                _et = SD.Data.ExpressionType.Contains;
                                break;
                            case "equal":
                                _et = SD.Data.ExpressionType.Equal;
                                break;
                            case "less":
                                _et = SD.Data.ExpressionType.LessThan;
                                break;
                            case "greater":
                                _et = SD.Data.ExpressionType.GreaterThan;
                                break;
                            case "lessorequal":
                                _et = SD.Data.ExpressionType.LessThanOrEqual;
                                break;
                            case "greaterorequal":
                                _et = SD.Data.ExpressionType.GreaterThanOrEqual;
                                break;
                            case "notequal":
                                _et = SD.Data.ExpressionType.NotEqual;
                                break;
                        }
                        if (string.IsNullOrEmpty(_t.value.ToString()))
                            break;

                        _jx.GetExpression(_t.field, _t.value, _et);
                    }
                    //  _jx.GetExpression("DgBz", _listbzid);
                    var lamada = _jx.GetLambda();
                    if (lamada != null)
                        tFindEntity = _rs.FindList<db_models.khxxb>(lamada, _p);

                    _isFind = true;
                }
            }
            if (!_isFind)    //显示全部
            {
                // _jx.GetExpression("DgBz", _listbzid);
                //tFindEntity = _rs.FindList<db_models.khxxb>(i => _listbzid.Contains(i.JxSsbz), _p);
                //tFindEntity = _rs.FindList<db_models.khxxb>(_jx.GetLambda(), _p);
                tFindEntity = _rs.FindList<db_models.khxxb>(_p);
            }


            //List<db_models.khxxb> _ss = new List<db_models.khxxb>();
            //var _tt=tFindEntity.GroupJoin(_rs.IQueryable<db_models.TeamABC>(), l => l.JxSgdw, r => r.ID, (l, r) => new { l, r });
            //foreach(var _t1 in _tt)
            //{
            //    if (_t1.r.Count() > 0)
            //    {
            //        _ss.Add(new db_models.khxxb { ID = _t1.l.ID, cSgdw = _t1.r.First().Bzmc });
            //    }
            //    else
            //    {
            //        _ss.Add(new db_models.khxxb { ID = _t1.l.ID});
            //    }

            //}
            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<db_models.khxxb>(tFindEntity);


            _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";

            //在JS中生成List列表
            //var aa= Json(new { total = tFindEntity.Count(), rows = tFindEntity }, JsonRequestBehavior.AllowGet);
            return Content(_json);
        }

        private class fff
        {
            public string field { get; set; }
            public object value { get; set; }
            public string op { get; set; }

        }

    }


}


