using System;
using System.Collections.Generic;
using System.Text;

namespace PrimovAlgoritam
{
    class Graph
    {
        public Node start;

        public int nodeNum;
        public Graph()
        {
            start = null;

            nodeNum = 0;
        }
        public void insertNode(int data)
        {

            start = new Node(data, null, start);
            if (start.next != null)
                start.next.prethodnik = start;
            nodeNum++;
        }
        public bool insertEdge(int datasrc, int weight, int datadest)
        {
            Node psrc = null;
            Node pdest = null;
            Node ptr = start;
            while (ptr != null && (psrc == null || pdest == null))
            {
                if (ptr.node == datasrc)
                    psrc = ptr;
                else if (ptr.node == datadest)
                    pdest = ptr;
                ptr = ptr.next;
            }
            if (psrc == null || pdest == null)
                return false;
            psrc.adj = new Edge(pdest, weight, psrc.adj);
            return true;

        }
        public void Print()
        {
            Node ptr = start;
            while (ptr != null)
            {
                Console.Write(ptr.node + "->");
                Edge edz = ptr.adj;
                while (edz != null)
                {
                    Console.Write(edz.dest.node);
                    Console.Write(" | ");
                    edz = edz.link;
                }
                Console.WriteLine("");
                ptr = ptr.next;
            }
        }
        public Node FindNode(int a)
        {
            Node ptr = start;
            while (ptr != null)
            {
                if (ptr.node == a)
                {
                    return ptr;
                }
                ptr = ptr.next;
            }
            return null;
        }
        public void swap(Node Node1, Node Node2)
        {
            Node temp;
            temp = Node1.next;
            Node1.next = Node2.next;
            Node2.next = temp;

            if (Node1.next != null)
                Node1.next.prethodnik = Node1;
            if (Node2.next != null)
                Node2.next.prethodnik = Node2;

            temp = Node1.prethodnik;
            Node1.prethodnik = Node2.prethodnik;
            Node2.prethodnik = temp;

            if (Node1.prethodnik != null)
                Node1.prethodnik.next = Node1;
            if (Node2.prethodnik != null)
                Node2.prethodnik.next = Node2;
            start = Node2;
        }
    }
}
