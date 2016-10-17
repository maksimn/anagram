using System;
using System.Collections.Generic;

using AnagramModel.Utils;

namespace AnagramModel {
    public class AnagramMaker {
        private IDictionary<String, ICollection<String>> dataStucture =
            new SortedDictionary<String, ICollection<String>>();
        private IAnagramUtils utils;

        public AnagramMaker(IAnagramUtils utils) {
            this.utils = utils;
        }

        public void AddWord(String word) {
            if (!String.IsNullOrWhiteSpace(word)) {
                if (!dataStucture.ContainsKey(AnagramClass(word))) {
                    var words = new SortedSet<String>();
                    words.Add(word);
                    dataStucture.Add(AnagramClass(word), words);
                } else {
                    dataStucture[AnagramClass(word)].Add(word);
                }
            }
        }

        public AnagramResult CreateAnagramClasses(IWordReader source) {
            Int64 numProcessedWords = 0;
            String s;
            while ((s = source.NextWord()) != null) {
                AddWord(s);
                numProcessedWords++;
                if(utils.ShouldReduceMemoryConsumption(numProcessedWords)) {
                    // Запись текущих результатов во временный файл, освобождение памяти
                    if (!utils.IsTmpFolderExist) {
                        utils.CreateTmpFolder();
                    }
                    String tmpFileName = utils.NextTmpFileName();
                    new FileWordWriter(tmpFileName).Write(dataStucture);
                    dataStucture = new Dictionary<String, ICollection<String>>();
                    utils.FreeMemory();
                }
            }
            return new AnagramResult(utils.IsTmpFolderExist,
                                                  dataStucture, utils.TmpFolderName);
        }

        public static String AnagramClass(String word) {
            if(word == null) {
                return null;
            }
            Char[] chars = word.ToLower().ToCharArray();
            Array.Sort(chars);
            return new String(chars);
        }

        public void MergeTmpFilesToOutFile() {
            // Временная директория с временными промежуточными результатами:
            String tmpFolderName = utils.TmpFolderName;
            // Выходной файл с результатами:
            String resultFileName = utils.OutFile;

            var mergeFilesHelper = new MergeFilesHelper();
            for(String[] files = mergeFilesHelper.FilesToMerge(tmpFolderName);                 
                         files.Length != 1; 
                         files = mergeFilesHelper.FilesToMerge(tmpFolderName)) {
                for (Int32 i = 0; i < files.Length; i += 2) {
                    String file1 = files[i];
                    String file2 = i + 1 < files.Length ? files[i + 1] : null;
                    mergeFilesHelper.Merge(file1, file2);
                }
            }
            mergeFilesHelper.MoveMergeResultToOutFile(tmpFolderName, resultFileName);
        }
    }
}
