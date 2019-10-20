using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//严重性 代码  说明 项目  文件 行   禁止显示状态
//错误  CS0453 类型“db_enum”必须是不可以为 null 值的类型，才能用作泛型类型或方法“StructuralTypeConfiguration<ckxxb>.Property<T>(Expression<Func<ckxxb, T>>)”中的参数“T”	db_mapping D:\VsProject\BK_MES_MVC\db_mapping\db_mapping.cs	19	活动的


namespace db_mapping
{

    #region(技术质量)

    public class djdmbMapping : SD.Data.Mapping<db_models.djdmb> {

        public djdmbMapping() {
            this.ToTable("等级代码表");
            this.HasKey(l=>l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.update_people_bm).HasColumnName("修改人编码");
            this.Property(l => l.add_people_bm).HasColumnName("加入人编码");
            this.Property(l => l.add_time).HasColumnName("添加时间");
            this.Property(l => l.update_time).HasColumnName("修改时间");
            this.Property(l => l.djdm).HasColumnName("等级代码");
            this.Property(l => l.cpmcbh).HasColumnName("产品名称编号");
            this.Property(l => l.gh).HasColumnName("钢号");
            this.Property(l => l.zbbh).HasColumnName("组别编号");
        }
    }

    public class zbbMapping : SD.Data.Mapping<db_models.zbb>
    {
        public zbbMapping()
        {
            this.ToTable("组别表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.update_people_bm).HasColumnName("修改人编码");
            this.Property(l => l.add_people_bm).HasColumnName("加入人编码");
            this.Property(l => l.add_time).HasColumnName("添加时间");
            this.Property(l => l.update_time).HasColumnName("修改时间");
            this.Property(l => l.zb).HasColumnName("组别");
            this.Property(l => l.ckbzbh).HasColumnName("参考标准编号");
        }
    }

    public class cpmcbMapping : SD.Data.Mapping<db_models.cpmcb>
    {
        public cpmcbMapping()
        {
            this.ToTable("产品名称表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.update_people_bm).HasColumnName("修改人编码");
            this.Property(l => l.add_people_bm).HasColumnName("加入人编码");
            this.Property(l => l.add_time).HasColumnName("添加时间");
            this.Property(l => l.update_time).HasColumnName("修改时间");
            this.Property(l => l.cpmc).HasColumnName("产品名称");
            this.Property(l => l.cpmc_eng).HasColumnName("Product");
        }
    }

    public class cpzlbzbMapping : SD.Data.Mapping<db_models.cpzlbzb>
    {
        public cpzlbzbMapping()
        {
            this.ToTable("产品质量标准表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.update_people_bm).HasColumnName("修改人编码");
            this.Property(l => l.add_people_bm).HasColumnName("加入人编码");
            this.Property(l => l.add_time).HasColumnName("添加时间");
            this.Property(l => l.update_time).HasColumnName("修改时间");
            this.Property(l => l.ckbz).HasColumnName("参考标准");
            //this.Property(l => l.klqd).HasColumnName("抗拉强度");
            //this.Property(l => l.nz).HasColumnName("扭转");
            //this.Property(l => l.wq).HasColumnName("弯曲");
            this.Property(l => l.fileName).HasColumnName("文件名");
            this.Property(l => l.filePath).HasColumnName("文件路径");
        }
    }

    public class gykzbzMapping : SD.Data.Mapping<db_models.gykzbz>
    {
        public gykzbzMapping()
        {
            this.ToTable("工艺控制标准");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.gc).HasColumnName("公差");
            this.Property(l => l.tyd).HasColumnName("椭圆度");
            this.Property(l => l.ggsx).HasColumnName("规格上限");
            this.Property(l => l.ggxx).HasColumnName("规格下限");
            this.Property(l => l.ckbzbh).HasColumnName("参考标准编号");
        }
    }

    public class machine_TableMapping : SD.Data.Mapping<db_models.machine_Table>
    {
        public machine_TableMapping()
        {
            this.ToTable("机器设备表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.update_people_bm).HasColumnName("修改人编码");
            this.Property(l => l.add_people_bm).HasColumnName("加入人编码");
            this.Property(l => l.add_time).HasColumnName("添加时间");
            this.Property(l => l.update_time).HasColumnName("修改时间");
            this.Property(l => l.sbmc).HasColumnName("设备名称");
            this.Property(l => l.scsj).HasColumnName("生产时间");
            this.Property(l => l.jj_jt).HasColumnName("卷径_卷筒");
            this.Property(l => l.jj_dls).HasColumnName("卷径_倒立式");
            this.Property(l => l.sl_jt).HasColumnName("矢量_卷筒");
            this.Property(l => l.sl_dls).HasColumnName("矢量_倒立式");
            this.Property(l => l.sxsd_jj).HasColumnName("收线速度_卷径");
            this.Property(l => l.sxsd_dls).HasColumnName("收线速度_倒立式");
            this.Property(l => l.gyyxsj).HasColumnName("工艺运行时间");
            this.Property(l => l.cpgg).HasColumnName("产品规格");
            this.Property(l => l.jtlb).HasColumnName("机台类别");
            this.Property(l => l.bz).HasColumnName("备注");
            this.Property(l => l.scs).HasColumnName("生产商");
            this.Property(l => l.azwz).HasColumnName("安装位置");
            this.Property(l => l.gdzcbh).HasColumnName("固定资产编号");
            this.Property(l => l.sbbh).HasColumnName("设备编号");
        }
    }

    /// <summary>
    /// 酸洗程序表
    /// </summary>
    public class sxcxbMapping : SD.Data.Mapping<db_models.sxcxb>
    {
        public sxcxbMapping()
        {
            this.ToTable("酸洗程序表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.sxcxh).HasColumnName("酸洗程序号");
            this.Property(l => l.sxsj).HasColumnName("所需时间");
            this.Property(l => l.update_people_bm).HasColumnName("修改人编码");
            this.Property(l => l.add_people_bm).HasColumnName("加入人编码");
            this.Property(l => l.add_time).HasColumnName("添加时间");
            this.Property(l => l.update_time).HasColumnName("修改时间");
        }
    }

    /// <summary>
    /// 加热炉速度表
    /// </summary>
    public class jrlsdbMapping : SD.Data.Mapping<db_models.jrlsdb>
    {
        public jrlsdbMapping()
        {
            this.ToTable("加热炉速度表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.update_people_bm).HasColumnName("修改人编码");
            this.Property(l => l.add_people_bm).HasColumnName("加入人编码");
            this.Property(l => l.add_time).HasColumnName("添加时间");
            this.Property(l => l.update_time).HasColumnName("修改时间");
            this.Property(l => l.sd).HasColumnName("速度");
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.ylggsx).HasColumnName("原料规格上限");
            this.Property(l => l.ylggxx).HasColumnName("原料规格下限");
        }
    }

    //public class lbgxbMapping : SD.Data.Mapping<db_models.lbgxb>
    //{
    //    public lbgxbMapping()
    //    {
    //        this.ToTable("拉拔工序表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.update_people_bm).HasColumnName("修改人编码");
    //        this.Property(l => l.add_people_bm).HasColumnName("加入人编码");
    //        this.Property(l => l.add_time).HasColumnName("添加时间");
    //        this.Property(l => l.update_time).HasColumnName("修改时间");
    //        this.Property(l => l.jtbh).HasColumnName("机台编号");
    //        this.Property(l => l.gxh).HasColumnName("工序号");
    //        this.Property(l => l.gxgg).HasColumnName("工序规格");
    //    }
    //}

    public class rclbMapping : SD.Data.Mapping<db_models.rclb>
    {
        public rclbMapping()
        {
            this.ToTable("热处理表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.update_people_bm).HasColumnName("修改人编码");
            this.Property(l => l.add_people_bm).HasColumnName("加入人编码");
            this.Property(l => l.add_time).HasColumnName("添加时间");
            this.Property(l => l.update_time).HasColumnName("修改时间");
            this.Property(l => l.sbmc).HasColumnName("设备名称");
            this.Property(l => l.bz).HasColumnName("备注");
        }
    }

