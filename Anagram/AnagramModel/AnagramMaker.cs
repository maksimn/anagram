using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramModel {
    public class AnagramMaker {
        public IDictionary<String, SortedSet<String>> CreateAnagramClasses(IWordReader source) {
            var anagramClasses = new AnagramClasses();
            String s;
            while ((s = source.NextWord()) != null) {
                anagramClasses.AddWord(new Word(s));
            }
            return anagramClasses.Classes;
        }
    }
}
