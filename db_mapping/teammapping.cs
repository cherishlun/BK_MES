using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_mapping
{
    class TeamMapping : SD.Data.Mapping<db_models.TeamABC>
    {
        public TeamMapping()
        {
            this.ToTable("班组表");
            this.HasKey(l => l.ID);
            this.Property(l => l.Bzmc).HasColumnName("班组名称");
            this.Property(l => l.Sy).HasColumnName("属于");
            this.Property(l => l.Sx).HasColumnName("顺序");

        }
    }
}
