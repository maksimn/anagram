using System;

namespace AnagramModel {
    public class Anagram {
        private String word;
        private String anagramClass;

        public Anagram(String word) {
            this.word = word;
            anagramClass = GetAnagramClass();
        }

        public String GetAnagramClass() {
            String lower = word.ToLower();
            Char[] chars = lower.ToCharArray();
            Array.Sort(chars);
            return new String(chars);
        }

        public String Word {
            get {
                return word;
            }
        }

        public String Class {
            get {
                return anagramClass;
            }
        }
    }
}
