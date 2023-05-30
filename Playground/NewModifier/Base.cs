using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewModifier
{
    public class Base
    {
        public int Number { get; set; }

        public void Invoke()
        {
            Console.WriteLine($"The Number is: {this.Number}");
        }
    }
}
