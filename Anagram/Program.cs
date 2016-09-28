using System;

using AnagramModel;

class Program {
    static void Main(String[] args) {
        if (args.Length != 1) {
            Console.WriteLine("You should pass a parameter from the command line.\n" +
                              "This parameter must be a file name or a full path to a text file.\n");
            return;
        }
        // Рабочий параметр:
        // @"F:\Dev\Anagram\TestData\example1.txt"

        var anagramMaker = new AnagramMaker();

        var anagrams = anagramMaker.CreateAnagramClasses(new FileWordReader(args[0]));

        new FileWordWriter(args[0] + ".result.txt").Write(anagrams);

        Console.WriteLine("Results are successfully written in " + args[0] + ".result.txt");
    }
}