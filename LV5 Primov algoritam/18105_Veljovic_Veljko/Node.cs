using System;
using System.Collections.Generic;
using System.Text;

namespace PrimovAlgoritam
{
    class Node
    {
        public int node;
        public Edge adj;
        public Node next;
        public int d;
        public Node prethodnik;
        public int status;
        public bool pripadnost;
        public Node()
        {
            node = 0;
            adj = null;
            next = null;
            d = 0;
            status = 0;
            pripadnost = false;
        }
        public Node(int nodeN)
        {
            node = nodeN;
            adj = null;
            next = null;
            d = 0;
            status = 0;
            pripadnost = false;
        }
        public Node(int nodeN, Edge a, Node n)
        {
            node = nodeN;
            adj = a;
            next = n;
            d = 0;
            prethodnik = null;
            status = 0;
            pripadnost = false;
        }
        public Node(int nodeN, Edge a, Node n, int dd, int statuss)
        {
            node = nodeN;
            adj = a;
            next = n;
            d = dd;
            status = statuss;
            pripadnost = false;
        }
        public void visit()
        {
            Console.Write(node);
        }
    }
}