using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Routing;

namespace BK_MES_MVC.App_Code
{
    /// <summary>
    /// 动态菜单
    /// </summary>
    public static class DynamicMenu
    {
        /// <summary>
        /// 返回生成菜单的HTML和方法内容
        /// </summary>
        /// <param name="List_Dm"></param>
        /// <param name="Menu_Html">菜单的HTML</param>
        /// <param name="Menu_Function">方法内容</param>
        /// <returns></returns>
        public static void CreateMenuy(List<DynamicMenuStruct> List_Dm, out string Menu_Html, out string Menu_Function)
        {
            StringBuilder _mh = new StringBuilder();
            StringBuilder _mf = new StringBuilder();
            foreach (var _l in List_Dm)
            {
                switch (_l.Menu_Flag)
                {
                    case MenuFlag.Add:
                        _mh.AppendFormat("<a href = \"javascript:{0}();\" class=\"easyui-linkbutton\" iconCls=\"icon-add\" plain=\"true\" >{1}</a>", _l.Menu_FunName, _l.Menu_Name);
                        _mf.AppendLine(@" function " + _l.Menu_FunName + @"()
                                    {
                                        $.ajax({
                                            url:'/" + _l.Menu_Url + @"',
                                            dataType:'json',
                                            cache:false,
                                            success: function(data){
                                                $('#forminput').html('');
                                                if(data.isError){
                                                        $.messager.alert('提示',data.Message);
                                                        return;
                                                        }
                                            if ($('#forminput').html().trim().length == 0)
                                                {
                                                     //var targetObj = $(data.Result).appendTo('#forminput');
                                                     //$.parser.parse(targetObj);  //局部渲染
                                                    $(data.Result).appendTo('#forminput');
                                                    $.parser.parse($('#forminput').parent());
                                                }
                                                $('#form_update').form('clear');
                                                $('#AID').html('');
                                                $('#input').window('open');  // open a window
                                                    }
                                            });
                                  }");
                        break;
                    case MenuFlag.Edit:
                        _mh.AppendFormat("<a href = \"javascript:{0}();\" class=\"easyui-linkbutton\" iconCls=\"icon-edit\" plain=\"true\" >{1}</a>", _l.Menu_FunName, _l.Menu_Name);
                        _mf.AppendLine(@" function " + _l.Menu_FunName + @"()
                                    {
                                       var dbs=getck();
                                       if(dbs!=null)
                                        {
                                            $('#AID').html('');
                                            var d=dbs[0].zdbh;
                                            for(var i=1;i<dbs.length;i++)
                                            {
                                                 d+=','+dbs[i].zdbh;
                                            }

                                             $.ajax({
                                            url:'/"+ _l.Menu_Url.Substring(0,_l.Menu_Url.IndexOf("/")) + @"/doUpdate?id='+d,
                                            dataType:'json',
                                            cache:false,
                                            success: function(data){
                                                    if(data.isError){
                                                          $.messager.alert('提示',data.Message);
                                                          return;
                                                        }
                                                    else{"+
                                         (_l.IsMultipleRow?@"
                                                $('#AID').html(d);"
                                                :
                                                @" if(dbs.length>1){ $.messager.alert('提示','无法同时修改多条记录！');return;} else {$('#AID').html(dbs[0].zdbh);} ") +
                                                @"if ($('#forminput').html().trim().length == 0)
                                                {
                                                     $.ajax({
                                                url:'/" + _l.Menu_Url + @"',
                                                dataType:'json',
                                                cache:false,
                                                success: function(data){
                                                        $('#forminput').html('');
                                                        if(data.isError){
                                                              $.messager.alert('提示',data.Message);
                                                              return;
                                                          }
                                                        var targetObj = $(data.Result).appendTo('#forminput');
                                                        $.parser.parse(targetObj);  //局部渲染
                                                        $('#form_update').form('clear');
                                                        if(dbs.length==1)
                                                        {
                                                           $('#form_update').form('load', dbs[0]);
                                                         }
                                                        $('#input').window('open');  // open a window
                                                    }
                                                });
                                               }
                                              else
                                                 {
                                                      $('#form_update').form('clear');
                                                        if(dbs.length==1)
                                                        {
                                                           $('#form_update').form('load', dbs[0]);
                                                         }
                                                      $('#input').window('open');  // open a window
                                                }
                                             }
                                            }
                                           });
                                         }
                                      }");
                        break;
                    case MenuFlag.Delete:   //url 地址优化，包含？，后面参数使用& 
                        _mh.AppendFormat("<a href = \"javascript:{0}();\" class=\"easyui-linkbutton\" iconCls=\"icon-remove\" plain=\"true\" >{1}</a>", _l.Menu_FunName, _l.Menu_Name);
                        _mf.AppendLine(@" function " + _l.Menu_FunName + @"()
                                    {
                                        var dbs=getck();
                                        if(dbs!=null)
                                        {
                                            if(dbs.length>1)
                                            {
                                                $.messager.alert('错误','无法同时删除多条记录！');
                                                return;
                                             }   

                                            $.messager.confirm('确认','您确认想要删除记录吗？',function(r){
                                            if (r){
                                                $('#form_update').form('submit', {
                                                    url:'/" + _l.Menu_Url + @"&AID='+dbs[0].zdbh,
                                                    dataType: 'json',
                                                    onSubmit: function () {
                                                      },
                                                    success: function (data) {
                                                    var data = eval('(' + data + ')');  // change the JSON string to javascript object
                                                    if (data.isError) {
                                                        $.messager.alert('错误',data.Message);
                                                       }
                                                    else {
                                                        $.messager.alert('提示', '删除成功！');
                                                        $('#dg').datagrid('reload');    // 重新载入当前页面数据
                                                      }
                                                  }    //end success
                                                });    //end form
                                               }    //end if
                                     });  //end mess
                                    }//end if
                                   }");
                        break;
                    case MenuFlag.Save:
                        if (_l.Menu_Name != "")
                        {
                            _mh.AppendFormat("<a href = \"javascript:{0}();\" class=\"easyui-linkbutton\" iconCls=\"icon-save\" plain=\"true\" >{1}</a>", _l.Menu_FunName, _l.Menu_Name);
                        }
                        _mf.AppendLine(@" function " + _l.Menu_FunName + @"()
                                { 
                                    $.messager.confirm('确认', '是否保存记录？', function(r) {
                                    if (r)
                                       {
                                        $.messager.progress();	// 显示进度条
                                        $('#form_update').form('submit', {
                                              url: '/" + _l.Menu_Url + @",
                                              dataType: 'json',
                                              onSubmit: function() {
                                                var isValid = $(this).form('validate');//验证表单中的一些控件的值是否填写正确，比如某些文本框中的内容必须是数字
                                                if (!isValid) {
                                                    $.messager.progress('close');	// 如果表单是无效的则隐藏进度条
                                                    $.messager.alert('警告', '请把信息输入完整！')
                                                }
                                                else {
                                                }
                                                return isValid; // 如果验证不通过，返回false终止表单提交
                                           },
                                          success: function(data) {
                                              var _t = eval('(' + data + ')');
                                                if (_t.isError)  {
                                                    $.messager.alert('警告', _t.Message);
                                                }
                                            else  {
                                                $.messager.alert('提示', '数据保存成功！')
                                                $('#dg').datagrid('reload');    // 重新载入当前页面数据
                                                }
                                        $.messager.progress('close');   // 如果表单是无效的则隐藏进度条
                                        }
                                    });
                                }
                                else {
                                    return;
                                }
                            });
                        }");
                        break;
                    case MenuFlag.Print:
                        if (_l.Menu_Name != "")
                        {
                            _mh.AppendFormat("<a href = \"javascript:{0}();\" class=\"easyui-linkbutton\" iconCls=\"icon-save\" plain=\"true\" >{1}</a>", _l.Menu_FunName, _l.Menu_Name);
                        }
                        _mf.AppendLine(@" function " + _l.Menu_FunName + @"()
                                { 
                                    windows.href='doprint';
                               }");
                        break;
                    default:
                        _mh.AppendFormat(" < a href = \"javascript:{0}();\" class=\"easyui-linkbutton\" iconCls=\"{1}\" plain=\"true\" >{2}</a>", _l.Menu_FunName, _l.Menu_Ico, _l.Menu_Name);
                        _mf.AppendLine(_l.Menu_Function);
                        break;
                }
            }
            Menu_Html = _mh.ToString();
            Menu_Function = _mf.ToString();
        }
    }

    /// <summary>
    /// 动态菜单属性
    /// </summary>
    public class DynamicMenuStruct
{
    /// <summary>
    /// 菜单名称
    /// </summary>
    public string Menu_Name { set; get; }
    /// <summary>
    /// 菜单图标
    /// </summary>
    public string Menu_Ico { set; get; }
    /// <summary>
    /// 菜单调用的方法名称
    /// </summary>
    public string Menu_FunName { set; get; }
    /// <summary>
    /// 菜单类型
    /// </summary>
    public MenuFlag Menu_Flag { set; get; }
    /// <summary>
    /// 菜单中的url
    /// </summary>
    public string Menu_Url{set;get;}
        /// <summary>
        /// 菜单JS内容
        /// </summary>
        public string Menu_Function { set; get; }

        /// <summary>
        /// 是否多行操作
        /// </summary>
        public bool IsMultipleRow { set; get; }
    }

    public enum MenuFlag
    {
        Query=1,
        Add=2,
        Edit=3,
        Delete=4,
        Save=5,
        Print = 6,
        Other =7

    }
}