using Base.Classes;
using System.Data.Entity.ModelConfiguration;

namespace Base.DataMappings
{
    public class LineItemMap : EntityTypeConfiguration<LineItem>
    {
        public LineItemMap()
        {
            Ignore(x => x.LineTotal);
        }
    }
}
