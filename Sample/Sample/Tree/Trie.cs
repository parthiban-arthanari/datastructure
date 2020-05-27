using System;

namespace Sample.Tree
{
    public class TrieRunner
    {
        public static TrieRunner Instance = new TrieRunner();

        public void Do()
        {
            Trie trie = new Trie();

            trie.Insert("apple");
            trie.Search("apple");   // returns true
            trie.Search("app");     // returns false
            trie.StartsWith("app"); // returns true
            trie.Insert("app");   
            trie.Search("app");
        }

    }
    public class Trie
    {
        char c;
        bool isEOS;
        Trie[] nodes;
        int count;

        public Trie()
        {
            nodes = new Trie[26];
        }

        private Trie Find(Trie parent, char c)
        {
            return parent.nodes[c - 'a'];
        }

        public void Insert(string word)
        {
            Trie node = this;
            for(int i =0; i<word.Length; i++)
            {
                var n = Find(node, word[i]);

                if(n != null)
                    node = n;
                else
                {
                    var newNode = new Trie();
                    newNode.c = word[i];
                    node.nodes[node.count++] = newNode;
                    node = newNode;
                }
            }
            node.isEOS = true;
        }
        private bool SearchWord(string word, bool fullString = true)
        {
            Trie node = this;

            for(int i =0; i<word.Length; i++)
            {
                node = Find(node, word[i]);

                if(node != null)
                {
                    if(i == word.Length - 1)
                        return fullString ? node.isEOS : true;
                }
                else
                    break;
            }

            return false;
        }

        public bool Search(string word)
        {
            return SearchWord(word);
        }

        public bool StartsWith(string prefix)
        {
            return SearchWord(prefix, false);
        }
    }
}
