using System;

using AnagramModel;

class Program {
    static void Main(String[] args) {
        var anagramMaker = new AnagramMaker();

        var anagrams = anagramMaker.CreateAnagramClasses(
            new FileWordReader(@"F:\Dev\Anagram\TestData\example1.txt")
        );

        new ConsoleWordWriter().Write(anagrams);
    }
}