    public class mxbMapping : SD.Data.Mapping<db_models.mxb>
    {

        public mxbMapping()
        {
            this.ToTable("模序表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.sbbh).HasColumnName("设备编号");
            this.Property(l => l.mxcs).HasColumnName("模序参数");
            this.Property(l => l.mx).HasColumnName("模序");
            this.Property(l => l.ml).HasColumnName("模链");
            this.Property(l => l.jxzj).HasColumnName("进线直径");
            this.Property(l => l.cxzj).HasColumnName("出线直径");
        }
    }

    //拉拔工序表
    public class lbgxbMapping : SD.Data.Mapping<db_models.lbgxb>
    {

        public lbgxbMapping()
        {
            this.ToTable("拉拔工序表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.sbbh).HasColumnName("设备编号");
            this.Property(l => l.mlxh).HasColumnName("模链序号");
            this.Property(l => l.ml).HasColumnName("模链");
            this.Property(l => l.update_people_bm).HasColumnName("修改人编码");
            this.Property(l => l.add_people_bm).HasColumnName("加入人编码");
            this.Property(l => l.add_time).HasColumnName("添加时间");
            this.Property(l => l.update_time).HasColumnName("修改时间");
        }
    }

    /// <summary>
    /// 客户特殊要求表
    /// </summary>
    public class khtsyqbMapping : SD.Data.Mapping<db_models.khtsyqb>
    {
        public khtsyqbMapping()
        {
            this.ToTable("客户特殊要求表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.khbm).HasColumnName("客户编码");
            this.Property(l => l.ylgysm).HasColumnName("原料供应商码");
            this.Property(l => l.bz).HasColumnName("标准");
            this.Property(l => l.pz).HasColumnName("品种");
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.khbzh).HasColumnName("客户标准号");
            this.Property(l => l.gh).HasColumnName("钢号");
            this.Property(l => l.gg).HasColumnName("规格");
            this.Property(l => l.zb).HasColumnName("组别");
            this.Property(l => l.zhyq).HasColumnName("装货要求");
            this.Property(l => l.qdyq).HasColumnName("强度要求");
            this.Property(l => l.gcyq).HasColumnName("公差要求");
            this.Property(l => l.dzyq).HasColumnName("单重要求");
            this.Property(l => l.bzyq).HasColumnName("包装要求");
            this.Property(l => l.beizhu).HasColumnName("备注");
            this.Property(l => l.shbz).HasColumnName("审核标志");
            this.Property(l => l.update_people_bm).HasColumnName("修改人编码");
            this.Property(l => l.add_people_bm).HasColumnName("加入人编码");
            this.Property(l => l.add_time).HasColumnName("添加时间");
            this.Property(l => l.update_time).HasColumnName("修改时间");
        }
    }

    public class klqdMapping : SD.Data.Mapping<db_models.klqd>
    {

        public klqdMapping()
        {
            this.ToTable("抗拉强度");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.zbbh).HasColumnName("组别编号");
            this.Property(l => l.ggsx).HasColumnName("规格上限");
            this.Property(l => l.ggxx).HasColumnName("规格下限");
            this.Property(l => l.klqdsx).HasColumnName("抗拉强度上限");
            this.Property(l => l.klqdxx).HasColumnName("抗拉强度下限");
        }
    }

    public class nzMapping : SD.Data.Mapping<db_models.nz>
    {

        public nzMapping()
        {
            this.ToTable("扭转");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.zbbh).HasColumnName("组别编号");
            this.Property(l => l.ggsx).HasColumnName("规格上限");
            this.Property(l => l.ggxx).HasColumnName("规格下限");
            this.Property(l => l.nzcs).HasColumnName("扭转次数");
        }
    }

    public class _cpxxbMapping : SD.Data.Mapping<db_models._cpxxb>
    {

        public _cpxxbMapping()
        {
            this.ToTable("产品信息表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.cpdm).HasColumnName("产品编码");
            this.Property(l => l.ptgg).HasColumnName("盘条规格");
            this.Property(l => l.cpgg).HasColumnName("成品规格");
            this.Property(l => l.khtsyqbh).HasColumnName("客户特殊要求编码");
            this.Property(l => l.djdmbh).HasColumnName("等级代码");
            //this.Property(l => l.gylxbh).HasColumnName("工艺路线");
            this.Property(l => l.update_people_bm).HasColumnName("修改人编码");
            this.Property(l => l.add_people_bm).HasColumnName("加入人编码");
            this.Property(l => l.add_time).HasColumnName("添加时间");
            this.Property(l => l.update_time).HasColumnName("修改时间");
        }
    }

    public class ProcductMessage_ViewMapping : SD.Data.Mapping<db_models.ProductMessage_View>
    {

        public ProcductMessage_ViewMapping()
        {
            this.ToTable("ProductMessage");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.cpmc_eng).HasColumnName("Product");
            this.Property(l => l.cpmc).HasColumnName("产品名称");
            this.Property(l => l.djdm).HasColumnName("等级代码");
            this.Property(l => l.gh).HasColumnName("钢号");
            this.Property(l => l.cpgg).HasColumnName("成品规格");
            this.Property(l => l.cpbm).HasColumnName("产品编码");
            this.Property(l => l.ptgg).HasColumnName("盘条规格");
            this.Property(l => l.zb).HasColumnName("组别");
            this.Property(l => l.ckbz).HasColumnName("参考标准");
            this.Property(l => l.wjm).HasColumnName("文件名");
            this.Property(l => l.wjlj).HasColumnName("文件路径");
            this.Property(l => l.gc).HasColumnName("公差");
            this.Property(l => l.tyd).HasColumnName("椭圆度");
            this.Property(l => l.nzcs).HasColumnName("扭转次数");
            this.Property(l => l.tsbz).HasColumnName("特殊备注");
            this.Property(l => l.tszb).HasColumnName("特殊组别");
            this.Property(l => l.tspz).HasColumnName("特殊品种");
            this.Property(l => l.tszh).HasColumnName("特殊装货");
            this.Property(l => l.tsgh).HasColumnName("特殊钢号");
            this.Property(l => l.tsbzhuang).HasColumnName("特殊包装");
            this.Property(l => l.tsdz).HasColumnName("特殊单重");
            this.Property(l => l.tsgc).HasColumnName("特殊公差");
            this.Property(l => l.tsqd).HasColumnName("特殊强度");
            this.Property(l => l.tsgg).HasColumnName("特殊规格");
            this.Property(l => l.tsbzhun ).HasColumnName("特殊标准");
            this.Property(l => l.klqd).HasColumnName("抗拉强度");
        }
    }

    //产品包装
    public class cpbzbMapping : SD.Data.Mapping<db_models.cpbz>
    {
        public cpbzbMapping()
        {
            this.ToTable("产品包装表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.update_people_bm).HasColumnName("修改人编码");
            this.Property(l => l.add_people_bm).HasColumnName("加入人编码");
            this.Property(l => l.add_time).HasColumnName("添加时间");
            this.Property(l => l.update_time).HasColumnName("修改时间");
            this.Property(l => l.bzmc).HasColumnName("包装名称");
            this.Property(l => l.sbbm).HasColumnName("设备编码");
            this.Property(l => l.zjsx).HasColumnName("直径上限");
            this.Property(l => l.zjxx).HasColumnName("直径下限");
            this.Property(l => l.bzzl).HasColumnName("标准重量");
            this.Property(l => l.bz).HasColumnName("备注");
            this.Property(l => l.bzdm).HasColumnName("包装代码");
        }
    }

    //工艺路线表
    public class gylxbMapping : SD.Data.Mapping<db_models.gylxb>
    {
        public gylxbMapping()
        {
            this.ToTable("工艺路线表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.gymc).HasColumnName("工艺名称");
            this.Property(l => l.jgsj).HasColumnName("间隔时间");
            this.Property(l => l.sx).HasColumnName("顺序");
            this.Property(l => l.gydybh).HasColumnName("工艺对应编号");
            this.Property(l => l.cpzdbh).HasColumnName("产品自动编号");
        }
    }
    #endregion














































