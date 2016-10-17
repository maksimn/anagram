using System;
using System.IO;

namespace AnagramModel.Utils {
    public class AnagramMakerUtils : IAnagramUtils {
        private readonly String inFile, outFile;
        private Boolean isTmpFolderExist;
        private String tmpFolderName;
        private Int32 numTmpFiles;

        private const Int64 MAX_MEMORY_SIZE = 100 * 1024 * 1024; // 100 MB

        public AnagramMakerUtils(String inFile, String outFile) {
            this.inFile = inFile;
            this.outFile = outFile;
        }
        public Int32 NumWordsBetweenMemoryChecks { get { return 1000; } }
        public Int64 MaxMemorySize { get { return MAX_MEMORY_SIZE; } } 

        public Int64 GetTotalMemoryUsage() {
            return GC.GetTotalMemory(false);
        }

        public void CreateTmpFolder() {
            String pathToTmp = outFile.Substring(0, outFile.LastIndexOf('\\') + 1);
            Int32 tmpName = 0;
            for (; tmpName < Int32.MaxValue && Directory.Exists(pathToTmp + tmpName); tmpName++);
            tmpFolderName = pathToTmp + tmpName;
            Directory.CreateDirectory(tmpFolderName);
            isTmpFolderExist = true;
        }

        public Boolean ShouldReduceMemoryConsumption(Int64 numProcessedWords) {
            return numProcessedWords % NumWordsBetweenMemoryChecks == 0 &&
                   GetTotalMemoryUsage() > MaxMemorySize;
        }

        public String NextTmpFileName() {
            return String.Format("{0}\\{1}.txt", TmpFolderName, numTmpFiles++);
        }

        public void FreeMemory() {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public String InFile { get { return inFile; } }
        public String OutFile { get { return outFile; } }

        public Boolean IsTmpFolderExist {
            get {
                return isTmpFolderExist;
            }
        }

        public String TmpFolderName {
            get {
                return tmpFolderName;
            }
        }
    }
}