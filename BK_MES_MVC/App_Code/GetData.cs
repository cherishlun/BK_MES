using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_MES_MVC.App_Code
{
    public class GetData
    {

        public List<TreeListModels> getgs()
        {

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            List<TreeListModels> _list = new List<App_Code.TreeListModels>();
            _list.Add(new App_Code.TreeListModels { text = "项目", id = "-1", children = "0", parent = "0", url = "", flag = "0" });

            var tMenuEntity = _rs.IQueryable<db_models.Menus>();
            foreach (var _entity in tMenuEntity)
            {
                _list.Add(new App_Code.TreeListModels { text = _entity.MenuName, id = _entity.ID.ToString(), children = "-1", parent = "1", url = "/" + _entity.MenuTag + "", flag = "" });
            }
            return _list;
        }

        public List<TreeJsonModels> getsgdw()
        {

            SD.Data.IRepositoryBase _rs = new SD.Data.RepositoryBase();
            List<TreeListModels> _list = new List<App_Code.TreeListModels>();
            //_list.Add(new App_Code.TreeListModels { text = "项目", id = "-1", children = "0", parent = "0", url = "", flag = "0" });

            var tMenuEntity = _rs.IQueryable<db_models.TeamABC>();
            foreach (var _entity in tMenuEntity)
            {
                _list.Add(new App_Code.TreeListModels { text = _entity.Bzmc, id = _entity.ID.ToString(), parent = _entity.Sy.ToString(), children = _entity.Sy.ToString(), flag = "" });
            }

            List<TreeJsonModels> _j = new List<App_Code.TreeJsonModels>();

            _j = TreeNode.initTree(_list);

            return _j;
        }
    }
}