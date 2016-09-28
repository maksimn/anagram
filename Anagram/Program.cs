using System;

using AnagramModel;

class Program {
    static void Main(String[] args) {
        String file = @"F:\Dev\Anagram\TestData\example1.txt";
        var anagramMaker = new AnagramMaker();

        var anagrams = anagramMaker.CreateAnagramClasses(
            new FileWordReader(file)
        );

        // new ConsoleWordWriter().Write(anagrams);
        new FileWordWriter(file + ".result.txt").Write(anagrams);
    }
}