    /// <summary>
    /// 成品入库撤销表
    /// </summary>
    public class cprkcxbMapping : SD.Data.Mapping<db_models.cprkcxb>
    {
        public cprkcxbMapping()
        {
            this.ToTable("成品入库撤销表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.cpxxbh).HasColumnName("成品信息编号");
            this.Property(l => l.rksj).HasColumnName("入库时间");
            this.Property(l => l.kwh).HasColumnName("库位号");
            this.Property(l => l.rkfsm).HasColumnName("入库方式码");
            this.Property(l => l.rkr).HasColumnName("入库人");
            this.Property(l => l.rkbz).HasColumnName("入库备注");

            this.Property(l => l.cxsj).HasColumnName("撤销时间");
            this.Property(l => l.cxyy).HasColumnName("撤销原因");
            this.Property(l => l.cxr).HasColumnName("撤销人");
        }
    }

    public class phdyzbMapping:SD.Data.Mapping<db_models.phzbdy>
    {
        public phdyzbMapping()
        {
            this.ToTable("配货规则对应表");
            this.HasKey(l => l.zdbh);

            this.Property(l => l.zdbh).HasColumnName("自动编号");

            this.Property(l => l.phzb).HasColumnName("订单组别");
            this.Property(l => l.phgz).HasColumnName("订单钢种");
            this.Property(l => l.dyzb).HasColumnName("对应组别");
            this.Property(l => l.dyph).HasColumnName("对应批号");
        }
    }

    /// <summary>
    /// 成品入库表
    /// </summary>
    public class cprkbMapping : SD.Data.Mapping<db_models.cprkb>
    {
        public cprkbMapping()
        {
            this.ToTable("成品入库表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.cpxxbh).HasColumnName("成品信息编号");
            this.Property(l => l.rkrq).HasColumnName("入库日期");
            this.Property(l => l.kwh).HasColumnName("库位号");
            this.Property(l => l.bz).HasColumnName("备注");
            this.Property(l => l.czrbm).HasColumnName("操作人编码");
            this.Property(l => l.rkfsm).HasColumnName("入库方式码");
        }
    }

    /// <summary>
    /// 成品库位表
    /// </summary>
    public class cpkwbMapping : SD.Data.Mapping<db_models.cpkwb>
    {
        public cpkwbMapping()
        {
            this.ToTable("成品库位表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.cpbh).HasColumnName("成品编号");
            this.Property(l => l.kwbh).HasColumnName("库位编号");
        }
    }
    public class cpxxb_4_Mapping:SD.Data.Mapping<db_models.cpxxb_4>
    {
       public cpxxb_4_Mapping()
        {
            this.ToTable("成品信息表_4");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");

            this.Property(l => l.sjbh).HasColumnName("数据编号");
            this.Property(l => l.gsmc).HasColumnName("钢丝名称");
            this.Property(l => l.scrq).HasColumnName("生产日期");
            this.Property(l => l.bc).HasColumnName("班次");
            this.Property(l => l.scpc).HasColumnName("生产批次");
            this.Property(l => l.jt).HasColumnName("机台");
            this.Property(l => l.gg).HasColumnName("规格");
            this.Property(l => l.zb).HasColumnName("组别");
            this.Property(l => l.khdm).HasColumnName("客户代码");
            this.Property(l => l.gh).HasColumnName("钢号");
            this.Property(l => l.lh).HasColumnName("炉号");
            this.Property(l => l.jh).HasColumnName("卷号");
            this.Property(l => l.zl).HasColumnName("净重");
            this.Property(l => l.ylcd).HasColumnName("原料产地");
            this.Property(l => l.bzrq).HasColumnName("包装日期");
            this.Property(l => l.ckrq).HasColumnName("出库日期2");
            this.Property(l => l.bzlb).HasColumnName("包装类别");
            this.Property(l => l.bz).HasColumnName("备注");
            this.Property(l => l.cpbz).HasColumnName("标准");
            this.Property(l => l.jrrbm).HasColumnName("加入人编码");
            this.Property(l => l.xgrbm).HasColumnName("修改人编码");
            this.Property(l => l.xgsj).HasColumnName("修改时间");
            this.Property(l => l.kw).HasColumnName("库位");
            this.Property(l => l.ph).HasColumnName("批号");


        }
    }

    public class cpxxb_temp_Mapping : SD.Data.Mapping<db_models.cpxxb_temp>
    {
        public cpxxb_temp_Mapping()
        {
            this.ToTable("成品信息临时表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");

            this.Property(l => l.sjbh).HasColumnName("数据编号");
            this.Property(l => l.gsmc).HasColumnName("钢丝名称");
            this.Property(l => l.scrq).HasColumnName("生产日期");
            this.Property(l => l.bc).HasColumnName("班次");
            this.Property(l => l.scpc).HasColumnName("生产批次");
            this.Property(l => l.jt).HasColumnName("机台");
            this.Property(l => l.gg).HasColumnName("规格");
            this.Property(l => l.zb).HasColumnName("组别");
            this.Property(l => l.khdm).HasColumnName("客户代码");
            this.Property(l => l.gh).HasColumnName("钢号");
            this.Property(l => l.lh).HasColumnName("炉号");
            this.Property(l => l.jh).HasColumnName("卷号");
            this.Property(l => l.zl).HasColumnName("净重");
            this.Property(l => l.ylcd).HasColumnName("原料产地");
            this.Property(l => l.bzrq).HasColumnName("包装日期");
            this.Property(l => l.ckrq).HasColumnName("出库日期2");
            this.Property(l => l.bzlb).HasColumnName("包装类别");
            this.Property(l => l.bz).HasColumnName("备注");
            this.Property(l => l.cpbz).HasColumnName("标准");
            this.Property(l => l.jrrbm).HasColumnName("加入人编码");
            this.Property(l => l.xgrbm).HasColumnName("修改人编码");
            this.Property(l => l.xgsj).HasColumnName("修改时间");
            this.Property(l => l.kw).HasColumnName("库位");
            this.Property(l => l.ph).HasColumnName("批号");


        }
    }

    public class t1_mapping:SD.Data.Mapping<db_models.t1>
    {
        public t1_mapping()
        {
            this.ToTable("T1");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("zdbh");
            this.Property(l => l.cname).HasColumnName("name");
        }
    }

    public class t2_mapping : SD.Data.Mapping<db_models.t2>
    {
        public t2_mapping()
        {
            this.ToTable("T2");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("zdbh");
            this.Property(l => l.cname).HasColumnName("name");
            this.Property(l => l.t1bh).HasColumnName("t1bh");

        }
    }


    public class fhxxb_Mapping:SD.Data.Mapping<db_models.fhxxb>
    {
        public fhxxb_Mapping()
        {
            this.ToTable("成品发货信息表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.ddtbh).HasColumnName("订单头编号");
            this.Property(l => l.zclxbm).HasColumnName("装车类型编码");
            this.Property(l => l.zch).HasColumnName("装车号");
            this.Property(l => l.bz).HasColumnName("备注");
            this.Property(l => l.jrrbm).HasColumnName("加入人编码");
            this.Property(l => l.jlsj).HasColumnName("加入时间");
            this.Property(l => l.xgrbm).HasColumnName("修改人编码");
            this.Property(l => l.xgsj).HasColumnName("修改时间");
            this.Property(l => l.qrrbm).HasColumnName("确认人编码");
            this.Property(l => l.qrsj).HasColumnName("确认时间");
            this.Property(l => l.jsrbm).HasColumnName("接收人编码");
            this.Property(l => l.jssj).HasColumnName("接收时间");
        }
    }

