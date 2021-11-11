using System.Collections.Generic;

namespace Algoritms
{
    public class Trie_NoPrefixSet
    {
        public class Node
        {
            public char Value { get; set; }
            public Node[] Children { get; set; }

            public Node(char value)
            {
                Value = value;
                Children = new Node[26];
            }
        }

        public string NoPrefixSet(string[] words)
        {
            var goodWords = new List<string>();
            foreach (var word in words)
            {
                var trie = ComposeTrie(word);
                foreach (var goodWord in goodWords)
                    if (IsPrefix(trie, goodWord))
                        return $"BAD SET: {word}";

                goodWords.Add(word);
            }

            return "GOOD SET";
        }

        private bool IsPrefix(Node trie, string goodWord)
        {
            var currentNode = trie;
            var isPrefix = true;
            for (int i = 0; i < goodWord.Length; i++)
            {
                if (currentNode.Children[goodWord[i] - 'a'] != null && currentNode.Children[goodWord[i] - 'a'].Value == goodWord[i])
                    currentNode = currentNode.Children[goodWord[i] - 'a'];
                else
                    return false;
            }

            return isPrefix;
        }

        private Node ComposeTrie(string word)
        {
            var trie = new Node('-');
            var currentNode = trie;
            for (int i = 0; i < word.Length; i++)
            {
                if (currentNode.Children[word[i] - 'a'] == null)
                    currentNode.Children[word[i] - 'a'] = new Node(word[i]);

                currentNode = currentNode.Children[word[i] - 'a'];
            }

            return trie;
        }
    }
}