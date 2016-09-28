using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramModel {
    public interface IWordWriter {
        void Write(IDictionary<String, SortedSet<String>> anagrams);
    }
}
