using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnagramModel {
    public class FileWordWriter : IWordWriter {
        private String outFileName;

        public FileWordWriter(String fileName) {
            outFileName = fileName;
        }

        public void Write(IDictionary<String, ICollection<String>> anagrams) {
            using (StreamWriter sw = File.CreateText(outFileName)) {
                foreach (var anagramClass in anagrams) {
                    var last = anagramClass.Value.Last();

                    foreach (var word in anagramClass.Value) {
                        if (word != last)
                            sw.Write(word + ", ");
                    }
                    sw.Write(last + "\n");
                }
            }
        }
    }

    public class ConsoleWordWriter : IWordWriter {
        public void Write(IDictionary<String, ICollection<String>> anagrams) {
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