    public class fhxxpjb_Mapping : SD.Data.Mapping<db_models.fhxxpjb>
    {
        public fhxxpjb_Mapping()
        {
            this.ToTable("成品发货信息配件表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.ddtbh).HasColumnName("订单头编号");
            this.Property(l => l.pjmc).HasColumnName("配件名称");
            this.Property(l => l.pjsl).HasColumnName("配件数量");
            this.Property(l => l.pjjldw).HasColumnName("配件计量单位");
            this.Property(l => l.sfhs).HasColumnName("是否回收");
            this.Property(l => l.hssj).HasColumnName("回收时间");
            this.Property(l => l.hsrbm).HasColumnName("回收人编码");
        }
    }



    public class YongHu_Mapping:SD.Data.Mapping<db_models.YongHu>
    {
        public YongHu_Mapping()
        {
            this.ToTable("v_user");
            this.HasKey(l => l.yhbm);
            this.Property(l => l.yhbm).HasColumnName("用户编码");
            this.Property(l => l.yhdlm).HasColumnName("用户登录名");
            this.Property(l => l.yhxm).HasColumnName("用户姓名");
            this.Property(l => l.yhms).HasColumnName("用户描述");
            this.Property(l => l.yhmm).HasColumnName("密码");
            this.Property(l => l.yhqxm).HasColumnName("权限编码");

        }
    }

    public class ChanPinMingCheng_Mapping: SD.Data.Mapping<db_models.ChanPinMingCheng>
    {
        public ChanPinMingCheng_Mapping()
        {
            this.ToTable("产品表_2");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.cpmc).HasColumnName("产品名称");
            this.Property(l => l.ywmc).HasColumnName("英文名称");
        }
    }

    public class dingdan_t_zt_Mapping : SD.Data.Mapping<db_models.dingdan_t_zt>
    {
        public dingdan_t_zt_Mapping()
        {
            this.ToTable("订单状态表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.ddtbm).HasColumnName("订单头编码");
            this.Property(l => l.ddzt).HasColumnName("订单状态");
            this.Property(l => l.jlrbm).HasColumnName("加入人编码");
            this.Property(l => l.xgrbm).HasColumnName("修改人编码");
            this.Property(l => l.xgrq).HasColumnName("修改时间");


        }
    }

    public class dingdan_t_Mapping : SD.Data.Mapping<db_models.dingdan_t>
    {
        public dingdan_t_Mapping()
        {
            this.ToTable("订货头表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.dhrq).HasColumnName("订货日期");
            this.Property(l => l.khbm).HasColumnName("客户码");
            this.Property(l => l.bz).HasColumnName("备注");
            this.Property(l => l.khmc).HasColumnName("客户名称");
            this.Property(l => l.ch).HasColumnName("车号");
            this.Property(l => l.zdr).HasColumnName("制单人");
            this.Property(l => l.thr).HasColumnName("提货人");

        }
    }

    public class dingdan_m_Mapping : SD.Data.Mapping<db_models.dingdan_m>
    {
        public dingdan_m_Mapping()
        {
            this.ToTable("订货明细表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.dhtbh).HasColumnName("订货头编号");
            this.Property(l => l.cpbm).HasColumnName("成品编码");
            this.Property(l => l.gh).HasColumnName("钢号");
            this.Property(l => l.gg).HasColumnName("规格");
            this.Property(l => l.zb).HasColumnName("组别");
            this.Property(l => l.bzbm).HasColumnName("包装编码");
            this.Property(l => l.yjl).HasColumnName("应交量");

            this.Property(l => l.jrrbm).HasColumnName("加入人编码");
            //this.Property(l => l.jrrq).HasColumnName("加入日期");
            this.Property(l => l.kh_bm).HasColumnName("客户_编码");
            this.Property(l => l.kh_ddh).HasColumnName("客户_订单号");
            this.Property(l => l.kh_wlbm).HasColumnName("客户_物料编码");
            this.Property(l => l.xgrbm).HasColumnName("修改人编码");
            this.Property(l => l.xgrq).HasColumnName("修改日期");
            this.Property(l => l.bz1).HasColumnName("备注1");
            this.Property(l => l.bz2).HasColumnName("备注2");
            this.Property(l => l.bz3).HasColumnName("备注3");

            this.Property(l => l.cpmc).HasColumnName("产品名称");
            this.Property(l => l.khdm).HasColumnName("客户代码");
            this.Property(l => l.khmc2).HasColumnName("客户名称2");
            


        }
    }



    public class ckxxMapping:SD.Data.Mapping<db_models.ckxxb>
    {
        public ckxxMapping()
        {
            this.ToTable("仓库信息表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.ckmc).HasColumnName("仓库名称");
            this.Property(l => l.cklx).HasColumnName("仓库类型");
            this.Property(l => l.ckwz).HasColumnName("仓库位置");
            this.Property(l => l.ckzt).HasColumnName("仓库状态");
            this.Property(l => l.ckbz).HasColumnName("备注");
            this.Property(l => l.jrrbm).HasColumnName("加入人编码");
            this.Property(l => l.xgrbm).HasColumnName("修改人编码");
            this.Property(l => l.xgsj).HasColumnName("修改时间");
        }
    }

    /// <summary>
    /// 仓库库位排号表
    /// </summary>
    public class cpxx_kwphMapping : SD.Data.Mapping<db_models.ckxx_kwph>
    {
        public cpxx_kwphMapping()
        {
            this.ToTable("仓库库位排号表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");

            this.Property(l => l.ckbh).HasColumnName("仓库编号");

            this.Property(l => l.pmc).HasColumnName("排名称");
            this.Property(l => l.gxr).HasColumnName("更新人");
         


        }
    }

    /// <summary>
    /// 成品库位配置表
    /// </summary>
    public class cpkwpzbMapping : SD.Data.Mapping<db_models.cpkwpzb>
    {
        public cpkwpzbMapping()
        {
            this.ToTable("仓库库位配置表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");

            this.Property(l => l.kwzt).HasColumnName("状态");

            this.Property(l => l.ph).HasColumnName("排编号");
            this.Property(l => l.ch).HasColumnName("层号");
            this.Property(l => l.wh).HasColumnName("位号");
            this.Property(l => l.qt).HasColumnName("其他");
            this.Property(l => l.jj).HasColumnName("间距");


        }
    }


    //    /// <summary>
    //    /// 工艺流程对照表
    //    /// </summary>
    //    public class gylcdzbMapping : SD.Data.Mapping<gylcdzb>
    //{
    //    public gylcdzbMapping()
    //    {
    //        this.ToTable("工艺流程对照表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.gylcbh).HasColumnName("工艺流程编号");

    //        this.Property(l => l.cpdm).HasColumnName("成品代码");

    //        this.Property(l => l.sxcxh).HasColumnName("酸洗程序号");

    //        this.Property(l => l.zdbh).HasColumnName("自动编号");


    //    }
    //}



    ///// <summary>
    ///// 质检名称表
    ///// </summary>
    //public class zjmcbMapping : SD.Data.Mapping<zjmcb>
    //{
    //    public zjmcbMapping()
    //    {
    //        this.ToTable("质检名称表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.dybzwjm).HasColumnName("对应标准文件码");

    //        this.Property(l => l.dyzbswjm).HasColumnName("对应质保书文件码");

    //        this.Property(l => l.jylx).HasColumnName("检验类型");

    //        this.Property(l => l.jymc).HasColumnName("检验名称");


    //    }
    //}



    ///// <summary>
    ///// 质检项目表
    ///// </summary>
    //public class zjxmbMapping : SD.Data.Mapping<zjxmb>
    //{
    //    public zjxmbMapping()
    //    {
    //        this.ToTable("质检项目表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.jymcbh).HasColumnName("检验名称编号");

    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.jyxm).HasColumnName("检验项目");

    //        this.Property(l => l.pdbz).HasColumnName("判定标准");

    //        this.Property(l => l.pdjb).HasColumnName("判定级别");


    //    }
    //}



    ///// <summary>
    ///// sysdiagrams
    ///// </summary>




