using System;

namespace AnagramModel {
    public class AnagramIO {
        public AnagramClasses CreateAnagramClasses(IWordReader source) {
            var anagramClasses = new AnagramClasses();
            String s;
            while ((s = source.NextWord()) != null) {
                anagramClasses.AddWord(new Word(s));
            }
            return anagramClasses;
        }
    }
}
