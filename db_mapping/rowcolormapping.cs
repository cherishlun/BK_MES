using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_mapping
{
    public class RowColorMapping : SD.Data.Mapping<db_models.RowColor>
    {
        public RowColorMapping()
        {
            this.ToTable("行颜色表");
            this.HasKey(l => l.ID);
            this.Property(l => l.ColorTable).HasColumnName("对应表");
            this.Property(l => l.ColorWhere).HasColumnName("变色条件");
            this.Property(l => l.ColorBack).HasColumnName("背景色");
            this.Property(l => l.ColorText).HasColumnName("文字色");
            this.Property(l => l.ColorOrder).HasColumnName("顺序");

        }
    }
}
