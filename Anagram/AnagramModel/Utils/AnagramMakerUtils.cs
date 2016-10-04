using System;

namespace AnagramModel.Utils {
    public static class AnagramMakerUtils {
        public static Int32 NumOfAddedWordsBetweenMemoryChecks {
            get {
                return 1000;
            }
        }

        public static Int64 MaxMemorySize {
            get {
                return 100 * 1024 * 1024; // 100 MB?
            }
        }

        public static Int64 GetTotalMemoryUsage() {
            return GC.GetTotalMemory(false);
        }

        public static String InFile { get; set; }
        public static String OutFile { get; set; }
    }
}