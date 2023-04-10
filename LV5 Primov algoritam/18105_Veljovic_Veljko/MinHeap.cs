using System;
using System.Collections.Generic;
using System.Text;

namespace PrimovAlgoritam
{
    class MinHeap
    {
        public int kapacitet;
        public Node[] el; // mh=el 
        public int trenutno;
        public MinHeap(int kap)
        {
            kapacitet = kap;
            el = new Node[kapacitet + 1];
            trenutno = 0;
        }
        public void makeHeap(Node[] niz)
        {
            if (niz.Length > 0)
            {
                for (int i = 0; i < niz.Length; i++)
                    insert(niz[i]);
            }
        }
        public void insert(Node cv)
        {
            if (kapacitet == trenutno)
            {
                Console.WriteLine("Prepuno!");
                return; 
            }
            trenutno++;
            int tr = trenutno;
            el[tr] = cv;
            bubbleUp(tr);

        }
        public void bubbleUp(int pos)
        {
            int parent = pos / 2;
            int curr = pos;
            while (parent>0 &&curr > 0 && el[parent].d > el[curr].d)
            {
                Zamena(curr, parent);
                curr = parent;
                parent = parent / 2;
            }
        }
        public void Zamena(int a, int b)
        {
            Node tmp = el[a];
            el[a] = el[b];
            el[b] = tmp;
        }
        public Node extractMin()
        {
            Node min = el[1];
            min.pripadnost = false;
            el[1] = el[trenutno];
            el[trenutno] = null;
            Potonuti(1);
            trenutno--;
            return min;
        }
        public void Potonuti(int k)
        {
            int minx = k;
            int levi = 2 * k;
            int desni = 2 * k + 1;
            if (levi < trenutno && el[minx].d > el[levi].d)
                minx = levi;
            if (desni < trenutno && el[minx].d > el[desni].d)
                minx = desni;
            if (minx != k)
            {
                Zamena(k, minx);
                Potonuti(minx);
            }
        }
        public void display()
        {
            for (int i = 1; i < el.Length; i++)
            {
                Console.Write(el[i].node + " ");
            }

        }
        public bool isEmpty()
        {
            if (trenutno == 0)
                return true;
            return false;
        }
        public void decreaseKey(Node p , int newval)
        {
            p.d = newval;
            int i = 1;
            while(i<el.Length &&el[i]!=null&& el[i].d!=newval)
            {
                i++;
            }
            if (el[i]!=null&&el[i].d == newval)
                bubbleUp(i);

        }
    }
}
