using System;

namespace AnagramModel {
    public class Word {
        public String value;

        public Word(String word) {
            value = word;
        }

        public String AnagramClass {
            get {
                Char[] chars = value.ToLower().ToCharArray();
                Array.Sort(chars);
                return new String(chars);
            }
        }
    }
}
