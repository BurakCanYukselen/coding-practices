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

        public double[] GetRunningMedian(int[] inputs)
        {
            var elementNumber = inputs[0];
            var highers = new SortedList<int, int>(new AscendingOrder());
            var lowers = new SortedList<int, int>(new DescendingOrder());
            var medians = new double [elementNumber];

            for (int i = 1; i <= elementNumber; i++)
            {
                AddNumber(inputs[i], highers, lowers);
                Balance(highers, lowers);
                medians[i - 1] = GetMedian(highers, lowers);
            }

            return medians;
        }

        private double GetMedian(SortedList<int, int> highers, SortedList<int, int> lowers)
        {
            var biggers = highers.Count > lowers.Count ? highers : lowers;
            var smallers = highers.Count > lowers.Count ? lowers : highers;

            if (biggers.Count == smallers.Count)
                return ((double)biggers.ElementAt(0).Value + smallers.ElementAt(0).Value) / 2;
            else
                return biggers.ElementAt(0).Value;
        }

        private void Balance(SortedList<int, int> highers, SortedList<int, int> lowers)
        {
            var biggers = highers.Count > lowers.Count ? highers : lowers;
            var smallers = highers.Count > lowers.Count ? lowers : highers;

            if (biggers.Count - smallers.Count >= 2)
            {
                var extra = biggers.ElementAt(0).Value;
                biggers.RemoveAt(0);
                smallers.Add(extra, extra);
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