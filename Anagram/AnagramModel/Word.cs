using System;

namespace AnagramModel {
    public class Word {
        private String value;

        public Word(String word) {
            value = word;
        }

        public String AnagramClass {
            get {
                String lower = value.ToLower();
                Char[] chars = lower.ToCharArray();
                Array.Sort(chars);
                return new String(chars);
            }
        }
    }
}
