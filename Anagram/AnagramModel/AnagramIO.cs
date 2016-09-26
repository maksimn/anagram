using System;

namespace AnagramModel {
    public class AnagramIO {
        public AnagramClasses anagramClasses = new AnagramClasses();

        public void CreateAnagramClasses(IWordReader source) {
            String s;
            while ((s = source.NextWord()) != null) {
                anagramClasses.AddWord(new Word(s));
            }
        }
    }
}
