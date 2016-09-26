using System;

namespace AnagramModel {
    public class AnagramIO {
        public AnagramClasses anagramClasses;
        public IWordReader wordReader;
        
        public AnagramIO(IWordReader wordReader) {
            this.wordReader = wordReader;
            anagramClasses = new AnagramClasses();            
        }

        public void CreateAnagramClasses() {
            String s;
            while ((s = wordReader.NextWord()) != null) {
                anagramClasses.AddWord(new Word(s));
            }
        }
    }
}
