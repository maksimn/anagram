using System;
using System.Collections.Generic;

namespace AnagramModel.Fakes {
    public class FakeWordReader : IWordReader {
        private List<String> word = new List<String>();
        private List<String>.Enumerator enumerator;
        public FakeWordReader() {
            word.Add("колун");
            word.Add("ток");
            word.Add("кильватер");
            word.Add("кот");
            word.Add("уклон");
            word.Add("ток");
            word.Add("кто");
            word.Add("ток");
            enumerator = word.GetEnumerator();
        }
        public String NextWord() {
            enumerator.MoveNext();
            return enumerator.Current;
        }
    }
}