using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovariantReturns
{
    public abstract class Document
    {
        public string Name { get; set; }
        public bool CanDownload { get; set; }
        public bool IsDynamic { get; set; }

        public abstract Document GetDocument();
    }

    public class Schedule : Document
    {
        public string FirstName { get; set; }
        // <LangVersion>8.0</LangVersion>
        //  throws an error -> covariant returns, are supported in version >= 9.0
        public override Schedule GetDocument() => new Schedule();
    }
}
