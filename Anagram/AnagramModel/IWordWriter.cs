using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramModel {
    public interface IWordWriter {
        void Write(IDictionary<String, SortedSet<String>> anagrams);
    }

    public class ConsoleWordWriter : IWordWriter {
        public void Write(IDictionary<String, SortedSet<String>> anagrams) {
            foreach (var anagramClass in anagrams) {
                var last = anagramClass.Value.Last();

                foreach (var word in anagramClass.Value) {
                    if (word != last)
                        Console.Write(word + ", ");
                }
                Console.Write(last + "\n");
            }
        }
    }
}
