using System;
using System.Collections.Generic;

namespace AnagramModel {
    public class AnagramResult {
        public AnagramResult(Boolean isResultInTmpFolder, 
                             IDictionary<String, ICollection<String>> dataStructure, 
                             String tmpFolderPath) {
            IsResultInTmpFolder = isResultInTmpFolder;
            TmpFolderPath = IsResultInTmpFolder ? tmpFolderPath : null;
            Data = IsResultInTmpFolder ? null: dataStructure;
        }
        public Boolean IsResultInTmpFolder { get; }
        public String TmpFolderPath { get; }
        public IDictionary<String, ICollection<String>> Data { get; }
    }
}
