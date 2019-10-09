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
        private readonly int[] _arr;
        private readonly int _threadNum;
        private readonly Random _r = new Random();

        public MultiThreadingRandom(int[] arr, int threadNum)
        {
            if (threadNum <= 0)
                throw new ArgumentOutOfRangeException(nameof(threadNum));
            if (arr == null || arr.Length < threadNum)
            {
                throw new ArgumentException($"Parametr{nameof(arr)}has invalid state");
            }
            _arr = arr;
            _threadNum = threadNum;

        }
        public void Start()
        {
            Thread[] threads = new Thread[_threadNum];
            for (int i = 0; i < _threadNum; i++)
            {
                threads[i] = new Thread(Proc);
            }
            for (int i = 0; i < _threadNum; i++)
            {
                threads[i].Start(i);
            }
            for (int i = 0; i < _threadNum; i++)
            {
                threads[i].Join();
            }

        }
        private void Proc(object state)
        {
            var numOfThread = (int)state;
            int start = numOfThread * _arr.Length / _threadNum;
            int end = start + (_arr.Length / _threadNum);
            if (numOfThread == _threadNum - 1)
                end = _arr.Length;
             for (int i = start; i < end; i++)
            {
                _arr[i] = _r.Next();
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            Random r = new Random();
            int[] arr = new int[500000000];
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = r.Next();
            //}


            //stopwatch.Stop();
            //Console.WriteLine("Random one thread: " + stopwatch.Elapsed);

            //stopwatch.Restart();

            var multiRandom = new MultiThreadingRandom(arr, 2);
            multiRandom.Start();


            stopwatch.Stop();
            Console.WriteLine("Random two thread: " + stopwatch.Elapsed);
            Console.ReadLine();
        }

    }
}
