using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingHomePractice
{
    class MultiThreadingRandom
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            //Thread thread1 = new Thread(Proc);
            //Thread thread2 = new Thread(Proc);
            //Thread thread3 = new Thread(Proc);

            //thread1.Start(1);
            //thread2.Start(2);
            //thread3.Start(3);


            //thread1.Join();
            //thread2.Join();
            //thread3.Join();
            Random r = new Random();
            int[] arr = new int[500000000];
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next();
            }
          
           
            stopwatch.Stop();
            Console.WriteLine("Random one thread: " + stopwatch.Elapsed);


            stopwatch.Restart();
            Thread thread1 = new Thread(()=>GenArr(r,arr,0,arr.Length/2));
            Thread thread2 = new Thread(()=>GenArr(r, arr,arr.Length/2,arr.Length));
            Thread thread3 = new Thread(()=>GenArr(r, arr,arr.Length/2,arr.Length));
            Thread thread4 = new Thread(()=>GenArr(r, arr,arr.Length/2,arr.Length));

            thread1.Start();
            thread2.Start();
            
            thread1.Join();
            thread2.Join();

            stopwatch.Stop();
            Console.WriteLine("Random two thread: " + stopwatch.Elapsed);
            Console.ReadLine();
        }

    

        static void GenArr(Random r,int[] arr,int start,int end)
        {
            for (int i = 0; i < end; i++)
            {
                arr[i] = r.Next();
            }
        }
        static void Proc(object state)
        {
            var numOfThread = (int)state;
            while (true)
            {
                if (numOfThread == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else if (numOfThread == 2)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(numOfThread);
                }
                Console.ResetColor();
            }
        }
    }
}
