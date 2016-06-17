using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Classes
{
    public interface IObjectWithState
    {
        ObjectState State { get; set; }
    }
}
