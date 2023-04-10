using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
namespace BucketHeapBubble
{
    class Program
    {
        //na pocetku sam izgenerisao nizove random brojeva od 100,1000,10k,100k,1m,100m
        //nakon toga sam za svaki sort za svaki broj el startovao stopericu i ispisao kolko treba da se izvrsi
        //izracunao sam i utrosak memorije
        //bubble sort za 1M i 10M elemenata se predugo izvrsava pa sam samo zakomentarisao taj poziv fje
        public static void BubbleSort( int[] niz)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var proc = System.Diagnostics.Process.GetCurrentProcess();
            var mem = proc.WorkingSet64;
            Console.WriteLine("Utrosak memorije pre BubbleSorta je " + mem);
            var memst = mem;
            int i = 0;
            int tmp;
            int j = 0;
            for (i = 0; i < niz.Length - 1; i++)
            {
                for (j = 0; j < niz.Length - 1; j++)
                {
                    if (niz[j] > niz[j + 1])
                    {
                        tmp = niz[j + 1];
                        niz[j + 1] = niz[j];
                        niz[j] = tmp;
                    }
                }
            }
            //foreach(int num in niz)
            //{
            //    Console.Write(num + " ");
            //}
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine();
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.WriteLine("Utrosak");
             proc = System.Diagnostics.Process.GetCurrentProcess();
             mem = proc.WorkingSet64;
            Console.WriteLine("Utrosak memorije na kraju BubbleSorta je " + mem);
            var raz = mem - memst;
            Console.WriteLine("Razlika je " + raz);
            
        }

