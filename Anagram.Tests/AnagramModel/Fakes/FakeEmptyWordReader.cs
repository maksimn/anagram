using System;

namespace AnagramModel.Fakes {
    public class FakEmptyWordReader : IWordReader {
        public String NextWord() {
            return null;
        }
    }
}
