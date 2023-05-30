using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuples;

namespace Tuples
{
    public class Node
    {
        public Node(int value = 0, Node left = null, Node right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}