    ///// <summary>
    ///// 检定数值表
    ///// </summary>
    //public class jdszbMapping : SD.Data.Mapping<jdszb>
    //{
    //    public jdszbMapping()
    //    {
    //        this.ToTable("检定数值表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.jdxmbh).HasColumnName("检定项目编号");

    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.jdsz).HasColumnName("检定数值");


    //    }
    //}



    ///// <summary>
    ///// 成品_半成品质检对应表
    ///// </summary>
    //public class cpbcpzjdybMapping : SD.Data.Mapping<cpbcpzjdyb>
    //{
    //    public cpbcpzjdybMapping()
    //    {
    //        this.ToTable("成品_半成品质检对应表");
    //        this.HasKey(l => l.cpbm);
    //        this.Property(l => l.jymcbh).HasColumnName("检验名称编号");

    //        this.Property(l => l.cpbm).HasColumnName("产品编码");


    //    }
    //}



    ///// <summary>
    ///// 成品_半成品条码对应表
    ///// </summary>
    //public class cpbcptmdybMapping : SD.Data.Mapping<cpbcptmdyb>
    //{
    //    public cpbcptmdybMapping()
    //    {
    //        this.ToTable("成品_半成品条码对应表");
    //        this.HasKey(l => l.scjhh);
    //        this.Property(l => l.scjhh).HasColumnName("生产计划号");

    //        this.Property(l => l.dycs).HasColumnName("打印次数");

    //        this.Property(l => l.dysj).HasColumnName("打印时间");

    //        this.Property(l => l.txm).HasColumnName("条形码");


    //    }
    //}




    /// <summary>
    /// 客户信息表
    /// </summary>
    public class khxxbMapping : SD.Data.Mapping<db_models.khxxb>
    {
        public khxxbMapping()
        {
            this.ToTable("客户信息表");
            this.HasKey(l => l.khbm);

            this.Property(l => l.fzrq).HasColumnName("发展日期");

            this.Property(l => l.tyrq).HasColumnName("停用日期");

            this.Property(l => l.jdrq).HasColumnName("建档日期");

            this.Property(l => l.bgrq).HasColumnName("变更日期");

            this.Property(l => l.khbm).HasColumnName("客户编码");

            this.Property(l => l.ssdqm).HasColumnName("所属地区码");

            this.Property(l => l.ssflm).HasColumnName("所属分类码");

            this.Property(l => l.ssxym).HasColumnName("所属行业码");

            this.Property(l => l.jdrm).HasColumnName("建档人码");

            this.Property(l => l.bgrm).HasColumnName("变更人码");

            this.Property(l => l.jsfsm).HasColumnName("结算方式码");

            this.Property(l => l.khmc).HasColumnName("客户名称");

            this.Property(l => l.khdmu8).HasColumnName("客户代码_U8");

            this.Property(l => l.khhz).HasColumnName("客户后缀");

            this.Property(l => l.khzgs).HasColumnName("客户总公司");

            this.Property(l => l.dygys).HasColumnName("对应供应商");

            this.Property(l => l.khzl).HasColumnName("客户种类");

            this.Property(l => l.bizhong).HasColumnName("币种");

            this.Property(l => l.fr).HasColumnName("法人");

            this.Property(l => l.khgllx).HasColumnName("客户管理类型");

            this.Property(l => l.sh).HasColumnName("税号");

            this.Property(l => l.zyywy).HasColumnName("专营业务员");

            this.Property(l => l.bz).HasColumnName("备注");

            this.Property(l => l.ls).HasColumnName("零售");


        }
    }



    ///// <summary>
    ///// 客户其他信息表
    ///// </summary>
    //public class khqtxxbMapping : SD.Data.Mapping<khqtxxb>
    //{
    //    public khqtxxbMapping()
    //    {
    //        this.ToTable("客户其他信息表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.khbm).HasColumnName("客户编码");

    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.sx).HasColumnName("属性");

    //        this.Property(l => l.sz).HasColumnName("数值");


    //    }
    //}



    ///// <summary>
    ///// 标准文件表
    ///// </summary>
    //public class bzwjbMapping : SD.Data.Mapping<bzwjb>
    //{
    //    public bzwjbMapping()
    //    {
    //        this.ToTable("标准文件表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.bzwjmc).HasColumnName("标准文件名称");

    //        this.Property(l => l.bzwjlj).HasColumnName("标准文件链接");


    //    }
    //}






    /// <summary>
    /// 成品出库表
    /// </summary>
    public class cpckbMapping : SD.Data.Mapping<db_models.cpckb>
    {
        public cpckbMapping()
        {
            this.ToTable("成品出库表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.cpxxbh).HasColumnName("成品信息编号");

            this.Property(l => l.czrbm).HasColumnName("操作人编码");

            this.Property(l => l.zdbh).HasColumnName("自动编号");

            this.Property(l => l.ckfsm).HasColumnName("出库方式码");

            this.Property(l => l.ckrq).HasColumnName("出库日期");

            this.Property(l => l.bz).HasColumnName("备注");

            this.Property(l => l.xsddbh).HasColumnName("销售订单编号");


        }
    }



    ///// <summary>
    ///// 客户信用等级表
    ///// </summary>
    //public class khxydjbMapping : SD.Data.Mapping<khxydjb>
    //{
    //    public khxydjbMapping()
    //    {
    //        this.ToTable("客户信用等级表");
    //        this.HasKey(l => l.khbh);
    //        this.Property(l => l.khbh).HasColumnName("客户编号");

    //        this.Property(l => l.xyedje).HasColumnName("信用额度金额");

    //        this.Property(l => l.xyedhwl).HasColumnName("信用额度货物量");

    //        this.Property(l => l.xydj).HasColumnName("信用等级");


    //    }
    //}



    ///// <summary>
    ///// 成品库存表
    ///// </summary>
    //public class cpkcbMapping : SD.Data.Mapping<cpkcb>
    //{
    //    public cpkcbMapping()
    //    {
    //        this.ToTable("成品库存表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.cpxxbh).HasColumnName("成品信息编号");

    //        this.Property(l => l.kwh).HasColumnName("库位号");

    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.czrbm).HasColumnName("操作人编码");

    //        this.Property(l => l.rkrq).HasColumnName("入库日期");

    //        this.Property(l => l.bz).HasColumnName("备注");


    //    }
    //}



    ///// <summary>
    ///// 原料供应商表
    ///// </summary>
    //public class ylgysbMapping : SD.Data.Mapping<ylgysb>
    //{
    //    public ylgysbMapping()
    //    {
    //        this.ToTable("原料供应商表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.mc).HasColumnName("名称");

    //        this.Property(l => l.dz).HasColumnName("地址");

    //        this.Property(l => l.dh).HasColumnName("电话");

    //        this.Property(l => l.bz).HasColumnName("备注");


    //    }
    //}



    ///// <summary>
    ///// 地区编码表
    ///// </summary>
    //public class dqbmbMapping : SD.Data.Mapping<dqbmb>
    //{
    //    public dqbmbMapping()
    //    {
    //        this.ToTable("地区编码表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.mc).HasColumnName("名称");


    //    }
    //}



    ///// <summary>
    ///// 行业编码表
    ///// </summary>
    //public class xybmbMapping : SD.Data.Mapping<xybmb>
    //{
    //    public xybmbMapping()
    //    {
    //        this.ToTable("行业编码表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.mc).HasColumnName("名称");


    //    }
    //}



    ///// <summary>
    ///// 客户分类表
    ///// </summary>
    //public class khflbMapping : SD.Data.Mapping<khflb>
    //{
    //    public khflbMapping()
    //    {
    //        this.ToTable("客户分类表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.mc).HasColumnName("名称");


    //    }
    //}



    ///// <summary>
    ///// 成品质检结果
    ///// </summary>
    //public class cpzjjgMapping : SD.Data.Mapping<cpzjjg>
    //{
    //    public cpzjjgMapping()
    //    {
    //        this.ToTable("成品质检结果");
    //        this.HasKey(l => l.scjhh);
    //        this.Property(l => l.scjhh).HasColumnName("生产计划号");

