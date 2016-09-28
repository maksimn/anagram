using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramModel {
    public class AnagramMaker {
        private IDictionary<String, ICollection<String>> dataStucture =
            new Dictionary<String, ICollection<String>>();

        public void AddWord(Word word) {
            if (!String.IsNullOrWhiteSpace(word.value)) {
                if (!dataStucture.ContainsKey(word.AnagramClass)) {
                    var words = new SortedSet<String>();
                    words.Add(word.value);
                    dataStucture.Add(word.AnagramClass, words);
                } else {
                    dataStucture[word.AnagramClass].Add(word.value);
                }
            }
        }

        public IDictionary<String, ICollection<String>> CreateAnagramClasses(IWordReader source) {
            String s;
            while ((s = source.NextWord()) != null) {
                AddWord(new Word(s));
            }
            return dataStucture;
        }
    }
}
