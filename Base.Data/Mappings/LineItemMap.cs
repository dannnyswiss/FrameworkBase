using Base.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data
{
   public class LineItemMap : EntityTypeConfiguration<LineItem>
    {
        public LineItemMap()
        {
            //Ingore(x => x.LineTotal);
        }
    }
}
