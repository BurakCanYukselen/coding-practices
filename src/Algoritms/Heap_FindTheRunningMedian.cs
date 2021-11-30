using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Algoritms
{
    public class Heap_FindTheRunningMedian
    {
        private class DescendingOrder : IComparer<int>
        {
            public int Compare(int x, int y) => y.CompareTo(x);
        }

        private class AscendingOrder : IComparer<int>
        {
            public int Compare(int x, int y) => x.CompareTo(y);
        }

        public string GetRunningMedian(int[] inputs)
        {
            var highers = new SortedList<int, int>(new AscendingOrder());
            var lowers = new SortedList<int, int>(new DescendingOrder());
            var medians = new double [inputs.Length];

            for (int i = 0; i < inputs.Length; i++)
            {
                AddNumber(inputs[i], highers, lowers);
                Balance(highers, lowers);
                medians[i] = GetMedian(highers, lowers);
            }

            return string.Join(",", medians);
        }

        private double GetMedian(SortedList<int, int> highers, SortedList<int, int> lowers)
        {
            var bigger = highers.Count > lowers.Count ? highers : lowers;
            var smaller = highers.Count > lowers.Count ? lowers : highers;

            if (bigger.Count == smaller.Count)
                return ((double)bigger.ElementAt(0).Value + smaller.ElementAt(0).Value) / 2;
            else
                return bigger.ElementAt(0).Value;
        }

        private void Balance(SortedList<int, int> highers, SortedList<int, int> lowers)
        {
            var bigger = highers.Count > lowers.Count ? highers : lowers;
            var smaller = highers.Count > lowers.Count ? lowers : highers;

            if (bigger.Count - smaller.Count >= 2)
            {
                var extra = bigger.ElementAt(0).Value;
                bigger.RemoveAt(0);
                smaller.Add(extra, extra);
            }
        }

        private void AddNumber(int input, SortedList<int, int> highers, SortedList<int, int> lowers)
        {
            if (lowers.Count == 0 || input < lowers.ElementAt(0).Value)
                lowers.Add(input, input);
            else
                highers.Add(input, input);
        }
    }
}