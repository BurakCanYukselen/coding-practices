using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Algoritms
{
    public class DP_FindKthPermutation
    {
        public class AscendingOrder : IComparer<int>
        {
            public int Compare(int x, int y) => x.CompareTo(y);
        }

        public string FindKthPermutation(int[] arr, int kthPermutation)
        {
            var solutionSpace = new SortedList<int, int>(new AscendingOrder());
            GenerateSolutionSpace(solutionSpace, arr, 0);
            return solutionSpace.ElementAt(kthPermutation - 1).Value.ToString();
        }

        private void GenerateSolutionSpace(SortedList<int, int> solutionSpace, int[] arr, int temp)
        {
            if (!arr.Any())
                solutionSpace.Add(temp, temp);
            else
            {
                for (var i = 0; i < arr.Length; i++)
                {
                    var remainingArr = arr.Except(new[] { arr[i] }).ToArray();
                    GenerateSolutionSpace(solutionSpace, remainingArr, (int)(temp + (arr[i] * Math.Pow(10, arr.Length - 1))));
                }
            }
        }
    }
}