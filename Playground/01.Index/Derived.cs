using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Index
{
    public class Derived : PrivateProtectedBase
    {
        public Derived(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int Age { get; set; }
    }
}
