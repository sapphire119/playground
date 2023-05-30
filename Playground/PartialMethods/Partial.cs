using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialMethods
{
    public partial class Partial
    {
        public partial string FormatName(string name);
    }

    public partial class Partial
    {
        //partial methods used for code generators
        public partial string FormatName(string name)
        {
            return $"Hello my name is: {name}";
        }
    }
}
