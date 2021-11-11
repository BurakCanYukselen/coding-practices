using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algoritms
{
    public class Stacks_PoisonousPlantsPoisonousPlants
    {
        public int GetTheDay(string[] inputs)
        {
            var plantAmount = int.Parse(inputs[0]);
            var pesticideAmounts = inputs[1].Split(' ', StringSplitOptions.TrimEntries).Select(p => int.Parse(p)).ToList();
            var pesticideStack = GetPesticideStack(pesticideAmounts);

            var day = 1;
            for (int i = 0; i < plantAmount; i++)
            {
                List<int> diedPlants = GetDiedPlants(pesticideStack);
                if (!diedPlants.Any())
                {
                    day++;
                    break;
                }
            }

            return day;
        }

        private List<int> GetDiedPlants(Stack<int> pesticideStack)
        {
            var diedPlants = new List<int>();
            var alivePlants = new Stack<int>();
            while (pesticideStack.Any())
            {
                var plant = pesticideStack.Pop();
                if (pesticideStack.Count > 0 && plant > pesticideStack.Peek())
                    diedPlants.Add(plant);
                else
                    alivePlants.Push(plant);
            }

            pesticideStack = GetPesticideStack(alivePlants);
            return diedPlants;
        }

        private Stack<int> GetPesticideStack(ICollection pesticideAmounts)
        {
            var pesticideStack = new Stack<int>();
            foreach (int input in pesticideAmounts)
                pesticideStack.Push(input);

            return pesticideStack;
        }
    }
}