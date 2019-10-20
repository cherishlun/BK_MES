using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BK_MES_MVC.Controllers
{
    public class BK_CkxxController : Controller
    {
        // GET: BK_Ckxx
        //public ActionResult Index()
        //{

        //    //生成表格列（使用全部的列)
        //    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
        //    //表格属性
        //    var tFindEntity = _rs.IQueryable<db_models.Propertys>(i => i.CorrTable == "仓库信息表").OrderBy(o => o.Order).ToList();
        //    //表格行颜色
        //    var tRowColor = _rs.IQueryable<db_models.RowColor>(i => i.ColorTable == "仓库信息表").ToList();
        //    //创建表格
        //    List<string> _listjson = BK_MES_MVC.App_Code.AutoGrid.CreateGrid(tFindEntity, tRowColor);

        //    //前台界面显示
        //    ViewBag.Grid = _listjson[0];   //表格列表
        //    ViewBag.Filter = _listjson[1];//表格筛选
        //    ViewBag.RowColor = _listjson[2];//行颜色

        //    //生成可以使用的菜单
        //   // int _usergroupid = Int32.Parse(SD.Data.WebHelper.GetCookie("NewTest2018", "userqx"));//测试参数 权限组ID

        //    //获取用户组权限(根据用户组ID和当前控制器ID）
        //    string _menu = RouteData.Values["controller"].ToString();
        //    //var tugEntity = _rs.IQueryable<Models.UserPermissions>(i => i.UserGroupId == _usergroupid && i.MenuName == _menu);
        //    List<App_Code.DynamicMenuStruct> _ldms = new List<App_Code.DynamicMenuStruct>();

        //    //foreach (var _t in tugEntity)
        //    //{
        //    //    //保存模式
        //    //    if (_t.FunFlag == 5)
        //    //    {
        //    //        _ldms.Add(new App_Code.DynamicMenuStruct() { Menu_Name = "", Menu_Flag = NewTest_2018.App_Code.MenuFlag.Save, Menu_FunName = "EditsubmitForm", Menu_Url = _menu + "/doSave?AID='+$('#AID').html()+'&id='" });
        //    //        ViewBag.Save = "<a class=\"easyui-linkbutton\" data-options=\"iconCls:'icon-save'\" style=\"margin-left: 10px;\" onclick=\"EditsubmitForm()\">确定</a>";
        //    //        // break;
        //    //    }
        //    //    else
        //    //    {
        //    //        _ldms.Add(new App_Code.DynamicMenuStruct() { Menu_Name = _t.FunDescribe, Menu_Flag = (NewTest_2018.App_Code.MenuFlag)_t.FunFlag, Menu_FunName = _t.FunName + _t.FunParam.ToString() + "_" + _t.FunFlag, Menu_Url = _menu + "/" + _t.FunName + "?id=" + _t.FunParam, IsMultipleRow = _t.IsMultipleRow });
        //    //    }
        //    //}
        //    _ldms.Add(new App_Code.DynamicMenuStruct() { Menu_Name = "", Menu_Flag = App_Code.MenuFlag.Save, Menu_FunName = "EditsubmitForm", Menu_Url = _menu + "/doSave?AID='+$('#AID').html()+'&id='" });
        //    ViewBag.Save = "<a class=\"easyui-linkbutton\" data-options=\"iconCls:'icon-save'\" style=\"margin-left: 10px;\" onclick=\"EditsubmitForm()\">确定</a>";

        //    _ldms.Add(new App_Code.DynamicMenuStruct() { Menu_Name = "增加", Menu_Flag = App_Code.MenuFlag.Add, Menu_FunName = "ADD", Menu_Url = _menu + "/doForm", IsMultipleRow = false });
        //    _ldms.Add(new App_Code.DynamicMenuStruct() { Menu_Name = "修改", Menu_Flag = App_Code.MenuFlag.Edit, Menu_FunName ="EDIT", Menu_Url = _menu + "/doForm?id=", IsMultipleRow = false });
        //    _ldms.Add(new App_Code.DynamicMenuStruct() { Menu_Name = "删除", Menu_Flag = App_Code.MenuFlag.Delete, Menu_FunName = "DELETE", Menu_Url = _menu + "/doDelete?id=", IsMultipleRow = false });
        //    string _m1, _m2;
        //    App_Code.DynamicMenu.CreateMenuy(_ldms, out _m1, out _m2);

        //    ViewBag.Menu = _m1;
        //    ViewBag.MenuFunction = _m2;


        //    return View();

        //}


        public ActionResult Index()
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            DataSet _ds = _rs.GetDataSet("Pr_CKXx_Index");
            //当前时间
            ViewBag._Now = ((DateTime)_ds.Tables[0].Rows[0][0]).ToString("yyyy-MM-dd HH:mm");
            //当前库存量
            ViewBag._KcSl = _ds.Tables[1].Rows[0]["_count"].ToString();
            ViewBag._KcZl = _ds.Tables[1].Rows[0]["_sum"].ToString();

            //入库存量
            ViewBag._RkSl = _ds.Tables[2].Rows[0]["_count"].ToString();
            ViewBag._RkZl = _ds.Tables[2].Rows[0]["_sum"].ToString();

            //出库存量
            ViewBag._CkSl = _ds.Tables[3].Rows[0]["_count"].ToString();
            ViewBag._CkZl = _ds.Tables[3].Rows[0]["_sum"].ToString();

            //库位未占用
            ViewBag._KcWyl = ((int)_ds.Tables[4].Rows[0][0] - (int)_ds.Tables[5].Rows[0][0]).ToString();
            //库位占用量
            ViewBag._KcZyl = _ds.Tables[5].Rows[0][0].ToString();

            //安全库存显示
            string _AqKc_Mc = "";
            string _AqKc_Sdzl = "";
            string _AqKc_Kczl = "";
            foreach (DataRow _dr in _ds.Tables[6].Rows)
            {
                _AqKc_Mc += "," + _dr[0].ToString() + "";
                _AqKc_Sdzl += "," + _dr[4].ToString();
                _AqKc_Kczl += "," + _dr[5].ToString();
            }
            ViewBag._AqKc_Mc = _AqKc_Mc;
            ViewBag._AqKc_Sdzl = _AqKc_Sdzl;
            ViewBag._AqKc_Kczl = _AqKc_Kczl;

            if (_ds.Tables[7] != null && _ds.Tables[7].Rows.Count>0)
            {
                ViewBag._Pk_KsSj = ((DateTime)_ds.Tables[7].Rows[0][0]).ToString("yyyy年MM月dd日"); ;
                ViewBag._Pk_JsSj = _ds.Tables[7].Rows[0][4].ToString() == "" ? "未结束盘点." : ((DateTime)_ds.Tables[7].Rows[0][4]).ToString("yyyy年MM月dd日 HH时mm分");
                ViewBag._Pk_Sl = _ds.Tables[7].Rows[0][1].ToString();
                ViewBag._Pk_Zl = _ds.Tables[7].Rows[0][2].ToString();
                ViewBag._Pk_Bz = _ds.Tables[7].Rows[0][3].ToString();
            }

            ViewBag._Data_Rk = _ds.Tables[8];
            ViewBag._Data_Ck = _ds.Tables[9];

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
            _p.sidx = "ckmc";
            _p.sord = "desc";
            bool _isFind = false;

            var t2 = _rs.IQueryable<db_models.Propertys>(i => i.CorrTable == "仓库信息表").OrderBy(o => o.Order).ToList();

            var _jx = new SD.Data.LamadaExtention<db_models.ckxxb>();
            List<db_models.ckxxb> tFindEntity = new List<db_models.ckxxb>();
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
                        tFindEntity = _rs.FindList<db_models.ckxxb>(lamada, _p);

                    _isFind = true;
                }
            }
            if (!_isFind)    //显示全部
            {
                // _jx.GetExpression("DgBz", _listbzid);
                //tFindEntity = _rs.FindList<db_models.khxxb>(i => _listbzid.Contains(i.JxSsbz), _p);
                //tFindEntity = _rs.FindList<db_models.khxxb>(_jx.GetLambda(), _p);
                tFindEntity = _rs.FindList<db_models.ckxxb>(_p);
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
            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<db_models.ckxxb>(tFindEntity);


            _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";

            //在JS中生成List列表
            //var aa= Json(new { total = tFindEntity.Count(), rows = tFindEntity }, JsonRequestBehavior.AllowGet);
            return Content(_json);
        }


        /// <summary>
        /// 表单
        /// </summary>
        /// <param name="qxid"></param>
        /// <returns></returns>
        public ActionResult doForm()
        {
            Models.ResultModels _rm = new Models.ResultModels();

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            var tFindEntity = _rs.IQueryable<db_models.Propertys>(i => i.CorrTable == "仓库信息表").OrderBy(o => o.Order).ToList<db_models.Propertys>();

            _rm.isError = false;
            _rm.Message = "ok";
            _rm.Result = App_Code.AutoForm.CreateForm(tFindEntity);

            var json = JsonConvert.SerializeObject(_rm); //把对象集合转换成Json
            return Content(json);
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public ActionResult doSave()
        {
            //这里测试是权限ID 1

            //int _usergroupid = Int32.Parse(SD.Data.WebHelper.GetCookie("NewTest2018", "userqx"));
            //int _userid = Int32.Parse(SD.Data.WebHelper.GetCookie("NewTest2018", "userid"));

            // SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            var _rs = new SD.Data.RepositoryBase().BeginTrans();


            //需要更新的字段
            var tFindEntity = _rs.IQueryable<db_models.Propertys>(i => i.CorrTable == "仓库信息表").ToList();

            List<string> _fildes = new List<string>();
            foreach (var _t in tFindEntity)
            {
                _fildes.Add(_t.CorrVar);
            }

            //属性表内容
            var tFindEntity2 = _rs.IQueryable<db_models.Propertys>(i => i.CorrTable == "仓库信息表").ToList();
            Models.ResultModels _rm = new Models.ResultModels();
            db_models.ckxxb _ts = new db_models.ckxxb();

            if (Request["Aid"] == null || Request["Aid"].ToString() == "")
            {
                //增加
                _ts = App_Code.AutoForm.SubmitForm<db_models.ckxxb>(tFindEntity2, System.Web.HttpContext.Current, null);
                try
                {
                    //_ts.JxSsbz = Int32.Parse(SD.Data.WebHelper.GetCookie("NewTest2018", "userbzid"));    //所属编组
                    _rs.Insert(_ts);

                    _rs.Commit();

                    _rm.isError = false;
                    _rm.Message = "ok";
                    _rm.Result = "{OK}";
                }
                catch (Exception ex)
                {
                    _rm.isError = true;
                    _rm.Message = ex.Message.ToString();
                }
            }
            else
            {
                //修改
                List<db_models.ckxxb> _tss = new List<db_models.ckxxb>();
                //List<Models.RowExamine> _tss2 = new List<Models.RowExamine>();

                foreach (string _key in Request["Aid"].ToString().Split(','))
                {
                    if (!String.IsNullOrEmpty(_key))
                    {
                        _tss.Add(App_Code.AutoForm.SubmitForm<db_models.ckxxb>(tFindEntity2, System.Web.HttpContext.Current, _key));
                        //_tss2.Add(new Models.RowExamine { RowId = Int32.Parse(_key), ExUser = _userid, MenuId = 1 });   //这里固定了一个值，正式上线需要更改
                    }
                }

                try
                {
                    _rs.Update(_tss, _fildes);    //部分更新
                                                  // _rs.Insert(_tss2);
                    _rs.Commit();   //提交

                    _rm.isError = false;
                    _rm.Message = "ok";
                    _rm.Result = "{OK}";
                }
                catch (Exception ex)
                {
                    _rm.isError = true;
                    _rm.Message = ex.Message.ToString();
                }
            }


            var json = JsonConvert.SerializeObject(_rm); //把对象集合转换成Json
                                                         // var json = Json(new { list }, JsonRequestBehavior.AllowGet);
            return Content(json);
        }

        public ActionResult doUpdate(string id)
        {
            //查找选择行审批的等级

            //List<int> _id = new List<int>();
            //foreach (string _i in id.Split(','))
            //{
            //    _id.Add(Int32.Parse(_i));
            //}

            Models.ResultModels _rm = new Models.ResultModels();



            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            //这里是有了一些固定值，正式上线需要替换
            //int _userqxdj = Int32.Parse(SD.Data.WebHelper.GetCookie("NewTest2018", "userqxdj"));
            //var tFindEntity = _rs.IQueryable<Models.RowExamineView>(u => u.MenuId == 1 && _id.ToList().Contains(u.RowId) && u.ExUserDj > _userqxdj);
            //if (tFindEntity.Count() > 0)
            //{
            //    _rm.isError = true;
            //    _rm.Message = "此记录已被审批，无法修改！";
            //}

            var tFindEntity = _rs.IQueryable<db_models.ckxxb>(u => u.zdbh == Int32.Parse(id));


            var json = JsonConvert.SerializeObject(_rm); //把对象集合转换成Json
            return Content(json);
        }
        public ActionResult doDelete()
        {
            //无法同时删除多条记录

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            Models.ResultModels _rm = new Models.ResultModels();
            try
            {
                if (Request["Aid"] != null && !String.IsNullOrEmpty(Request["Aid"].ToString()))
                {
                    if (Request["Aid"].ToString().IndexOf(",") >= 0)
                    {
                        _rm.isError = true;
                        _rm.Message = "无法删除多条记录！";
                    }
                    else
                    {
                        Int32 _id = Int32.Parse(Request["Aid"].ToString());

                        //  int _usergroupid = Int32.Parse(SD.Data.WebHelper.GetCookie("NewTest2018", "userqx"));

                        //var tFindEntity = _rs.IQueryable<Models.RowExamineView>(u => u.MenuId == 1 && u.RowId == _id && u.ExUserDj >= _usergroupid);  //这里测试，正式上线需要删除
                        //if (tFindEntity.Count() > 0)
                        //{
                        //    _rm.isError = true;
                        //    _rm.Message = "此记录已被审批，无法修改！";
                        //}
                        //else
                        //{
                        _rs.Delete<db_models.ckxxb>(i => i.zdbh == _id);
                        _rm.isError = false;
                        _rm.Message = "ok";
                        _rm.Result = "{OK}";
                        // }
                    }
                }
            }
            catch (Exception ex)
            {
                _rm.isError = true;
                _rm.Message = ex.Message.ToString();
            }

            var json = JsonConvert.SerializeObject(_rm); //把对象集合转换成Json
                                                         // var json = Json(new { list }, JsonRequestBehavior.AllowGet);
            return Content(json);
        }

        /// <summary>
        /// 仓库名称管理
        /// </summary>
        /// <returns></returns>
        /// 

        public ActionResult Ck_Mcgl()
        {
            return View();
        }


        /// <summary>
        /// 库位_库位管理
        /// </summary>
        /// <param name="cCkbh">仓库编号</param>
        /// <returns></returns>
        public ActionResult Ck_Kwgl(int Ckbh, String Ckph)
        {
            //string  _ch="";
            //int _twh = 0,_wh=0;
            //StringBuilder _table_th = new StringBuilder();
            //StringBuilder _table_td = new StringBuilder();

            ////获取该仓库的所有库位信息
            ////数据显示
            //SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            //var t2 = _rs.IQueryable<db_models.cpkwpzb>(i => i.ckbh == Ckbh && i.ph.Substring(0,1)==Ckph).OrderBy(o => o.ph).ToList();

            //BK_MES_MVC.App_Code.ClassOne _class = new App_Code.ClassOne();
            //ViewBag.from_zt = _class.abc<db_models.db_enum.enum_zt, db_models.cpkwpzb>(t2[0]);
            //int _iwh = 0;
            //foreach(db_models.cpkwpzb _kw in t2)
            //{
            //    if (_ch != _kw.ch)
            //    {
            //        if (_ch != "")
            //        {
            //            _table_td.Append("</tr>");
            //        }

            //        _ch = _kw.ch;
            //        _table_td.AppendFormat("<tr><td>{0}</td>",_ch);
            //        _iwh = 0;
            //    }

            //    _wh = int.Parse(_kw.wh);
            //    if (_twh < _wh)
            //    {
            //        _twh = _wh;
            //    }

            //    _iwh += 1;

            //    if (_iwh == int.Parse(_kw.wh))
            //    {
            //        _table_td.Append("<td><input type = \"checkbox\" onclick = \"check_bet(this)\" ></td>");
            //    }
            //    else
            //    {
            //        for (int i = 0; i < _wh - _iwh; i++)
            //        {
            //            _table_td.Append("<td></td>");
            //        }
            //        _table_td.Append("<td><input type = \"checkbox\" onclick = \"check_bet(this)\" ></td>");
            //    }

            //}

            //for(int i= 1;i <= _twh;i++)
            //{
            //    _table_th.AppendFormat("<th>{0}</th>", i.ToString());
            //}

            //_table_td.Append("</tr>");

            //ViewBag.Tr = _table_td.ToString();
            //ViewBag.Th = _table_th.ToString();

            return View();
        }

        private class fff
        {
            public string field { get; set; }
            public object value { get; set; }
            public string op { get; set; }

        }

        public ActionResult CkMc_GetData(int limit, int offset)
        {

            //var data = new List<object>(){new { ID=1, Name="Arbet", Sex="男"},
            //    new { ID= 2, Name="Arbet1", Sex="女" },
            //    new {ID=3, Name="Arbet2",Sex="男" },
            //    new {ID=4, Name="Arbet3",Sex="女" },
            //    new {ID=5, Name="Arbet4",Sex="男" },
            //    new {ID=6, Name="Arbet5",Sex="男" },
            //    new {ID=7, Name="Arbet6",Sex="女" },
            //    new {ID=8, Name="Arbet7",Sex="男" },
            //    new { ID=9, Name="Arbet1", Sex="女" },
            //    new {ID=10, Name="Arbet2",Sex="男" },
            //    new {ID=11, Name="Arbet3",Sex="女" },
            //    new {ID=12, Name="Arbet4",Sex="男" },
            //    new {ID=13, Name="Arbet5",Sex="男" },
            //    new {ID=14, Name="Arbet6",Sex="女" },
            //    new {ID=15, Name="Arbet7",Sex="男" }
            //};
            //var total = data.Count;
            //var rows = data.Skip(offset).Take(limit).ToList();
            //return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);

            //数据显示

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
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
            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "ckmc";
            _p.sord = "asc";

            var _jx = new SD.Data.LamadaExtention<db_models.ckxxb>();
            List<db_models.ckxxb> tFindEntity = new List<db_models.ckxxb>();

            //查询按仓库名称
            if (Request["search"] != null && !string.IsNullOrEmpty(Request["search"].ToString()))
            {
                string _search = Request["search"].ToString();
                tFindEntity = _rs.FindList<db_models.ckxxb>(x => x.ckmc.Contains(_search), _p);
            }
            else
            {
                tFindEntity = _rs.FindList<db_models.ckxxb>(_p);
            }
            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<db_models.ckxxb>(tFindEntity);
            string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }

        public ActionResult Ckmc_Data(int? id)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.ckxxb tFindEntity = new db_models.ckxxb();

            //if (Request.IsAjaxRequest())
            //{
            //数据显示
            //     tFindEntity = _rs.FindEntity<db_models.ckxxb>(id);
            // }

            BK_MES_MVC.App_Code.ClassOne _class = new App_Code.ClassOne();



            if (id != null)
            {
                tFindEntity = _rs.FindEntity<db_models.ckxxb>(id);
            }
            else
            {
                tFindEntity.zdbh = null;
            }

            ViewBag.from_cklx = _class.abc<db_models.db_enum.enum_cklx, db_models.ckxxb>(tFindEntity);
            ViewBag.from_zt = _class.abc<db_models.db_enum.enum_zt, db_models.ckxxb>(tFindEntity);

            return View(tFindEntity);
        }

        public ActionResult Ckmc_Data_Save()
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                db_models.ckxxb _data = new db_models.ckxxb();

                TableRowToModel<db_models.ckxxb>(_data, Request.Form);

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                try
                {
                    if (_data.zdbh == null)
                    {
                        _data.jrrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
                        _rs.Insert<db_models.ckxxb>(_data);
                        _jsons.info = "数据增加成功!";
                    }
                    else
                    {
                        _data.xgrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
                        _data.xgsj = DateTime.Now;
                        _rs.Update<db_models.ckxxb>(_data);
                        _jsons.info = "数据修改成功!";
                    }
                    _jsons.info = "数据增加成功!";
                    _jsons.status = 1;
                }
                catch (Exception ex)
                {
                    _jsons.info = "数据处理失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();

        }

        public ActionResult Ckmc_Name_Exists()
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.ckxxb tFindEntity = new db_models.ckxxb();

            BK_MES_MVC.App_Code.ClassOne _class = new App_Code.ClassOne();

            string _cName = Request["ckmc"].ToString();
            string _cId = Request["id"].ToString();
            tFindEntity = _rs.FindEntity<db_models.ckxxb>(x => x.ckmc == _cName);
            if (tFindEntity != null)
            {
                if (_cId == "")
                {
                    //增加查询
                    return Content("{\"valid\":false}");
                }
                else
                {
                    //修改查询
                    int _iId = Int32.Parse(_cId);
                    if (tFindEntity.zdbh == _iId)
                    {
                        return Content("{\"valid\":true}");
                    }
                    else
                    {
                        return Content("{\"valid\":false}");
                    }
                }
            }
            return Content("{\"valid\":true}");
        }

        public ActionResult Ckmc_Data_Delete(int Id)
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                db_models.ckxxb _data = new db_models.ckxxb();

                _data.zdbh = Id;

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                try
                {
                    _rs.Delete<db_models.ckxxb>(_data);
                    _jsons.info = "数据删除成功!";
                    _jsons.status = 1;
                }
                catch (Exception ex)
                {
                    _jsons.info = "数据删除失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();

        }


        //public static Dictionary<object, object> GetProperties<T>(T t)
        //{
        //    var ret = new Dictionary<object, object>();
        //    if (t == null) { return null; }
        //    PropertyInfo[] properties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
        //    if (properties.Length <= 0) { return null; }
        //    foreach (PropertyInfo item in properties)
        //    {
        //        string name = item.Name;
        //        object value = item.GetValue(t, null);
        //        if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
        //        {
        //            ret.Add(name, value);
        //        }
        //    }
        //    return ret;
        //}

        public T TableRowToModel<T>(T objmodel, System.Collections.Specialized.NameValueCollection form)
        {
            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                string name = info.Name;

                if (form.GetValues(name) != null)
                {
                    //如果不是泛型
                    if (!info.PropertyType.IsGenericType)
                    {
                        //枚举类型
                        if (info.PropertyType.IsEnum)
                        {
                            info.SetValue(objmodel, string.IsNullOrEmpty(form.GetValues(name).GetValue(0).ToString()) ? "&nbsp;" : Enum.Parse(info.PropertyType, form.GetValues(name).GetValue(0).ToString()),null);
                        }
                        else
                        {
                            //如果是空则设置空，非空则设置值。
                            info.SetValue(objmodel, string.IsNullOrEmpty(form.GetValues(name).GetValue(0).ToString()) ? "&nbsp;" : Convert.ChangeType(form.GetValues(name).GetValue(0).ToString().Trim(), info.PropertyType), null);
                        }
                    }
                    //如果是泛型，则找他的基础类型
                    else if (info.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        info.SetValue(objmodel, string.IsNullOrEmpty(form.GetValues(name).GetValue(0).ToString()) ? "&nbsp;" : Convert.ChangeType(form.GetValues(name).GetValue(0).ToString(), Nullable.GetUnderlyingType(info.PropertyType)), null);
                    }
                }
            }
            return objmodel;
        }

        /// <summary>
        /// 仓库库位名称管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Ck_KWMcgl()
        {
            return View();
        }

        /// <summary>
        /// 仓库库位名称显示
        /// </summary>
        /// <returns></returns>
        public ActionResult Ck_KwMc_GetData(int limit, int offset)
        {
            //数据显示

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
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
            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "ckmc";
            _p.sord = "asc";

            var _jx = new SD.Data.LamadaExtention<db_models.ckxxb>();
            List<db_models.ckxxb> tFindEntity = new List<db_models.ckxxb>();

            //查询按仓库名称
            if (Request["search"] != null && !string.IsNullOrEmpty(Request["search"].ToString()))
            {
                string _search = Request["search"].ToString();
                tFindEntity = _rs.FindList<db_models.ckxxb>(x => x.ckmc.Contains(_search) && x.ckzt == db_models.db_enum.enum_zt.可用, _p);
            }
            else
            {
                tFindEntity = _rs.FindList<db_models.ckxxb>(x => x.ckzt == db_models.db_enum.enum_zt.可用, _p);
            }
            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<db_models.ckxxb>(tFindEntity);
            string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }

        /// <summary>
        /// 库位排号显示
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public ActionResult Ck_KwMc_GetData_ph(int limit, int offset, int ckbh)
        {
            //数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
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
            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "排名称";
            _p.sord = "asc";

            //List<Models.GroupByModels> _GroupbyModels = new List<Models.GroupByModels>();
            //var abc = _rs.IQueryable<db_models.cpkwpzb>(x => x.kwzt == db_models.db_enum.enum_zt.可用).GroupBy(x => new { x.ph }).Select(x => new { cc = x.Count(), ph = x.Key }).OrderBy(x => x.ph).Skip(_p.rows * (_p.page - 1)).Take(_p.rows);
            //foreach (var _s in abc)
            //{
            //    _GroupbyModels.Add(new Models.GroupByModels { gbKey = _s.ph.ph.ToString(), gbCount = _s.cc });
            //}

            //string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.GroupByModels>(_GroupbyModels);
            //string _json = "{\"total\":10" + ",\"rows\":" + _datajson + "}";
            // return Content(_json);

            List<Models.GroupByModels> _GroupbyModels = new List<Models.GroupByModels>();
            _GroupbyModels = _rs.IQueryable<Models.GroupByModels>("Select A.排名称 as gbName,A.自动编号 as gbKey,case when B.状态 is null then 0 else Count(1) end  as gbCount,B.状态 From 仓库库位排号表 A left outer join 仓库库位配置表 B On A.自动编号 = B.排编号  Where A.仓库编号 = " + ckbh.ToString() + " group by A.排名称, A.自动编号, B.状态 having isnull(B.状态, 1) = 1"
                                                ,_p).ToList();

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.GroupByModels>(_GroupbyModels);
            string _json = "{\"total\":"+ _p.records.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }

        /// <summary>
        /// 排名称位号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Data_PMC(int ph, int ckbh)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.ckxx_kwph tFindEntity = new db_models.ckxx_kwph();

            //if (Request.IsAjaxRequest())
            //{
            //数据显示
            //     tFindEntity = _rs.FindEntity<db_models.ckxxb>(id);
            // }

            if (ph > 0)
            {
                tFindEntity = _rs.FindEntity<db_models.ckxx_kwph>(ph);
            }
            if (ckbh > 0)
            {
                tFindEntity.ckbh = ckbh;
            }


            return View(tFindEntity);
        }

        public ActionResult Pmc_Name_Exists()
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.ckxx_kwph tFindEntity = new db_models.ckxx_kwph();

            string _cName = Request["pmc"].ToString();
            string _cId = Request["id"].ToString();
            int _iCkbm = int.Parse(Request["ck"].ToString());

            tFindEntity = _rs.FindEntity<db_models.ckxx_kwph>(x => x.pmc == _cName && x.ckbh == _iCkbm);
            if (tFindEntity != null)
            {
                if (_cId == "")
                {
                    //增加查询
                    return Content("{\"valid\":false}");
                }
                else
                {
                    //修改查询
                    int _iId = Int32.Parse(_cId);
                    if (tFindEntity.zdbh == _iId)
                    {
                        return Content("{\"valid\":true}");
                    }
                    else
                    {
                        return Content("{\"valid\":false}");
                    }
                }
            }
            return Content("{\"valid\":true}");
        }


        ///
        public ActionResult Data_Save_PMC()
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                db_models.ckxx_kwph _data = new db_models.ckxx_kwph();

                TableRowToModel<db_models.ckxx_kwph>(_data, Request.Form);

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                try
                {
                    if (_data.zdbh == null)
                    {
                        _rs.Insert<db_models.ckxx_kwph>(_data);
                        _jsons.info = "数据增加成功!";
                    }
                    else
                    {
                        _rs.Update<db_models.ckxx_kwph>(_data);
                        _jsons.info = "数据修改成功!";
                    }
                    _jsons.info = "数据增加成功!";
                    _jsons.status = 1;
                }
                catch (Exception ex)
                {
                    _jsons.info = "数据处理失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();

        }

        public ActionResult Data_Delete_PMC(int Id)
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                db_models.ckxx_kwph _data = new db_models.ckxx_kwph();

                _data.zdbh = Id;

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                try
                {
                    _rs.Delete<db_models.ckxx_kwph>(_data);
                    _jsons.info = "数据删除成功!";
                    _jsons.status = 1;
                }
                catch (Exception ex)
                {
                    _jsons.info = "数据删除失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();
        }


        public ActionResult Ck_KwMc_GetData_ph_wz(int ph)
        {
            //数据显示
            ViewBag.ph = ph;
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.PwModels> _pwModels = new List<Models.PwModels>();
            _pwModels = _rs.FindList<Models.PwModels>("Select A.排名称 as pmc,B.自动编号 as zdbh,B.层号 as ch,B.位号 as wh,B.其他 as qt,B.状态 as zt,B.间距 as jj From 仓库库位排号表 A left outer join 仓库库位配置表 B On A.自动编号 = B.排编号 Where A.自动编号 = " + ph.ToString() + " And B.状态 = 1 order by 层号,位号");

            int _ch = 0;
            int _twh = 0, _wh = 0;
            int _iwh = 0;
            StringBuilder _table_th = new StringBuilder();
            StringBuilder _table_td = new StringBuilder();
            foreach (Models.PwModels _kw in _pwModels)
            {
                if (_ch != _kw.ch)
                {
                    if (_ch != 0)
                    {
                        _table_td.Append("</tr>");
                    }

                    _ch = _kw.ch;
                    _table_td.AppendFormat("<tr><td>{0}</td>", _ch);
                    _iwh = 0;
                }

                _wh = _kw.wh;
                if (_twh < _wh)
                {
                    _twh = _wh;
                }

                _iwh += 1;

                string _color = "#FFFFFF";
                switch (_kw.jj)
                {
                    case db_models.db_enum.enum_kwdx.大:
                        _color = "#7FFF00";
                        break;
                    case db_models.db_enum.enum_kwdx.中:
                        _color = "#76EEC6";
                        break;
                    case db_models.db_enum.enum_kwdx.小:
                        _color = "#63B8FF";
                        break;
                }

                if (_iwh == _kw.wh)
                {
                    _table_td.Append(string.Format("<td style=\"background:{2}\" title=\"{2}\" >{0}<input type = \"checkbox\" onclick = \"check_bet(this,{1})\" id=\"{1}\"></td>", _kw.pmc + "_" + _kw.wh + "_" + _kw.ch + "(" + _kw.jj + ")", _kw.zdbh, _color));
                }
                else
                {
                    for (int i = 0; i < _wh - _iwh; i++)
                    {
                        _table_td.Append("<td></td>");
                    }
                    _iwh += _wh - _iwh;
                    _table_td.Append(string.Format("<td style=\"background:{2}\" title=\"{2}\">{0}<input type = \"checkbox\" onclick = \"check_bet(this,{1})\" id=\"{1}\"></td>", _kw.pmc + "_" + _kw.wh + "_" + _kw.ch + "(" + _kw.jj + ")", _kw.zdbh, _color));
                }

            }

            ViewBag.phmc = "";
            if (_pwModels != null && _pwModels.Count > 0)
            {
                ViewBag.phmc = _pwModels[0].pmc + "排货架";
            }

            for (int i = 1; i <= _twh; i++)
            {
                _table_th.AppendFormat("<th>{0}</th>", i.ToString());
            }

            _table_td.Append("</tr>");

            ViewBag.Tr = _table_td.ToString();
            ViewBag.Th = _table_th.ToString();


            //


            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.PwModels>(_pwModels);
            string _json = "{\"total\":1000" + ",\"rows\":" + _datajson + "}";
            //return Content(_json);
            return View();
        }

        public ActionResult Data_Ph_wz(int ph)
        {
            ViewBag.ph = ph;
            return View();
        }


        //    return View(tFindEntity);
        //}


        public ActionResult Save_Ph_wz(int ph)
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                List<db_models.cpkwpzb> _data = new List<db_models.cpkwpzb>();

                int rowx = int.Parse(Request.Form["rowx"].ToString());
                int columny = int.Parse(Request.Form["columny"].ToString());
                // int _ph = int.Parse(Request.Form["ph"].ToString());
                int _ph = ph;

                //提取排号的层数和列数
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                List<Models.PwModels> _xy = new List<Models.PwModels>();
                _xy = _rs.FindList<Models.PwModels>("select isnull(Max(位号),0) as maxwh,isnull(Max(层号),0) as maxch from 仓库库位配置表 where 排编号 = " + ph.ToString());

                db_models.db_enum.enum_kwdx _defalut_jj = db_models.db_enum.enum_kwdx.中;

                if (_xy[0].maxch == 0 && _xy[0].maxwh == 0 && rowx > 0 && columny > 0)
                {
                    for (int x = 1; x <= rowx; x++)
                    {
                        for (int y = 1; y <= columny; y++)
                        {
                            _data.Add(new db_models.cpkwpzb { ph = _ph, ch = x, wh = y, kwzt = db_models.db_enum.enum_zt.可用, jj = _defalut_jj });
                        }
                    }
                }

                if (_xy[0].maxch > 0 && _xy[0].maxwh > 0 && rowx > 0 && columny > 0)
                {
                    //先加层
                    for (int x = _xy[0].maxch + 1; x <= _xy[0].maxch + rowx; x++)
                    {
                        for (int y = 1; y <= _xy[0].maxwh; y++)
                        {
                            _data.Add(new db_models.cpkwpzb { ph = _ph, ch = x, wh = y, kwzt = db_models.db_enum.enum_zt.可用, jj = _defalut_jj });
                        }
                    }
                    //再加列
                    for (int x = 1; x <= _xy[0].maxch + rowx; x++)
                    {
                        for (int y = _xy[0].maxwh + 1; y <= _xy[0].maxwh + columny; y++)
                        {
                            _data.Add(new db_models.cpkwpzb { ph = _ph, ch = x, wh = y, kwzt = db_models.db_enum.enum_zt.可用, jj = _defalut_jj });
                        }
                    }
                }

                //加列
                if (_xy[0].maxch > 0 && _xy[0].maxwh > 0 && rowx == 0 && columny > 0)
                {
                    for (int x = 1; x <= _xy[0].maxch; x++)
                    {
                        for (int y = _xy[0].maxwh + 1; y <= _xy[0].maxwh + columny; y++)
                        {
                            _data.Add(new db_models.cpkwpzb { ph = _ph, ch = x, wh = y, kwzt = db_models.db_enum.enum_zt.可用, jj = _defalut_jj });
                        }
                    }
                }

                //加层
                if (_xy[0].maxch > 0 && _xy[0].maxwh > 0 && rowx > 0 && columny == 0)
                {
                    for (int x = _xy[0].maxch + 1; x <= _xy[0].maxch + rowx; x++)
                    {
                        for (int y = 1; y <= _xy[0].maxwh; y++)
                        {
                            _data.Add(new db_models.cpkwpzb { ph = _ph, ch = x, wh = y, kwzt = db_models.db_enum.enum_zt.可用, jj = _defalut_jj });
                        }
                    }
                }

                //数据显示
                try
                {

                    _rs.Insert<db_models.cpkwpzb>(_data);
                    _jsons.info = "数据增加成功!";

                    _jsons.info = "数据增加成功!";
                    _jsons.status = 1;
                }
                catch (Exception ex)
                {
                    _jsons.info = "数据处理失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        //public ActionResult Data_Delete_Ph_wz(List<Models.PwModels> lb, string clb)
        public ActionResult Data_Delete_Ph_wz(int ph, string clb)
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                db_models.cpkwpzb _data = new db_models.cpkwpzb();

                string _info = clb == "c" ? "列" : "行";

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                try
                {
                    _rs.FindList<BK_MES_MVC.Models.JsonSuccess>(string.Format("Execute pr_仓库库位删除 {0},{1}", ph, clb));
                    _jsons.info = "数据" + _info + "删除成功!";
                    _jsons.status = 1;
                }
                catch (Exception ex)
                {
                    _jsons.info = "数据" + _info + "删除失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        public ActionResult Data_Ph_dx(string id)
        {
            BK_MES_MVC.App_Code.ClassOne _class = new App_Code.ClassOne();

            db_models.cpkwpzb _data = new db_models.cpkwpzb();
            ViewBag.from_dx = _class.abc<db_models.db_enum.enum_kwdx, db_models.cpkwpzb>(_data);
            ViewBag.from_id = id;

            return View(_data);

        }

        public ActionResult Save_Ph_dx()
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();


                var _dx = Enum.Parse(typeof(db_models.db_enum.enum_kwdx), Request.Form["jj"].ToString());

                List<db_models.cpkwpzb> _data = new List<db_models.cpkwpzb>();

                foreach (string _st in Request.Form["ids"].ToString().Split(','))
                {
                    if (string.IsNullOrEmpty(_st))
                        continue;

                    _data.Add(new db_models.cpkwpzb { zdbh = int.Parse(_st), jj = (db_models.db_enum.enum_kwdx)_dx });
                }

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                try
                {
                    _rs.Update<db_models.cpkwpzb>(_data, new List<string> { "jj" });
                    _jsons.info = "数据更新成功!";
                    _jsons.status = 1;
                }
                catch (Exception ex)
                {
                    _jsons.info = "数据更新失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        public ActionResult Temp()
        {
            BK_MES_MVC.Models.tmpa _tm = new BK_MES_MVC.Models.tmpa();

            if (Request.QueryString["id"] != null)
            {
                _tm.sa = Request.QueryString["id"].ToString();
                _tm.sb = "cc";


                return Json(_tm, JsonRequestBehavior.AllowGet);

            }

            return View(_tm);
        }


        /// <summary>
        /// 订单 显示界面
        /// </summary>
        /// <returns></returns>
        public ActionResult DingDan_View()
        {
            //父子表,父表显示订单，子表显示订单明细
            return View();
        }

        /// <summary>
        /// 订单导入
        /// </summary>
        /// <returns></returns>
        public ActionResult DingDan_Input_Import()
        {
            //如果有很多空白的列,可以选择表格但要多选一列

            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();
                db_models.ckxxb _ts = new db_models.ckxxb();

                _jsons.info = "数据增加成功!";
                _jsons.mess = "数据增加成功!";
                _jsons.status = 1;


                string _txt = Request["excel_dingdan"].ToString().Replace("\"（净重）\n实交量\"", "实交量");
                List <Models.ExcelModels> _sr = new List<Models.ExcelModels>();
                //
                try
                {
                    var s2 = _txt.Split(new string[] { "\n" }, StringSplitOptions.None);
                    foreach (var s1 in _txt.Split(new string[] { "\n" }, StringSplitOptions.None).Where(s => !string.IsNullOrEmpty(s)))
                    {
                        string[] _st = s1.Split(new string[] { "\t" }, StringSplitOptions.None);
                        Models.ExcelModels _tmp = new Models.ExcelModels();
                        for (int i = 0; i < 21; i++)
                        {
                            string _sa = "A" + i.ToString();
                            if (i < _st.Length)
                            {
                                _tmp.GetType().GetProperty(_sa).SetValue(_tmp, _st[i].Trim(), null);
                            }
                            else
                            {
                                _tmp.GetType().GetProperty(_sa).SetValue(_tmp, null, null);
                            }
                        }
                        _sr.Add(_tmp);
                    }

                    //格式判断,第一行必须有[新余新钢金属制品有限公司钢丝发货磅单]
                    if (_sr[0].A0.IndexOf("发货")<0)
                    {
                        _jsons.info = "格式错误!";
                        _jsons.mess = "请从[发货磅单]行开始复制";
                        _jsons.status = 0;
                        return Json(_jsons, JsonRequestBehavior.AllowGet);
                    }


                    //保存
                    //订单头插入
                    db_models.dingdan_t _dinddan_t = new db_models.dingdan_t();

                    DateTime _t_a1;
                    DateTime _date;
                    if (DateTime.TryParse(_sr[1].A1, out _date))
                    { _t_a1 = _date; }
                    else
                    {
                        _jsons.info = "订单日期无效,请输入正确的日期格式!";
                        _jsons.mess = "yyyy/mm/dd";
                        _jsons.status = 0;
                        return Json(_jsons, JsonRequestBehavior.AllowGet);
                    }

                    //保存前先判断是否已经导入
                    //判断条件[订单日期][订货单位]

                    string _khmc = _sr[2].A1;
                    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                    //if (_rs.FindEntity<db_models.dingdan_t>(x => x.dhrq == _t_a1 && x.khmc == _khmc) != null)
                    //{
                    //    _jsons.info = "数据重复!";
                    //    _jsons.mess = "数据已经存在";
                    //    _jsons.status = 0;
                    //    return Json(_jsons, JsonRequestBehavior.AllowGet);
                    //}

                    _dinddan_t = new db_models.dingdan_t
                    {
                        dhrq = _t_a1,
                        khmc = _sr[2].A1,
                        bz = _sr[2].A3
                    };

                    int icount = 0;
                    //
                    //第四行 表头
                    //需要的 钢号,规格,组别,品种,应交量,客户代码,客户名称,备注1,备注2,备注3
                    //
                    Models.ExcelFields _ef = new Models.ExcelFields();
                    
                    for (int i = 0; i < 21; i++)
                    {
                        string _sa = "A" + i.ToString();
                        var _fv = _sr[3].GetType().GetProperty(_sa).GetValue(_sr[3]);
                        if (_fv == null)
                            continue;

                        switch (_fv.ToString().Trim().Replace(" ",""))
                        {
                            case "钢号":
                                _ef.E_gh = _sa;
                                break;
                            case "规格":
                                _ef.E_gg = _sa;
                                break;
                            case "组别":
                                _ef.E_zb = _sa;
                                break;
                            case "品种":
                                _ef.E_pz = _sa;
                                break;
                            case "应交量":
                                _ef.E_yjl = _sa;
                                break;
                            case "客户代码":
                                _ef.E_khdm = _sa;
                                break;
                            case "客户名称":
                                _ef.E_khmc = _sa;
                                break;
                            case "备注1":
                                _ef.E_bz1 = _sa;
                                break;
                            case "备注2":
                                _ef.E_bz2 = _sa;
                                break;
                            case "备注3":
                                _ef.E_bz3 = _sa;
                                break;
                        }
                    }

                    //
                    List<db_models.dingdan_m> _dinddan_m = new List<db_models.dingdan_m>();
                    foreach (Models.ExcelModels _s in _sr)
                    {
                        icount += 1;

                        if (_s.A0 == "制单人")
                        {
                            _dinddan_t.ch = _s.A6;
                            _dinddan_t.zdr = _s.A1;
                            _dinddan_t.thr = _s.A7;
                            break;
                        }

                        if (icount < 5)
                            continue;

                        //if (_s.A0 == "" || _s.A0.Trim().Replace(" ", "") == "合计")/
                        //因为第一列可能是会为空值,所有去除了
                        if (_s.A0.Trim().Replace(" ", "") == "合计")
                            continue;

                        decimal _a1;
                        decimal.TryParse(_s.GetType().GetProperty(_ef.E_gg).GetValue(_s).ToString(), out _a1);

                        decimal _a4;
                        decimal.TryParse(_s.GetType().GetProperty(_ef.E_yjl).GetValue(_s).ToString(), out _a4);

                        string _khmc2 = null;
                        if (_ef.E_khmc != null)
                        {
                            _khmc2 = _s.GetType().GetProperty(_ef.E_khmc).GetValue(_s).ToString();
                        }

                        if(string.IsNullOrEmpty(_khmc2))
                        {
                            _khmc2 = _khmc; //使用表头的客户名称替换
                        }

                        //应交量,规格都为零的话重新循环下一条
                        if (_a4 == 0 && _a1==0)
                            continue;

                        string _gh = "";
                        if (_ef.E_gh != null)
                        {
                            _gh = _s.GetType().GetProperty(_ef.E_gh).GetValue(_s).ToString();
                        }


                        _dinddan_m.Add(new db_models.dingdan_m
                        {
                            gh = (_ef.E_gh==null?"": _s.GetType().GetProperty(_ef.E_gh).GetValue(_s).ToString())
                            ,
                            gg = _a1
                            ,
                            zb = (_ef.E_zb == null ? "" : _s.GetType().GetProperty(_ef.E_zb).GetValue(_s).ToString())
                            ,
                            cpmc = (_ef.E_pz == null ? "" : _s.GetType().GetProperty(_ef.E_pz).GetValue(_s).ToString())
                            ,
                            yjl = _a4 * 1000  //导入为:吨,系统为:公斤
                            ,
                            khdm = (_ef.E_khdm == null ? "" : _s.GetType().GetProperty(_ef.E_khdm).GetValue(_s).ToString())
                            ,
                            bz1 = (_ef.E_bz1 == null ? "" : _s.GetType().GetProperty(_ef.E_bz1).GetValue(_s).ToString())
                            ,
                            bz2 = (_ef.E_bz2 == null ? "" : _s.GetType().GetProperty(_ef.E_bz2).GetValue(_s).ToString())
                            ,
                            bz3 = (_ef.E_bz3 == null ? "" : _s.GetType().GetProperty(_ef.E_bz3).GetValue(_s).ToString())
                           ,
                            khmc2 = _khmc2
                            ,
                            jrrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"))
                        });
                    }

                   
                    _rs.BeginTrans();
                    int _key=_rs.Insert<db_models.dingdan_t>(_dinddan_t,"zdbh");
                    foreach(db_models.dingdan_m _dm in _dinddan_m)
                    {
                        _dm.dhtbh = _key;
                    }
                    _rs.Insert<db_models.dingdan_m>(_dinddan_m);

                    _rs.Insert<db_models.dingdan_t_zt>(new db_models.dingdan_t_zt { ddtbm = _key, jlrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm")), ddzt = 0 });

                    _rs.Commit();

                    _jsons.info = "保存成功!";

                }
                catch (Exception ex)
                {
                    _jsons.info = "数据保存失败!";
                    _jsons.mess = ex.Message;
                    _jsons.status = 0;

                }

                return Json(_jsons, JsonRequestBehavior.AllowGet);

            }

            return View();
        }

        /// <summary>
        /// 订单头输入界面
        /// </summary>
        /// <returns></returns>
        public ActionResult DingDan_Input_T(int? id)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.dingdan_t tFindEntity = new db_models.dingdan_t();
            db_models.dingdan_t_zt tFindEntity2 = new db_models.dingdan_t_zt();


            BK_MES_MVC.App_Code.ClassOne _class = new App_Code.ClassOne();

            if (id != null)
            {
                tFindEntity = _rs.FindEntity<db_models.dingdan_t>(id);
                tFindEntity2 = _rs.FindEntity<db_models.dingdan_t_zt>(x => x.ddtbm == id && x.ddzt == 0);
                ViewBag.form_ddzt_zdbh = tFindEntity2.zdbh;
            }
            else
            {
                tFindEntity.zdbh = null;
                tFindEntity.dhrq = DateTime.Today.Date;
            }

            List<SelectListItem> _a = new List<SelectListItem>();
            List<db_models.khxxb> tKhxxEntity = new List<db_models.khxxb>();
            tKhxxEntity = _rs.IQueryable<db_models.khxxb>().ToList();
            foreach (db_models.khxxb _k in tKhxxEntity)
            {
                _a.Add(new SelectListItem { Text = _k.khmc.ToString(), Value = _k.khbm.GetHashCode().ToString() });
            }

            ViewBag.form_khmc = _a;


            return View(tFindEntity);
        }

        /// <summary>
        /// 订单明细输入界面
        /// </summary>
        /// <returns></returns>
        public ActionResult DingDan_Input_M(int? id)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.dingdan_m tFindEntity = new db_models.dingdan_m();

            if (id != null)
            {
                tFindEntity = _rs.FindEntity<db_models.dingdan_m>(id);
            }
            else
            {
                tFindEntity.zdbh = null;
                tFindEntity.dhtbh = Int32.Parse(Request.QueryString["ddbh"].ToString());
            }

            //List<SelectListItem> _a = new List<SelectListItem>();
            //List<db_models.ChanPinMingCheng> tKhxxEntity = new List<db_models.ChanPinMingCheng>();
            //tKhxxEntity = _rs.IQueryable<db_models.ChanPinMingCheng>().ToList();
            //foreach (db_models.ChanPinMingCheng _k in tKhxxEntity)
            //{
            //    _a.Add(new SelectListItem { Text = _k.cpmc.ToString(), Value = _k.zdbh.GetHashCode().ToString() });
            //}

            //ViewBag.form_cpmc = _a;

            return View(tFindEntity);
        }

        /// <summary>
        /// 订单头保存
        /// </summary>
        /// <returns></returns>
        public ActionResult DingDan_Save_T()
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                db_models.dingdan_t _data = new db_models.dingdan_t();
                db_models.dingdan_t_zt _data_zt = new db_models.dingdan_t_zt();

                TableRowToModel<db_models.dingdan_t>(_data, Request.Form);

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                _rs.BeginTrans();
                try
                {
                    if (_data.zdbh == null)
                    {
                        int _key = _rs.Insert<db_models.dingdan_t>(_data, "zdbh");
                        _data_zt.ddzt = db_models.db_enum.enum_ddzt.未确认订单记录;
                        _data_zt.jlrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
                        _data_zt.ddtbm = _key;
                        _rs.Insert<db_models.dingdan_t_zt>(_data_zt);
                        _jsons.info = "数据增加成功!";
                    }
                    else
                    {
                        _rs.Update<db_models.dingdan_t>(_data);

                        _data_zt.ddtbm = (int)_data.zdbh;
                        _data_zt.xgrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
                        _data_zt.xgrq = DateTime.Now;
                        _data_zt.zdbh = Convert.ToInt32(Request.Form["ddzt_zdbh"].ToString());
                        _rs.Update<db_models.dingdan_t_zt>(_data_zt, new List<string>() { "xgrbm", "xgrq" });
                        _jsons.info = "数据修改成功!";
                    }
                    _rs.Commit();
                    _jsons.info = "数据增加成功!";
                    _jsons.status = 1;
                }
                catch (Exception ex)
                {
                    _jsons.info = "数据处理失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();

        }

        /// <summary>
        /// 订单明细保存
        /// </summary>
        /// <returns></returns>
        public ActionResult DingDan_Save_M()
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                db_models.dingdan_m _data = new db_models.dingdan_m();

                TableRowToModel<db_models.dingdan_m>(_data, Request.Form);

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                try
                {
                    if (_data.zdbh == null)
                    {
                        _data.jrrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
                        //_data.jrrq = DateTime.Now;
                        _rs.Insert<db_models.dingdan_m>(_data);
                        _jsons.info = "数据增加成功!";
                    }
                    else
                    {
                        _data.xgrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
                        _data.xgrq = DateTime.Now;
                        _rs.Update<db_models.dingdan_m>(_data);
                        _jsons.info = "数据修改成功!";
                    }
                    _jsons.info = "数据增加成功!";
                    _jsons.status = 1;
                }
                catch (Exception ex)
                {
                    _jsons.info = "数据处理失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        /// <summary>
        /// 订单删除
        /// </summary>
        /// <returns></returns>
        public ActionResult DingDan_Delete_T(int id)
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                db_models.dingdan_t _data = new db_models.dingdan_t();

                _data.zdbh = id;

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                try
                {
                    _rs.BeginTrans();
                    _rs.Delete<db_models.dingdan_t>(_data);
                    _rs.Delete<db_models.dingdan_t_zt>(x => x.ddtbm == id && x.ddzt == 0);
                    _rs.Delete<db_models.dingdan_m>(x => x.dhtbh == id);
                    _rs.Commit();

                    _jsons.info = "数据删除成功!";
                    _jsons.status = 1;
                }
                catch (Exception ex)
                {
                    _jsons.info = "数据删除失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();

        }

        public ActionResult DingDan_Delete_M(int id)
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                db_models.dingdan_m _data = new db_models.dingdan_m();

                _data.zdbh = id;

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                try
                {
                    _rs.Delete<db_models.dingdan_m>(_data);
                    _jsons.info = "数据删除成功!";
                    _jsons.status = 1;
                }
                catch (Exception ex)
                {
                    _jsons.info = "数据删除失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();

        }


        /// <summary>
        /// 回滚
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DingDan_Qx_x(int id, int zt)
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();
                _jsons.info = "订单处理成功";
                _jsons.status = 1;

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                try
                {
                    //配货撤销到订单未确认状态
                    if (zt==3)
                    {
                        _rs.Delete<db_models.dingdan_t_zt>(x => x.ddtbm == id && x.ddzt > db_models.db_enum.enum_ddzt.未确认订单记录);
                        _rs = new SD.Data.RepositoryBase();
                        _rs.FindList<BK_MES_MVC.Models.One>(@"delete A from 成品库存锁定表 A inner join 订货明细表 B on A.销售订单编号=B.自动编号 inner join 订货头表 C on B.订货头编号=C.自动编号 where C.自动编号=" + id.ToString());
                    }
                    //装车撤销到配货未确认状态
                    if(zt==4)
                    {
                        _rs.Delete<db_models.dingdan_t_zt>(x => x.ddtbm == id && x.ddzt > db_models.db_enum.enum_ddzt.正在配货记录);
                    }

                }
                catch (Exception ex)
                {
                    _jsons.info = "处理失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();
        }


            /// <summary>
            /// 撤销/确认已订单状态
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public ActionResult DingDan_QC_M(int id, int zt, int fs)
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();
                _jsons.info = "订单处理成功";
                _jsons.status = 1;

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                try
                {

                    db_models.dingdan_t_zt _data = new db_models.dingdan_t_zt();
                    if (fs == 0)
                    {
                        //撤销
                        //事务
                        _rs.BeginTrans();

                        if (_rs.FindEntity<db_models.dingdan_t_zt>(x => x.ddtbm == id && x.ddzt > (db_models.db_enum.enum_ddzt)zt) != null)
                        {
                            _jsons.info = "订单信息撤销失败,该订单已经进入到下一环节,请重新刷新页面!";
                            _jsons.status = 0;
                        }
                        else
                        {
                            _data = _rs.FindEntity<db_models.dingdan_t_zt>(x => x.ddtbm == id && x.ddzt == (db_models.db_enum.enum_ddzt)zt);
                            _rs.Delete(_data);

                            _data = new db_models.dingdan_t_zt();
                            _data = _rs.FindEntity<db_models.dingdan_t_zt>(x => x.ddtbm == id && x.ddzt == (db_models.db_enum.enum_ddzt)(zt - 1));
                            _data.xgrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
                            _data.xgrq = DateTime.Now;
                            _rs.Update<db_models.dingdan_t_zt>(_data, new List<string> { "xgrbm", "xgrq" });

                            _rs.Commit();

                            //配货撤销
                            if (zt == 3)
                            {
                                _rs = new SD.Data.RepositoryBase();
                                _rs.FindList<BK_MES_MVC.Models.One>(@"delete A from 成品配货表 A inner join 订货明细表 B on A.销售订单编号=B.自动编号 inner join 订货头表 C on B.订货头编号=C.自动编号 where C.自动编号=" + id.ToString());
                            }

                        }
                    }
                    if (fs == 1)
                    {
                        //先判断订单[应交量]是都大于零,[规格]是否都有,[组别]是否都有,[客户编码]是否都有
                        if (_rs.FindEntity<db_models.dingdan_m>(x => x.dhtbh == id && x.yjl <= 0) != null)
                        {
                            _jsons.info = "订单中还有未填写应交量的记录!";
                            _jsons.status = 0;
                            return Json(_jsons, JsonRequestBehavior.AllowGet);
                        }

                        if (_rs.FindEntity<db_models.dingdan_m>(x => x.dhtbh == id && (x.gg == 0 || x.gg == null)) != null)
                        {
                            _jsons.info = "订单中还有未设置规格的记录!";
                            _jsons.status = 0;
                            return Json(_jsons, JsonRequestBehavior.AllowGet);
                        }

                        //配货确认判断,如果订单明细表的数据不在锁定表中,说明没有配货,无法确认保存
                        if (zt == 2 && _rs.FindList<Models.One>(@"select top 1 自动编号 as iu
                                                                           from 订货明细表 A 
                                                                            Where 订货头编号=" + id.ToString() +
                                                                                @" And Not Exists(Select 1 from 成品库存锁定表 B Where B.销售订单编号=A.自动编号)").Count > 0)
                        {
                            _jsons.info = "有订单没有配货信息,无法确认!";
                            _jsons.status = 0;
                            return Json(_jsons, JsonRequestBehavior.AllowGet);
                        }
                        //装车确认
                        if (zt == 4 && _rs.FindEntity<db_models.dingdan_t>(x => x.zdbh == id && (x.ch == null || x.ch == "")) != null)
                        {
                            _jsons.info = "车号未输入,无法确认!";
                            _jsons.status = 0;
                            return Json(_jsons, JsonRequestBehavior.AllowGet);
                        }

                        //确认
                        _data.ddtbm = id;
                        _data.jlrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
                        _data.ddzt = (db_models.db_enum.enum_ddzt)(zt + 1);
                        _rs.Insert<db_models.dingdan_t_zt>(_data);

                        //配货确认
                        if (zt == 2)
                        {
                            _rs = new SD.Data.RepositoryBase();
                            //配货确认后,把锁定记录复制到[成品配货表]中
                            _rs.FindList<BK_MES_MVC.Models.One>(@"
                            insert into 成品配货表(成品信息编号, 销售订单编号, 配货日期, 配货人编码)
                                select A.成品库存编号,A.销售订单编号,A.锁定日期,A.锁定人 from 成品库存锁定表 A inner join 订货明细表 B on A.销售订单编号 = B.自动编号 inner join 订货头表 C on B.订货头编号 = C.自动编号
                                    where not exists(Select 1 from 成品配货表 D where d.成品信息编号 = A.成品库存编号 and D.销售订单编号 = A.销售订单编号) and C.自动编号=" + id.ToString());
                        }

                    }



                    //_jsons = _rs.IQueryable<BK_MES_MVC.Models.JsonSuccess>(string.Format("Execute pr_DingDan_Zt_Update {0},{1},{2}", id.ToString(), zt.ToString(), fs.ToString())).First();

                }
                catch (Exception ex)
                {
                    _jsons.info = "订单信息处理失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();

        }


        /// <summary>
        /// 订单查找
        /// </summary>
        /// <returns></returns>
        public ActionResult DingDan_Find(int limit, int offset)
        {
            //数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
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
            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "A.自动编号";
            _p.sord = "desc";

            string _where = "1=1";

            //权限判定
            //该用户的下级用户
            if (App_Code.WebHelper.GetCookie("qxbm") != "0")
            {
                if(Request["select"]==null)
                    _where += " And C.加入人编码=" + App_Code.WebHelper.GetCookie("yhbm");
            }

            if (Request["ddzt"] != null && !string.IsNullOrEmpty(Request["ddzt"].ToString()))
            {
                _where += " And C.订单状态 =" + Request["ddzt"].ToString() + "";
            }
            if (Request["rq1"] != null && Request["rq2"] != null && !String.IsNullOrEmpty(Request["rq1"].ToString()) && !String.IsNullOrEmpty(Request["rq2"].ToString()))
            {
                _where += " And A.订货日期 >= '" + Request["rq1"].ToString() + "' A.订货日期<Dateadd(day,1, '" + Request["rq2"].ToString() + "')";
            }

            if (Request["rq1"] != null && Request["rq2"] != null && !String.IsNullOrEmpty(Request["rq1"].ToString()) && String.IsNullOrEmpty(Request["rq2"].ToString()))
            {
                _where += " And A.订货日期 >= '" + Request["rq1"].ToString() + "'";
            }

            if (Request["rq1"] != null && Request["rq2"] != null && String.IsNullOrEmpty(Request["rq1"].ToString()) && !String.IsNullOrEmpty(Request["rq2"].ToString()))
            {
                _where += " And A.订货日期 <Dateadd(day,1,'" + Request["rq2"].ToString() + "')";
            }

            if(Request["dingdan_bh"]!=null && !String.IsNullOrEmpty(Request["dingdan_bh"]))
            {
                _where += " And A.自动编号=" + Request["dingdan_bh"].ToString();
            }


            if (Request["lb"] != null
                && !string.IsNullOrEmpty(Request["lb"].ToString())
                && Request["ddzt"] != null
                && !string.IsNullOrEmpty(Request["ddzt"].ToString())
                )
            {
                _where += " And C.订单状态 =" + Request["ddzt"].ToString() + "";
            }

            if (Request["search"] != null && !string.IsNullOrEmpty(Request["search"].ToString()))
            {
                _where += " And A.客户名称 like '%" + Request["search"].ToString() + "%'";

            }

            List<Models.DingDan_t> _DingDan_t = new List<Models.DingDan_t>();
            //_DingDan_t = _rs.IQueryable<Models.DingDan_t>(@"select A.订货日期 as dhrq
            //                                              , A.客户码 as khbm
            //                                              , C.加入时间 as jlrq
            //                                              , A.自动编号 as zdbh
            //                                              , B.客户名称 as khmc
            //                                              , B.客户后缀 as khhz
            //                                              , C.最新订单状态 as ddzt
            //                                              , C.最新订单状态 as ddztm
            //                                              , A.备注 as bz
            //                                             From 订货头表 A inner join 客户信息表 B on A.客户码 = B.客户编码
            //                                                             inner join(select C1.加入人编码, C1.订单头编码, C1.加入时间, C1.订单状态, C2.最新订单状态
            //                                                                                    from(select * from 订单状态表) C1 inner join
            //                                                                                         (select 订单头编码, max(订单状态) 最新订单状态 From 订单状态表 group by 订单头编码) C2 on C1.订单头编码 = C2.订单头编码 And C1.订单状态=C2.最新订单状态) C On A.自动编号 = C.订单头编码
            //                                             Where " + _where
            //                                                , _p).ToList();

            _DingDan_t = _rs.IQueryable<Models.DingDan_t>(@"select A.订货日期 as dhrq
                                                          , A.客户码 as khbm
                                                          , C.加入时间 as jlrq
                                                          , A.自动编号 as zdbh
                                                          , A.客户名称 as khmc
                                                          , C.最新订单状态 as ddzt
                                                          , C.最新订单状态 as ddztm
                                                          , A.备注 as bz
                                                          ,A.制单人 as zdr
                                                          ,车号 as ch
                                                          ,提货人 as thr
                                                         From 订货头表 A inner join(select C1.加入人编码, C1.订单头编码, C1.加入时间, C1.订单状态, C2.最新订单状态
                                                                                 from 订单状态表 C1 inner join
                                                                                                     (select 订单头编码, max(订单状态) 最新订单状态 From 订单状态表 group by 订单头编码) C2 on C1.订单头编码 = C2.订单头编码 And C1.订单状态=C2.最新订单状态) C On A.自动编号 = C.订单头编码
                                                         Where " + _where
                                                           , _p).ToList();


            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.DingDan_t>(_DingDan_t);
            string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }

        /// <summary>
        /// 明细订单查询
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public ActionResult DingDan_Find_M(int limit, int offset, int ddbh)
        {
            //数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
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
            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "A.自动编号";
            _p.sord = "asc";

            string _where = "";
            if (Request["search"] != null && !string.IsNullOrEmpty(Request["search"].ToString()))
            {
                _where = " And B.产品名称 like '%" + Request["search"].ToString() + "%'";

            }

            List<Models.DingDan_m> _DingDan_t = new List<Models.DingDan_m>();
            //_DingDan_t = _rs.IQueryable<Models.DingDan_m>("select A.订货头编号 as ddtbh,A.成品编码 as cpbm,A.钢号 as gh,A.规格 as gg,A.组别 as zb,'' as bzmc,A.应交量 as yjl,A.备注1 as bz1,A.备注2 as bz2,A.加入日期 as jrrq,A.自动编号 as zdbh,B.产品名称 as cpmc,C.s_sl,C.s_zl,Round((C.s_zl/A.应交量-1)*100,2) as s_bl,A.客户_编码 as kh_bm,A.客户_订单号 as kh_ddh,A.客户_物料编码 as kh_wlbm from 订货明细表 A inner join 产品表_2 B on A.成品编码=B.自动编号 left outer join (select Count(1) as s_sl,Sum(重量) as s_zl,C1.销售订单编号 s_dh from [成品库存锁定表] C1 inner join 成品信息表_4 C2 On C1.成品库存编号=C2.自动编号 Group By 销售订单编号) C On A.自动编号=C.s_dh Where 订货头编号=" + ddbh.ToString() + _where
            //                                                , _p).ToList();

            _DingDan_t = _rs.IQueryable<Models.DingDan_m>("select A.订货头编号 as ddtbh,A.成品编码 as cpbm,A.钢号 as gh,A.规格 as gg,A.组别 as zb,'' as bzmc,A.应交量 as yjl,A.备注1 as bz1,A.备注2 as bz2,A.备注3 as bz3,A.客户代码 as khdm,A.加入日期 as jrrq,A.自动编号 as zdbh,A.产品名称 as cpmc,C.s_sl,C.s_zl,Convert(Decimal,Round((C.s_zl/A.应交量-1)*100,2)) as s_bl,A.客户_编码 as kh_bm,A.客户_订单号 as kh_ddh,A.客户_物料编码 as kh_wlbm,A.客户名称2 as khmc2 from 订货明细表 A left outer join (select Count(1) as s_sl,Convert(Decimal,Sum(净重)) as s_zl,C1.销售订单编号 s_dh from [成品库存锁定表] C1 inner join 成品信息表_4 C2 On C1.成品库存编号=C2.自动编号 Group By 销售订单编号) C On A.自动编号=C.s_dh Where 订货头编号=" + ddbh.ToString() + _where
                                                            , _p).ToList();

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.DingDan_m>(_DingDan_t);
            string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }

        //public ActionResult DingDan_Find_Select(int limit, int offset)
        //{
        //    //数据显示
        //    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
        //    //加入分页
        //    SD.Data.Pagination _p = new SD.Data.Pagination();
        //    if (Request["page"] == null)
        //    {
        //        _p.page = 1;
        //    }
        //    else
        //    {
        //        _p.page = Int32.Parse(Request["page"].ToString());
        //    }
        //    _p.page = offset / limit + 1;
        //    _p.rows = limit;
        //    _p.sidx = "B.产品名称";
        //    _p.sord = "desc";

        //    string _where = "1=1";
        //    if (Request["search"] != null && !string.IsNullOrEmpty(Request["search"].ToString()))
        //    {
        //        _where += " And A.客户_订单号 like '%" + Request["search"].ToString() + "%'";

        //    }

        //    List<Models.DingDan_m> _DingDan_t = new List<Models.DingDan_m>();
        //    //_DingDan_t = _rs.IQueryable<Models.DingDan_m>("select A.订货头编号 as ddtbh,A.成品编码 as cpbm,A.钢号 as gh,A.规格 as gg,A.组别 as zb,'' as bzmc,A.备注1 as bz1,A.备注2 as bz2,A.加入日期 as jrrq,A.自动编号 as zdbh,B.产品名称 as cpmc,A.客户_编码 as kh_bm,A.客户_订单号 as kh_ddh,A.客户_物料编码 as kh_wlbm from 订货明细表 A inner join 产品表_2 B on A.成品编码=B.自动编号  Where "  + _where
        //    //                                               , _p).ToList();

        //    _DingDan_t = _rs.IQueryable<Models.DingDan_m>("select A.成品编码 as cpbm,A.钢号 as gh,A.规格 as gg,A.组别 as zb,'' as bzmc,B.产品名称 as cpmc,A.客户_编码 as kh_bm,A.客户_订单号 as kh_ddh,A.客户_物料编码 as kh_wlbm,jrrq from (select 成品编码,钢号,规格,组别,客户_编码,客户_订单号,客户_物料编码,Max(加入日期) as jrrq from 订货明细表 group by 成品编码,钢号,规格,组别,客户_编码,客户_订单号,客户_物料编码) A inner join 产品表_2 B on A.成品编码=B.自动编号 Where " + _where
        //                                                   , _p).ToList();


        //    string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.DingDan_m>(_DingDan_t);
        //    string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
        //    return Content(_json);
        //}

        /// <summary>
        /// 订单选择
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="ddbh"></param>
        /// <returns></returns>
        public ActionResult DingDan_Select(int limit, int offset, int ddbh)
        {

            return View();
        }


        /// <summary>
        /// 配货 显示界面
        /// </summary>
        /// <returns></returns>
        public ActionResult PeiHuo_View()
        {
            //列表，显示配货，子表显示配货明细

            //SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            //List<SelectListItem> _a = new List<SelectListItem>();
            //List<db_models.khxxb> tKhxxEntity = new List<db_models.khxxb>();
            //tKhxxEntity = _rs.IQueryable<db_models.khxxb>().ToList();
            //foreach (db_models.khxxb _k in tKhxxEntity)
            //{
            //    _a.Add(new SelectListItem { Text = _k.khmc.ToString(), Value = _k.khbm.GetHashCode().ToString() });
            //}

            //ViewBag.form_khxxb = _a;

            return View();
        }


        /// <summary>
        /// 订单接收
        /// </summary>
        /// <param name="id"></param>
        /// <param name="zt"></param>
        /// <param name="fs"></param>
        /// <returns></returns>
        public ActionResult PeiHuo_Receive(Models.PeiHuo[] mPh)
        {
            //if (Request.IsAjaxRequest())
            //{
            //    BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

            //    //数据显示
            //    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            //    try
            //    {
            //        _jsons = _rs.IQueryable<BK_MES_MVC.Models.JsonSuccess>("Execute pr_DingDan_Zt_Update '',1,2").First();

            //    }
            //    catch (Exception ex)
            //    {
            //        _jsons.info = "订单信息接收失败!";
            //        _jsons.status = 0;
            //    }
            //    return Json(_jsons, JsonRequestBehavior.AllowGet);
            //}
            //return View();

            List<db_models.dingdan_t_zt> _sdb = new List<db_models.dingdan_t_zt>();
            foreach (Models.PeiHuo _p in mPh)
            {
                _sdb.Add(new db_models.dingdan_t_zt() { ddtbm = _p.zdbh, jlrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm")), ddzt = db_models.db_enum.enum_ddzt.正在配货记录 });
            }

            BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            try
            {
                _rs.Insert<db_models.dingdan_t_zt>(_sdb);
                _jsons.info = "订单信息接收成功!";
                _jsons.status = 1;
            }
            catch (Exception)
            {
                _jsons.info = "订单信息接收失败!";
                _jsons.status = 0;
            }
            return Json(_jsons, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 配货 显示界面
        /// </summary>
        /// <returns></returns>
        public ActionResult PeiHuo_View_1(int ddbh, string dhrq, string khmc)
        {
            //列表，显示配货，子表显示配货明细
            //
            ViewBag.ddbh = ddbh;
            ViewBag.dhrq = dhrq;
            ViewBag.khmc = khmc;

            return View();
        }

        /// <summary>
        /// 配货与订单关联显示
        /// </summary>
        /// <returns></returns>
        public ActionResult PeiHuo_Find_1(int ddbh)
        {
            //数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.DingDan_t_m> _DingDan_t = new List<Models.DingDan_t_m>();
            _DingDan_t = _rs.IQueryable<Models.DingDan_t_m>("select A.订货日期 as dhrq,B.客户名称 as khmc,B.客户后缀 as khhz ,D.产品名称 as cpmc,C.钢号 as gh,C.规格 as gg,C.组别 as zb,C.应交量 as yjl,C.备注 as bz,C.操作日期 as czrq,C.自动编号 as ddzdbh from 订货头表 A inner join 客户信息表 B on A.客户码=B.客户编码 inner join 订货明细表 C on A.自动编号 =C.订货头编号 inner join 产品表_2 D on C.成品编码=D.自动编号 where A.自动编号=" + ddbh.ToString()).ToList();

            ViewBag.dhrq = _DingDan_t[0].dhrq.ToString("yyyy-MM-dd");
            ViewBag.khmc = _DingDan_t[0].khmc.ToString();

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.DingDan_t_m>(_DingDan_t);
            string _json = "{\"total\":" + _DingDan_t.Count.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }

        public ActionResult PeiHuo_Find(int ddbh)
        {
            //数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.PeiHuo> _PeiHuo = new List<Models.PeiHuo>();
            _PeiHuo = _rs.IQueryable<Models.PeiHuo>("Select B.钢丝名称 as cpmc, B.钢号 as gh, B.规格 as gg, B.生产日期 as scrq, B.净重 as zl, B.组别 as zb, A.自动编号 as zdbh,B.客户代码 as khbm ,D.库位 as kwmc from 成品库存锁定表 A Inner join 成品信息表_4 B on A.成品库存编号 = B.自动编号  Inner Join 成品库位表 C On A.成品库存编号=C.成品编号 Inner Join 仓库库位视图 D On C.库位编号=D.库位编号 Where 销售订单编号 = " + ddbh.ToString()).ToList();

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.PeiHuo>(_PeiHuo);
            string _json = "{\"total\":" + _PeiHuo.Count.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }
        //public ActionResult PeiHuo_Select(int ddbh)
        //{
        //    //SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
        //    //List<SelectListItem> _a = new List<SelectListItem>();
        //    //List<db_models.ChanPinMingCheng> tKhxxEntity = new List<db_models.ChanPinMingCheng>();
        //    //tKhxxEntity = _rs.IQueryable<db_models.ChanPinMingCheng>().ToList();
        //    //foreach (db_models.ChanPinMingCheng _k in tKhxxEntity)
        //    //{
        //    //    _a.Add(new SelectListItem { Text = _k.cpmc.ToString(), Value = _k.zdbh.GetHashCode().ToString() });
        //    //}

        //    //ViewBag.from_cpmc = _a;
        //    ViewBag.xxdbh = ddbh;
        //    return View();
        //}

        /// <summary>
        /// 配货 输入界面
        /// </summary>
        /// <returns></returns>
        public ActionResult PeiHuo_Select_Find(int limit, int offset)
        {
            //列表，显示配货，子表显示配货明细，再子表显示配货的明细

            string _where = "";
            //if (Request["cpmc"].ToString() != "")
            //{
            //    _where += string.Format(" And 钢丝名称 Like '%{0}%'", Request["cpmc"].ToString());
            //}
            if (Request["gh"].ToString() != "")
            {
                _where += string.Format(" And 钢号 = '{0}'", Request["gh"].ToString());
            }
            if (Request["gg"].ToString() != "")
            {
                _where += string.Format(" And 规格 = '{0}'", Request["gg"].ToString());
            }
            if (Request["zb"].ToString() != "")
            {
                _where += string.Format(" And 组别 = '{0}'", Request["zb"].ToString());
            }
            if (Request["ph"].ToString() != "")
            {
                _where += string.Format(" And 等级代码 like '%{0}%'", Request["ph"].ToString());
            }
            if (Request["khbm"].ToString() != "")
            {
                _where += string.Format(" And 客户代码 Like '%{0}%'", Request["khbm"].ToString());
            }
            if (Request["zl1"].ToString() != "" && Request["zl2"].ToString() != "")
            {
                _where += string.Format(" And 净重 between {0} and {1}", Request["zl1"].ToString(), Request["zl2"].ToString());
            }

            if (Request["zl1"].ToString() != "" && Request["zl2"].ToString() == "")
            {
                _where += string.Format(" And 净重 >= {0} ", Request["zl1"].ToString());
            }

            if (Request["zl1"].ToString() == "" && Request["zl2"].ToString() != "")
            {
                _where += string.Format(" And 净重 <= {0} ", Request["zl2"].ToString());
            }




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
            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "生产日期,A3.库位,净重";
            _p.sord = "asc";

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.PeiHuo> _PeiHuos = new List<Models.PeiHuo>();
            _PeiHuos = _rs.IQueryable<Models.PeiHuo>("Select 钢丝名称 as cpmc, 钢号 as gh, 规格 as gg, 生产日期 as scrq, 净重 as zl, 组别 as zb, A.自动编号 as cpbh,等级代码 as ph,客户代码 as khbm ,A3.库位 as kwmc From 成品信息表_4 A inner join 成品库位表 A2 on A.自动编号=A2.成品编号 inner join 仓库库位视图 A3 on A2.库位编号=A3.库位编号 Where Not Exists(Select 1 From 成品库存锁定表 B Where B.成品库存编号 = A.自动编号) " + _where
                                                , _p).ToList();

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.PeiHuo>(_PeiHuos);
            string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }

        /// <summary>
        /// 配货保存
        /// </summary>
        /// <returns></returns>
        public ActionResult PeiHuo_Save(Models.PeiHuo[] mPh)
        {
            List<db_models.cpkcsdb> _sdb = new List<db_models.cpkcsdb>();
            foreach (Models.PeiHuo _p in mPh)
            {
                _sdb.Add(new db_models.cpkcsdb() { zdbh = null, cpkcbh = _p.cpbh, sdrq = DateTime.Parse(DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")), sdr = 1, sdyy = "1", xxdbh = _p.xxdbh });
            }

            BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            try
            {
                _rs.Insert<db_models.cpkcsdb>(_sdb);
                _jsons.info = "数据增加成功!";
                _jsons.status = 1;
            }
            catch (Exception ex)
            {
                _jsons.info = "数据增加失败!";
                _jsons.status = 0;
            }
            return Json(_jsons, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 配货删除
        /// </summary>
        /// <returns></returns>
        public ActionResult PeiHuo_Delete(int id)
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                db_models.cpkcsdb _data = new db_models.cpkcsdb();

                _data.zdbh = id;

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                try
                {
                    _rs.Delete<db_models.cpkcsdb>(_data);
                    _jsons.info = "数据删除成功!";
                    _jsons.status = 1;
                }
                catch (Exception ex)
                {
                    _jsons.info = "数据删除失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        /// <summary>
        /// 配货处理_自动配货
        /// </summary>
        /// <returns></returns>
        public ActionResult PeiHuo_Ph_Auto(int ddth, int max, int min, int hl)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.JsonSuccess> _jsons = new List<Models.JsonSuccess>();

            _jsons = _rs.FindList<BK_MES_MVC.Models.JsonSuccess>(string.Format("Execute Pr_PeiHuo_Batch {0},{1},{2},{3}", ddth.ToString(),max.ToString(),min.ToString(),hl.ToString()));

            if (_jsons.Count == 0)
            {
                _jsons.Add(new Models.JsonSuccess() { info = "无法配货!", status = 0 });
            }

            return Json(_jsons[0], JsonRequestBehavior.AllowGet);
        }

        public ActionResult PeiHuo_Ph_clear(int ddh)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.JsonSuccess> _jsons = new List<Models.JsonSuccess>();

            _jsons = _rs.FindList<BK_MES_MVC.Models.JsonSuccess>(string.Format("Execute Pr_PeiHuo_Cleare {0}", ddh.ToString()));

            if (_jsons.Count == 0)
            {
                _jsons.Add(new Models.JsonSuccess() { info = "无法清除配货信息!", status = 0 });
            }

            return Json(_jsons[0], JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 配货处理_自动配货
        /// </summary>
        /// <returns></returns>
        //public ActionResult PeiHuo_Ph_Auto()
        //{
        //    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

        //    List<Models.JsonSuccess> _jsons = new List<Models.JsonSuccess>();

        //    _jsons = _rs.FindList<BK_MES_MVC.Models.JsonSuccess>("Execute Pr_PeiHuo_Js");

        //    return Json(_jsons[0], JsonRequestBehavior.AllowGet);
        //}


        /// <summary>
        /// 配货处理_手工选择
        /// </summary>
        /// <returns></returns>
        public ActionResult PeiHuo_Ph_Manual_Show()
        {
            //显示所有入库未锁定的记录

            return View();
        }

        /// <summary>
        /// 配货处理_手工选择_保存
        /// </summary>
        /// <returns></returns>
        public ActionResult PeiHuo_Ph_Manual_Save()
        {
            //保存选择的记录

            return View();
        }


        /// <summary>
        /// 出库查看
        /// </summary>
        /// <returns></returns>
        //public ActionResult ChuKu_View()
        //{
        //    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
        //    List<SelectListItem> _a = new List<SelectListItem>();
        //    List<db_models.khxxb> tKhxxEntity = new List<db_models.khxxb>();
        //    tKhxxEntity = _rs.IQueryable<db_models.khxxb>().ToList();
        //    foreach (db_models.khxxb _k in tKhxxEntity)
        //    {
        //        _a.Add(new SelectListItem { Text = _k.khmc.ToString(), Value = _k.khbm.GetHashCode().ToString() });
        //    }
        //    ViewBag.form_khxxb = _a;

        //    return View();
        //}


        /// <summary>
        /// 出库接收
        /// </summary>
        /// <param name="mPh"></param>
        /// <returns></returns>
        //public ActionResult ChuKu_Receive(Models.PeiHuo[] mPh)
        //{
        //    List<db_models.dingdan_t_zt> _sdb = new List<db_models.dingdan_t_zt>();
        //    foreach (Models.PeiHuo _p in mPh)
        //    {
        //        _sdb.Add(new db_models.dingdan_t_zt() { ddtbm = _p.zdbh, jlrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm")), ddzt = db_models.db_enum.enum_ddzt.未分配拣货记录 });
        //    }

        //    BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();
        //    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
        //    try
        //    {
        //        _rs.Insert<db_models.dingdan_t_zt>(_sdb);
        //        _jsons.info = "订单信息接收成功!";
        //        _jsons.status = 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        _jsons.info = "订单信息接收失败!";
        //        _jsons.status = 0;
        //    }
        //    return Json(_jsons, JsonRequestBehavior.AllowGet);
        //}

        /// <summary>
        /// 拣货接收
        /// </summary>
        /// <returns></returns>
        public ActionResult JianHuo_Receive(int id)
        {
            List<db_models.dingdan_t> _sdb = new List<db_models.dingdan_t>();
            //2019.02.26
            //_sdb.Add(new db_models.dingdan_t() { zdbh = id, ddzt = db_models.db_enum.enum_ddzt.正在配拣货记录 });

            BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            try
            {
                _rs.Update<db_models.dingdan_t>(_sdb, new List<string> { "ddzt" });
                _jsons.info = "成功接收任务!!";
                _jsons.status = 1;
            }
            catch (Exception ex)
            {
                _jsons.info = "接收失败!";
                _jsons.status = 0;
            }
            return Json(_jsons, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 装车确认-显示
        /// </summary>
        /// <returns></returns>
        public ActionResult ZhuangChe_View(int id)
        {
            //数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            Models.DingDan_t _DingDan_t = new Models.DingDan_t();
            _DingDan_t = _rs.IQueryable<Models.DingDan_t>("select A.订货日期 as dhrq,A.客户码 as khbm,A.操作日期 as czrq,A.自动编号 as zdbh,B.客户名称 as khmc,B.客户后缀 as khhz,A.状态 as ddzt,A.状态 as ddztm from 订货头表 A inner join 客户信息表 B on A.客户码=B.客户编码 Where A.自动编号 =" + id.ToString()).Single();
            //只要一条记录
            return View(_DingDan_t);
        }

        /// <summary>
        /// 装车确认-数据查询
        /// </summary>
        /// <returns></returns>
        public ActionResult ZhuangChe_Find(int id)
        {
            //数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.PeiHuo> _PeiHuo = new List<Models.PeiHuo>();
            _PeiHuo = _rs.IQueryable<Models.PeiHuo>("Select B.钢丝名称 as cpmc, B.钢号 as gh, B.规格 as gg, B.生产日期 as scrq, B.净重 as zl, B.组别 as zb, A.自动编号 as zdbh from 成品库存锁定表 A Inner join 成品信息表_4 B on A.成品库存编号 = B.自动编号 inner join 订货明细表 C On A.销售订单编号=C.自动编号 Where C.订货头编号= " + id.ToString()).ToList();

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.PeiHuo>(_PeiHuo);
            string _json = "{\"total\":" + _PeiHuo.Count.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);

        }

        /// <summary>
        /// 安全库存浏览
        /// </summary>
        /// <returns></returns>
        public ActionResult AnQuanKuCun_View()
        {

            return View();
        }

        /// <summary>
        /// 安全库存数据显示
        /// </summary>
        /// <returns></returns>
        public ActionResult AnQuanKuCun_Find(int limit, int offset)
        {
            string _where = "1=1";
            if (Request["search"].ToString() != "")
            {
                _where += string.Format(" And B.产品名称 like '%{0}%' ", Request["search"].ToString());
            }

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
            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "B.产品名称";
            _p.sord = "asc";

            // 数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.AnQuanKuCun> _Aqkc = new List<Models.AnQuanKuCun>();
            _Aqkc = _rs.IQueryable<Models.AnQuanKuCun>("Select B.产品名称 as cpmc, A.钢号 as gh, A.规格 as gg, A.组别 as zb, A.安全库存重量 as aqkczl,A.设定日期 as sdrq,C.用户姓名 as sdr, A.自动编号 as zdbh from 成品安全库存表 A Inner join 产品表_2 B on A.产品编码 = B.自动编号 inner join v_user C On A.设定人编码=C.用户编码 Where " + _where
                                                        , _p).ToList();

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.AnQuanKuCun>(_Aqkc);
            string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);

        }

        /// <summary>
        /// 安全库存数据编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult AnQuanKuCun_Input(int? id)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.cpaqkcb tFindEntity = new db_models.cpaqkcb();

            if (id != null)
            {
                tFindEntity = _rs.FindEntity<db_models.cpaqkcb>(id);
            }
            else
            {
                tFindEntity.zdbh = null;
            }

            List<SelectListItem> _a = new List<SelectListItem>();
            List<db_models.ChanPinMingCheng> tKhxxEntity = new List<db_models.ChanPinMingCheng>();
            tKhxxEntity = _rs.IQueryable<db_models.ChanPinMingCheng>().ToList();
            foreach (db_models.ChanPinMingCheng _k in tKhxxEntity)
            {
                _a.Add(new SelectListItem { Text = _k.cpmc.ToString(), Value = _k.zdbh.GetHashCode().ToString() });
            }

            ViewBag.form_cpmc = _a;

            return View(tFindEntity);
        }


        /// <summary>
        /// 安全库存数保存
        /// </summary>
        /// <returns></returns>
        public ActionResult AnQuanKuCun_Save()
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                db_models.cpaqkcb _data = new db_models.cpaqkcb();

                TableRowToModel<db_models.cpaqkcb>(_data, Request.Form);

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                try
                {
                    _jsons.info = "数据增加成功!";
                    _jsons.status = 1;
                    if (_data.zdbh == null)
                    {
                        if (((db_models.cpaqkcb)_rs.FindEntity<db_models.cpaqkcb>(x => x.cpbm == _data.cpbm && x.gg == _data.gg && x.gh == _data.gh.Trim() && x.zb == _data.zb.Trim())) != null)
                        {
                            _jsons.info = "相同的成品信息已经存在!";
                            _jsons.status = 0;
                        }
                        else
                        {
                            _data.sdrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
                            _data.sdrq = DateTime.Now;
                            _rs.Insert<db_models.cpaqkcb>(_data);
                            _jsons.info = "数据增加成功!";
                        }
                    }
                    else
                    {
                        db_models.cpaqkcb _data2 = new db_models.cpaqkcb();
                        _data2 = _rs.FindEntity<db_models.cpaqkcb>(x => x.cpbm == _data.cpbm && x.gg == _data.gg && x.gh == _data.gh.Trim() && x.zb == _data.zb.Trim());
                        if (_data2 != null && _data2.zdbh != _data.zdbh)
                        {
                            _jsons.info = "相同的成品信息已经存在!";
                            _jsons.status = 0;
                        }
                        else
                        {
                            _data.sdrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
                            _data.sdrq = DateTime.Now;
                            _rs.Update<db_models.cpaqkcb>(_data);

                            _jsons.info = "数据修改成功!";
                        }
                    }

                }
                catch (Exception ex)
                {
                    _jsons.info = "数据处理失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        /// <summary>
        /// 安全是库存数据删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AnQuanKuCun_Delete(db_models.cpaqkcb _key)
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                db_models.cpaqkcb _data = new db_models.cpaqkcb();

                _data.zdbh = _key.zdbh;

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                try
                {
                    _rs.Delete<db_models.cpaqkcb>(_data);
                    _jsons.info = "数据删除成功!";
                    _jsons.status = 1;
                }
                catch (Exception ex)
                {
                    _jsons.info = "数据删除失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        /// <summary>
        /// 盘库浏览界面
        /// </summary>
        /// <returns></returns>
        public ActionResult PanKu_View()
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.cppkxxb tFindEntity = new db_models.cppkxxb();

            List<SelectListItem> _a = new List<SelectListItem>();
            List<db_models.cppkxxb> tKhxxEntity = new List<db_models.cppkxxb>();
            tKhxxEntity = _rs.IQueryable<db_models.cppkxxb>().ToList();
            foreach (db_models.cppkxxb _k in tKhxxEntity)
            {
                _a.Add(new SelectListItem { Text = ((DateTime)_k.pkrq).ToString("yyyy.MM.dd"), Value = _k.zdbh.GetHashCode().ToString() });
            }

            ViewBag.form_pkrq = _a;

            return View();
        }

        /// <summary>
        /// 盘库数据显示
        /// </summary>
        /// <returns></returns>
        public ActionResult PanKu_Find()
        {
            int _pkid = 0;
            if (Request["pkrq"].ToString() != "")
            {
                _pkid = Int32.Parse(Request["pkrq"].ToString());
            }
            else
            {
                return View();
            }

            // 数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            List<db_models.cppkxxb> _cpxxb = new List<db_models.cppkxxb>();
            _cpxxb = _rs.IQueryable<db_models.cppkxxb>(x => x.zdbh == _pkid).ToList();
            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<db_models.cppkxxb>(_cpxxb);
            string _json = "{\"total\":1,\"rows\":" + _datajson + "}";
            return Content(_json);
        }
        public ActionResult PanKu_Find_Mx(int limit, int offset, int iPkbh, int iZt)
        {

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
            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "B.钢丝名称";
            _p.sord = "asc";

            // 数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.PanKu_Mx> _PkMx = new List<Models.PanKu_Mx>();
            _PkMx = _rs.IQueryable<Models.PanKu_Mx>(@"select  case A.状态 when 3 then A.备注 else B.批号 end as ph
                                                                  ,B.钢丝名称 as cpmc
	                                                              ,B.钢号 as gh
	                                                              ,B.规格 as gg
	                                                              ,B.组别 as zb
	                                                              ,E.仓库名称 as ckmc
	                                                              ,ltrim(D.排名称)+'-'+ltrim(str(C.位号))+'-'+ltrim(str(C.层号) )as wzmc
	                                                              ,F.用户姓名 as yhxm
	                                                              ,A.操作日期 as czrq
                                                                  ,B.净重 as zl
	                                                                from 成品盘库日志表 A Left Outer Join 成品信息表_4 B On A.成品编号=B.自动编号
							                                                              Left Outer Join 仓库库位配置表 C On  A.库位编码=C.自动编号
							                                                              Left Outer Join 仓库库位排号表 D On C.排编号=D.自动编号
							                                                              Left Outer Join 仓库信息表 E On D.仓库编号=E.自动编号
							                                                              Left Outer Join v_user F on A.操作人编码=F.用户编码
	                                                                Where 盘库编号 =" + iPkbh + " And (A.状态=" + (iZt == 1 ? "1 Or A.状态=3" : iZt.ToString()) + ")"
                                                                                                                       , _p).ToList();
            if (iZt == 2)
            {
                //少了
                _PkMx = _rs.IQueryable<Models.PanKu_Mx>(@"select B.批号 as ph
                                                                ,B.钢丝名称 as cpmc
                                                                ,B.钢号 as gh
                                                                ,B.规格 as gg
                                                                ,B.组别 as zb
                                                                ,F.仓库名称 as ckmc
                                                                ,ltrim(E.排名称)+'-'+ltrim(str(D.位号))+'-'+ltrim(str(D.层号) )as wzmc
                                                                ,G.用户姓名 as yhxm
                                                                ,C.入库日期 as czrq
                                                                ,B.净重 as zl
                                                               from 成品库位表 A  Left Outer Join  成品信息表_4 B On A.成品编号=B.自动编号
                                                                    Left Outer Join  成品入库表 C On A.成品编号=C.成品信息编号
                                                                    Left Outer Join  仓库库位配置表 D On  C.库位号=D.自动编号
                                                                    Left Outer Join  仓库库位排号表 E On D.排编号=E.自动编号
                                                                    Left Outer Join  仓库信息表 F On E.仓库编号=F.自动编号
                                                                    Left Outer Join  v_user G on C.操作人编码=G.用户编码
                                                                Where Not Exists(Select 1 From 成品盘库日志表 A1 Where A.成品编号=A1.成品编号 And 盘库编号=" + iPkbh + " and 状态=" + iZt + ")"
                                                                                                                           , _p).ToList();
            }
            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.PanKu_Mx>(_PkMx);
            string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }

        /// <summary>
        /// 库存浏览
        /// </summary>
        /// <returns></returns>
        public ActionResult KuCun_View()
        {
            return View();
        }

        public ActionResult KuCun_Find(int limit, int offset)
        {
            string _where = "1=1";
            if (Request["srkfs"].ToString() != "" && Request["srkfs"].ToString() != "0")
            {
                _where += string.Format(" And F.入库方式码 ={0} ", Request["srkfs"].ToString());
            }

            if (Request["sph"].ToString() != "")
            {
                _where += string.Format(" And B.批号 like '%{0}%' ", Request["sph"].ToString());
            }

            if (Request["scpmc"].ToString() != "")
            {
                _where += string.Format(" And B.钢丝名称 like '%{0}%' ", Request["scpmc"].ToString());
            }

            if (Request["scpkw"].ToString() != "")
            {
                _where += string.Format(" And D.排名称+'-'+ltrim(str(C.位号))+'-'+ltrim(str(C.层号))='{0}' ", Request["scpkw"].ToString());
            }

            if (Request["srkrq1"] != null && Request["srkrq2"] != null && !String.IsNullOrEmpty(Request["srkrq1"].ToString()) && !String.IsNullOrEmpty(Request["srkrq2"].ToString()))
            {
                _where += " And F.入库日期 >= '" + Request["srkrq1"].ToString() + "' And F.入库日期<DateAdd(Day,1,'" + Request["srkrq2"].ToString() + "')";
            }

            if (Request["srkrq1"] != null && Request["srkrq2"] != null && !String.IsNullOrEmpty(Request["srkrq1"].ToString()) && String.IsNullOrEmpty(Request["srkrq2"].ToString()))
            {
                _where += " And F.入库日期 >= '" + Request["srkrq1"].ToString() + "'";
            }

            if (Request["srkrq1"] != null && Request["srkrq2"] != null && String.IsNullOrEmpty(Request["srkrq1"].ToString()) && !String.IsNullOrEmpty(Request["srkrq2"].ToString()))
            {
                _where += " And F.入库日期 <DateAdd(day,1,'" + Request["srkrq2"].ToString() + "')";
            }




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
            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "F.入库日期";
            _p.sord = "desc";

            // 数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.KuCun_Mx> KcMx = new List<Models.KuCun_Mx>();
            KcMx = _rs.IQueryable<Models.KuCun_Mx>(@"select A.自动编号 as zdbh
	                                                       ,B.钢丝名称 as cpmc
                                                            ,B.净重 as zl
	                                                       ,B.钢号 as gh
	                                                       ,B.规格 as gg
	                                                       ,B.组别 as zb
	                                                       ,B.公差 as gc
	                                                       ,B.插入时间 as crrq
	                                                       ,E.仓库名称 as ckmc
	                                                       ,D.排名称+'-'+ltrim(str(C.位号))+'-'+ltrim(str(C.层号)) as kwmc
	                                                       ,F.入库日期 as rkrq
	                                                       ,G.用户姓名 as czymc
	                                                       ,F.入库方式码 as rkfsbm
                                                           ,B.批号 as ph
                                                           ,H.锁定日期 as sdsj
	                                                        from [成品库位表] A left outer join 成品信息表_4 B On A.成品编号=B.自动编号 
							                                                     left outer join 仓库库位配置表 C On A.库位编号=C.自动编号
							                                                     left outer join 仓库库位排号表 D on C.排编号=D.自动编号
							                                                     left outer join 仓库信息表 E On D.仓库编号=E.自动编号
							                                                     left outer join  (select B1.成品信息编号
							,B1.库位号,操作人编码,入库方式码,B1.入库日期
						 from 成品入库表 B1 inner join
											 (Select 成品信息编号
													,Max(入库日期) as 入库日期
												 From 成品入库表 Group By 成品信息编号) B2 on B1.成品信息编号=B2.成品信息编号 And B1.入库日期=B2.入库日期)  F On A.成品编号=F.成品信息编号
							                                                     left outer join v_user G On F.操作人编码 =G.用户编码 
                                                                                 left outer join 成品库存锁定表 H on A.成品编号=H.成品库存编号
                                                          Where " + _where
                                                       , _p).ToList();

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.KuCun_Mx>(KcMx);
            string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }

        /// <summary>
        /// 发货信息
        /// </summary>
        /// <returns></returns>
        public ActionResult FaHuo_View()
        {
            return View();

        }

        //public ActionResult FaHuo_Find(int limit, int offset)
        //{
        //    string _where = "1=1";
        //    if (Request["ddzt"].ToString() != "" && Request["ddzt"].ToString() != "0")
        //    {
        //        if (Request["ddzt"].ToString() == "100")
        //            _where += " And 接收人编码 is null ";
        //        if (Request["ddzt"].ToString() == "200")
        //            _where += " And 接收人编码 is not null ";
        //    }

        //    if (Request["search_ch"].ToString() != "")
        //    {
        //        _where += string.Format(" And zcxx like '%{0}%' ", Request["search_ch"].ToString());
        //    }

        //    if (Request["search_ddh"].ToString() != "")
        //    {
        //        _where += string.Format(" And 自动编号='{0}' ", Request["search_ddh"].ToString());
        //    }

        //    if (Request["search_kh"].ToString() != "")
        //    {
        //        _where += string.Format(" And 客户名称 like '%{0}%' ", Request["search_kh"].ToString());
        //    }


        //    //加入分页
        //    SD.Data.Pagination _p = new SD.Data.Pagination();
        //    if (Request["page"] == null)
        //    {
        //        _p.page = 1;
        //    }
        //    else
        //    {
        //        _p.page = Int32.Parse(Request["page"].ToString());
        //    }
        //    _p.page = offset / limit + 1;
        //    _p.rows = limit;
        //    _p.sidx = "C.加入时间";
        //    _p.sord = "asc";

        //    // 数据显示
        //    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

        //    List<Models.FaHuoX_Mx> _FhX = new List<Models.FaHuoX_Mx>();
        //    _FhX = _rs.IQueryable<Models.FaHuoX_Mx>(@"select A.订货日期 as dhrq
        //                                                     , C.加入时间 as jlrq
        //                                                     , A.自动编号 as zdbh
        //                                                     , B.客户名称 as khmc
        //                                                     , B.客户后缀 as khhz
        //                                                     , C.最新订单状态 as ddzt
        //                                                     , C.最新订单状态 as ddztm
        //                                                     , A.备注 as bz
        //						     ,E.zcxx
        //						     ,F.pjxx
        //                                                from 订货头表 A inner join 客户信息表 B on A.客户码 = B.客户编码
        //                                                                inner join(select C1.加入人编码, C1.订单头编码, C1.加入时间, C1.订单状态, C2.最新订单状态
        //                                                                                from(select * from 订单状态表) C1 inner join
        //                                                                                    (select 订单头编码
        //                                                                                            , max(订单状态) 最新订单状态 
        //                                                                                        from 订单状态表 group by 订单头编码) C2 on C1.订单头编码 = C2.订单头编码 
        //                                                                                                                                And C1.订单状态=C2.最新订单状态 ) C On A.自动编号 = C.订单头编码
        //                                                                left outer join (select 订货头编号
        //                                                                                        ,stuff((select ';'+ltrim(str(装车类型编码))+','+装车号+','+isnull(备注,'')
        //                                                                                                    from 成品发货信息表 E2 
        //                                                                                                        where E2.订货头编号=E1.订货头编号 for xml path('')),1,1,'') as zcxx
        //                                                                                     from 成品发货信息表 E1 group by 订货头编号) E on A.自动编号=E.订货头编号
        //										left outer join (select 订货头编号
        //                                                                         ,stuff((select ';'+配件名称+':'+ltrim(str(配件数量,5,2))+''+配件计量单位+case 是否回收 when 1 then ',需回收' else '' end 
        //	                                                                                    from 成品发货信息配件表 F2 where F2.订货头编号=F1.订货头编号 for xml path('')),1,1,'') pjxx  
        //                                                                        from 成品发货信息配件表 F1 group by 订货头编号) F on A.自动编号=F.订货头编号 Where " + _where
        //                                                    , _p).ToList();

        //    string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.FaHuoX_Mx>(_FhX);
        //    string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
        //    return Content(_json);
        //}

        public ActionResult FaHuo_Find(int limit, int offset)
        {
            string _where = "1=1";
            if (Request["ddzt"].ToString() != "" && Request["ddzt"].ToString() != "0")
            {
                if (Request["ddzt"].ToString() == "100")
                    _where += " And 接收人编码 is null ";
                if (Request["ddzt"].ToString() == "200")
                    _where += " And 接收人编码 is not null ";
            }

            if (Request["search_ch"].ToString() != "")
            {
                _where += string.Format(" And zcxx like '%{0}%' ", Request["search_ch"].ToString());
            }

            if (Request["search_ddh"].ToString() != "")
            {
                _where += string.Format(" And 自动编号='{0}' ", Request["search_ddh"].ToString());
            }

            if (Request["search_kh"].ToString() != "")
            {
                _where += string.Format(" And 客户名称 like '%{0}%' ", Request["search_kh"].ToString());
            }


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
            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "C.加入时间";
            _p.sord = "asc";

            // 数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.FaHuoX_Mx> _FhX = new List<Models.FaHuoX_Mx>();
            _FhX = _rs.IQueryable<Models.FaHuoX_Mx>(@"select A.订货日期 as dhrq
                                                             , C.加入时间 as jlrq
                                                             , A.自动编号 as zdbh
                                                             , B.客户名称 as khmc
                                                             , B.客户后缀 as khhz
                                                             , C.最新订单状态 as ddzt
                                                             , C.最新订单状态 as ddztm
                                                             , A.备注 as bz
														     ,E.zcxx
														     ,F.pjxx
                                                        from 订货头表 A inner join 客户信息表 B on A.客户码 = B.客户编码
                                                                        inner join(select C1.加入人编码, C1.订单头编码, C1.加入时间, C1.订单状态, C2.最新订单状态
                                                                                        from 订单状态表 C1 inner join
                                                                                            (select 订单头编码
                                                                                                    , max(订单状态) 最新订单状态 
                                                                                                from 订单状态表 group by 订单头编码) C2 on C1.订单头编码 = C2.订单头编码 
                                                                                                                                        And C1.订单状态=C2.最新订单状态 ) C On A.自动编号 = C.订单头编码
                                                                        left outer join (select 订货头编号
                                                                                                ,stuff((select ';'+ltrim(str(装车类型编码))+','+装车号+','+isnull(备注,'')
                                                                                                            from 成品发货信息表 E2 
                                                                                                                where E2.订货头编号=E1.订货头编号 for xml path('')),1,1,'') as zcxx
                                                                                             from 成品发货信息表 E1 group by 订货头编号) E on A.自动编号=E.订货头编号
																		left outer join (select 订货头编号
					                                                                            ,stuff((select ';'+配件名称+':'+ltrim(str(配件数量,5,2))+''+配件计量单位+case 是否回收 when 1 then ',需回收' else '' end 
    					                                                                                    from 成品发货信息配件表 F2 where F2.订货头编号=F1.订货头编号 for xml path('')),1,1,'') pjxx  
				                                                                            from 成品发货信息配件表 F1 group by 订货头编号) F on A.自动编号=F.订货头编号 Where " + _where
                                                            , _p).ToList();

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.FaHuoX_Mx>(_FhX);
            string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }


        /// <summary>
        /// 发运车号维护
        /// </summary>
        /// <returns></returns>
        public ActionResult FaHuo_Input_Ch()
        {
            //因为这是一个单独的页面,所有必须引用jquery.js,bootstrap.js,等js,css文件,否则会报错
            return View();
        }

        /// <summary>
        /// 发货车号保存
        /// </summary>
        /// <returns></returns>
        //public ActionResult FaHuo_Input_Save(db_models.fhxxb chb,db_models.fhxxpjb pjb)
        //{
        public ActionResult FaHuo_Input_Save(string chb, string pjb)
        {
            List<db_models.fhxxb> _xxb = new List<db_models.fhxxb>();
            List<db_models.fhxxpjb> _pjb = new List<db_models.fhxxpjb>();
            _xxb = Newtonsoft.Json.JsonConvert.DeserializeObject<List<db_models.fhxxb>>(chb);
            _pjb = Newtonsoft.Json.JsonConvert.DeserializeObject<List<db_models.fhxxpjb>>(pjb);

            int _ddtbh = Convert.ToInt32(Request["ddtbh"]);
            int _zdbh = Convert.ToInt32(Request["zdbh"]);

            BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();
            _jsons.info = "数据增加成功!";
            _jsons.status = 1;

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            try
            {
                //未完成
                _rs.BeginTrans();
                if (_zdbh > 0)
                {
                    _rs.Delete<db_models.fhxxb>(x => x.ddtbh == _ddtbh);
                    _rs.Delete<db_models.fhxxpjb>(x => x.ddtbh == _ddtbh);
                }

                _rs.Insert<db_models.fhxxb>(_xxb);
                _rs.Insert<db_models.fhxxpjb>(_pjb);

                _rs.Commit();
            }
            catch (Exception ex)
            {
                _jsons.info = "数据增加失败!";
                _jsons.status = 0;

            }
            return Json(_jsons, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查看发货单号的详细信息,并可以修改车号等信息
        /// </summary>
        /// <returns></returns>
        public ActionResult FaHuo_View2()
        {
            return View();

        }

        public ActionResult FaHuo_Find2(int limit, int offset)
        {
            string _where = "1=1";
            if (Request["ddzt"] != null)
            {
                _where += " And C.订单状态 =" + Request["ddzt"].ToString() + "";
            }

            if (Request["search_dd"].ToString() != "")
            {
                _where += string.Format(" And A.自动编号 = {0} ", Request["search_dd"].ToString());
            }

            if (Request["search_ch"].ToString() != "")
            {
                _where += string.Format(" And 车号 like '%{0}%' ", Request["search_ch"].ToString());
            }

            if (Request["search_kh"].ToString() != "")
            {
                _where += string.Format(" And 客户名称 like '%{0}%' ", Request["search_kh"].ToString());
            }


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
            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "C.加入时间";
            _p.sord = "asc";

            // 数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.DingDan_t> _DingDan_t = new List<Models.DingDan_t>();

            _DingDan_t = _rs.IQueryable<Models.DingDan_t>(@"select A.订货日期 as dhrq
                                                          , A.客户码 as khbm
                                                          , C.加入时间 as jlrq
                                                          , A.自动编号 as zdbh
                                                          , A.客户名称 as khmc
                                                          , C.最新订单状态 as ddzt
                                                          , C.最新订单状态 as ddztm
                                                          , A.备注 as bz
                                                          ,A.制单人 as zdr
                                                          ,车号 as ch
                                                          ,提货人 as thr
                                                         From 订货头表 A inner join(select C1.加入人编码, C1.订单头编码, C1.加入时间, C1.订单状态, C2.最新订单状态
                                                                                 from 订单状态表 C1 inner join
                                                                                                     (select 订单头编码, max(订单状态) 最新订单状态 From 订单状态表 group by 订单头编码) C2 on C1.订单头编码 = C2.订单头编码 And C1.订单状态=C2.最新订单状态) C On A.自动编号 = C.订单头编码 
                                                         Where " + _where
                                                             , _p).ToList();

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.DingDan_t>(_DingDan_t);
            string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);

        }

        public ActionResult FaHuo_Receive(Models.PeiHuo[] mPh)
        {

            List<db_models.dingdan_t_zt> _sdb = new List<db_models.dingdan_t_zt>();
            foreach (Models.PeiHuo _p in mPh)
            {
                _sdb.Add(new db_models.dingdan_t_zt() { ddtbm = _p.zdbh, jlrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm")), ddzt = db_models.db_enum.enum_ddzt.未装车订单 });
            }

            BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            try
            {
                _rs.Insert<db_models.dingdan_t_zt>(_sdb);
                _jsons.info = "成功接收任务!!";
                _jsons.status = 1;
            }
            catch (Exception ex)
            {
                _jsons.info = "接收失败!";
                _jsons.status = 0;
            }
            return Json(_jsons, JsonRequestBehavior.AllowGet);

        }

        public ActionResult FaHuo_Find_M(int limit, int offset, int ddbh)
        {
            //数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
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
            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "A.自动编号";
            _p.sord = "desc";

            string _where = "";
          

            List<Models.DingDan_m> _DingDan_t = new List<Models.DingDan_m>();
          
            _DingDan_t = _rs.IQueryable<Models.DingDan_m>(@"select A.订货头编号 as ddtbh
	                                                               ,A.成品编码 as cpbm
	                                                               ,A.钢号 as gh
	                                                               ,A.规格 as gg
	                                                               ,A.组别 as zb
	                                                               ,'' as bzmc
	                                                               ,A.应交量 as yjl
	                                                               ,A.备注1 as bz1
	                                                               ,A.备注2 as bz2
	                                                               ,A.备注3 as bz3
	                                                               ,A.客户代码 as khdm
	                                                               ,A.加入日期 as jrrq
	                                                               ,A.自动编号 as zdbh
	                                                               ,A.产品名称 as cpmc
	                                                               ,C.s_sl
	                                                               ,C.s_zl
	                                                               ,Convert(Decimal,Round((C.s_zl/A.应交量-1)*100,2)) as s_bl
	                                                               ,A.客户_编码 as kh_bm
	                                                               ,A.客户_订单号 as kh_ddh
	                                                               ,A.客户_物料编码 as kh_wlbm
	                                                             from 订货明细表 A left outer join
	                                                              (
		                                                            select Count(1) as s_sl
			                                                              ,Convert(Decimal,Sum(净重)) as s_zl
			                                                              ,C3.销售订单编号 s_dh 
			                                                             from [成品出库表] C1 inner join 成品信息表_4 C2 On C1.成品信息编号=C2.自动编号
								                                                              inner join [成品配货表] C3 On  C1.成品信息编号=C3.成品信息编号 
                                                                            where  C1.销售订单编号="+ ddbh.ToString()+
                                                                  @"                  Group By C3.销售订单编号
	                                                               ) C On A.自动编号=C.s_dh
	                                                                Where 订货头编号=" + ddbh.ToString() +
                                                            @"union all 
                                                                    select 
	                                                                    A.销售订单编号 as ddtbh
	                                                                                    ,'' as cpbm
	                                                                                    ,'' as gh
	                                                                                    ,null as gg
	                                                                                    ,'' as zb
	                                                                                    ,'' as bzmc
	                                                                                    ,null as yjl
	                                                                                    ,'' as bz1
	                                                                                    ,'' as bz2
	                                                                                    ,'' as bz3
	                                                                                    ,'' as khdm
	                                                                                    ,null as jrrq
	                                                                                    ,A.销售订单编号*-1 as zdbh
	                                                                                    ,'无计划的配货' as cpmc
	                                                                                    ,Count(1) s_sl
	                                                                                    ,Sum(C.净重) s_zl
	                                                                                    ,0 as s_bl
	                                                                                    ,'' as kh_bm
	                                                                                    ,'' as kh_ddh
	                                                                                    ,'' as kh_wlbm
                                                                     from [成品出库表] A left outer join [成品配货表] B on A.成品信息编号=B.成品信息编号
					                                                                    inner join 成品信息表_4 C On A.成品信息编号=C.自动编号
                                                                        Where A.销售订单编号=" + ddbh.ToString() +
                                                                  @"And B.成品信息编号  is null
                                                                    group by A.销售订单编号"
                                                            ).ToList();

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.DingDan_m>(_DingDan_t);
            string _json = "{\"total\":" + _DingDan_t.Count().ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }


        public ActionResult FaHuo_Find_Mx2(int limit, int offset,int id)
        {
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
            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "出库日期";
            _p.sord = "asc";


            // 数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.FaHuo_Mx2> _fahuomx2 = new List<Models.FaHuo_Mx2>();
            if (id < 0)
            {
                _fahuomx2 = _rs.IQueryable<Models.FaHuo_Mx2>(string.Format(@"select C.钢丝名称 cpmc
		                                                            ,C.批号 ph
		                                                            ,C.钢号 gh
		                                                            ,C.规格 gg
		                                                            ,C.组别 zb
		                                                            ,C.净重 zl
		                                                            ,A.出库日期 ckrq
		                                                            ,'未按计划拣货' zt
																	,C.自动编号
	                                                             From  
																  [成品出库表] A left outer join [成品配货表] B on A.成品信息编号=B.成品信息编号
				                                                	inner join 成品信息表_4 C On A.成品信息编号=C.自动编号 Where A.销售订单编号={0} And B.成品信息编号 is null", id*-1)
                                                            , _p).ToList();

            }
            else
            {

                //这里的销售订单编号是明细订单的编号不是订单头编号
                _fahuomx2 = _rs.IQueryable<Models.FaHuo_Mx2>(string.Format(@"select C.钢丝名称 cpmc
		                                                            ,C.批号 ph
		                                                            ,C.钢号 gh
		                                                            ,C.规格 gg
		                                                            ,C.组别 zb
		                                                            ,C.净重 zl
		                                                            ,A.出库日期 ckrq
		                                                            ,'计划拣货' zt
	                                                             From  
		                                                             [成品出库表] A right outer join [成品配货表] B on A.成品信息编号=B.成品信息编号
				                                                	inner join 成品信息表_4 C On B.成品信息编号=C.自动编号
		                                                            where B.销售订单编号={0} ", id)
                                                                 , _p).ToList();

            }
            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.FaHuo_Mx2>(_fahuomx2);
            string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);

        }

        public ActionResult FaHuo_Input_Ch2(int? id)
        {
            //因为这是一个单独的页面,所有必须引用jquery.js,bootstrap.js,等js,css文件,否则会报错
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.dingdan_t tFindEntity = new db_models.dingdan_t();
            db_models.dingdan_t_zt tFindEntity2 = new db_models.dingdan_t_zt();


            BK_MES_MVC.App_Code.ClassOne _class = new App_Code.ClassOne();

            if (id != null)
            {
                tFindEntity = _rs.FindEntity<db_models.dingdan_t>(id);
                tFindEntity2 = _rs.FindEntity<db_models.dingdan_t_zt>(x => x.ddtbm == id && x.ddzt == 0);
                ViewBag.form_ddzt_zdbh = tFindEntity2.zdbh;
            }
            else
            {
                tFindEntity.zdbh = null;
                tFindEntity.dhrq = DateTime.Today.Date;
            }

            List<SelectListItem> _a = new List<SelectListItem>();
            List<db_models.khxxb> tKhxxEntity = new List<db_models.khxxb>();
            tKhxxEntity = _rs.IQueryable<db_models.khxxb>().ToList();
            foreach (db_models.khxxb _k in tKhxxEntity)
            {
                _a.Add(new SelectListItem { Text = _k.khmc.ToString(), Value = _k.khbm.GetHashCode().ToString() });
            }

            ViewBag.form_khmc = _a;


            return View(tFindEntity);
        }

        public ActionResult FaHuo_Save_Ch2()
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                db_models.dingdan_t _data = new db_models.dingdan_t();
                db_models.dingdan_t_zt _data_zt = new db_models.dingdan_t_zt();

                TableRowToModel<db_models.dingdan_t>(_data, Request.Form);

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                _rs.BeginTrans();
                try
                {
                    if (_data.zdbh == null)
                    {
                        
                    }
                    else
                    {
                        _rs.Update<db_models.dingdan_t>(_data, new List<string> { "ch", "bz", "zdr", "thr" });

                        _data_zt.ddtbm = (int)_data.zdbh;
                        _data_zt.xgrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
                        _data_zt.xgrq = DateTime.Now;
                        _data_zt.zdbh = Convert.ToInt32(Request.Form["ddzt_zdbh"].ToString());
                        _rs.Update<db_models.dingdan_t_zt>(_data_zt, new List<string>() { "xgrbm", "xgrq" });
                        _jsons.info = "数据修改成功!";
                    }
                    _rs.Commit();
                    _jsons.info = "数据增加成功!";
                    _jsons.status = 1;
                }
                catch (Exception ex)
                {
                    _jsons.info = "数据处理失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();

        }

        public ActionResult JianHuo_Print(int id)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.RuKu_Mx> RKMx = new List<Models.RuKu_Mx>();

            try
            {
                //RKMx = _rs.IQueryable<Models.RuKu_Mx>(@"select D.批号 as ph, C.库位 as kwmc,D.钢号 as gh,D.规格 as gg,D.组别 as zb
                //                                            from 成品配货表 A inner Join 成品库位表 B On A.成品信息编号 = B.成品编号
                //                                                              Inner Join 仓库库位视图 C On B.库位编号 = C.库位编号
                //                                                              inner join 成品信息表_4  D on A.成品信息编号 = D.自动编号
                //                                                              inner join 订货明细表 E On A.销售订单编号=E.自动编号
                //                                                     Where E.订货头编号=" + id.ToString()+ " Order By D.钢号,D.规格,D.组别,C.库位,D.批号")
                //                                                    .ToList();
                RKMx = _rs.IQueryable<Models.RuKu_Mx>("Execute Pr_JianHuo_List_1 " + id.ToString()).ToList();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _rs.Dispose();
            }

            DataTable _dataTable = new DataTable();
            _dataTable.Columns.Add("ph", typeof(System.String));
            _dataTable.Columns.Add("kw", typeof(System.String));
            _dataTable.Columns.Add("gh", typeof(System.String));
            _dataTable.Columns.Add("gg", typeof(System.String));
            _dataTable.Columns.Add("zb", typeof(System.String));
            _dataTable.Columns.Add("khdm", typeof(System.String));
            _dataTable.Columns.Add("m3", typeof(System.Int16));

            DataRow _dr;
            string _ph = "";
            string _gh, _gg, _zb, _kw,_kw2,_khdm;
            int _m3 = 1;
            foreach (Models.RuKu_Mx _p in RKMx)
            {
                _dr = _dataTable.NewRow();
                //_dr["ph"] = _p.ph;
                _dr["kw"] = _p.kwmc;
                _dr["gh"] = _p.gh;
                _dr["gg"] = _p.gg;
                _dr["zb"] = _p.zb;
                //_dr["ph"] = _ph == "" ? _p.ph : _ph + "--" + _p.ph;
                _dr["ph"] = _ph == "" ? _p.p2 + _p.p3 : "[" + _ph + "--" + _p.p3 + "]";
                _dr["m3"] = _m3;
                _dr["khdm"] = _p.khdm;

                if (_p.m3 == 1)
                {
                    _m3 += 1;
                    //_ph = _ph == "" ? _p.ph : _ph;
                    _ph = _ph == "" ? _p.p2 + _p.p3 : _ph;
                    continue;
                }

                _dataTable.Rows.Add(_dr);
                _ph = "";
                _m3 = 1;
            }

            DataTable _dataTable2 = _dataTable.Clone();

            _kw = "";
            _ph = "";
            _khdm = "";
            _m3 = 0;
            for (int i = 0; i < _dataTable.Rows.Count; i++)
            {
                _gh = _dataTable.Rows[i]["gh"].ToString();
                _gg = _dataTable.Rows[i]["gg"].ToString();
                _zb = _dataTable.Rows[i]["zb"].ToString();

                if (i< _dataTable.Rows.Count-1
                   && _gh == _dataTable.Rows[i + 1]["gh"].ToString()
                   && _gg == _dataTable.Rows[i + 1]["gg"].ToString()
                   && _zb == _dataTable.Rows[i + 1]["zb"].ToString()
                    )
                {

                    if (_kw.IndexOf(_dataTable.Rows[i]["kw"].ToString()) < 0)
                    {
                        _kw += "," + _dataTable.Rows[i]["kw"].ToString();
                    }

                    if (_khdm.IndexOf(_dataTable.Rows[i]["khdm"].ToString()) < 0)
                    {
                        _khdm += "," + _dataTable.Rows[i]["khdm"].ToString();
                    }

                    _ph += "," + _dataTable.Rows[i]["ph"].ToString();
                    _m3 += Int16.Parse(_dataTable.Rows[i]["m3"].ToString());
                }
                else
                {
                    _dr = _dataTable2.NewRow();

                    if (_kw.IndexOf(_dataTable.Rows[i]["kw"].ToString()) < 0)
                    {
                        _kw += "," + _dataTable.Rows[i]["kw"].ToString();
                    }
                    if (_khdm.IndexOf(_dataTable.Rows[i]["khdm"].ToString()) < 0)
                    {
                        _khdm += "," + _dataTable.Rows[i]["khdm"].ToString();
                    }
                    _dr["khdm"] = _khdm.Length > 0 && _khdm.Substring(0, 1) == "," ? _khdm.Substring(1) : _khdm;
                    _dr["kw"] = _kw.Length>0 && _kw.Substring(0, 1) == "," ? _kw.Substring(1) : _kw;
                    _dr["gh"] = _gh;
                    _dr["gg"] = _gg;
                    _dr["zb"] = _zb;
                    _dr["ph"] = (_ph.Length>0 && _ph.Substring(0, 1) == "," ? _ph.Substring(1) + "," : "") + _dataTable.Rows[i]["ph"].ToString();
                    _dr["m3"] = _m3 + Int16.Parse(_dataTable.Rows[i]["m3"].ToString());

                    _dataTable2.Rows.Add(_dr);
                    _kw = "";
                    _ph = "";
                    _khdm = "";
                    _m3 = 0;
                }
            }



            ReportViewer _view = new ReportViewer();
            _view.LocalReport.EnableExternalImages = true;

            LocalReport localReport = new LocalReport();
            _view.LocalReport.ReportPath = Server.MapPath("~/Report/JianHuo_Report_3.rdlc");

            List<ReportParameter> parameters = new List<ReportParameter>
            {
                new ReportParameter("ddbh",id.ToString())
            };
            _view.LocalReport.SetParameters(parameters);

            //var sss= _view.LocalReport.GetParameters();

           // _dataTable.DefaultView.Sort = "gh,gg,zb,kw,ph";

            ReportDataSource reportDataSource0 = new ReportDataSource("JianHuo", _dataTable2);
            _view.LocalReport.DataSources.Add(reportDataSource0);

            string reportType = "PDF"; //Word,Excel,Pdf 
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceInfo =
            "<DeviceInfo>" +
            "  <OutputFormat>PDF</OutputFormat>" +    //Word,Excel,Pdf 
            "  <PageWidth>8.27in</PageWidth>" +
            "  <PageHeight>11.69in</PageHeight>" +
            "  <MarginTop>0.0in</MarginTop>" +
            "  <MarginLeft>0.2in</MarginLeft>" +
            "  <MarginRight>0in</MarginRight>" +
            "  <MarginBottom>0.0in</MarginBottom>" +
            "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            renderedBytes = _view.LocalReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
            return File(renderedBytes, mimeType, Url.Encode("拣货信息表.pdf"));


        }


        public ActionResult x2(string abc)
        {
            //byte[] imageByte = result.ImageByte;
            byte[] imgBytes = App_Code.QrCode.Create_QrCode(abc);
            //string _x = System.Convert.ToBase64String(imgBytes);
            return File(imgBytes, @"image/jpeg");
        }

        /// <summary>
        /// 图片显示在WEB页面上
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ShowImage(string id)
        {
            byte[] imgBytes = App_Code.QrCode.Create_QrCode(id.ToString());
            return File(imgBytes, "image/jpg");
        }
        /// <summary>
        /// 仓库位置标签打印
        /// </summary>
        /// <returns></returns>
        public ActionResult CangKu_Print_View()
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();


            List<db_models.ckxxb> _ckxx = new List<db_models.ckxxb>();
            _ckxx = _rs.IQueryable<db_models.ckxxb>(x => x.ckzt == db_models.db_enum.enum_zt.可用).ToList();

            List<SelectListItem> _a = new List<SelectListItem>();

            foreach (db_models.ckxxb _k in _ckxx)
            {
                _a.Add(new SelectListItem { Text = _k.ckmc, Value = _k.zdbh.ToString() });
            }

            ViewBag.form_ckmc = _a;
            ViewBag.form_pmc = new List<SelectListItem>();

            return View();
        }

        


        //public ActionResult CangKu_Find(int l1, int l2, int h1, int h2, int ph, int col)
        //{
        //    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

        //    string _where = "";

        //    if (l1 > 0 && l2 > 0)
        //    {
        //        _where += string.Format(" And  层号 between {0} and {1}", l1, l2);
        //    }
        //    else
        //    {
        //        _where += string.Format(" And  层号 between {0} and {1}", l1, l1);
        //    }

        //    if (h1 > 0 && h2 > 0)
        //    {
        //        _where += string.Format(" And  位号 between {0} and {1}", h1, h2);
        //    }
        //    else if (h1 > 0 && h2 == 0)
        //    {
        //        _where += string.Format(" And  位号 between {0} and {1}", h1, h1);
        //    }




        //    List<Models.PwModels> _pwModels = new List<Models.PwModels>();
        //    _pwModels = _rs.FindList<Models.PwModels>(@"Select C.仓库名称 as ckmc
        //                                          ,A.排名称 as pmc
        //                                          ,B.层号 as ch
        //                                          ,B.位号 as wh
        //                                          ,B.自动编号 as zdbh
        //                                            From 仓库库位排号表 A left outer join 仓库库位配置表 B On A.自动编号 = B.排编号
        //                                                      inner join 仓库信息表 C On A.仓库编号=C.自动编号
        //                                           Where A.自动编号 = " + ph.ToString() +
        //                                          "And B.状态 = 1 " +
        //                                      _where +
        //                                          "Order by 层号,位号");

        //    //List<Models.CangKu_Print> _pwModels = new List<Models.CangKu_Print>();
        //    //string _colname = "";
        //    //for (int i = 1; i < col; i++)
        //    //{
        //    //    _colname += string.Format("[{0}],", i);
        //    //}

        //    //_colname += "[0]";

        //    //string _showname = "";
        //    //for (int i = 1; i < col; i++)
        //    //{
        //    //    _showname += string.Format("[{0}] as Ck{0},", i);
        //    //}

        //    //_showname += "[0] as Ck0";



        //    //_pwModels = _rs.FindList<Models.CangKu_Print>(@"select xh3," + _showname + @" from(
        //    //                                                select zdbh, xh% " + col.ToString() + @".0 as xh2,ceiling(Xh / " + col.ToString() + @".0) xh3
        //    //                                                from(
        //    //                                                Select ROW_NUMBER() over(order by  层号, 位号) as xh
        //    //                                                        , ltrim(str(库位编号)) + ',' + 仓库名称 + ',' +库位 as zdbh
        //    //                                                          From 仓库库位视图
        //    //                                                        Where 排编号 = " + ph.ToString() +
        //    //                                                             " And 库位状态 = 1 " +
        //    //                                                            _where +
        //    //                                                    @") X 
        //    //                                                   ) Y
        //    //                                                PIVOT
        //    //                                                (
        //    //                                                    max(zdbh) FOR
        //    //                                                    xh2 IN(" + _colname + @")
        //    //                                                ) AS T"
        //    //                                                );

        //    //string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.CangKu_Print>(_pwModels);
        //    //string _json = "{\"total\":" + _pwModels.Count().ToString() + ",\"rows\":" + _datajson + "}";
        //    //return Content(_json);

        //    //



        //    DataTable _dataTable = new DataTable();
        //    _dataTable.Columns.Add("MC", typeof(System.String));
        //    _dataTable.Columns.Add("Tb", typeof(System.Byte[]));
        //    foreach(Models.PwModels _p in _pwModels)
        //    {
        //        DataRow _dr = _dataTable.NewRow();

        //        _dr["Mc"] = _p.pmc + "-" + _p.wh + "-" + _p.ch;
        //        byte[] imgBytes = App_Code.QrCode.Create_QrCode(_p.zdbh + "," + _p.pmc + "-" + _p.wh + "-" + _p.ch);
        //        _dr["Tb"] = imgBytes;  //Convert.ToBase64String(imgBytes);

        //        _dataTable.Rows.Add(_dr);
        //    }

        //    ReportViewer _view = new ReportViewer();
        //    _view.LocalReport.EnableExternalImages = true;

        //    LocalReport localReport = new LocalReport();
        //    _view.LocalReport.ReportPath = Server.MapPath("~/Report/CangKu_Label.rdlc");

        //    ReportDataSource reportDataSource0 = new ReportDataSource("CangKu_Data", _dataTable);
        //    _view.LocalReport.DataSources.Add(reportDataSource0);

        //    string reportType = "PDF";
        //    string mimeType;
        //    string encoding;
        //    string fileNameExtension;
        //    string deviceInfo =
        //     "<DeviceInfo>" +
        //     "  <OutputFormat>PDF</OutputFormat>" +
        //     "  <PageWidth>8.27in</PageWidth>" +
        //     "  <PageHeight>11.69in</PageHeight>" +
        //     "  <MarginTop>0.0in</MarginTop>" +
        //     "  <MarginLeft>0.0in</MarginLeft>" +
        //     "  <MarginRight>0.0in</MarginRight>" +
        //     "  <MarginBottom>0.0in</MarginBottom>" +
        //     "</DeviceInfo>";
        //    Warning[] warnings;
        //    string[] streams;
        //    byte[] renderedBytes;
        //    renderedBytes = _view.LocalReport.Render(
        //        reportType,
        //        deviceInfo,
        //        out mimeType,
        //        out encoding,
        //        out fileNameExtension,
        //        out streams,
        //        out warnings);
        //    return File(renderedBytes, mimeType);


        //}

        public ActionResult CangKu_Print()
        {
            int l1, l2;
            l1 =Int32.Parse(Request["l1"]!=""? Request["l1"]:"0");
            l2 =Int32.Parse(Request["l2"] != "" ? Request["l2"] : "0");

            int h1, h2;
            h1 = Int32.Parse(Request["h1"] != "" ? Request["h1"] : "0");
            h2 = Int32.Parse(Request["h2"] != "" ? Request["h2"] : "0");

            string ph;
            ph = Request["ph"].ToString();

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            string _where = "";

            if (l1 > 0 && l2 > 0)
            {
                _where += string.Format(" And  层号 between {0} and {1}", l1, l2);
            }
            else
            {
                _where += string.Format(" And  层号 between {0} and {1}", l1, l1);
            }

            if (h1 > 0 && h2 > 0)
            {
                _where += string.Format(" And  位号 between {0} and {1}", h1, h2);
            }
            else if (h1 > 0 && h2 == 0)
            {
                _where += string.Format(" And  位号 between {0} and {1}", h1, h1);
            }

            List<Models.PwModels> _pwModels = new List<Models.PwModels>();
            _pwModels = _rs.FindList<Models.PwModels>(@"Select C.仓库名称 as ckmc
                                                  ,A.排名称 as pmc
                                                  ,B.层号 as ch
                                                  ,B.位号 as wh
                                                  ,B.自动编号 as zdbh
                                                    From 仓库库位排号表 A left outer join 仓库库位配置表 B On A.自动编号 = B.排编号
                                                              inner join 仓库信息表 C On A.仓库编号=C.自动编号
                                                   Where A.自动编号 = " +ph+
                                                  " And B.状态 = 1 " +
                                                  _where+
                                                  " Order by 层号,位号");
            DataTable _dataTable = new DataTable();
            _dataTable.Columns.Add("CkWz", typeof(System.String));
            _dataTable.Columns.Add("CkEwm", typeof(System.Byte[]));
            _dataTable.Columns.Add("CkPai", typeof(System.String));

            foreach (Models.PwModels _p in _pwModels)
            {
                DataRow _dr = _dataTable.NewRow();
                _dr["CkPai"] = _p.pmc;
                _dr["CkWz"] = _p.wh + "-" + _p.ch;
                byte[] imgBytes = App_Code.QrCode.Create_QrCode(_p.zdbh + ","+_p.ckmc+"," + _p.pmc + "-" + _p.wh + "-" + _p.ch);
                _dr["CkEwm"] = imgBytes;  //Convert.ToBase64String(imgBytes);

                _dataTable.Rows.Add(_dr);
            }

            ReportViewer _view = new ReportViewer();
            _view.LocalReport.EnableExternalImages = true;

            LocalReport localReport = new LocalReport();
            _view.LocalReport.ReportPath = Server.MapPath("~/Report/CangKu_Label.rdlc");

            ReportDataSource reportDataSource0 = new ReportDataSource("CangKu_Data", _dataTable);
            _view.LocalReport.DataSources.Add(reportDataSource0);

            string reportType = "PDF"; //Word
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceInfo=
            "<DeviceInfo>" +
            "  <OutputFormat>PDF</OutputFormat>" +
            "  <PageWidth>8.27in</PageWidth>" +
            "  <PageHeight>11.69in</PageHeight>" +
            "  <MarginTop>0.0in</MarginTop>" +
            "  <MarginLeft>0.2in</MarginLeft>" +
            "  <MarginRight>0in</MarginRight>" +
            "  <MarginBottom>0.0in</MarginBottom>" +
            "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            renderedBytes = _view.LocalReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
            return File(renderedBytes, mimeType);
        }


        /// <summary>
        /// 仓库列显示
        /// </summary>
        /// <returns></returns>
        public ActionResult CangKu_Lie_List(int id)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            List<db_models.ckxx_kwph> _kwph = new List<db_models.ckxx_kwph>();
            _kwph = _rs.IQueryable<db_models.ckxx_kwph>(x => x.ckbh == id).ToList();

            return Json(_kwph, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 入库信息浏览
        /// </summary>
        /// <returns></returns>
        public ActionResult RuKu_Log_View()
        {
            return View();
        }

        /// <summary>
        /// 入库信息查询
        /// </summary>
        /// <returns></returns>
        public ActionResult RuKu_Log_Find(int limit, int offset)
        {
            string _where = "1=1";
            if (Request["srkfs"].ToString() != "" && Request["srkfs"].ToString() != "0")
            {
                _where += string.Format(" And A.入库方式码 ={0} ", Request["srkfs"].ToString());
            }

            if (Request["scpmc"].ToString() != "")
            {
                _where += string.Format(" And B.钢丝名称 like '%{0}%' ", Request["scpmc"].ToString());
            }

            if (Request["srkrq1"] != null && Request["srkrq2"] != null && !String.IsNullOrEmpty(Request["srkrq1"].ToString()) && !String.IsNullOrEmpty(Request["srkrq2"].ToString()))
            {
                _where += " And A.入库日期>= '" + Request["srkrq1"].ToString() + "' And A.入库日期<DateAdd(day,1,'" + Request["srkrq2"].ToString() + "')";
            }

            if (Request["srkrq1"] != null && Request["srkrq2"] != null && !String.IsNullOrEmpty(Request["srkrq1"].ToString()) && String.IsNullOrEmpty(Request["srkrq2"].ToString()))
            {
                _where += " And A.入库日期 >= '" + Request["srkrq1"].ToString() + "'";
            }

            if (Request["srkrq1"] != null && Request["srkrq2"] != null && String.IsNullOrEmpty(Request["srkrq1"].ToString()) && !String.IsNullOrEmpty(Request["srkrq2"].ToString()))
            {
                _where += " And A.入库日期 <DateAdd(Day,1,'" + Request["srkrq2"].ToString() + "')";
            }

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
            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "A.入库日期";
            _p.sord = "desc";

            // 数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.RuKu_Mx> RKMx = new List<Models.RuKu_Mx>();
            RKMx = _rs.IQueryable<Models.RuKu_Mx>(@"select A.自动编号 as zdbh
	                                                       ,B.钢丝名称 as cpmc
                                                           ,批号 as ph   
                                                           ,B.净重 as zl
	                                                       ,B.钢号 as gh
	                                                       ,B.规格 as gg
	                                                       ,B.组别 as zb
	                                                       ,B.公差 as gc
	                                                       ,B.插入时间 as crrq
	                                                       ,C.仓库名称 as ckmc
	                                                       ,C.库位 as kwmc
	                                                       ,A.入库日期 as rkrq
	                                                       ,G.用户姓名 as czymc
	                                                       ,A.入库方式码 as rkfsbm
	                                                        from 成品入库表 A left outer join 成品信息表_4 B On A.成品信息编号=B.自动编号 
							                                                     left outer join 仓库库位视图 C On A.库位号=C.库位编号
							                                                     left outer join v_user G On A.操作人编码 =G.用户编码 
                                                            Where " + _where
                                                      , _p).ToList();

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.RuKu_Mx>(RKMx);
            string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }

        //
        /// <summary>
        /// 出库信息浏览
        /// </summary>
        /// <returns></returns>
        public ActionResult ChuKu_Log_View()
        {
            return View();
        }

        /// <summary>
        /// 出库信息查询
        /// </summary>
        /// <returns></returns>
        public ActionResult ChuKu_Log_Find(int limit, int offset)
        {
            string _where = "1=1";
            if (Request["srkfs"].ToString() != "" && Request["srkfs"].ToString() != "0")
            {
                _where += string.Format(" And 出库方式码 ={0} ", Request["srkfs"].ToString());
            }

            if (Request["scpmc"].ToString() != "")
            {
                _where += string.Format(" And 钢丝名称 like '%{0}%' ", Request["scpmc"].ToString());
            }

            if (Request["srkrq1"] != null && Request["srkrq2"] != null && !String.IsNullOrEmpty(Request["srkrq1"].ToString()) && !String.IsNullOrEmpty(Request["srkrq2"].ToString()))
            {
                _where += " And 出库日期>= '" + Request["srkrq1"].ToString() + "' And 出库日期<DateAdd(Day,1,'" + Request["srkrq2"].ToString() + "')";
            }

            if (Request["srkrq1"] != null && Request["srkrq2"] != null && !String.IsNullOrEmpty(Request["srkrq1"].ToString()) && String.IsNullOrEmpty(Request["srkrq2"].ToString()))
            {
                _where += " And 出库日期 >= '" + Request["srkrq1"].ToString() + "'";
            }

            if (Request["srkrq1"] != null && Request["srkrq2"] != null && String.IsNullOrEmpty(Request["srkrq1"].ToString()) && !String.IsNullOrEmpty(Request["srkrq2"].ToString()))
            {
                _where += " And 出库日期 <DateAdd(Day,1,'" + Request["srkrq2"].ToString() + "')";
            }

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
            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "出库日期";
            _p.sord = "desc";

            // 数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.ChuKu_Mx> CKMx = new List<Models.ChuKu_Mx>();
            CKMx = _rs.IQueryable<Models.ChuKu_Mx>(@"select 
		                                                钢丝名称 as cpmc
		                                                ,批号 as ph
		                                                 ,钢号 as gh
                                                         ,规格 as gg
                                                         ,组别 as zb
                                                        ,公差 as gc
		                                                ,净重 as zl
		                                                ,C.仓库名称 as ckmc
		                                                ,出库日期 as ckrq
		                                                ,出库方式码 as ckfsbm
		                                                ,F.用户姓名 as czymc
	                                                 From 成品出库表 A left outer join  
					                                                (select B1.成品信息编号
							                                                ,B1.库位号
						                                                 from 成品入库表 B1 inner join
											                                                 (Select 成品信息编号
													                                                ,Max(入库日期) as 入库日期
												                                                 From 成品入库表 Group By 成品信息编号) B2 on B1.成品信息编号=B2.成品信息编号 And B1.入库日期=B2.入库日期) B
						                                                on A.成品信息编号=B.成品信息编号
					                                                inner join 成品信息表_4 X on A.成品信息编号=X.自动编号
					                                                left outer join 仓库库位视图 C on B.库位号=C.库位编号
					                                                left outer join v_user F on A.操作人编码=F.用户编码
                                                            Where " + _where
                                                      , _p).ToList();

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.ChuKu_Mx>(CKMx);
            string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }

        //

        //
        /// <summary>
        /// 安全库存信息浏览
        /// </summary>
        /// <returns></returns>
        public ActionResult AnQuanKuCun_Data_View()
        {
            return View();
        }

        /// <summary>
        /// 安全库存信息查询
        /// </summary>
        /// <returns></returns>
        public ActionResult AnQuanKuCun_Data_Find(int limit, int offset)
        {
            string _where = "1=1";

            if (Request["scpmc"].ToString() != "")
            {
                _where += string.Format(" And 钢丝名称 like '%{0}%' ", Request["scpmc"].ToString());
            }

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
            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "C.钢丝名称";
            _p.sord = "desc";

            // 数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.AnQuanKuCun> _Mx = new List<Models.AnQuanKuCun>();
            _Mx = _rs.IQueryable<Models.AnQuanKuCun>(@"select	C.钢丝名称 as cpmc
		                                                    ,C.钢号 as gh
		                                                    ,C.规格 as gg
		                                                    ,C.组别 as zb
		                                                    ,A.安全库存重量 as aqkczl
		                                                    ,C._sum as kczl
		                                                    ,C._count as kcsl
                                                            ,A.自动编号 as zdbh
	                                                     From 成品安全库存表 A inner join 产品表_2 B On A.产品编码=B.自动编号 
						                                                       inner join  (Select 钢丝名称
												                                                    ,钢号
												                                                    ,规格
												                                                    ,组别
												                                                    ,Count(1) as _count
												                                                    ,Sum(净重) as _sum
											                                                     From 成品信息表_4 C1 inner join 成品库位表 C2 On C1.自动编号=C2.成品编号 
												                                                    Group By 钢丝名称,钢号,规格,组别 ) C On B.产品名称=C.钢丝名称 And A.钢号=C.钢号 And A.规格=C.规格 And A.组别=C.组别 
                                                            Where " + _where
                                                      , _p).ToList();

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.AnQuanKuCun>(_Mx);
            string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }

        //
        /// <summary>
        /// 库位图浏览
        /// </summary>
        /// <returns></returns>
        public ActionResult KuWeiTu_View()
        {
            // 数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            DataSet _ds = _rs.GetDataSet(@"select Count(1) as _count
                                            From 仓库信息表 A inner join 仓库库位排号表 B On A.自动编号 = B.仓库编号 inner join 仓库库位配置表 C on B.自动编号 = C.排编号
                                             Where A.仓库类型 = 3 And A.仓库状态 = 1;
                                          select Count(1) as _count
                                            From(select 1 as sl from 成品库位表 group by 库位编号) A");

            //库位总数
            ViewBag._KcZl = _ds.Tables[0].Rows[0][0].ToString();
            //库位未占用
            ViewBag._KcWyl = ((int)_ds.Tables[0].Rows[0][0] - (int)_ds.Tables[1].Rows[0][0]).ToString();
            //库位占用量
            ViewBag._KcZyl = _ds.Tables[1].Rows[0][0].ToString();



            return View();
        }

        /// <summary>
        /// 库位图查询后显示的图表
        /// </summary>
        /// <returns></returns>
        public ActionResult KuWeiTu_Details_Find_View()
        {
            string _ckbh = null;
            string _ph = "", _gsmc = "", _gg = "", _zb = "", _khbm = "", _gz = "";
            if (Request["ph"] != null)
            {
                _ph = Request["ph"].ToString();
                _gsmc = Request["gsmc"].ToString();
                _gg = Request["gg"].ToString();
                _zb = Request["zb"].ToString();
                _khbm = Request["khbm"].ToString();
                _gz = Request["gz"].ToString();
            }

            ViewBag._ph = _ph;
            ViewBag._gsmc = _gsmc;
            ViewBag._gg = _gg;
            ViewBag._zb = _zb;
            ViewBag._khbm = _khbm;
            ViewBag._gz = _gz;

            string _where = "1=1 ";
            if (_ph != "")
            {
                _where += " And 生产批次='" + _ph + "'";
            }
            if (_gsmc != "")
            {
                _where += " And 钢丝名称 like '%" + _gsmc + "%'";
            }
            if (_gg != "")
            {
                _where += " And 规格='" + _gg + "'";
            }
            if (_zb != "")
            {
                _where += " And 组别='" + _zb + "'";
            }
            if (_khbm != "")
            {
                _where += " And 客户代码='" + _khbm + "'";
            }
            if (_gz != "")
            {
                _where += " And 钢号='" + _gz + "'";
            }


            // 数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            var _ck = _rs.FindEntity<db_models.ckxxb>(x => x.cklx == db_models.db_enum.enum_cklx.成品库);
            if (_ck != null)
            {
                _ckbh = _ck.zdbh.ToString();
            }

            if (_ckbh == null)
            {
                return View();
            }

            string _pBh = "";
            string _pZyl = "";
            string _pWyl = "";

            DataSet _ds = _rs.GetDataSet(string.Format(@"select Y.排名称 pmc
                                                                ,count(1) psl
                                                                from (
                                                                    select 库位编号
	                                                                    from 成品库位表 A inner join 成品信息表_4 B On A.成品编号=B.自动编号 
                                                                        Where  {1}
												                            Group By A.库位编号) X
                                                                inner join  仓库库位视图 Y On X.库位编号=Y.库位编号
                                                                    Where Y.仓库编号={0}
                                                                    Group By Y.排名称"
                                                        , _ckbh, _where));
            if (_ds.Tables[0].Rows.Count == 0)
            {
                _pBh = "0";
                //库位列占用量
                _pZyl = "0";
                //库位列未用量
                _pWyl = "0";
            }
            else
            {
                foreach (DataRow _dr in _ds.Tables[0].Rows)
                {
                    _pBh += "," + _dr["pmc"].ToString() + "排";
                    _pZyl += "," + _dr["psl"].ToString();
                    _pWyl += ",0";
                }
            }

            //库位列名称
            ViewBag._KcLMc = _pBh.Substring(1);
            //库位列占用量
            ViewBag._KcLZyl = _pZyl.Substring(1);
            //库位列未用量
            ViewBag._KcLWyl = _pWyl.Substring(1);

            return View();

        }


        /// <summary>
        /// 库位图详情
        /// </summary>
        /// <returns></returns>
        public ActionResult KuWeiTu_Details_View()
        {

            string _ckbh = null;



            // 数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            var _ck=_rs.FindEntity<db_models.ckxxb>(x => x.cklx == db_models.db_enum.enum_cklx.成品库);
            if(_ck!=null)
            {
                _ckbh = _ck.zdbh.ToString();
            }

            if(_ckbh==null)
            {
                return View();
            }

            DataSet _ds = _rs.GetDataSet(string.Format(@"select 排名称 as pmc,isnull(cs,0) as psl
                                                            from (select 排编号,count(1) as cs from 仓库库位配置表 group by 排编号) A right outer join 仓库库位排号表 B on A.排编号=B.自动编号
                                                                Where B.仓库编号={0}
                                                           select 排名称 as pmc
                                                                ,count(1) as psl
                                                            from (select 库位编号
                                                                        from 成品库位表 
                                                                            group by 库位编号
                                                                   ) A inner join 仓库库位视图 B on A.库位编号=B.库位编号
                                                               where 仓库编号={0}
                                                                group by B.排名称"
                                                        , _ckbh));

            string _pBh = "";
            string _pSl = "";
            string _pZyl = "";
            string _pWyl = "";

            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _pBh += "," + _dr["pmc"].ToString() + "排";
                //占用量
                var _s = _ds.Tables[1].AsEnumerable().Where(p => p.Field<string>("pmc") == (string)_dr["pmc"]).Select(p => new { _pbh = p.Field<string>("pmc"), _psl = p.Field<Int32>("psl") }).ToList();
                if (_s.Count > 0)
                {
                    _pWyl += "," + ((Int32)_dr["psl"] - _s[0]._psl).ToString();
                    _pZyl += "," + _s[0]._psl.ToString();
                }
                else
                {
                    _pWyl += "," + _dr["psl"].ToString();
                    _pZyl += ",0";
                }
            }
            //库位列名称
            ViewBag._KcLMc = _pBh.Substring(1);
            //库位列占用量
            ViewBag._KcLZyl = _pZyl.Substring(1);
            //库位列未用量
            ViewBag._KcLWyl = _pWyl.Substring(1);

            return View();
        }

        /// <summary>
        /// 排信息显示
        /// </summary>
        /// <returns></returns>
        public ActionResult KuWeiTu_Line_Details_View(string pbh)
        {
            string _pbh = pbh.Replace("排","");
            // 数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.PwModels> _pwModels = new List<Models.PwModels>();
            //_pwModels = _rs.FindList<Models.PwModels>(string.Format(@"select A.状态 zt
            //                                                ,A.层号 ch
            //                                                ,A.位号 wh
            //                                                ,间距 jj
            //                                                ,C.zcxx kwxx
            //                                                    from 仓库库位配置表 A 
            //                                                   inner join 仓库库位排号表 B on A.排编号=B.自动编号
            //                                                   left outer join 
            //                                            (select 库位编号
            //                                             ,stuff((select ';'+ltrim(C12.钢丝名称)+','+ltrim(str(C12.净重))
            //                                             from 成品库位表 C11 Inner Join 成品信息表_4 C12 On C11.成品编号=C12.自动编号 Where C11.库位编号=C1.库位编号
            //                                              for xml path('')),1,1,'') as zcxx
            //                                             from 成品库位表 C1 inner join 仓库库位配置表 C2 on C1.库位编号=C2.自动编号 
            //                                                   inner join 仓库库位排号表 C3 on C2.排编号=C3.自动编号
            //                                              where C2.排编号 ={0} group by 库位编号) C on A.自动编号=C.库位编号
            //                                            where A.排编号={0} order by 层号,位号"
            //                                            , _pbh));

            //注释掉了,可以使用
            //_pwModels = _rs.FindList<Models.PwModels>(string.Format(@"select 1 zt
            //                                                ,A.层号 ch
            //                                                ,A.位号 wh
            //                                                ,999 jj
            //                                                ,C.zcxx kwxx
            //                                                    from 仓库库位视图 A 
            //                                                   left outer join 
            //                                            (select C1.库位编号
            //                                             ,stuff((select ';'+ltrim(C12.钢丝名称)+','+ltrim(str(C12.净重))
            //                                             from 成品库位表 C11 Inner Join 成品信息表_4 C12 On C11.成品编号=C12.自动编号 Where C11.库位编号=C1.库位编号
            //                                              for xml path('')),1,1,'') as zcxx
            //                                             from 成品库位表 C1 inner join 仓库库位视图 C2 on C1.库位编号=C2.库位编号
            //                                              where C2.排名称 ='{0}' group by C1.库位编号) C on A.库位编号=C.库位编号
            //                                            where A.排名称='{0}' order by 层号,位号"
            //                                         , _pbh));


            _pwModels = _rs.FindList<Models.PwModels>(string.Format(@"Select '共'+Cast(sl as varchar(10))+'件,总重量:'+cast(zl as varchar(10))+'Kg' as kwxx
	                                                                       ,isnull(kwbh,0) as zdbh
	                                                                       ,1 zt
	                                                                       ,B.层号 ch
	                                                                       ,B.位号 wh
	                                                                        ,999 jj
	                                                                        From 
                                                                    (
                                                                    select count(1) as sl,sum(A2.净重) as zl,A1.库位编号 as kwbh
	                                                                        from 成品库位表 A1 Inner Join 成品信息表_4 A2 On A1.成品编号=A2.自动编号
							                                                                    Inner Join 仓库库位视图 A3 On A1.库位编号=A3.库位编号
	                                                                    Where A3.排名称='{0}'
	                                                                    Group By A1.库位编号
                                                                    ) A right outer join 仓库库位视图 B on A.kwbh=B.库位编号
                                                                    where B.排名称='{0}' order by 层号,位号"
                                                     , _pbh));

            //循环显示表格
            int _ch = 0;
            int _twh = 0, _wh = 0;
            int _iwh = 0;
            StringBuilder _table_th = new StringBuilder();
            StringBuilder _table_td = new StringBuilder();
            foreach (Models.PwModels _kw in _pwModels)
            {
                if (_ch != _kw.ch)
                {
                    if (_ch != 0)
                    {
                        _table_td.Append(" </tr>");
                    }

                    _ch = _kw.ch;
                    _table_td.AppendFormat("<tr><td>{0}</td>", _ch);
                    _iwh = 0;
                }

                _wh = _kw.wh;
                if (_twh < _wh)
                {
                    _twh = _wh;
                }

                _iwh += 1;

                string _color = "#FFFFFF";
                switch (_kw.jj)
                {
                    case db_models.db_enum.enum_kwdx.大:
                        _color = "#7FFF00";
                        break;
                    case db_models.db_enum.enum_kwdx.中:
                        _color = "#76EEC6";
                        break;
                    case db_models.db_enum.enum_kwdx.小:
                        _color = "#63B8FF";
                        break;
                }

                if (_iwh == _kw.wh)
                {
                    _table_td.Append(string.Format("<td style=\"background:{2}\" title=\"{1}\" ><a href='javascript:detailed({3})'>{0}</a></td>", _kw.kwxx, _kw.ch.ToString() + "-" + _kw.wh.ToString(), _color,_kw.zdbh));
                }
                else
                {
                    for (int i = 0; i < _wh - _iwh; i++)
                    {
                        _table_td.Append("<td></td>");
                    }
                    _iwh += _wh - _iwh;
                    _table_td.Append(string.Format("<td style=\"background:{2}\" title=\"{1}\"><a href='javascript:detailed({3})'>{0}</a></td>", _kw.kwxx, _kw.ch.ToString() + "-" + _kw.wh.ToString(), _color, _kw.zdbh));
                }

            }

            ViewBag.phmc = "";
            if (_pwModels != null && _pwModels.Count > 0)
            {
                ViewBag.phmc = _pwModels[0].pmc + "排货架";
            }

            for (int i = 1; i <= _twh; i++)
            {
                _table_th.AppendFormat("<th>{0}</th>", i.ToString());
            }

            _table_td.Append("</tr>");

            ViewBag.Tr = _table_td.ToString();
            ViewBag.Th = _table_th.ToString();

            //

            return View();
        }

        /// <summary>
        /// 库位图查询明细
        /// </summary>
        /// <param name="pbh"></param>
        /// <returns></returns>
        public ActionResult KuWeiTu_Line_Details_Find_View(string pbh)
        {

            string _ph = "", _gsmc = "", _gg = "", _zb = "", _khbm = "", _gz = "";
            if (Request["ph"] != null)
            {
                _ph = Request["ph"].ToString();
                _gsmc = Request["gsmc"].ToString();
                _gg = Request["gg"].ToString();
                _zb = Request["zb"].ToString();
                _khbm = Request["khbm"].ToString();
                _gz = Request["gz"].ToString();
            }

            ViewBag._ph = _ph;
            ViewBag._gsmc = _gsmc;
            ViewBag._gg = _gg;
            ViewBag._zb = _zb;
            ViewBag._khbm = _khbm;
            ViewBag._gz = _gz;


            string _where = "";
            if (_ph != "")
            {
                _where += " And 生产批次='" + _ph + "'";
            }
            if (_gsmc != "")
            {
                _where += " And 钢丝名称 like '%" + _gsmc + "%'";
            }
            if (_gg != "")
            {
                _where += " And 规格='" + _gg + "'";
            }
            if (_zb != "")
            {
                _where += " And 组别='" + _zb + "'";
            }
            if (_khbm != "")
            {
                _where += " And 客户代码='" + _khbm + "'";
            }
            if (_gz != "")
            {
                _where += " And 钢号='" + _gz + "'";
            }

            string _pbh = pbh.Replace("排", "");
            // 数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.PwModels> _pwModels = new List<Models.PwModels>();

            _pwModels = _rs.FindList<Models.PwModels>(string.Format(@"Select '找到'+Cast(sl as varchar(10))+'件,总重量:'+cast(zl as varchar(10))+'Kg' as kwxx
	                                                                       ,isnull(kwbh,0) as zdbh
	                                                                       ,1 zt
	                                                                       ,B.层号 ch
	                                                                       ,B.位号 wh
	                                                                        ,999 jj
	                                                                        From 
                                                                    (
                                                                    select count(1) as sl,sum(A2.净重) as zl,A1.库位编号 as kwbh
	                                                                        from 成品库位表 A1 Inner Join 成品信息表_4 A2 On A1.成品编号=A2.自动编号
							                                                                    Inner Join 仓库库位视图 A3 On A1.库位编号=A3.库位编号
	                                                                    Where A3.排名称='{0}' {1}
	                                                                    Group By A1.库位编号
                                                                    ) A right outer join 仓库库位视图 B on A.kwbh=B.库位编号
                                                                    where B.排名称='{0}' order by 层号,位号"
                                                     , _pbh,_where));

            //循环显示表格
            int _ch = 0;
            int _twh = 0, _wh = 0;
            int _iwh = 0;
            StringBuilder _table_th = new StringBuilder();
            StringBuilder _table_td = new StringBuilder();
            foreach (Models.PwModels _kw in _pwModels)
            {
                if (_ch != _kw.ch)
                {
                    if (_ch != 0)
                    {
                        _table_td.Append(" </tr>");
                    }

                    _ch = _kw.ch;
                    _table_td.AppendFormat("<tr><td>{0}</td>", _ch);
                    _iwh = 0;
                }

                _wh = _kw.wh;
                if (_twh < _wh)
                {
                    _twh = _wh;
                }

                _iwh += 1;

                string _color = "#FFFFFF";
                switch (_kw.jj)
                {
                    case db_models.db_enum.enum_kwdx.大:
                        _color = "#7FFF00";
                        break;
                    case db_models.db_enum.enum_kwdx.中:
                        _color = "#76EEC6";
                        break;
                    case db_models.db_enum.enum_kwdx.小:
                        _color = "#63B8FF";
                        break;
                }

                if (_iwh == _kw.wh)
                {
                    _table_td.Append(string.Format("<td style=\"background:{2}\" title=\"{1}\" ><a href='javascript:detailed({3})'>{0}</a></td>", _kw.kwxx, _kw.ch.ToString() + "-" + _kw.wh.ToString(), _color, _kw.zdbh));
                }
                else
                {
                    for (int i = 0; i < _wh - _iwh; i++)
                    {
                        _table_td.Append("<td></td>");
                    }
                    _iwh += _wh - _iwh;
                    _table_td.Append(string.Format("<td style=\"background:{2}\" title=\"{1}\"><a href='javascript:detailed({3})'>{0}</a></td>", _kw.kwxx, _kw.ch.ToString() + "-" + _kw.wh.ToString(), _color, _kw.zdbh));
                }

            }

            ViewBag.phmc = "";
            if (_pwModels != null && _pwModels.Count > 0)
            {
                ViewBag.phmc = _pwModels[0].pmc + "排货架";
            }

            for (int i = 1; i <= _twh; i++)
            {
                _table_th.AppendFormat("<th>{0}</th>", i.ToString());
            }

            _table_td.Append("</tr>");

            ViewBag.Tr = _table_td.ToString();
            ViewBag.Th = _table_th.ToString();

            //

            return View();
        }

        public ActionResult KuWeiTu_Row_Find_Details(int Kwbh)
        {

            string _ph = "", _gsmc = "", _gg = "", _zb = "", _khbm = "", _gz = "";
            if (Request["ph"] != null)
            {
                _ph = Request["ph"].ToString();
                _gsmc = Request["gsmc"].ToString();
                _gg = Request["gg"].ToString();
                _zb = Request["zb"].ToString();
                _khbm = Request["khbm"].ToString();
                _gz = Request["gz"].ToString();
            }


            string _where = "";
            if (_ph != "")
            {
                _where += " And 生产批次='" + _ph + "'";
            }
            if (_gsmc != "")
            {
                _where += " And 钢丝名称 like '%" + _gsmc + "%'";
            }
            if (_gg != "")
            {
                _where += " And 规格='" + _gg + "'";
            }
            if (_zb != "")
            {
                _where += " And 组别='" + _zb + "'";
            }
            if (_khbm != "")
            {
                _where += " And 客户代码='" + _khbm + "'";
            }
            if (_gz != "")
            {
                _where += " And 钢号='" + _gz + "'";
            }

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.RuKu_Mx> RKMx = new List<Models.RuKu_Mx>();
            RKMx = _rs.IQueryable<Models.RuKu_Mx>(@"select A.自动编号 as zdbh
	                                                       ,B.钢丝名称 as cpmc
                                                           ,批号 as ph   
                                                           ,B.净重 as zl
	                                                       ,B.钢号 as gh
	                                                       ,B.规格 as gg
	                                                       ,B.组别 as zb
	                                                       ,B.公差 as gc
	                                                       ,B.插入时间 as crrq
                                                           ,C.库位 as kwmc
	                                                        from 成品库位表 A inner join 成品信息表_4 B On A.成品编号=B.自动编号 
                                                                              inner join 仓库库位视图 C On A.库位编号=C.库位编号
                                                            Where A.库位编号=" + Kwbh.ToString() +_where
                                                      ).ToList();

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.RuKu_Mx>(RKMx);
            string _json = "{\"total\":" + RKMx.Count.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }


        public ActionResult KuWeiTu_Row_Details(int Kwbh)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.RuKu_Mx> RKMx = new List<Models.RuKu_Mx>();
            RKMx = _rs.IQueryable<Models.RuKu_Mx>(@"select A.自动编号 as zdbh
	                                                       ,B.钢丝名称 as cpmc
                                                           ,批号 as ph   
                                                           ,B.净重 as zl
	                                                       ,B.钢号 as gh
	                                                       ,B.规格 as gg
	                                                       ,B.组别 as zb
	                                                       ,B.公差 as gc
	                                                       ,B.插入时间 as crrq
                                                           ,C.库位 as kwmc
	                                                       ,D.成品库存编号 as sdzt
                                                           ,B.生产日期 as scrq
	                                                        from 成品库位表 A inner join 成品信息表_4 B On A.成品编号=B.自动编号 
                                                                              inner join 仓库库位视图 C On A.库位编号=C.库位编号
																			  left outer join 成品库存锁定表 D on A.成品编号=D.成品库存编号
                                                            Where A.库位编号=" + Kwbh.ToString()
                                                      ).ToList();

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.RuKu_Mx>(RKMx);
            string _json = "{\"total\":" + RKMx.Count.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }

        /// <summary>
        /// 仓库信息数据输入(粘贴,从Excel中)
        /// </summary>
        /// <returns></returns>
        public ActionResult Ckxx_Data_Input_ImPort()
        {
            if(Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();
                db_models.ckxxb _ts = new db_models.ckxxb();

                _jsons.info = "数据增加成功!";
                _jsons.mess ="数据增加成功!";
                _jsons.status = 1;


                string _txt = Request["excel_ckxx"].ToString();
                List<Models.ExcelModels> _sr = new List<Models.ExcelModels>();
                //
                try
                {
                    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                    _rs = new SD.Data.RepositoryBase();
                    _rs.FindList<BK_MES_MVC.Models.One>("truncate table 成品信息临时表");

                    var s2 = _txt.Split(new string[] { "\t\n" }, StringSplitOptions.None);
                    foreach (var s1 in _txt.Split(new string[] { "\t\n" }, StringSplitOptions.None).Where(s => !string.IsNullOrEmpty(s)))
                    {
                        string[] _st = s1.Split(new string[] { "\t" }, StringSplitOptions.None);
                        Models.ExcelModels _tmp = new Models.ExcelModels();
                        for (int i = 0; i < 21; i++)
                        {
                            string _sa = "A" + i.ToString();
                            if (i < _st.Length)
                            {
                                _tmp.GetType().GetProperty(_sa).SetValue(_tmp, _st[i].Trim(), null);
                            }
                            else
                            {
                                _tmp.GetType().GetProperty(_sa).SetValue(_tmp, null, null);
                            }
                        }
                        _sr.Add(_tmp);
                    }

                    //保存
                    int icount = 0;
                    List<db_models.cpxxb_temp> _cpxxb = new List<db_models.cpxxb_temp>();
                    foreach (Models.ExcelModels _s in _sr)
                    {
                        SD.Data.IRepositoryBase _rs_sr = new SD.Data.RepositoryBase();
                        //if (_rs_sr.FindEntity<db_models.cpxxb_4>(x => x.sjbh == _s.A0) != null)
                        //{
                        //    //
                        //    continue;
                        //}
                        icount += 1;

                        DateTime? _a1=null;
                        DateTime _date;
                        if (DateTime.TryParse(_s.A1, out _date))
                        { _a1 = _date; }
                        else
                        {
                            _a1 = null;
                        }
                        
                        decimal _a11;
                        decimal.TryParse(_s.A11, out _a11);



                        DateTime? _a14;
                        if(_s.A14.Length>1 && DateTime.TryParse(_s.A14.Substring(0,_s.A14.Length-1), out _date))
                        {
                            _a14 = _date;
                        }
                        else
                        { _a14 = null; }


                        DateTime? _a18;

                        if (DateTime.TryParse(_s.A18, out _date))
                        {
                            _a18 = _date;
                        }
                        else if(_s.A18.Length>0)
                        {
                            _a18 = DateTime.Now;
                        }
                        else
                        { _a18 = null; }

                        if(_a18==null)
                        {
                            if (DateTime.TryParseExact(_s.A18,"yyyy年MM月dd日",null,System.Globalization.DateTimeStyles.None, out _date))
                            {
                                _a18 = _date;
                            }
                        }


                        _cpxxb.Add(new db_models.cpxxb_temp
                        {
                            sjbh = _s.A0
                                                           ,
                            scrq = _a1
                                                           ,
                            bc = _s.A2
                                                           ,
                            scpc = _s.A3
                                                           ,
                            jt = _s.A4
                                                           ,
                            gg = _s.A5
                                                           ,
                            zb = _s.A6
                                                           ,
                            khdm = _s.A7
                                                           ,
                            gh = _s.A8
                                                           ,
                            lh = _s.A9
                                                           ,
                            jh = _s.A10
                                                           ,
                            zl = _a11
                                                           ,
                            ylcd = _s.A12
                                                           ,
                            kw = _s.A13
                                                           ,
                            bzrq = _a14
                                                           ,
                            bz = _s.A19
                                                           ,
                            ckrq=_a18                     ,
                            jrrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"))
                        });
                    }

                     _rs = new SD.Data.RepositoryBase();
                    _rs.Insert<db_models.cpxxb_temp>(_cpxxb);

                    _rs = new SD.Data.RepositoryBase();
                    _rs.FindList<BK_MES_MVC.Models.One>("Execute pr_仓库_成品导入处理");

                    _jsons.info = "保存了"+ icount.ToString()+"条记录!";
                }
                catch(Exception ex)
                {
                    _jsons.info = "数据保存失败!";
                    _jsons.mess = ex.Message;
                    _jsons.status = 0;

                }

                return Json(_jsons, JsonRequestBehavior.AllowGet);

            }
            return View();
        }

        /// <summary>
        /// 成品信息浏览
        /// </summary>
        /// <returns></returns>
        public ActionResult Ckxx_View()
        {
            return View();
        }

        public ActionResult Ckxx_Find(int limit, int offset)
        {
            string _where = "1=1";

            if (Request["szt"].ToString() != "" && Request["szt"].ToString() == "1")
            {
                _where += " And B.入库日期 is null And C.出库日期 is Null  ";
            }

            if (Request["szt"].ToString() != "" && Request["szt"].ToString() == "2")
            {
                _where += " And B.入库日期 is not null ";
            }
            if (Request["szt"].ToString() != "" && Request["szt"].ToString() == "3")
            {
                _where += " And C.出库日期 is not null ";
            }

            if (Request["sph"].ToString() != "" )
            {
                _where += string.Format(" And 批号 like '%{0}%' ", Request["sph"].ToString());
            }

            if (Request["sjbh"].ToString() != "")
            {
                _where += string.Format(" And 数据编号= '{0}' ", Request["sjbh"].ToString());
            }

            if (Request["scpmc"].ToString() != "")
            {
                _where += string.Format(" And 钢丝名称 like '%{0}%' ", Request["scpmc"].ToString());
            }

            if (Request["srkrq1"] != null && Request["srkrq2"] != null && !String.IsNullOrEmpty(Request["srkrq1"].ToString()) && !String.IsNullOrEmpty(Request["srkrq2"].ToString()))
            {
                _where += " And 插入时间 >= '" + Request["srkrq1"].ToString() + "' And 插入时间<DateAdd(Day,1,'" + Request["srkrq2"].ToString() + "')";
            }

            if (Request["srkrq1"] != null && Request["srkrq2"] != null && !String.IsNullOrEmpty(Request["srkrq1"].ToString()) && String.IsNullOrEmpty(Request["srkrq2"].ToString()))
            {
                _where += " And 插入时间 >= '" + Request["srkrq1"].ToString() + "'";
            }

            if (Request["srkrq1"] != null && Request["srkrq2"] != null && String.IsNullOrEmpty(Request["srkrq1"].ToString()) && !String.IsNullOrEmpty(Request["srkrq2"].ToString()))
            {
                _where += " And 插入时间 <Dateadd(Day,1,'" + Request["srkrq2"].ToString() + "')";
            }

            //加入分页
            SD.Data.Pagination _p = new SD.Data.Pagination();

            if(Request["isfind"] != null && Request["isfind"] == "1")
            {
                offset = 0;
            }

            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "A.自动编号";
            _p.sord = "desc";

            // 数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.Ckxx_Mx> RKMx = new List<Models.Ckxx_Mx>();
            RKMx = _rs.IQueryable<Models.Ckxx_Mx>(@"select [数据编号] as sjbh
                                                                  ,[批号]	as ph
                                                                  ,[钢丝名称] as gsmc
                                                                  ,[生产日期] as scrq
                                                                  ,[班次] as bc
                                                                  ,[生产批次] as scpc
                                                                  ,[机台] as jt
                                                                  ,[规格] as gg
                                                                  ,[组别] as zb
                                                                  ,[客户代码] as khbm
                                                                  ,[钢号] as gh
                                                                  ,[炉号] as lh
                                                                  ,[卷号] as jh
                                                                  ,[净重] as zl
                                                                  ,[原料产地] as ylcd
                                                                  ,[包装日期] as bzrq
                                                                  ,[包装类别] as bzlb
                                                                  ,[出库日期2] as ckrq2
                                                                  ,[标准] as cpbz
                                                                  ,A.[备注] as bz
                                                                  ,[库位] as kw
                                                                  ,[插入时间] as jrsj
                                                                  ,D.用户姓名 as yhxm
                                                                  ,A.[自动编号] as zdbh
	                                                              ,B.入库日期 as rksj
	                                                              ,C.出库日期 as cksj
	                                                               from 成品信息表_4 A left outer join 成品入库表 B on A.自动编号=B.成品信息编号 left outer join 成品出库表 C on A.自动编号=C.成品信息编号 
						                                                               left outer join v_user D on A.加入人编码=D.用户编码
                                                                                                                        Where " + _where
                                                      , _p).ToList();

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.Ckxx_Mx>(RKMx);
            string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }

        public ActionResult Ckxx_Input(int? id)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.cpxxb_4 tFindEntity = new db_models.cpxxb_4();

            if (id != null)
            {
                tFindEntity = _rs.FindEntity<db_models.cpxxb_4>(id);
            }
            else
            {
                tFindEntity.zdbh = null;
            }
           
            return View(tFindEntity);
        }

        public ActionResult Ckxx_Save()
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                db_models.cpxxb_4 _data = new db_models.cpxxb_4();

                TableRowToModel<db_models.cpxxb_4>(_data, Request.Form);

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                try
                {
                    _jsons.status = 1;

                    //_data.zl =Convert.ToDecimal(Request["zl"]);
                            _data.xgrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
                            _data.xgsj = DateTime.Now;
                    _rs.Update<db_models.cpxxb_4>(_data, new List<string> { "zl", "xgrbm", "xgsj" });

                    _jsons.info = "数据修改成功!";

                }
                catch (Exception ex)
                {
                    _jsons.info = "数据处理失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        /// <summary>
        /// 安全是库存数据删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Ckxx_Dele(db_models.cpxxb_4 _key)
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                db_models.cpxxb_4 _data = new db_models.cpxxb_4();

                _data.zdbh = _key.zdbh;

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                try
                {
                    _rs.Delete<db_models.cpxxb_4>(_data);
                    _jsons.info = "数据删除成功!";
                    _jsons.status = 1;
                }
                catch (Exception ex)
                {
                    _jsons.info = "数据删除失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        /// <summary>
        /// 盘库
        /// </summary>
        /// <returns></returns>
        public ActionResult KuCun_PanKu()
        {
            ViewBag.formBegin = "";
            ViewBag.formEnd = "disabled";

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            if (_rs.FindEntity<db_models.cppkxxb>(x => x.pkjsrq == null) != null)
            {
                ViewBag.formBegin = "disabled";
                ViewBag.formEnd = "";
            }

            return View();
        }

        public ActionResult KuCun_PanKu_Find()
        {


            //数据显示
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.KuCun_PanKu_Hz> tFindEntity = new List<Models.KuCun_PanKu_Hz>();

            tFindEntity = _rs.FindList<Models.KuCun_PanKu_Hz>(@"select B.用户姓名 as pkr
                                                                    , A.pksl
                                                                    , A.pkzt
                                                                    , A.pksj
                                                                from(
                                                                    select max(操作日期) as pksj
                                                                           , count(1) as pksl
                                                                           , 操作人编码, max(状态) as pkzt
                                                                        from 成品盘库临时表  group by 操作人编码
                                                                    ) A left outer join v_user B on A.操作人编码 = B.用户编码");

            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.KuCun_PanKu_Hz>(tFindEntity);
            string _json = "{\"total\":" + tFindEntity.Count.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }

        public ActionResult KuCun_PanKu_Begin()
        {
            BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();
            _jsons.info = "可以开始盘库了!";
            _jsons.status = 1;


            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            if (_rs.FindEntity<db_models.cppkxxb>(x => x.pkjsrq == null) != null)
            {
                _jsons.info = "上次盘库未结束!";
                _jsons.status = 0;

                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }


            db_models.cppkxxb _tEntity = new db_models.cppkxxb();
            _tEntity.pkrq = System.DateTime.Now;
            try
            {
                _rs.Insert(_tEntity);
            }
            catch (Exception ex)
            {
                _jsons.info = "无法进行盘库!";
                _jsons.status = 0;
            }

            return Json(_jsons, JsonRequestBehavior.AllowGet);
        }

        public ActionResult KuCun_PanKu_End()
        {
            BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();
            _jsons.info = "盘库正常结束!";
            _jsons.status = 1;


            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            if (_rs.FindEntity<db_models.cppkxxb>(x => x.pkjsrq == null) == null)
            {
                _jsons.info = "没有检测到盘库信息!";
                _jsons.status = 0;

                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }


            try
            {
                List<Models.One> _one =_rs.FindList<BK_MES_MVC.Models.One>("Execute PanKu_Cl");
                switch(_one[0].iu)
                {
                    case 0:
                        break;
                    case -1:
                        _jsons.info = "没有检测到盘库信息!";
                        _jsons.status = 0;
                        break;
                    case -2:
                        _jsons.info = "盘库还未完成!";
                        _jsons.status = 0;
                        break;
                    case -3:
                        _jsons.info = "已经盘库,无法修改!";
                        _jsons.status = 0;
                        break;
                }
            }
            catch (Exception ex)
            {
                _jsons.info = "无法进行盘库!";
                _jsons.status = 0;
            }

            return Json(_jsons, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 入库报表
        /// </summary>
        /// <returns></returns>
        public ActionResult RuKu_Report()
        {
            //按日,周,月,年,自定义
            //按钢号,规格,组别,客户代码统计
            if(Request.IsAjaxRequest())
            {
                if(Request["hz[]"] == null)
                {
                    return View();
                }
                string _gg = Request["gg"].ToString().Trim();
                string _zb = Request["zb"].ToString().Trim();
                string _gh = Request["gh"].ToString().Trim();
                string _khbm = Request["khbm"].ToString().Trim();
                string _hz = Request["hz[]"].ToString().Trim();
                string _rq1 = Request["rq1"].ToString().Trim();
                string _rq2 = Request["rq2"].ToString().Trim();

                string _where1 =string.Format("入库日期>='{0}' and 入库日期<DateAdd(day,1,'{1}')", _rq1,_rq2);
                string _where2 = "1=1 ";
                if (_gg!="")
                {
                    _where2 += " And 规格='" + _gg + "'";
                }
                if (_gh != "")
                {
                    _where2 += " And 钢号='" + _gh + "'";
                }
                if (_khbm != "")
                {
                    _where2 += " And 客户代码='" + _khbm + "'";
                }
                if (_zb != "")
                {
                    _where2 += " And 组别='" + _zb + "'";
                }

                string _group = _hz.Replace("1", "钢号").Replace("2", "规格").Replace("3", "组别").Replace("4", "客户代码");
                string _field = _hz.Replace("1", "钢号 as gh").Replace("2", "规格 as gg").Replace("3", "组别 as zb").Replace("4", "客户代码 as khdm");

                //加入分页
                SD.Data.Pagination _p = new SD.Data.Pagination();
                int offset = Int16.Parse(Request["offset"]);
                int limit = Int16.Parse(Request["limit"]);
                _p.page = offset / limit + 1;
                _p.rows = limit;
                _p.sidx = _group;
                _p.sord = "asc";

                // 数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                List<Models.RuKu_Mx> RKMx = new List<Models.RuKu_Mx>();
                List<Models.RuKu_Mx> SRkMx = new List<Models.RuKu_Mx>();

                try
                {
                    
                        RKMx = _rs.IQueryable<Models.RuKu_Mx>(string.Format(@"select 
                                                               {0}
                                                                ,count(1) as sl
                                                                ,sum(B.净重) as zl
                                                              From
                                                                (select 成品信息编号
                                                                        from 成品入库表
                                                                    where {1} group by 成品信息编号)  A
                                                               inner  join 成品信息表_4 B on A.成品信息编号 = B.自动编号
                                                               where {2}
                                                               group By {3}", _field, _where1, _where2, _group)
                                                                  , _p).ToList();
                    if (Request["isHz"] != null)
                    {
                        //汇总
                        SRkMx = _rs.IQueryable<Models.RuKu_Mx>(string.Format(@"select sum(sl) as sl
                                                                                ,sum(zl) as zl
                                                                        from (select 
                                                                                count(1) as sl
                                                                                ,sum(B.净重) as zl
                                                                              From
                                                                                (select 成品信息编号
                                                                                        from 成品入库表
                                                                                    where {1} group by 成品信息编号)  A
                                                                               inner  join 成品信息表_4 B on A.成品信息编号 = B.自动编号
                                                                               where {2}
                                                                               group By {3}) X", _field, _where1, _where2, _group)
                                                                           ).ToList();

                        RKMx[0].ssl = SRkMx[0].sl;
                        RKMx[0].szl = SRkMx[0].zl;
                    }

                }
                catch(Exception ex)
                {
                    MyClass.LogClass.WriteLog("ruku_report", ex.Message.ToString(), MyClass.EFlag.error);
                }
                finally
                {
                    _rs.Dispose();
                }

                string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.RuKu_Mx>(RKMx);
                string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
                return Content(_json);
            }
            return View();
        }

        public ActionResult Ruku_Hz_Print()
        {
          
            string _gg = Request["gg"].ToString().Trim();
            string _zb = Request["zb"].ToString().Trim();
            string _gh = Request["gh"].ToString().Trim();
            string _khbm = Request["khbm"].ToString().Trim();
            string _hz = Request["hz"].ToString().Trim();
            string _rq1 = Request["rq1"].ToString().Trim();
            string _rq2 = Request["rq2"].ToString().Trim();

            string _where1 = string.Format("入库日期>='{0}' and 入库日期<DateAdd(day,1,'{1}')", _rq1, _rq2);
            string _where2 = "1=1 ";
            if (_gg != "")
            {
                _where2 += " And 规格='" + _gg + "'";
            }
            if (_gh != "")
            {
                _where2 += " And 钢号='" + _gh + "'";
            }
            if (_khbm != "")
            {
                _where2 += " And 客户代码='" + _khbm + "'";
            }
            if (_zb != "")
            {
                _where2 += " And 组别='" + _zb + "'";
            }

            string _group = _hz.Replace("1", "钢号").Replace("2", "规格").Replace("3", "组别").Replace("4", "客户代码");
            string _field = _hz.Replace("1", "钢号 as gh").Replace("2", "规格 as gg").Replace("3", "组别 as zb").Replace("4", "客户代码 as khdm");


            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.RuKu_Mx> RKMx = new List<Models.RuKu_Mx>();

            try
            {
                RKMx = _rs.IQueryable<Models.RuKu_Mx>(string.Format(@"select 
                                                               {0}
                                                                ,count(1) as sl
                                                                ,sum(B.净重) as zl
                                                              From
                                                                (select 成品信息编号
                                                                        from 成品入库表
                                                                    where {1} group by 成品信息编号)  A
                                                               inner  join 成品信息表_4 B on A.成品信息编号 = B.自动编号
                                                               where {2}
                                                               group By {3}", _field, _where1, _where2, _group)
                                                                    ).ToList();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                _rs.Dispose();
            }

            DataTable _dataTable = new DataTable();
            _dataTable.Columns.Add("Gh", typeof(System.String));
            _dataTable.Columns.Add("Gg", typeof(System.String));
            _dataTable.Columns.Add("Zb", typeof(System.String));
            _dataTable.Columns.Add("Khbm", typeof(System.String));
            _dataTable.Columns.Add("Ssl", typeof(System.Int32));
            _dataTable.Columns.Add("Szl", typeof(System.Decimal));

            foreach (Models.RuKu_Mx _p in RKMx)
            {
                DataRow _dr = _dataTable.NewRow();
                _dr["Gh"] = _p.gh;
                _dr["Gg"] = _p.gg;
                _dr["Zb"] = _p.zb;
                _dr["khbm"] = _p.khdm;
                _dr["ssl"] = _p.sl;
                _dr["szl"] = _p.zl;
                _dataTable.Rows.Add(_dr);
            }

            ReportViewer _view = new ReportViewer();
            _view.LocalReport.EnableExternalImages = true;

            LocalReport localReport = new LocalReport();
            _view.LocalReport.ReportPath = Server.MapPath("~/Report/Ruku_Hz_Report.rdlc");

            List<ReportParameter> parameters = new List<ReportParameter>
            {
                new ReportParameter("srq", _rq1 + "至" + _rq2)
            };
            _view.LocalReport.SetParameters(parameters);

            //var sss= _view.LocalReport.GetParameters();

            ReportDataSource reportDataSource0 = new ReportDataSource("RuKu_Hz", _dataTable);
            _view.LocalReport.DataSources.Add(reportDataSource0);

            string reportType = "Excel"; //Word,Excel,Pdf 
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceInfo =
            "<DeviceInfo>" +
            "  <OutputFormat>Excel</OutputFormat>" +    //Word,Excel,Pdf 
            "  <PageWidth>8.27in</PageWidth>" +
            "  <PageHeight>11.69in</PageHeight>" +
            "  <MarginTop>0.0in</MarginTop>" +
            "  <MarginLeft>0.2in</MarginLeft>" +
            "  <MarginRight>0in</MarginRight>" +
            "  <MarginBottom>0.0in</MarginBottom>" +
            "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            renderedBytes = _view.LocalReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
            return File(renderedBytes, mimeType, Url.Encode("入库汇总记录.xls"));
        }


        //
        /// <summary>
        /// 出库报表
        /// </summary>
        /// <returns></returns>
        public ActionResult ChuKu_Report()
        {
            //按日,周,月,年,自定义
            //按钢号,规格,组别,客户代码统计
            if (Request.IsAjaxRequest())
            {
                if (Request["hz[]"] == null)
                {
                    return View();
                }
                string _gg = Request["gg"].ToString().Trim();
                string _zb = Request["zb"].ToString().Trim();
                string _gh = Request["gh"].ToString().Trim();
                string _khbm = Request["khbm"].ToString().Trim();
                string _hz = Request["hz[]"].ToString().Trim();
                string _rq1 = Request["rq1"].ToString().Trim();
                string _rq2 = Request["rq2"].ToString().Trim();

                string _where1 = string.Format("出库日期>='{0}' and 出库日期<DateAdd(day,1,'{1}')", _rq1, _rq2);
                string _where2 = "1=1 ";
                if (_gg != "")
                {
                    _where2 += " And 规格='" + _gg + "'";
                }
                if (_gh != "")
                {
                    _where2 += " And 钢号='" + _gh + "'";
                }
                if (_khbm != "")
                {
                    _where2 += " And 客户代码='" + _khbm + "'";
                }
                if (_zb != "")
                {
                    _where2 += " And 组别='" + _zb + "'";
                }

                string _group = _hz.Replace("1", "钢号").Replace("2", "规格").Replace("3", "组别").Replace("4", "客户代码");
                string _field = _hz.Replace("1", "钢号 as gh").Replace("2", "规格 as gg").Replace("3", "组别 as zb").Replace("4", "客户代码 as khdm");

                //加入分页
                SD.Data.Pagination _p = new SD.Data.Pagination();
                int offset = Int16.Parse(Request["offset"]);
                int limit = Int16.Parse(Request["limit"]);
                _p.page = offset / limit + 1;
                _p.rows = limit;
                _p.sidx = _group;
                _p.sord = "asc";

                // 数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                List<Models.RuKu_Mx> RKMx = new List<Models.RuKu_Mx>();
                List<Models.RuKu_Mx> SRkMx = new List<Models.RuKu_Mx>();

                try
                {

                    RKMx = _rs.IQueryable<Models.RuKu_Mx>(string.Format(@"select 
                                                               {0}
                                                                ,count(1) as sl
                                                                ,sum(B.净重) as zl
                                                              From
                                                                (select 成品信息编号
                                                                        from 成品出库表
                                                                    where {1} group by 成品信息编号)  A
                                                               inner  join 成品信息表_4 B on A.成品信息编号 = B.自动编号
                                                               where {2}
                                                               group By {3}", _field, _where1, _where2, _group)
                                                              , _p).ToList();
                    if (Request["isHz"] != null)
                    {
                        //汇总
                        SRkMx = _rs.IQueryable<Models.RuKu_Mx>(string.Format(@"select sum(sl) as sl
                                                                                ,sum(zl) as zl
                                                                        from (select 
                                                                                count(1) as sl
                                                                                ,sum(B.净重) as zl
                                                                              From
                                                                                (select 成品信息编号
                                                                                        from 成品出库表
                                                                                    where {1} group by 成品信息编号)  A
                                                                               inner  join 成品信息表_4 B on A.成品信息编号 = B.自动编号
                                                                               where {2}
                                                                               group By {3}) X", _field, _where1, _where2, _group)
                                                                           ).ToList();

                        RKMx[0].ssl = SRkMx[0].sl;
                        RKMx[0].szl = SRkMx[0].zl;
                    }

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _rs.Dispose();
                }

                string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.RuKu_Mx>(RKMx);
                string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
                return Content(_json);
            }
            return View();
        }

        public ActionResult Chuku_Hz_Print()
        {

            string _gg = Request["gg"].ToString().Trim();
            string _zb = Request["zb"].ToString().Trim();
            string _gh = Request["gh"].ToString().Trim();
            string _khbm = Request["khbm"].ToString().Trim();
            string _hz = Request["hz"].ToString().Trim();
            string _rq1 = Request["rq1"].ToString().Trim();
            string _rq2 = Request["rq2"].ToString().Trim();

            string _where1 = string.Format("出库日期>='{0}' and 出库日期<DateAdd(day,1,'{1}')", _rq1, _rq2);
            string _where2 = "1=1 ";
            if (_gg != "")
            {
                _where2 += " And 规格='" + _gg + "'";
            }
            if (_gh != "")
            {
                _where2 += " And 钢号='" + _gh + "'";
            }
            if (_khbm != "")
            {
                _where2 += " And 客户代码='" + _khbm + "'";
            }
            if (_zb != "")
            {
                _where2 += " And 组别='" + _zb + "'";
            }

            string _group = _hz.Replace("1", "钢号").Replace("2", "规格").Replace("3", "组别").Replace("4", "客户代码");
            string _field = _hz.Replace("1", "钢号 as gh").Replace("2", "规格 as gg").Replace("3", "组别 as zb").Replace("4", "客户代码 as khdm");


            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.RuKu_Mx> RKMx = new List<Models.RuKu_Mx>();

            try
            {
                RKMx = _rs.IQueryable<Models.RuKu_Mx>(string.Format(@"select 
                                                               {0}
                                                                ,count(1) as sl
                                                                ,sum(B.净重) as zl
                                                              From
                                                                (select 成品信息编号
                                                                        from 成品出库表
                                                                    where {1} group by 成品信息编号)  A
                                                               inner  join 成品信息表_4 B on A.成品信息编号 = B.自动编号
                                                               where {2}
                                                               group By {3}", _field, _where1, _where2, _group)
                                                                    ).ToList();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _rs.Dispose();
            }

            DataTable _dataTable = new DataTable();
            _dataTable.Columns.Add("Gh", typeof(System.String));
            _dataTable.Columns.Add("Gg", typeof(System.String));
            _dataTable.Columns.Add("Zb", typeof(System.String));
            _dataTable.Columns.Add("Khbm", typeof(System.String));
            _dataTable.Columns.Add("Ssl", typeof(System.Int32));
            _dataTable.Columns.Add("Szl", typeof(System.Decimal));

            foreach (Models.RuKu_Mx _p in RKMx)
            {
                DataRow _dr = _dataTable.NewRow();
                _dr["Gh"] = _p.gh;
                _dr["Gg"] = _p.gg;
                _dr["Zb"] = _p.zb;
                _dr["khbm"] = _p.khdm;
                _dr["ssl"] = _p.sl;
                _dr["szl"] = _p.zl;
                _dataTable.Rows.Add(_dr);
            }

            ReportViewer _view = new ReportViewer();
            _view.LocalReport.EnableExternalImages = true;

            LocalReport localReport = new LocalReport();
            _view.LocalReport.ReportPath = Server.MapPath("~/Report/Chuku_Hz_Report.rdlc");

            List<ReportParameter> parameters = new List<ReportParameter>
            {
                new ReportParameter("srq", _rq1 + "至" + _rq2)
            };
            _view.LocalReport.SetParameters(parameters);

            //var sss= _view.LocalReport.GetParameters();

            ReportDataSource reportDataSource0 = new ReportDataSource("RuKu_Hz", _dataTable);
            _view.LocalReport.DataSources.Add(reportDataSource0);

            string reportType = "Excel"; //Word,Excel,Pdf 
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceInfo =
            "<DeviceInfo>" +
            "  <OutputFormat>Excel</OutputFormat>" +    //Word,Excel,Pdf 
            "  <PageWidth>8.27in</PageWidth>" +
            "  <PageHeight>11.69in</PageHeight>" +
            "  <MarginTop>0.0in</MarginTop>" +
            "  <MarginLeft>0.2in</MarginLeft>" +
            "  <MarginRight>0in</MarginRight>" +
            "  <MarginBottom>0.0in</MarginBottom>" +
            "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            renderedBytes = _view.LocalReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
            return File(renderedBytes, mimeType, Url.Encode("出库汇总记录.xls"));
        }
        //


        //

        /// <summary>
        /// 库存报表
        /// </summary>
        /// <returns></returns>
        public ActionResult KuCun_Report()
        {
            //按日,周,月,年,自定义
            //按钢号,规格,组别,客户代码统计
            if (Request.IsAjaxRequest())
            {
                if (Request["hz[]"] == null)
                {
                    return View();
                }
                string _gg = Request["gg"].ToString().Trim();
                string _zb = Request["zb"].ToString().Trim();
                string _gh = Request["gh"].ToString().Trim();
                string _khbm = Request["khbm"].ToString().Trim();
                string _hz = Request["hz[]"].ToString().Trim();
                //string _rq1 = Request["rq1"].ToString().Trim();
                //string _rq2 = Request["rq2"].ToString().Trim();

                string _where1 = "";
                string _where2 = "";
                if (_gg != "")
                {
                    _where2 += " And 规格='" + _gg + "'";
                }
                if (_gh != "")
                {
                    _where2 += " And 钢号='" + _gh + "'";
                }
                if (_khbm != "")
                {
                    _where2 += " And 客户代码='" + _khbm + "'";
                }
                if (_zb != "")
                {
                    _where2 += " And 组别='" + _zb + "'";
                }

                string _group = _hz.Replace("1", "钢号").Replace("2", "规格").Replace("3", "组别").Replace("4", "客户代码");
                string _field = _hz.Replace("1", "钢号 as gh").Replace("2", "规格 as gg").Replace("3", "组别 as zb").Replace("4", "客户代码 as khdm");

                //加入分页
                SD.Data.Pagination _p = new SD.Data.Pagination();
                int offset = Int16.Parse(Request["offset"]);
                int limit = Int16.Parse(Request["limit"]);
                _p.page = offset / limit + 1;
                _p.rows = limit;
                _p.sidx = _group;
                _p.sord = "asc";

                // 数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                List<Models.RuKu_Mx> RKMx = new List<Models.RuKu_Mx>();
                List<Models.RuKu_Mx> SRkMx = new List<Models.RuKu_Mx>();

                try
                {

                    RKMx = _rs.IQueryable<Models.RuKu_Mx>(string.Format(@"select 
                                                               {0}
                                                                ,count(1) as sl
                                                                ,sum(B.净重) as zl
                                                              From
                                                                 成品库位表 A
                                                               inner join 成品信息表_4 B on A.成品编号 = B.自动编号
                                                               where  not exists(select 1 from 成品库存锁定表 x where x.成品库存编号=A.成品编号) {2}
                                                               group By {3}", _field, _where1, _where2, _group)
                                                              , _p).ToList();
                    if (Request["isHz"] != null)
                    {
                        //汇总
                        SRkMx = _rs.IQueryable<Models.RuKu_Mx>(string.Format(@"select sum(sl) as sl
                                                                                ,sum(zl) as zl
                                                                        from (select 
                                                                                count(1) as sl
                                                                                ,sum(B.净重) as zl
                                                                              From 成品库位表 A
                                                                               inner  join 成品信息表_4 B on A.成品编号 = B.自动编号
                                                                               where not exists(select 1 from 成品库存锁定表 x where x.成品库存编号=A.成品编号) {2}
                                                                               group By {3}) X", _field, _where1, _where2, _group)
                                                                           ).ToList();

                        RKMx[0].ssl = SRkMx[0].sl;
                        RKMx[0].szl = SRkMx[0].zl;
                    }

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _rs.Dispose();
                }

                string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.RuKu_Mx>(RKMx);
                string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
                return Content(_json);
            }
            return View();
        }

        public ActionResult KuCun_Hz_Print()
        {

            string _gg = Request["gg"].ToString().Trim();
            string _zb = Request["zb"].ToString().Trim();
            string _gh = Request["gh"].ToString().Trim();
            string _khbm = Request["khbm"].ToString().Trim();
            string _hz = Request["hz"].ToString().Trim();
            

            string _where1 = "";
            string _where2 = "1=1 ";
            if (_gg != "")
            {
                _where2 += " And 规格='" + _gg + "'";
            }
            if (_gh != "")
            {
                _where2 += " And 钢号='" + _gh + "'";
            }
            if (_khbm != "")
            {
                _where2 += " And 客户代码='" + _khbm + "'";
            }
            if (_zb != "")
            {
                _where2 += " And 组别='" + _zb + "'";
            }

            string _group = _hz.Replace("1", "钢号").Replace("2", "规格").Replace("3", "组别").Replace("4", "客户代码");
            string _field = _hz.Replace("1", "钢号 as gh").Replace("2", "规格 as gg").Replace("3", "组别 as zb").Replace("4", "客户代码 as khdm");


            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            List<Models.RuKu_Mx> RKMx = new List<Models.RuKu_Mx>();

            try
            {
                RKMx = _rs.IQueryable<Models.RuKu_Mx>(string.Format(@"select 
                                                               {0}
                                                                ,count(1) as sl
                                                                ,sum(B.净重) as zl
                                                              From 成品库位表 A
                                                               inner  join 成品信息表_4 B on A.成品编号 = B.自动编号
                                                               where {2}
                                                               group By {3}", _field, _where1, _where2, _group)
                                                                    ).ToList();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _rs.Dispose();
            }

            DataTable _dataTable = new DataTable();
            _dataTable.Columns.Add("Gh", typeof(System.String));
            _dataTable.Columns.Add("Gg", typeof(System.String));
            _dataTable.Columns.Add("Zb", typeof(System.String));
            _dataTable.Columns.Add("Khbm", typeof(System.String));
            _dataTable.Columns.Add("Ssl", typeof(System.Int32));
            _dataTable.Columns.Add("Szl", typeof(System.Decimal));

            foreach (Models.RuKu_Mx _p in RKMx)
            {
                DataRow _dr = _dataTable.NewRow();
                _dr["Gh"] = _p.gh;
                _dr["Gg"] = _p.gg;
                _dr["Zb"] = _p.zb;
                _dr["khbm"] = _p.khdm;
                _dr["ssl"] = _p.sl;
                _dr["szl"] = _p.zl;
                _dataTable.Rows.Add(_dr);
            }

            ReportViewer _view = new ReportViewer();
            _view.LocalReport.EnableExternalImages = true;

            LocalReport localReport = new LocalReport();
            _view.LocalReport.ReportPath = Server.MapPath("~/Report/KuCun_Hz_Report.rdlc");

            List<ReportParameter> parameters = new List<ReportParameter>
            {
                new ReportParameter("srq",DateTime.Now.ToString("yyyy-MM-dd"))
            };
            _view.LocalReport.SetParameters(parameters);

            //var sss= _view.LocalReport.GetParameters();

            ReportDataSource reportDataSource0 = new ReportDataSource("RuKu_Hz", _dataTable);
            _view.LocalReport.DataSources.Add(reportDataSource0);

            string reportType = "Excel"; //Word,Excel,Pdf 
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceInfo =
            "<DeviceInfo>" +
            "  <OutputFormat>Excel</OutputFormat>" +    //Word,Excel,Pdf 
            "  <PageWidth>8.27in</PageWidth>" +
            "  <PageHeight>11.69in</PageHeight>" +
            "  <MarginTop>0.0in</MarginTop>" +
            "  <MarginLeft>0.2in</MarginLeft>" +
            "  <MarginRight>0in</MarginRight>" +
            "  <MarginBottom>0.0in</MarginBottom>" +
            "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            renderedBytes = _view.LocalReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
            return File(renderedBytes, mimeType, Url.Encode("库存汇总记录.xls"));
        }
        //

            /// <summary>
            /// 配货组别对应维护
            /// </summary>
            /// <returns></returns>
        public ActionResult PhZbDy()
        {

            return View();

        }
        public ActionResult PhZbDy_Find(int limit, int offset)
        {
            //数据显示

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
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
            _p.page = offset / limit + 1;
            _p.rows = limit;
            _p.sidx = "dyzb";
            _p.sord = "asc";

            var _jx = new SD.Data.LamadaExtention<db_models.ckxxb>();
            List<db_models.phzbdy> tFindEntity = new List<db_models.phzbdy>();

            //查询按仓库名称
            if (Request["search"] != null && !string.IsNullOrEmpty(Request["search"].ToString()))
            {
                string _search = Request["search"].ToString();
                tFindEntity = _rs.FindList<db_models.phzbdy>(x => x.phzb.Contains(_search), _p);
            }
            else
            {
                tFindEntity = _rs.FindList<db_models.phzbdy>(_p);
            }
            string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<db_models.phzbdy>(tFindEntity);
            string _json = "{\"total\":" + _p.records.ToString() + ",\"rows\":" + _datajson + "}";
            return Content(_json);
        }

        public ActionResult PhZbDy_Input(int? id)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.phzbdy tFindEntity = new db_models.phzbdy();


            BK_MES_MVC.App_Code.ClassOne _class = new App_Code.ClassOne();

            if (id != null)
            {
                tFindEntity = _rs.FindEntity<db_models.phzbdy>(id);
            }
            else
            {
                tFindEntity.zdbh = null;
            }

            ViewBag.from_cklx = _class.abc<db_models.db_enum.enum_cklx, db_models.phzbdy>(tFindEntity);
            ViewBag.from_zt = _class.abc<db_models.db_enum.enum_zt, db_models.phzbdy>(tFindEntity);

            return View(tFindEntity);
        }

        public ActionResult PhZbDy_Exists()
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            db_models.phzbdy tFindEntity = new db_models.phzbdy();

            BK_MES_MVC.App_Code.ClassOne _class = new App_Code.ClassOne();

            string _cName = Request["name1"].ToString();
            string _cName2 = Request["name2"].ToString();
            string _cId = Request["id"].ToString();
            tFindEntity = _rs.FindEntity<db_models.phzbdy>(x => x.phgz == _cName && x.phzb == _cName2);
            if (tFindEntity != null)
            {
                if (_cId == "")
                {
                    //增加查询
                    return Content("{\"valid\":false}");
                }
                else
                {
                    //修改查询
                    int _iId = Int32.Parse(_cId);
                    if (tFindEntity.zdbh == _iId)
                    {
                        return Content("{\"valid\":true}");
                    }
                    else
                    {
                        return Content("{\"valid\":false}");
                    }
                }
            }
            return Content("{\"valid\":true}");
        }

        public ActionResult PhZbDy_Save()
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                db_models.phzbdy _data = new db_models.phzbdy();

                TableRowToModel<db_models.phzbdy>(_data, Request.Form);

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                try
                {
                    if (_data.zdbh == null)
                    {
                        _rs.Insert<db_models.phzbdy>(_data);
                        _jsons.info = "数据增加成功!";
                    }
                    else
                    {
                        _rs.Update<db_models.phzbdy>(_data);
                        _jsons.info = "数据修改成功!";
                    }
                    _jsons.info = "数据增加成功!";
                    _jsons.status = 1;
                }
                catch (Exception ex)
                {
                    _jsons.info = "数据处理失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();

        }

        public ActionResult PhZbDy_Delete(int Id)
        {
            if (Request.IsAjaxRequest())
            {
                BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();

                db_models.phzbdy _data = new db_models.phzbdy();

                _data.zdbh = Id;

                //数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                try
                {
                    _rs.Delete<db_models.phzbdy>(_data);
                    _jsons.info = "数据删除成功!";
                    _jsons.status = 1;
                }
                catch (Exception ex)
                {
                    _jsons.info = "数据删除失败!";
                    _jsons.status = 0;
                }
                return Json(_jsons, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        /// <summary>
        /// 拆分保存
        /// </summary>
        /// <returns></returns>
        public ActionResult ChaiFen_Save(db_models.dingdan_m[] mPh)
        {
            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

            BK_MES_MVC.Models.JsonSuccess _jsons = new BK_MES_MVC.Models.JsonSuccess();
            try
            {
                _rs.FindEntity<Models.One>(String.Format("Execute Pr_订单拆分 {0},{1}", "1", "2"));
                _jsons.info = "订单拆分成功!";
                _jsons.status = 1;
            }
            catch (Exception ex)
            {
                _jsons.info = "订单拆分失败!";
                _jsons.status = 0;
            }
            return Json(_jsons, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 订单汇总数据浏览
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DingDan_Hz(int id)
        {
            //按日,周,月,年,自定义
            //按钢号,规格,组别,客户代码统计
            if (Request.IsAjaxRequest())
            {
                // 数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                List<Models.RuKu_Mx> RKMx = new List<Models.RuKu_Mx>();
                try
                {
                    RKMx = _rs.IQueryable<Models.RuKu_Mx>(string.Format(@"select  B.钢号 as gh
	   ,B.规格 as gg
	   ,B.组别 as zb
	   ,B.客户代码 as khdm
	   ,Count(1) as ssl
	   ,Sum(净重) as szl
	 from 成品出库表 A inner join 成品信息表_4 B on A.成品信息编号=B.自动编号
		where A.销售订单编号 ={0}
 Group By A.销售订单编号,B.钢号,B.规格,B.组别,B.客户代码
 Order by A.销售订单编号,B.钢号,B.规格,B.组别,B.客户代码", id)
                                                              ).ToList();

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _rs.Dispose();
                }

                string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.RuKu_Mx>(RKMx);
                string _json = "{\"total\":" + RKMx.Count.ToString() + ",\"rows\":" + _datajson + "}";
                return Content(_json);
            }
            ViewBag.ddid = id;
            return View();
        }

        /// <summary>
        /// 锁定数据浏览
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SuoDing_View()
        { 
            if (Request.IsAjaxRequest())
            {
                string _sjbh = Request["sjbh"].ToString().Trim();
                string _ph = Request["ph"].ToString().Trim();

                string _where2 = "1=1 ";
                if (_sjbh != "")
                {
                    _where2 += " And 数据编号='" + _sjbh + "'";
                }
                if (_ph != "")
                {
                    _where2 += " And 批号 like '%" + _ph + "%'";
                }


                // 数据显示
                    SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                //加入分页
                SD.Data.Pagination _p = new SD.Data.Pagination();
                int offset = Int16.Parse(Request["offset"]);
                int limit = Int16.Parse(Request["limit"]);
                _p.page = offset / limit + 1;
                _p.rows = limit;
                _p.sidx = "锁定日期";
                _p.sord = "desc";


                List<Models.SuoDing> SuoDing_View = new List<Models.SuoDing>();
                try
                {
                    SuoDing_View = _rs.IQueryable<Models.SuoDing>(@"select B.数据编号 as sjbh
	   ,B.批号 as ph
	   ,B.钢丝名称 as cpmc
	   ,B.钢号 as gh
	   ,B.规格 as gg
	   ,B.组别 as zb
	   ,B.客户代码 as khdm
	   ,B.净重 as zl
	   ,B.库位 as kw
	   ,A.锁定日期 as sdrq
	   ,A.锁定人 as sdr
	   ,A.锁定原因 as sdyy
	   ,A.销售订单编号 as xsddbh
	 from 成品库存锁定表 A inner join 成品信息表_4 B on A.成品库存编号=B.自动编号
     Where "+ _where2
    , _p).ToList();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _rs.Dispose();
                }

                string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.SuoDing>(SuoDing_View);
                string _json = "{\"total\":" + _p.records + ",\"rows\":" + _datajson + "}";
                return Content(_json);
            }
            return View();
        }

        /// <summary>
        /// 呆库查看
        /// </summary>
        /// <returns></returns>
        public ActionResult DaiKu_View()
        {
            if (Request.IsAjaxRequest())
            {
                string _day = Request["day"].ToString().Trim();
                string _sjbh = Request["sjbh"].ToString().Trim();
                string _ph = Request["ph"].ToString().Trim();

                string _where2 = "";
                if (_sjbh != "")
                {
                    _where2 += " And 数据编号='" + _sjbh + "'";
                }
                if (_ph != "")
                {
                    _where2 += " And 批号 like '%" + _ph + "%'";
                }


                // 数据显示
                SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();

                //加入分页
                SD.Data.Pagination _p = new SD.Data.Pagination();
                int offset = Int16.Parse(Request["offset"]);
                int limit = Int16.Parse(Request["limit"]);
                _p.page = offset / limit + 1;
                _p.rows = limit;
                _p.sidx = "入库日期,钢号,规格,组别";
                _p.sord = "asc";

                List<Models.DaiKu> DaiKu_View = new List<Models.DaiKu>();
                try
                {
                    DaiKu_View = _rs.IQueryable<Models.DaiKu>(@"select B.数据编号 as sjbh
	   ,B.批号 as ph
	   ,B.钢丝名称 as cpmc
	   ,B.钢号 as gh
	   ,B.规格 as gg
	   ,B.组别 as zb
	   ,B.客户代码 as khdm
	   ,B.净重 as zl
	   ,D.库位 as kw
	   ,C.入库日期 as rkrq 
       ,DATEDIFF(day,C.入库日期,Getdate()) as dkday
	 from 成品库位表 A inner join 成品信息表_4 B on A.成品编号=B.自动编号
					   inner join 成品入库表 C on A.成品编号=C.成品信息编号
					   inner join 仓库库位视图 D on A.库位编号=D.库位编号
	Where DATEDIFF(day,C.入库日期,Getdate())>" + _day+_where2
    , _p).ToList();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _rs.Dispose();
                }

                string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.DaiKu>(DaiKu_View);
                string _json = "{\"total\":" + _p.records + ",\"rows\":" + _datajson + "}";
                return Content(_json);
            }
            return View();
        }


        public ActionResult Temp2()
        {



            return View();
        }

        public ActionResult Temp3()
        {

            //System.Data.DataTable _dt = new System.Data.DataTable();
            //_dt.Columns.Add("title", typeof(String));
            ////_dt.Columns.Add("vid", typeof(int));

            //_dt.Rows.Add("第一");
            //_dt.Rows.Add("第二");
            //_dt.Rows.Add("第三");
            //_dt.Rows.Add("第四");

            ////return Json(_dt, JsonRequestBehavior.AllowGet);
            //string _ss = JsonConvert.SerializeObject(_dt);
            ////return Json("{data:[{title:\"abcd'},{title:'abcd'},{title:'abcd'}]}", JsonRequestBehavior.AllowGet);
            //return Json("{title:\"abcd\"},{title:\"abcd\"},{title:\"abcd\"}");

            List<Models.tmpb> _tmpb = new List<Models.tmpb>();
            _tmpb.Add(new Models.tmpb { title = Request.QueryString["id"].ToString() + "abce" });
            _tmpb.Add(new Models.tmpb { title = Request.QueryString["id"].ToString() + "abce1" });
            _tmpb.Add(new Models.tmpb { title = Request.QueryString["id"].ToString() + "abce2" });
            Models.tmpc _tmpc = new Models.tmpc();
            _tmpc.data = _tmpb;
            return Json(_tmpc, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Temp4()
        {
            return View();
        }

        public ActionResult Temp5()
        {
            return View();
        }

        public ActionResult Temp6()
        {
            ////数据显示
            //SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            //db_models.dingdan_t_zt _data = new db_models.dingdan_t_zt();

            ////撤销
            ////事务
            //_rs.BeginTrans();

            ////_data = _rs.FindEntity<db_models.dingdan_t_zt>(x => x.ddtbm == id && x.ddzt == (db_models.db_enum.enum_ddzt)zt);
            //_rs.Delete(_data);

            //_data = new db_models.dingdan_t_zt();
            //_data = _rs.FindEntity<db_models.dingdan_t_zt>(x => x.ddtbm == id && x.ddzt == (db_models.db_enum.enum_ddzt)(zt - 1));
            //_data.xgrbm = Convert.ToInt16(App_Code.WebHelper.GetCookie("yhbm"));
            //_data.xgrq = DateTime.Now;
            //_rs.Update<db_models.dingdan_t_zt>(_data, new List<string> { "xgrbm", "xgrq" });

            //_rs.Commit();
            return View();

        }

        public ActionResult Temp7()
        {
            if (Request.IsAjaxRequest())
            {
                List<Models.tmpb> _tmpb = new List<Models.tmpb>();
                _tmpb.Add(new Models.tmpb { title = "abce" });
                _tmpb.Add(new Models.tmpb { title = "abce1" });
                _tmpb.Add(new Models.tmpb { title = "abce2" });
                Models.tmpc _tmpc = new Models.tmpc();
                _tmpc.data = _tmpb;
                //return Json(_tmpc, JsonRequestBehavior.AllowGet);

                string _datajson = BK_MES_MVC.App_Code.AutoGrid.CreateData<Models.tmpb>(_tmpb);
                string _json = "{\"total\":1,\"rows\":" + _datajson + "}";
                return Content(_json);

            }
            else
            {
                return View();
            }
        }


    }


}