    //        this.Property(l => l.qrrbm).HasColumnName("确认人编码");

    //        this.Property(l => l.jdjg).HasColumnName("检定结果");


    //    }
    //}



    ///// <summary>
    ///// 成品质检调整表
    ///// </summary>
    //public class cpzjdzbMapping : SD.Data.Mapping<cpzjdzb>
    //{
    //    public cpzjdzbMapping()
    //    {
    //        this.ToTable("成品质检调整表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.ysrq).HasColumnName("原始日期");

    //        this.Property(l => l.ggrq).HasColumnName("更改日期");

    //        this.Property(l => l.scjhh).HasColumnName("生产计划号");

    //        this.Property(l => l.qrrbm).HasColumnName("确认人编码");

    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.ysjg).HasColumnName("原始结果");

    //        this.Property(l => l.ggjg).HasColumnName("更改结果");


    //    }
    //}



    ///// <summary>
    ///// 原料库位配置表
    ///// </summary>
    //public class ylkwpzbMapping : SD.Data.Mapping<ylkwpzb>
    //{
    //    public ylkwpzbMapping()
    //    {
    //        this.ToTable("原料库位配置表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.zt).HasColumnName("状态");

    //        this.Property(l => l.ph).HasColumnName("排号");

    //        this.Property(l => l.ch).HasColumnName("层号");

    //        this.Property(l => l.wh).HasColumnName("位号");

    //        this.Property(l => l.ckmc).HasColumnName("仓库名称");

    //        this.Property(l => l.zdbh).HasColumnName("自动编号");


    //    }
    //}



    ///// <summary>
    ///// 企业基础信息表
    ///// </summary>
    //public class qyjcxxbMapping : SD.Data.Mapping<qyjcxxb>
    //{
    //    public qyjcxxbMapping()
    //    {
    //        this.ToTable("企业基础信息表");
    //        this.HasKey(l => l.mc);
    //        this.Property(l => l.mc).HasColumnName("名称");

    //        this.Property(l => l.dz).HasColumnName("地址");

    //        this.Property(l => l.dh).HasColumnName("电话");

    //        this.Property(l => l.cz).HasColumnName("传真");

    //        this.Property(l => l.swdjh).HasColumnName("税务登记号");

    //        this.Property(l => l.khyx).HasColumnName("开户银行");

    //        this.Property(l => l.zh).HasColumnName("账号");


    //    }
    //}



    ///// <summary>
    ///// 原料表
    ///// </summary>
    //public class ylbMapping : SD.Data.Mapping<ylb>
    //{
    //    public ylbMapping()
    //    {
    //        this.ToTable("原料表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.rksj).HasColumnName("入库时间");

    //        this.Property(l => l.gysbm).HasColumnName("供应商编码");

    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.rkrbm).HasColumnName("入库人编码");

    //        this.Property(l => l.ckrbm).HasColumnName("出库人编码");

    //        this.Property(l => l.cksj).HasColumnName("出库时间");

    //        this.Property(l => l.gz).HasColumnName("钢种");

    //        this.Property(l => l.gg).HasColumnName("规格");

    //        this.Property(l => l.lh).HasColumnName("炉号");

    //        this.Property(l => l.kwh).HasColumnName("库位号");

    //        this.Property(l => l.zt).HasColumnName("状态");

    //        this.Property(l => l.bz).HasColumnName("备注");


    //    }
    //}



    ///// <summary>
    ///// 合同头表
    ///// </summary>
    //public class httbMapping : SD.Data.Mapping<httb>
    //{
    //    public httbMapping()
    //    {
    //        this.ToTable("合同头表");
    //        this.HasKey(l => l.htbh);
    //        this.Property(l => l.khbm).HasColumnName("客户编码");

    //        this.Property(l => l.qdsj).HasColumnName("签订时间");

    //        this.Property(l => l.htbh).HasColumnName("合同编号");


    //    }
    //}



    ///// <summary>
    ///// 质保书文件表
    ///// </summary>
    //public class zbswjbMapping : SD.Data.Mapping<zbswjb>
    //{
    //    public zbswjbMapping()
    //    {
    //        this.ToTable("质保书文件表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.jrr).HasColumnName("加入人");

    //        this.Property(l => l.ggr).HasColumnName("更改人");

    //        this.Property(l => l.jrsj).HasColumnName("加入时间");

    //        this.Property(l => l.ggsj).HasColumnName("更改时间");

    //        this.Property(l => l.zbswjlj).HasColumnName("质保书文件路径");


    //    }
    //}



    ///// <summary>
    ///// 合同尾表
    ///// </summary>
    //public class htwbMapping : SD.Data.Mapping<htwb>
    //{
    //    public htwbMapping()
    //    {
    //        this.ToTable("合同尾表");
    //        this.HasKey(l => l.htbh);
    //        this.Property(l => l.htzz).HasColumnName("合同总值");

    //        this.Property(l => l.htbh).HasColumnName("合同编号");

    //        this.Property(l => l.htlxd).HasColumnName("合同履行地");

    //        this.Property(l => l.jhzyqx).HasColumnName("交货装运期限");

    //        this.Property(l => l.zyfs).HasColumnName("装运方式");

    //        this.Property(l => l.shdw).HasColumnName("收货单位");

    //        this.Property(l => l.shdz).HasColumnName("收货地址");

    //        this.Property(l => l.fktj).HasColumnName("付款条件");

    //        this.Property(l => l.qt).HasColumnName("其他");


    //    }
    //}



    ///// <summary>
    ///// 生产数据表
    ///// </summary>
    //public class scsjbMapping : SD.Data.Mapping<scsjb>
    //{
    //    public scsjbMapping()
    //    {
    //        this.ToTable("生产数据表");
    //        this.HasKey(l => l.scjhh);
    //        this.Property(l => l.scrq).HasColumnName("生产日期");

    //        this.Property(l => l.scjhh).HasColumnName("生产计划号");

    //        this.Property(l => l.czgbm).HasColumnName("操作工编码");

    //        this.Property(l => l.zl).HasColumnName("重量");

    //        this.Property(l => l.jh).HasColumnName("卷号");

    //        this.Property(l => l.scbc).HasColumnName("生产班次");

    //        this.Property(l => l.scbz).HasColumnName("生产班组");

    //        this.Property(l => l.bz).HasColumnName("备注");


    //    }
    //}

    /// <summary>
    /// 成品盘库临时表
    /// </summary>
    public class cppklsbMapping : SD.Data.Mapping<db_models.cppklsb>
    {
        public cppklsbMapping()
        {
            this.ToTable("成品盘库临时表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.pkbh).HasColumnName("盘库编号");
            this.Property(l => l.cpbh).HasColumnName("成品编号");
            this.Property(l => l.kwbm).HasColumnName("库位编码");
            this.Property(l => l.czrbm).HasColumnName("操作人编码");
            this.Property(l => l.czrq).HasColumnName("操作日期");

            this.Property(l => l.pkzt).HasColumnName("状态");
            this.Property(l => l.pkbz).HasColumnName("备注");
        }
    }

    /// <summary>
    /// 成品盘库日志表
    /// </summary>
    public class cppkrzbMapping : SD.Data.Mapping<db_models.cppkrzb>
    {
        public cppkrzbMapping()
        {
            this.ToTable("成品盘库日志表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.pkbh).HasColumnName("盘库编号");
            this.Property(l => l.cpbh).HasColumnName("成品编号");
            this.Property(l => l.kwbm).HasColumnName("库位编码");
            this.Property(l => l.czrbm).HasColumnName("操作人编码");
            this.Property(l => l.czrq).HasColumnName("操作日期");
        }
    }

