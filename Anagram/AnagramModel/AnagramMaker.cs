﻿using System;
using System.Collections.Generic;
using System.Linq;

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
                    // Здесь нужно записать текущие результаты во временный файл,
                    // освободить память и продолжить дальше до конца
                    if (!utils.IsTmpFolderExist) {
                        utils.CreateTmpFolder();
                    }
                    String tmpFileName = utils.NextTmpFileName();
                    new FileWordWriter(tmpFileName).Write(dataStucture);
                    dataStucture = new Dictionary<String, ICollection<String>>();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
            return new AnagramResult(utils.IsTmpFolderExist,
                                                  dataStucture, utils.TmpFolderName);
        }

        public String AnagramClass(String word) {
            Char[] chars = word.ToLower().ToCharArray();
            Array.Sort(chars);
            return new String(chars);
        }
    }
}
