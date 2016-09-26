using System;
using System.Collections.Generic;

namespace AnagramModel {
    public class AnagramClasses {
        public Dictionary<String, SortedSet<String>> dataStucture = 
            new Dictionary<String, SortedSet<String>>();
        public void AddWord(Word word) {
            if(!String.IsNullOrWhiteSpace(word.value)) {
                if(!dataStucture.ContainsKey(word.AnagramClass)) {
                    SortedSet<String> words = new SortedSet<String>();
                    words.Add(word.value);
                    dataStucture.Add(word.AnagramClass, words);
                } else {
                    dataStucture[word.AnagramClass].Add(word.value);
                }
            }
        }
    }
}
