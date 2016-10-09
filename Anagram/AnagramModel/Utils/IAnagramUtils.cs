using System;

namespace AnagramModel.Utils {
    public interface IAnagramUtils {
        Boolean ShouldReduceMemoryConsumption(Int64 numProcessedWords);    
        void CreateTmpFolder();
        String TmpFolderName { get; }
        Boolean IsTmpFolderExist { get; }
        String NextTmpFileName();
    }
}