    public class cppkxxbMapping : SD.Data.Mapping<db_models.cppkxxb>
    {
        public cppkxxbMapping()
        {
            this.ToTable("成品盘库信息表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.pkrq).HasColumnName("盘库日期");
            this.Property(l => l.pksl).HasColumnName("盘库数量");
            this.Property(l => l.pkzl).HasColumnName("盘库重量");
            this.Property(l => l.pkxx).HasColumnName("信息");
            this.Property(l => l.pkzt).HasColumnName("状态");
            this.Property(l => l.pkbz).HasColumnName("备注");
            this.Property(l => l.pkjsrq).HasColumnName("结束日期");
        }
    }



    /// <summary>
    /// 成品安全库存表
    /// </summary>
    public class cpaqkcbMapping : SD.Data.Mapping<db_models.cpaqkcb>
    {
        public cpaqkcbMapping()
        {
            this.ToTable("成品安全库存表");
            this.HasKey(l => l.zdbh);
            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.aqkczl).HasColumnName("安全库存重量");
            this.Property(l => l.sdrbm).HasColumnName("设定人编码");
            this.Property(l => l.sdrq).HasColumnName("设定日期");
            this.Property(l => l.cpbm).HasColumnName("产品编码");
            this.Property(l => l.gh).HasColumnName("钢号");
            this.Property(l => l.gg).HasColumnName("规格");
            this.Property(l => l.zb).HasColumnName("组别");
        }
    }



    /// <summary>
    /// 成品库存锁定表
    /// </summary>
    public class cpkcsdbMapping : SD.Data.Mapping<db_models.cpkcsdb>
    {
        public cpkcsdbMapping()
        {
            this.ToTable("成品库存锁定表");
            this.HasKey(l => l.zdbh);

            this.Property(l => l.zdbh).HasColumnName("自动编号");
            this.Property(l => l.cpkcbh).HasColumnName("成品库存编号");
            this.Property(l => l.sdr).HasColumnName("锁定人");
            this.Property(l => l.sdrq).HasColumnName("锁定日期");
            this.Property(l => l.sdyy).HasColumnName("锁定原因");
            this.Property(l => l.xxdbh).HasColumnName("销售订单编号");
            



        }
    }



    ///// <summary>
    ///// 出库方式表
    ///// </summary>
    //public class ckfsbMapping : SD.Data.Mapping<ckfsb>
    //{
    //    public ckfsbMapping()
    //    {
    //        this.ToTable("出库方式表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.ckfs).HasColumnName("出库方式");


    //    }
    //}



    ///// <summary>
    ///// 产品表
    ///// </summary>
    //public class cpbMapping : SD.Data.Mapping<cpb>
    //{
    //    public cpbMapping()
    //    {
    //        this.ToTable("产品表");
    //        this.HasKey(l => l.cpbm);
    //        this.Property(l => l.ckbzm).HasColumnName("参考标准码");

    //        this.Property(l => l.cpbm).HasColumnName("产品编码");

    //        this.Property(l => l.cpmc).HasColumnName("产品名称");

    //        this.Property(l => l.gh).HasColumnName("钢号");

    //        this.Property(l => l.zb).HasColumnName("组别");

    //        this.Property(l => l.gg).HasColumnName("规格");

    //        this.Property(l => l.zldj).HasColumnName("质量等级");

    //        this.Property(l => l.gc).HasColumnName("公差");

    //        this.Property(l => l.klqd).HasColumnName("抗拉强度");

    //        this.Property(l => l.djdm).HasColumnName("等级代码");

    //        this.Property(l => l.cplb).HasColumnName("产品类别");

    //        this.Property(l => l.qt).HasColumnName("其它");

    //        this.Property(l => l.bz).HasColumnName("备注");


    //    }
    //}



    ///// <summary>
    ///// 合同尾基础信息表
    ///// </summary>
    //public class htwjcxxbMapping : SD.Data.Mapping<htwjcxxb>
    //{
    //    public htwjcxxbMapping()
    //    {
    //        this.ToTable("合同尾基础信息表");
    //        this.HasKey(l => l.zdbh);

    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.dz).HasColumnName("单证");

    //        this.Property(l => l.zytz).HasColumnName("装运通知");

    //        this.Property(l => l.hwys).HasColumnName("货物验收");

    //        this.Property(l => l.bkkl).HasColumnName("不可抗力");

    //        this.Property(l => l.zycl).HasColumnName("争议处理");


    //    }
    //}



    ///// <summary>
    ///// 成品信息表
    ///// </summary>
    //public class cpxxbMapping : SD.Data.Mapping<cpxxb>
    //{
    //    public cpxxbMapping()
    //    {
    //        this.ToTable("成品信息表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.scrq).HasColumnName("生产日期");

    //        this.Property(l => l.bzrq).HasColumnName("包装日期");

    //        this.Property(l => l.scjhh).HasColumnName("生产计划号");

    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.zl).HasColumnName("重量");

    //        this.Property(l => l.bz).HasColumnName("备注");

    //        this.Property(l => l.bc).HasColumnName("班次");

    //        this.Property(l => l.bz).HasColumnName("班组");

    //        this.Property(l => l.cpbm).HasColumnName("成品编码");

    //        this.Property(l => l.jh).HasColumnName("卷号");

    //        this.Property(l => l.ylgys).HasColumnName("原料供应商");

    //        this.Property(l => l.ylgg).HasColumnName("原料规格");

    //        this.Property(l => l.ylgh).HasColumnName("原料钢号");

    //        this.Property(l => l.yllh).HasColumnName("原料炉号");

    //        this.Property(l => l.cpgg).HasColumnName("成品规格");

    //        this.Property(l => l.bzlb).HasColumnName("包装类别");

    //        this.Property(l => l.zjdj).HasColumnName("质检等级");


    //    }
    //}



    ///// <summary>
    ///// 产品价格表
    ///// </summary>
    //public class cpjgbMapping : SD.Data.Mapping<cpjgb>
    //{
    //    public cpjgbMapping()
    //    {
    //        this.ToTable("产品价格表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.khbm).HasColumnName("客户编码");

    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.jg).HasColumnName("价格");

    //        this.Property(l => l.cpbm).HasColumnName("产品编码");


    //    }
    //}



    ///// <summary>
    ///// 价格调整表
    ///// </summary>
    //public class jgdzbMapping : SD.Data.Mapping<jgdzb>
    //{
    //    public jgdzbMapping()
    //    {
    //        this.ToTable("价格调整表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.ddbh).HasColumnName("订单编号");

    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.ysrq).HasColumnName("原始日期");

    //        this.Property(l => l.djrq).HasColumnName("调价日期");

    //        this.Property(l => l.ysjg).HasColumnName("原始价格");

    //        this.Property(l => l.djjg).HasColumnName("调价价格");


    //    }
    //}



    ///// <summary>
    ///// 生产计划状态表
    ///// </summary>
    //public class scjhztbMapping : SD.Data.Mapping<scjhztb>
    //{
    //    public scjhztbMapping()
    //    {
    //        this.ToTable("生产计划状态表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.scjhh).HasColumnName("生产计划号");

    //        this.Property(l => l.smr).HasColumnName("扫码人");

    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.sj).HasColumnName("时间");

    //        this.Property(l => l.zt).HasColumnName("状态");


    //    }
    //}



    ///// <summary>
    ///// 发运方式表
    ///// </summary>
    //public class fyfsbMapping : SD.Data.Mapping<fyfsb>
    //{
    //    public fyfsbMapping()
    //    {
    //        this.ToTable("发运方式表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.fyfsmc).HasColumnName("发运方式名称");

    //        this.Property(l => l.zdbh).HasColumnName("自动编号");


    //    }
    //}



    ///// <summary>
    ///// 模序表
    ///// </summary>
    //public class mxbMapping : SD.Data.Mapping<mxb>
    //{
    //    public mxbMapping()
    //    {
    //        this.ToTable("模序表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.sbbh).HasColumnName("设备编号");

    //        this.Property(l => l.mx).HasColumnName("模序");


    //    }
    //}