        public static void  InsertionSort(ref List<int> list)
        {
            int[] niz = new int[list.Count];
            list.CopyTo(niz, 0);
            
            int tmp;
            int j;
            for(int i = 1;i<niz.Length;i++)
            {
                tmp = niz[i];
                j = i - 1;
                while(j>=0&&niz[j]>tmp)
                {
                    niz[j + 1] = niz[j];
                    j = j - 1;
                }
                niz[j + 1] = tmp;
            }
            list = niz.ToList<int>();
           

        }
        public static void Heapify( int[] niz, int i, int size)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int tmp;
            int pomswap;
            if (left <= size && niz[left] > niz[i])
            {
                tmp = left;
            }
            else
                tmp = i;
            if (right <= size && niz[right] > niz[tmp])
                tmp = right;
            if (tmp != i)
            {
                pomswap = niz[i];
                niz[i] = niz[tmp];
                niz[tmp] = pomswap;
                Heapify( niz, tmp, size);
            }

        }
        public static void BuildHeap( int[] niz, int size)
        {

            int start = size / 2;
            int i = start;
            while (i >= 0)
            {
                Heapify( niz, i, size);
                i--;
            }
        }
        public static void HeapSort( int[] niz, int size)
        {
            var proc = System.Diagnostics.Process.GetCurrentProcess();
            var mem = proc.WorkingSet64;
            Console.WriteLine("Utrosak memorije pre HeapSorta je " + mem);
            var memst = mem;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            BuildHeap( niz, size);
            int pom;
            for (int i = size; i > 0; i--)
            {
                pom = niz[i];
                niz[i] = niz[0];
                niz[0] = pom;
                size--;
                Heapify( niz, 0, size);

            }
            //foreach (int num in niz)
            //{
            //    Console.Write(num + " ");
            //}
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine();
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.WriteLine("Utrosak");
            proc = System.Diagnostics.Process.GetCurrentProcess();
            mem = proc.WorkingSet64;
            Console.WriteLine("Utrosak memorije na kraju HeapSorta je " + mem);
            var raz = mem - memst;
            Console.WriteLine("Razlika je " + raz);
        }
        public static void BucketSort( int []ar)
        {
            var proc = System.Diagnostics.Process.GetCurrentProcess();
            var mem = proc.WorkingSet64;
            Console.WriteLine("Utrosak memorije pre BucketSorta je " + mem);
            var memst = mem;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            List<int> list3 = new List<int>();
            List<int> list4 = new List<int>();
            List<int> list5 = new List<int>();
            List<int> list6 = new List<int>();
            List<int> list7 = new List<int>();
            List<int> list8 = new List<int>();
            List<int> list9 = new List<int>();
            List<int> list10 = new List<int>();
           
            foreach(int number in ar)
            {
               
                switch (number)
                {
                    case < 1000:
                        list1.Add(number);
                        break;
                    case < 2000:
                        list2.Add(number);
                        break;
                    case < 3000:
                        list3.Add(number);
                        break;
                    case < 4000:
                        list4.Add(number);
                        break;
                    case < 5000:
                        list5.Add(number);
                        break;
                    case < 6000:
                        list6.Add(number);
                        break;
                    case < 7000:
                        list7.Add(number);
                        break;
                    case < 8000:
                        list8.Add(number);
                        break;
                    case < 9000:
                        list9.Add(number);
                        break;
                    default:
                        list10.Add(number);
                        break;
                }

            }

            Console.WriteLine();
            InsertionSort(ref list1);
            InsertionSort(ref list2);
            InsertionSort(ref list3);
            InsertionSort(ref list4);
            InsertionSort(ref list5);
            InsertionSort(ref list6);
            InsertionSort(ref list7);
            InsertionSort(ref list8);
            InsertionSort(ref list9);
            InsertionSort(ref list10);
            List<int> niz = new List<int>();
            niz.AddRange(list1);
            niz.AddRange(list2);
            niz.AddRange(list3);
            niz.AddRange(list4);
            niz.AddRange(list5);
            niz.AddRange(list6);
            niz.AddRange(list8);
            niz.AddRange(list8);
            niz.AddRange(list9);
            niz.AddRange(list10);
            ar=niz.ToArray();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine();
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.WriteLine("Utrosak");
            proc = System.Diagnostics.Process.GetCurrentProcess();
            mem = proc.WorkingSet64;
            Console.WriteLine("Utrosak memorije na kraju BucketSorta je " + mem);
            var raz = mem - memst;
            Console.WriteLine("Razlika je " + raz);
            //foreach (int num in niz)
            //{
            //    Console.Write(num + " ");
            //}
        }
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int[] niz1 = new int[100];
            for (int i = 0; i < 100; i++)
            {
                int number = new Random().Next(0, 10000);
                niz1[i] = number;
            }
            int[] niz2 = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                int number = new Random().Next(0, 10000);
                niz2[i] = number;
            }
            int[] niz3 = new int[10000];
            for (int i = 0; i < 10000; i++)
            {
                int number = new Random().Next(0, 10000);
                niz3[i] = number;
            }
            int[] niz4 = new int[100000];
            for (int i = 0; i < 100000; i++)
            {
                int number = new Random().Next(0, 10000);
                niz4[i] = number;
            }
            int[] niz5 = new int[1000000];
            for (int i = 0; i < 1000000; i++)
            {
                int number = new Random().Next(0, 10000);
                niz5[i] = number;
            }
            int[] niz6 = new int[10000000];
            for (int i = 0; i < 10000000; i++)
            {
                int number = new Random().Next(0, 10000);
                niz6[i] = number;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine();
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("Nizovi random brojeva su izgenerisani za: " + elapsedTime);
            Console.WriteLine("Sortiranje 100 elementa");
            Console.WriteLine("HeapSort:");
            HeapSort( niz1,niz1.Length-1);
            Console.WriteLine("BucketSort:");
            BucketSort(niz1);
            Console.WriteLine("BubbleSort:");
            BubbleSort(niz1);
            Console.WriteLine("Sortiranje 1000 elemenata:");
            Console.WriteLine("HeapSort:");
            HeapSort(niz2, niz2.Length - 1);
            Console.WriteLine("BucketSort:");
            BucketSort(niz2);
            Console.WriteLine("BubbleSort:");
            BubbleSort(niz2);
            Console.WriteLine("Sortiranje 10000 elemenata:");
            Console.WriteLine("HeapSort:");
            HeapSort(niz3, niz3.Length - 1);
            Console.WriteLine("BucketSort:");
            BucketSort(niz3);
            Console.WriteLine("BubbleSort:");
            BubbleSort(niz3);
            Console.WriteLine("Sortiranje 100000 elemenata:");
            Console.WriteLine("HeapSort:");
            HeapSort(niz4, niz4.Length - 1);
            Console.WriteLine("BucketSort:");
            BucketSort(niz4);
            Console.WriteLine("BubbleSort:");
            BubbleSort(niz4);
            Console.WriteLine("Sortiranje 1000000 elemenata:");
            Console.WriteLine("HeapSort:");
            HeapSort(niz5, niz5.Length - 1);
            Console.WriteLine("BucketSort:");
            BucketSort(niz5);
            Console.WriteLine("BubbleSort:");
            //BubbleSort(niz5);
            Console.WriteLine("Sortiranje 10000000 elemenata:");
            Console.WriteLine("HeapSort:");
            HeapSort(niz6, niz6.Length - 1);
            Console.WriteLine("BucketSort:");
            BucketSort(niz6);
            Console.WriteLine("BubbleSort:");
            //BubbleSort(niz6);
        }

    }
    }

