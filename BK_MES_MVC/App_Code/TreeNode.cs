using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace BK_MES_MVC.App_Code
{
    /// <summary>
    /// Tree数据生成为Json列表，然后转换为JSon格式
    /// </summary>
    public class TreeNode
    {

        public static List<TreeJsonModels> initTree(List<TreeListModels> ListTree)
        {

            List<TreeJsonModels> rootNode = new List<TreeJsonModels>();

            foreach (TreeListModels _ltm in ListTree)
            {

                if (_ltm.parent != "0")
                    continue;

                TreeJsonModels _jt = new TreeJsonModels();
                //_jt.id = int.Parse(_ltm.id);
                _jt.id = _ltm.id;
                _jt.text = _ltm.text;
                _jt.state = "open";
                _jt.url = _ltm.url;
                _jt.attributes = CreateFlag(ListTree, _jt);
                _jt.children = CreateChildTree(ListTree, _jt);
                rootNode.Add(_jt);
            }

            return rootNode;
        }

        private static List<TreeJsonModels> CreateChildTree(List<TreeListModels> ListTree, TreeJsonModels jt)
        {
            List<TreeJsonModels> nodeList = new List<TreeJsonModels>();
            if (ListTree.Count > 0)
            {
                //int keyid = jt.id;                                        //根节点ID

                foreach (var _ltm in ListTree.FindAll(i => i.children == jt.id.ToString()))
                {
                    TreeJsonModels node = new TreeJsonModels();
                    //node.id = int.Parse(_ltm.id);
                    node.id = _ltm.id;
                    node.text = _ltm.text;
                    node.url = _ltm.url;
                    node.state = "";
                    node.attributes = CreateFlag(ListTree, node);
                    node.children = CreateChildTree(ListTree, node);
                    nodeList.Add(node);
                }
            }
            return nodeList;
        }

        private static Dictionary<string, string> CreateFlag(List<TreeListModels> ListTree, TreeJsonModels jt)    //把Flag属性添加到attribute中，如果需要别的属性，也可以在这里添加
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if(ListTree.Count>0)
            {
                dic.Add("flag", ListTree.Find(i => i.id == jt.id.ToString()).flag);
            }
            return dic;
        }


    }

    /// <summary>
    /// 生成Json格式的列表
    /// </summary>
    public class TreeJsonModels
    {
        private string _id;
        private string _text;
        private string _state = "open";
        private Dictionary<string, string> _attributes = new Dictionary<string, string>();
        private object _children;
        private string _url;

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string text
        {
            get { return _text; }
            set { _text = value; }
        }
        public string state
        {
            get { return _state; }
            set { _state = value; }
        }
        public Dictionary<string, string> attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }
        public object children
        {
            get { return _children; }
            set { _children = value; }
        }

        public string url
        {
            get
            {
                return _url;
            }

            set
            {
                _url = value;
            }
        }
    }
     
    /// <summary>
    /// 通过数据库转换出来的列表
    /// </summary>
    public class TreeListModels
    {
        /// <summary>
        /// 文本
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 属于父节点
        /// </summary>
        public string children { get; set; }//属于父节点
        /// <summary>
        /// 主节点
        /// </summary>
        public string parent { get; set; } 
        /// <summary>
        /// 链接
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 其他信息
        /// </summary>
        public string flag { get; set; }
     
    }


}
