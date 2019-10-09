using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingHomePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Proc);
            Thread thread2 = new Thread(Proc);
            Thread thread3 = new Thread(Proc);
           
            thread1.Start(1);
            thread2.Start(2);
            thread3.Start(3);
            
          
            thread1.Join();
            thread2.Join();
            thread3.Join();
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
