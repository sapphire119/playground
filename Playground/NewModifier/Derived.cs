using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewModifier
{
    public class Derived : Base
    {
        new public void Invoke()
        {
            Console.WriteLine($"This is the new Invoke!");
        }
    }
}
