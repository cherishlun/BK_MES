using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BK_MES_MVC.App_Code
{
    public class AutoGrid
    {
        public static List<string> CreateGrid(List<db_models.Propertys> tFindEntity,List<db_models.RowColor> tRowColor)
        {
            StringBuilder _sgrid = new StringBuilder();
            List<ModelsGridColumn> _listgridcolumn = new List<ModelsGridColumn>();  //表格列
            List<ModelsGridFilter> _listgridfilter = new List<ModelsGridFilter>();  //表格筛选

            //主键
            db_models.Propertys _p = tFindEntity.Find(i => i.ValidateType.ToLower() == "key");
            if (_p != null)
            {
                _listgridcolumn.Add(new ModelsGridColumn() { field = "ID", title = _p.ShowName , checkbox = true });  //这里固定了主键为ID
            }

            foreach (var _t in tFindEntity)
            {
                //长度等于0 跳过
                //if (_t.ShowLenght == 0)
                //    continue;

                if (_t.ValidateType.ToLower() == "nogrid" || _t.ValidateType.ToLower() == "key")
                    continue;

                //过滤添加
                switch(_t.ShowType)
                {
                    case "I":
                    case "N":
                        _listgridfilter.Add(new ModelsGridFilter() {field=_t.CorrVar, type  = GridFilterEnum.numberbox.ToString(), op = new List<string>() { "equal", "notequal", "less", "lessorequal", "greater", "greaterorequal" } });
                        break;
                    case "D":
                    case "T":
                        _listgridfilter.Add(new ModelsGridFilter() { field = _t.CorrVar, type = GridFilterEnum.datebox.ToString(), op = new List<string>() { "equal", "notequal", "less", "lessorequal", "greater", "greaterorequal" } });
                        break;
                    case "S":
                        //List<opp> _aaa = new List<opp>();
                        //_aaa.Add(new App_Code.opp() { id = "111", text = "男", children =new App_Code.opp() { id = "222", text = "nn" } });
                        //_aaa.Add(new App_Code.opp() { id = "女", text = "女" });

                        SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
                        List<BK_MES_MVC.App_Code.TreeListModels> _list = new List<App_Code.TreeListModels>();

                        var tMenuEntity = _rs.IQueryable<db_models.TeamABC>().OrderBy(i => i.Sx);
                        foreach (var _entity in tMenuEntity)
                        {
                            _list.Add(new App_Code.TreeListModels { text = _entity.Bzmc, id = _entity.ID.ToString(), parent = _entity.Sy.ToString(), children = _entity.Sy.ToString(), flag = "" });
                        }

                        List<App_Code.TreeJsonModels> _j = new List<App_Code.TreeJsonModels>();

                        _j = App_Code.TreeNode.initTree(_list);



                        _listgridfilter.Add(new ModelsGridFilter() { field = _t.CorrVar, type = GridFilterEnum.combotree.ToString(), op = new List<string>() { "equal", "notequal" }, options = new Dictionary<string, List<App_Code.TreeJsonModels>>() { { "data", _j } } });
                        break;
                    default:
                        _listgridfilter.Add(new ModelsGridFilter() { field = _t.CorrVar, type = GridFilterEnum.text.ToString(), op = new List<string>() { "equal", "notequal", "contains" } });
                        break;
                }

                //字段添加
                _listgridcolumn.Add(new ModelsGridColumn() { field = "" + _t.CorrVar, title = _t.ShowName, width = (_t.ShowName.Length * 20 < 100 ? 100 : _t.ShowName.Length * 20) });
            }

            //行变色条件
            StringBuilder _yssb = new StringBuilder();
            foreach (db_models.RowColor _list in tRowColor.OrderByDescending(i=>i.ColorOrder))
            {
                _yssb.AppendLine("if (" + _list.ColorWhere + ") {  return 'background-color:" + _list.ColorBack + ";color:" + _list.ColorText + ";' }");
            }



            List<string> _List_json = new List<string>();
            _List_json.Add(Newtonsoft.Json.JsonConvert.SerializeObject(_listgridcolumn));   //字段添加
            _List_json.Add(Newtonsoft.Json.JsonConvert.SerializeObject(_listgridfilter));   //过滤添加
            _List_json.Add(_yssb.ToString()); //条件行颜色添加

            return _List_json;
        }

        public static String CreateData<TEntity>(List<TEntity> tFindEntity)
        {
            //拼接字符串（已取消）
            //StringBuilder _data = new StringBuilder();
            //string _name = "";
            //foreach (TEntity _t in tFindEntity)
            //{
            //    _data.Append(",{");

            //    for (int i=0;i< _t.GetType().GetProperties().Count();i++)
            //    {
            //        _name = _t.GetType().GetProperties()[i].Name;
            //        _data.Append("\"A"+_name+"\":\""+_t.GetType().GetProperty(_name).GetValue(_t)+"\",");
            //    }
            //    //末列，等同于动态SQL中Where的1=1模式
            //    _data.Append("\"\":\"\"");

            //    _data.Append("}");
            //}
            //return _data.ToString().Substring(1);

            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return Newtonsoft.Json.JsonConvert.SerializeObject(tFindEntity, timeConverter);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ModelsGridColumn
    {
        public string field { get; set; }
        public string title { get; set; }
        public bool checkbox { get; set; }
        public int width { get; set; }
    }
    public class ModelsGridFilter
    {
        public string field { get; set; }
        public string type { get; set; }
        public List<string> op { get; set; }

        // public Dictionary<string, List<opp>> options {get;set;}
        public Dictionary<string, List<App_Code.TreeJsonModels>> options { get; set; }

       

    }
    public class opp
    {
        public string id { set; get; }
        public string text { set; get; }

        public opp children { set; get; }
    }


    public enum GridFilterEnum
    {
        numberbox,
        datebox,
        combotree,
        text,
    }
}