using System;

namespace AnagramModel.Utils {
    public interface IAnagramUtils {
        Int32 NumWordsBetweenMemoryChecks {
            get;
        }
        Int64 GetTotalMemoryUsage();
        Int64 MaxMemorySize {
            get;
        }
        Boolean IsTmpFolderExist {
            get; set;
        }
        void CreateTmpFolder();
        String CreateFileInTmpFolder();
        String TmpFolderName {
            get;
        }
    }
}
