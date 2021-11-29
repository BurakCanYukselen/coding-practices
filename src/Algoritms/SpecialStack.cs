using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Algoritms
{
    // T: O(1) | S: O(n)
    public class SpecialStack
    {
        private int ElementNumber { get; set; }
        private Dictionary<int, int> Map { get; set; }
        private int MinElement { get; set; }

        public SpecialStack()
        {
            MinElement = int.MaxValue;
            Map = new Dictionary<int, int>();
        }
        
        public void Push(int element)
        {
            var elementToPush = element;
            if (elementToPush < MinElement)
            {
                elementToPush = 2 * elementToPush - MinElement;
                MinElement = element;
            }

            ElementNumber = ElementNumber + 1;
            Map.Add(ElementNumber, elementToPush);
        }

        public int Pop()
        {
            var element = Map[ElementNumber];
            var elementToPop = element;
            if (elementToPop < MinElement)
            {
                elementToPop = MinElement;
                MinElement = 2 * MinElement - element;
            }

            Map.Remove(ElementNumber);
            ElementNumber = ElementNumber - 1;
            return elementToPop;
        }

        public int? GetMin() => MinElement == int.MaxValue ? null : MinElement;
    }
}