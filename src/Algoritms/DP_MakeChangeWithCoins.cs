using System;
using System.Collections;
using System.Collections.Generic;

namespace Algoritms
{
    public class DP_MakeChangeWithCoins
    {
        /*
             1,2,5 => 7
             7: 1111111 => 007
             7: 111112  => 015
             7: 11122   => 023
             7: 1222    => 031
             7: 115     => 102
             7: 25      => 110
        */
        public int MakeChangeWithCoins(int[] coins, int amount)
        {
            var solutionSpace = new HashSet<int>();
            GenerateSolutionSpace(solutionSpace, amount, coins, 0, 0);
            return solutionSpace.Count;
        }

        private void GenerateSolutionSpace(HashSet<int> solutionSpace, int amount, int[] coins, int tempTotal, int solution)
        {
            if (tempTotal == amount)
            {
                solutionSpace.Add(solution);
            }
            else if (tempTotal < amount)
            {
                for (var i = 0; i < coins.Length; i++)
                {
                    if (tempTotal + coins[i] <= amount)
                    {
                        GenerateSolutionSpace(solutionSpace, amount, coins, tempTotal + coins[i], solution + (int)Math.Pow(10, i));
                    }
                }
            }
        }
    }
}