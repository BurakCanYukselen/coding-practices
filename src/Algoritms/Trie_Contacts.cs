using System;
using System.Collections.Generic;

namespace Algoritms
{
    public class Trie_Contacts
    {
        public class Node
        {
            public char Character { get; set; }
            public Node[] Children { get; set; }
            public bool IsContract { get; set; }

            public Node(char c)
            {
                Character = c;
                Children = new Node[26];
            }
        }

        private Node root;

        public Trie_Contacts()
        {
            root = new Node('-');
        }

        public int[] Operate(string[] inputs)
        {
            var operationCount = int.Parse(inputs[0]);
            var countOfStartsWith = new List<int>();
            for (int i = 1; i <= operationCount; i++)
            {
                var input = inputs[i].Split(" ", StringSplitOptions.TrimEntries);
                var operation = input[0];
                var word = input[1];

                switch (operation)
                {
                    case "add":
                        AddContact(word);
                        break;
                    case "find":
                        countOfStartsWith.Add(CountOfStartsWith(word));
                        break;
                }
            }

            return countOfStartsWith.ToArray();
        }

        private void AddContact(string contract)
        {
            var currentNode = root;
            for (int i = 0; i < contract.Length; i++)
            {
                var character = contract[i];
                if (currentNode.Children[character - 'a'] == null)
                    currentNode.Children[character - 'a'] = new Node(character);
                currentNode = currentNode.Children[character - 'a'];
            }

            currentNode.IsContract = true;
        }

        private int CountOfStartsWith(string partialName)
        {
            var currentNode = root;
            for (int i = 0; i < partialName.Length; i++)
            {
                var character = partialName[i];
                if (currentNode.Children[character - 'a'] == null)
                    return 0;
                currentNode = currentNode.Children[character - 'a'];
            }

            return ContractNumber(currentNode);
        }

        private int ContractNumber(Node node)
        {
            var currentNode = node;
            var contractCountsFromChild = 0;
            foreach (var child in currentNode.Children)
            {
                if (child != null)
                    contractCountsFromChild = contractCountsFromChild + ContractNumber(child);
            }

            if (currentNode.IsContract)
                return contractCountsFromChild + 1;

            return contractCountsFromChild;
        }
    }
}