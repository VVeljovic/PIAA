using System;
using System.Collections.Generic;
using System.Text;

namespace PrimovAlgoritam
{
    class Edge
    {
        public Node dest;
        public int weight;
        public Edge link;
        public Edge()
        {
            dest = null;
            link = null;
            weight = Int32.MaxValue;
        }
        public Edge(Node destN, Edge linkN)
        {
            dest = destN;
            link = linkN;
            weight = 0;
        }
        public Edge(Node destN, int weig, Edge linkN)
        {
            dest = destN;
            link = linkN;
            weight = weig;
        }
    }

}
