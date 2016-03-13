using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

namespace ArrayVsLinkedList
{
    class Program
    {
        public static void Main()
        {
            var summary = BenchmarkRunner.Run<ArrayVsLinkedList>();
        }
    }

    public class ArrayVsLinkedList
    {
        private const int N = 1000000;

        private readonly int[] _arr = new int[N];
        private readonly LinkedList<int> _linked = new LinkedList<int>();

        public ArrayVsLinkedList()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < N; i++)
            {
                int res = rnd.Next();

                _arr[i] = res;
                _linked.AddLast(res);
            }
        }

        [Benchmark]
        public void Array()
        {
            int sum = 0;
            for (int curr = 0; curr < _arr.Length; ++curr)
            {
                sum += _arr[curr];
            }
        }

        [Benchmark]
        public void LinkedList()
        {
            int sum = 0;
            for (LinkedListNode<int> curr = _linked.First; curr != null; curr = curr.Next)
            {
                sum += curr.Value;
            }
        }
    }
}

