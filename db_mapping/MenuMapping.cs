using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_mapping
{
    public class MenuMapping : SD.Data.Mapping<db_models.Menus>
    {
        public MenuMapping()
        {
            this.ToTable("菜单表");
            this.HasKey(l => l.ID);
            this.Property(l => l.MenuName).HasColumnName("菜单名称");
            this.Property(l => l.MenuTag).HasColumnName("菜单目录");

        }

    }
}
