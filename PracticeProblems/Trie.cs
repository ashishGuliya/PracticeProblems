using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    class TrieNode
    {
        public char Data;
        public bool IsLeaf;
        public Dictionary<char, TrieNode> children;
        private char c;

    }

    class Trie
    {
        private TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        public void InsertKeys(string[] keys)
        {
            foreach (var key in keys)
            {
                InsertKey(key);
            }
        }

        public void InsertKey(string key)
        {
            var temp = _root;
            foreach (var c in key)
            {
                temp.children = temp.children ?? new Dictionary<char, TrieNode>();
                if (temp.children.ContainsKey(c))
                {
                    temp = temp.children[c];
                }
                else
                {
                    var newNode = new TrieNode();
                    newNode.Data = c;
                    temp.children.Add(c,newNode);
                    temp = newNode;
                }
            }

            temp.IsLeaf = true;
        }

        private TrieNode FindNode(string key)
        {
            var temp = _root;
            foreach (var c in key)
            {
                if (temp.children.ContainsKey(c))
                    temp = temp.children[c];
                else
                    return null;
            }

            return temp;

        }

        public IEnumerable<String> Suggestions(string key)
        {
            var suggestions = new List<string>();
            var suggestion = new StringBuilder();
            var temp = FindNode(key);
            if(temp ==null)
                return suggestions;
            AddSuggestions(temp,key, suggestions);
            return suggestions;
        }

        public void AddSuggestions(TrieNode node, string suggestion, List<string> suggestions)
        {
            if (node.IsLeaf)
                suggestions.Add(suggestion);
            if (node.children == null)
                return;
            foreach (var trieNode in node.children.Values)
            {
                AddSuggestions(trieNode, suggestion+ trieNode.Data, suggestions);
            }
        }
    }
}
