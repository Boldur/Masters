using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace SerchAlgorthmsPrototypes
{
    internal class Node
    {
        public (int, int) State { get; set; }
        public int Cost {  get; set; }
        public Node Parent { get; set; }        

        public Node((int, int) gridCoordinates, Node parent = null) 
        {
            State = gridCoordinates;
            Parent = parent;
            Cost = 0;
        }

        public Node((int, int) gridCoordinates, int cost, Node parent = null)
        {
            State = gridCoordinates;
            Parent = parent;
            Cost = cost;
        }
    }
}
