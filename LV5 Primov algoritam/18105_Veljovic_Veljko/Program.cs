using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PrimovAlgoritam
{
    class Program
    {
        public static void printGr(Graph g)
        {
            Node ptr2 = g.start;
            
            using (StreamWriter sr = new StreamWriter("ispis.txt"))
            {
                int ukupnatezinapravoggrafa = 0;
                int sumaspreznogstabla = 0;
                while (ptr2 != null)
                {
                    sumaspreznogstabla += ptr2.d;
                    Edge a = ptr2.adj;
                    while(a!=null)
                    {
                        ukupnatezinapravoggrafa += a.weight;
                        a = a.link;
                    }
                    if (ptr2.prethodnik != null)
                    {
                        sr.WriteLine(ptr2.node + "->" + ptr2.prethodnik.node);
                        
                    }
                    else
                        sr.WriteLine(ptr2.node + "->");

                    ptr2 = ptr2.next;
                }
                Console.WriteLine("Ukupna tezina potega pocetnog grafa je " + ukupnatezinapravoggrafa + " ,a minimalnog spreznog stabla " + sumaspreznogstabla);
            }
        }
        public static void PrimovAlgoritam(Graph G,Node prvi)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Node polazni = new Node(-1); //setujem polazni cvor na nevalidnu vrednost,tj na vrednost koja nije iz opsega skupa cvorova
            Node ptr = G.start;
            Node[] nizcvorova = new Node[G.nodeNum];
            MinHeap q = new MinHeap(nizcvorova.Length);
            int i = 0;
            
            while(ptr != null)
            {
                ptr.d = Int32.MaxValue;
                ptr.pripadnost = true;
                nizcvorova[i] = ptr;
                if (ptr.node == prvi.node)
                { polazni = ptr; polazni.d = 0; nizcvorova[i].d = 0; }
                    ptr = ptr.next;
                i++;
            }
            if(polazni.node==-1)
            {
                Console.WriteLine("Polazni cvor nije pronadjen");
                return;
            }
            polazni.d = 0;
            polazni.prethodnik = null;
            q.makeHeap(nizcvorova);
            while(!q.isEmpty()) 
            {
                Node v = q.extractMin();
                Edge link = v.adj;
                while(link!= null)
                {
                    if (link.dest.pripadnost==true && link.dest.d>link.weight)
                    {
                        link.dest.prethodnik = v;
                        link.dest.d = link.weight;
                        q.decreaseKey(link.dest,link.weight);
                    }
                    link = link.link;
                }
               
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine();
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("Primov algoritam za graf od "+ G.nodeNum + " cvorova se izvrsio za "+ elapsedTime);

        }
        public static void DaisyChain(Dictionary<string ,int > potezi,Graph a,Node cv)
        {
            Node iter = a.start;
            //cv je cvor koji spajamo sa svima 
            while (iter != null)
            {
                if (iter.node != cv.node) //pocetni cvor ne smemo da povezemo sa samim sobom
                {
                    int n1 = iter.node;
                    int n2 = cv.node;
                    string s1 = n1.ToString();
                    string s2 = n2.ToString();
                    s1 += s2;  //pravimo kljuc 
                    Random rnd = new Random();
                    int weig = rnd.Next(1, 100); 
                    a.insertEdge(iter.node, weig, cv.node); // dodamo u graf i dictionary potez izmedju tekuceg cvora i cvora CV
                    a.insertEdge(cv.node, weig, iter.node);
                    potezi.TryAdd(s1, n1);
                }
                iter = iter.next;

            }
        }
        public static void FirstCase(Dictionary<string, int> potezi, Graph a)
        {
            Node iter2 = a.start;
            Random tezinapoteg = new Random();
            int tezina = tezinapoteg.Next(1, 100);
            string s1 = "", s2 = "";
            while (iter2.next != null) // krecem se sve dok ne dodjem do poslednjeg cvora
            {
                tezinapoteg = new Random();
                tezina = tezinapoteg.Next(1, 100);
                a.insertEdge(iter2.node, tezina, iter2.next.node); //dodajem poteg izmedju tekuceg cvora i cvora ispred njega
                a.insertEdge(iter2.next.node, tezina, iter2.node);
                s1 = iter2.node.ToString();
                s2 = iter2.next.node.ToString();
                s1 += s2; //pravim kljuc za potege 
                potezi.TryAdd(s1, iter2.node); //dodavanje poteza u dictionary
                iter2 = iter2.next;
            }
            tezina = tezinapoteg.Next(1, 100);
            a.insertEdge(iter2.node, tezina, a.start.node); //kad sam dosao do poslednjeg cvora u listi cvorova njega spajam sa prvim 
            a.insertEdge(a.start.node, tezina, iter2.node); //prvi spajam sa poslednjim
            s1 = iter2.node.ToString();
            s2 = a.start.node.ToString();
            s1 += s2;
            potezi.TryAdd(s1, iter2.node);
        }
        public static void GenerisiKNpotega(Dictionary<string, int> potezi, Graph a,Dictionary<int,Node>recnik,int kn)
        {
            int ii = 0;
            while (ii < kn)
            {
                Random rnd = new Random();
                int num1 = rnd.Next(0, recnik.Count - 1); //pronalazak 2 random cvora iz recnika
                int num2 = rnd.Next(0, recnik.Count - 1);
                while (num1 == num2) //ukoliko je izgenerisao 2 ista cvora trazim da generise novi 
                    num1 = rnd.Next(0,recnik.Count-1);
                int weig = rnd.Next(1, 100);
                int prvicv = recnik.ElementAt(num1).Key;
                int drugicv = recnik.ElementAt(num2).Key;
                string s1 = prvicv.ToString();
                string s2 = drugicv.ToString();
                s1 += s2; // pravljenje kljuca 
                if (potezi.TryAdd(s1, num1))//Koristim jako bitnu odliku dictionary-ja da ne mogu da postoje 2 elementa sa istim kljucem
                {                           //tj.ako vec postoji poteg u dictionary-ju then grana se ne izvrsava,puno efikasnije nego da prolazim kroz listu potega
                                            //i proveravam da li postoji grana
                    a.insertEdge(prvicv, weig, drugicv);
                    a.insertEdge(drugicv, weig, prvicv);
                    ii++;
                }
                else
                {
                   // Console.WriteLine($"Potez Vec postoji izmedju cvorova {prvicv} i {drugicv}");
                }


            }
        }
        static void Main(string[] args)
        {
            Graph a = new Graph();
            Console.WriteLine("Unesite N cvorova:");
            string num = Console.ReadLine();
            int n = Convert.ToInt32(num);
            Dictionary<int, Node> recnik = new Dictionary<int, Node>();//koristim recnik,gde cu osim u graf,cvorove da ubacujem i u ovaj recnik radi efikasnijeg pristupa cvorovima
            int i = 0;
            while (i < n)
            {
                Random rnd = new Random();
                int br = rnd.Next(0, 150000);
                Node novicvor = new Node(br);
                if (recnik.TryAdd(br, novicvor)) //ukoliko cvor uspesno dodam u recnik
                {
                    i++; // 
                    a.insertNode(br); //dodam i u graf
                }
            }
            Dictionary<string, int> potezi = new Dictionary<string, int>();//pravim takodje recnik za poteze razlog uvodjenja je isti kao i za grafove,
            //kljuc za ovaj dictionary je string tj ako potez cine cvorovi 3 i 5 kljuc ce biti "35"
            Console.WriteLine("Unesite 1 ukoliko zelite da se izvrsi slucaj 1,unesite 2 ukoliko zelite da se izvrsi slucaj 2 "); //slucaj 1 i 2 su oni kao na timsu opisani
            string slucaj = Console.ReadLine();
            int sl = Convert.ToInt32(slucaj);
            if (sl == 2)
            {
                Random rnd2 = new Random();
                int br2 = rnd2.Next(0, n - 1); //pronalazimo iz recnika neki random cvor i njega povezujemo sa svima
                Node cv = recnik.ElementAt(br2).Value;
                DaisyChain(potezi, a, cv); 

            }
            if (sl == 1)
            {
                FirstCase(potezi, a);

            }
            Console.WriteLine("Unesite k za potege pa ce se izgenerisati k*N potega");
            num = Console.ReadLine();
            int k = Convert.ToInt32(num);
            int kn = k * n;
            GenerisiKNpotega(potezi, a, recnik, kn);
            Random ind = new Random();
            int pp = ind.Next(0, n - 1);
            PrimovAlgoritam(a, recnik.ElementAt(pp).Value);
            printGr(a);
           // u fajlu ispis.txt se nalazi minimalno sprezno stablo



        }
    }
}
