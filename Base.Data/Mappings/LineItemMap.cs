using Base.Classes;
using System.Data.Entity.ModelConfiguration;

namespace Base.Data
{
    public class LineItemMap : EntityTypeConfiguration<LineItem>
    {
        public LineItemMap()
        {
            Ignore(x => x.LineTotal);
        }
    }
}
