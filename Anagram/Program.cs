using System;
using System.Diagnostics;

using AnagramModel;

class Program {
    static void Anagrams(String inFile, String outFile) {
        var anagramMaker = new AnagramMaker();

        var anagrams = anagramMaker.CreateAnagramClasses(new FileWordReader(inFile));

        new FileWordWriter(outFile).Write(anagrams);

        Console.WriteLine("\nResults are successfully written in " + outFile);
    }

    static void Main(String[] args) {
        if (args.Length != 1) {
            Console.WriteLine("\nYou should pass a parameter from the command line.\n" +
                              "This parameter must be a file name or a full path to a text file.\n");
            return;
        }
        // Рабочий параметр:
        // @"F:\Dev\Anagram\TestData\example1.txt"
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        Anagrams(args[0], args[0] + ".result.txt");

        stopWatch.Stop();
        TimeSpan ts = stopWatch.Elapsed;
        String elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        Console.WriteLine("Anagrams() method execution time: " + elapsedTime);
    }
}