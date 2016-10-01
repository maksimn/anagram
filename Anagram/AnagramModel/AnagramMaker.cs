using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramModel {
    public class AnagramMaker {
        private IDictionary<String, ICollection<String>> dataStucture =
            new Dictionary<String, ICollection<String>>();

        public void AddWord(String word) {
            if (!String.IsNullOrWhiteSpace(word)) {
                if (!dataStucture.ContainsKey(AnagramClass(word))) {
                    var words = new SortedSet<String>();
                    words.Add(word);
                    dataStucture.Add(AnagramClass(word), words);
                } else {
                    dataStucture[AnagramClass(word)].Add(word);
                }
            }
        }

        public IDictionary<String, ICollection<String>> CreateAnagramClasses(IWordReader source) {
            String s;
            while ((s = source.NextWord()) != null) {
                AddWord(s);
            }
            return dataStucture;
        }

        public String AnagramClass(String word) {
            Char[] chars = word.ToLower().ToCharArray();
            Array.Sort(chars);
            return new String(chars);
        }
    }
}
