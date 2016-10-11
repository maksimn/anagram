using System;
using System.Diagnostics;

using AnagramModel;
using AnagramModel.Utils;

class Program {
    static Stopwatch stopWatch;

    static void MeasureProgramExecutionTimeStart() {
        stopWatch = new Stopwatch();
        stopWatch.Start();
    }

    static void MeasureProgramExecutionTimeEnd() {
        stopWatch.Stop();
        TimeSpan ts = stopWatch.Elapsed;
        String elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        Console.WriteLine("Anagrams() method execution time: " + elapsedTime);
    }

    static void Anagrams(String inFile, String outFile) {
        var anagramMaker = new AnagramMaker(new AnagramMakerUtils(inFile, outFile));

        var anagrams = anagramMaker.CreateAnagramClasses(new FileWordReader(inFile));

        if (anagrams.IsResultInTmpFolder) {
            anagramMaker.MergeTmpFilesToOutFile();
        } else {
            new FileWordWriter(outFile).Write(anagrams.Data);
        }
        Console.WriteLine("\nResults are successfully written in " + outFile);
    }

    static void Main(String[] args) {
        if (args.Length != 1) {
            Console.WriteLine("\nYou should pass a parameter from the command line.\n" +
                              "This parameter must be a file name or a full path to a text file.\n");
            return;
        }

        MeasureProgramExecutionTimeStart();

        Anagrams(args[0], args[0] + ".result.txt");

        MeasureProgramExecutionTimeEnd();
    }
}