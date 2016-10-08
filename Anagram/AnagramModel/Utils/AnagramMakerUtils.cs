using System;

namespace AnagramModel.Utils {
    public class AnagramMakerUtils : IAnagramUtils {
        private readonly String inFile, outFile;

        public AnagramMakerUtils(String inFile, String outFile) {
            this.inFile = inFile;
            this.outFile = outFile;
        }
        public Int32 NumWordsBetweenMemoryChecks {
            get {
                return 1000;
            }
        }

        public Int64 MaxMemorySize {
            get {
                return 100 * 1024 * 1024; // 100 MB?
            }
        }

        public Int64 GetTotalMemoryUsage() {
            return GC.GetTotalMemory(false);
        }

        public void CreateTmpFolder() {
            throw new NotImplementedException();
        }

        public String CreateFileInTmpFolder() {
            return null;
        }

        public String InFile { get { return inFile; } }
        public String OutFile { get { return outFile; } }

        public Boolean IsTmpFolderExist {
            get; set;
        }

        public String TmpFolderName {
            get {
                return null;
            }
        }
    }
}