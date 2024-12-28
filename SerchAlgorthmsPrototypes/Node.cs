using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerchAlgorthmsPrototypes
{
    internal class Node
    {
        public (int, int) State {  get; set; }
        public Node Parent { get; set; }

        public Node((int, int) state, Node parent = null) 
        {
            State = state;
            Parent = parent;
        }
    }
}