    ///// <summary>
    ///// 工艺路线表
    ///// </summary>
    //public class gylxbMapping : SD.Data.Mapping<gylxb>
    //{
    //    public gylxbMapping()
    //    {
    //        this.ToTable("工艺路线表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.jgsj).HasColumnName("间隔时间");

    //        this.Property(l => l.sx).HasColumnName("顺序");

    //        this.Property(l => l.gymc).HasColumnName("工艺名称");

    //        this.Property(l => l.sbbh).HasColumnName("设备编号");

    //        this.Property(l => l.djdm).HasColumnName("等级代码");

    //        this.Property(l => l.dycxwjm).HasColumnName("对应程序文件码");


    //    }
    //}



    ///// <summary>
    ///// 半成品库位配置表
    ///// </summary>
    //public class bcpkwpzbMapping : SD.Data.Mapping<bcpkwpzb>
    //{
    //    public bcpkwpzbMapping()
    //    {
    //        this.ToTable("半成品库位配置表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.ph).HasColumnName("排号");

    //        this.Property(l => l.ch).HasColumnName("层号");

    //        this.Property(l => l.wh).HasColumnName("位号");

    //        this.Property(l => l.ckmc).HasColumnName("仓库名称");

    //        this.Property(l => l.zt).HasColumnName("状态");


    //    }
    //}



    ///// <summary>
    ///// 机器设备表
    ///// </summary>
    //public class jqsbbMapping : SD.Data.Mapping<jqsbb>
    //{
    //    public jqsbbMapping()
    //    {
    //        this.ToTable("机器设备表");
    //        this.HasKey(l => l.sbbh);
    //        this.Property(l => l.scsj).HasColumnName("生产时间");

    //        this.Property(l => l.sxsdjj).HasColumnName("收线速度_卷径");

    //        this.Property(l => l.sxsddls).HasColumnName("收线速度_倒立式");

    //        this.Property(l => l.gyyxsj).HasColumnName("工艺运行时间");

    //        this.Property(l => l.sbbh).HasColumnName("设备编号");

    //        this.Property(l => l.sbmc).HasColumnName("设备名称");

    //        this.Property(l => l.jjjt).HasColumnName("卷径_卷筒");

    //        this.Property(l => l.jjdls).HasColumnName("卷径_倒立式");

    //        this.Property(l => l.sljt).HasColumnName("矢量_卷筒");

    //        this.Property(l => l.sldls).HasColumnName("矢量_倒立式");

    //        this.Property(l => l.cpgg).HasColumnName("产品规格");


    //    }
    //}



    ///// <summary>
    ///// 半成品信息表
    ///// </summary>
    //public class bcpxxbMapping : SD.Data.Mapping<bcpxxb>
    //{
    //    public bcpxxbMapping()
    //    {
    //        this.ToTable("半成品信息表");
    //        this.HasKey(l => l.zdbh);
    //        this.Property(l => l.scjhh).HasColumnName("生产计划号");

    //        this.Property(l => l.ylbm).HasColumnName("原料编码");

    //        this.Property(l => l.zdbh).HasColumnName("自动编号");

    //        this.Property(l => l.kwh).HasColumnName("库位号");

    //        this.Property(l => l.rkrbm).HasColumnName("入库人编码");

    //        this.Property(l => l.ckrbm).HasColumnName("出库人编码");

    //        this.Property(l => l.scrq).HasColumnName("生产日期");

    //        this.Property(l => l.cksj).HasColumnName("出库时间");

    //        this.Property(l => l.zjdj).HasColumnName("质检等级");

    //        this.Property(l => l.bc).HasColumnName("班次");

    //        this.Property(l => l.bz).HasColumnName("班组");

    //        this.Property(l => l.jh).HasColumnName("卷号");

    //        this.Property(l => l.zl).HasColumnName("重量");


    //    }
    //}



   



    ///// <summary>
    ///// 生产计划表_a
    ///// </summary>
    //public class scjhbaMapping : SD.Data.Mapping<scjhba>
    //{
    //    public scjhbaMapping()
    //    {
    //        this.ToTable("生产计划表_a");
    //        this.HasKey(l => l.scjhh);
    //        this.Property(l => l.jhrq).HasColumnName("交货日期");

    //        this.Property(l => l.scjhh).HasColumnName("生产计划号");

    //        this.Property(l => l.ylbh).HasColumnName("原料编号");

    //        this.Property(l => l.bcpbh).HasColumnName("半成品编号");

    //        this.Property(l => l.ps).HasColumnName("盘数");

    //        this.Property(l => l.jhcn).HasColumnName("计划产能");

    //        this.Property(l => l.cpbm).HasColumnName("成品编码");

    //        this.Property(l => l.jhlb).HasColumnName("计划类别");


    //    }
    //}



    ///// <summary>
    ///// 产品包装表
    ///// </summary>
    //public class cpbzbMapping : SD.Data.Mapping<cpbzb>
    //{
    //    public cpbzbMapping()
    //    {
    //        this.ToTable("产品包装表");
    //        this.HasKey(l => l.bzdm);
    //        this.Property(l => l.bzzl).HasColumnName("标准重量");

    //        this.Property(l => l.bzdm).HasColumnName("包装代码");

    //        this.Property(l => l.bzmc).HasColumnName("包装名称");

    //        this.Property(l => l.sbbh).HasColumnName("设备编号");

    //        this.Property(l => l.ggfw).HasColumnName("规格范围");

    //        this.Property(l => l.bz).HasColumnName("备注");


    //    }
    //}



    



    ///// <summary>
    ///// 订单表
    ///// </summary>
    //public class ddbMapping : SD.Data.Mapping<ddb>
    //{
    //    public ddbMapping()
    //    {
    //        this.ToTable("订单表");
    //        this.HasKey(l => l.ddbh);
    //        this.Property(l => l.xdrq).HasColumnName("下单日期");

    //        this.Property(l => l.yqjfrq).HasColumnName("要求交付日期");

    //        this.Property(l => l.ddbh).HasColumnName("订单编号");

    //        this.Property(l => l.dj).HasColumnName("单价");

    //        this.Property(l => l.ddsl).HasColumnName("订单数量");

    //        this.Property(l => l.htbh).HasColumnName("合同编号");

    //        this.Property(l => l.khddh).HasColumnName("客户订单号");

    //        this.Property(l => l.cpmc).HasColumnName("成品名称");

    //        this.Property(l => l.cpbm).HasColumnName("成品编码");

    //        this.Property(l => l.zj).HasColumnName("直径");

    //        this.Property(l => l.gc).HasColumnName("公差");

    //        this.Property(l => l.gh).HasColumnName("钢号");

    //        this.Property(l => l.gg).HasColumnName("规格");

    //        this.Property(l => l.zb).HasColumnName("组别");

    //        this.Property(l => l.bzdm).HasColumnName("包装代码");

    //        this.Property(l => l.fhckm).HasColumnName("发货仓库码");

    //        this.Property(l => l.bz).HasColumnName("备注");


    //    }
    //}



    ///// <summary>
    ///// 生产订单对应销售订单表
    ///// </summary>
    //public class scdddyxsddbMapping : SD.Data.Mapping<scdddyxsddb>
    //{
    //    public scdddyxsddbMapping()
    //    {
    //        this.ToTable("生产订单对应销售订单表");
    //        this.HasKey(l => l.scjhh);
    //        this.Property(l => l.scjhh).HasColumnName("生产计划号");

    //        this.Property(l => l.xsddh).HasColumnName("销售订单号");


    //    }
    //}



    ///// <summary>
    ///// 加热炉生产计划表
    ///// </summary>
    //public class jrlscjhbMapping : SD.Data.Mapping<jrlscjhb>
    //{
    //    public jrlscjhbMapping()
    //    {
    //        this.ToTable("加热炉生产计划表");
    //        this.HasKey(l => l.scjhh);
    //        this.Property(l => l.scjhh).HasColumnName("生产计划号");

    //        this.Property(l => l.sd).HasColumnName("速度");

    //        this.Property(l => l.xh).HasColumnName("线号");


    //    }
    //}

}










