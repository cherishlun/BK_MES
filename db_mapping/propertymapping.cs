using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_mapping
{
    public class PropertysMapping : SD.Data.Mapping<db_models.Propertys>
    {
        public PropertysMapping()
        {
            this.ToTable("属性表");
            this.HasKey(l => l.ID);
            this.Property(l => l.ShowName).HasColumnName("显示名称");
            this.Property(l => l.CorrTable).HasColumnName("对应表");
            this.Property(l => l.CorrField).HasColumnName("对应字段");
            this.Property(l => l.ShowType).HasColumnName("显示类型");
            this.Property(l => l.ShowLenght).HasColumnName("长度");
            this.Property(l => l.ShowDataItem).HasColumnName("数据项");
            this.Property(l => l.ID).HasColumnName("序号");
            this.Property(l => l.CorrVar).HasColumnName("变量名");
            this.Property(l => l.ValidateType).HasColumnName("验证类型");
            this.Property(l => l.IsAllowableEmpty).HasColumnName("允许空");
            this.Property(l => l.DecimalDigits).HasColumnName("小数位");
            this.Property(l => l.Order).HasColumnName("顺序");

        }
    }
}
