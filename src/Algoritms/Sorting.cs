using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algoritms
{
    public class Sorting
    {
        public string SelectiveSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var currentMin = arr[i];
                var currentMinIndex = i;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] < currentMin)
                    {
                        currentMin = arr[j];
                        currentMinIndex = j;
                    }
                }

                var temp = arr[i];
                arr[i] = currentMin;
                arr[currentMinIndex] = temp;
            }

            return string.Join(string.Empty, arr);
        }

        public string BubbleSort(int[] arr)
        {
            var iterate = true;
            while (iterate)
            {
                iterate = false;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        var temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        iterate = true;
                    }
                }
            }

            return string.Join(string.Empty, arr);
        }

        public string InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                var j = i;
                while (j > 0 && arr[j] < arr[j - 1])
                {
                    var temp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = temp;
                    j = j - 1;
                }
            }

            return string.Join(string.Empty, arr);
        }

        #region MergeSort

        public string MergeSort(int[] arr) => string.Join(string.Empty, MergeSortRecursive(arr.ToList()));

        public List<int> MergeSortRecursive(List<int> arr)
        {
            var lenght = arr.Count();
            if (lenght == 1)
                return arr;

            var arr1 = arr.Take(lenght / 2).ToList();
            var arr2 = arr.Skip(lenght / 2).ToList();

            arr1 = MergeSortRecursive(arr1);
            arr2 = MergeSortRecursive(arr2);

            return Merge(arr1, arr2);
        }

        public List<int> Merge(List<int> arr1, List<int> arr2)
        {
            var resultArr = new List<int>();
            while (arr1.Any() && arr2.Any())
            {
                if (arr1[0] < arr2[0])
                {
                    resultArr.Add(arr1[0]);
                    arr1.RemoveAt(0);
                }
                else
                {
                    resultArr.Add(arr2[0]);
                    arr2.RemoveAt(0);
                }
            }

            if (arr1.Any())
                resultArr.AddRange(arr1);

            if (arr2.Any())
                resultArr.AddRange(arr2);

            return resultArr;
        }

        #endregion
    }
}