﻿using System;
using System.IO;
using System.Linq;

namespace AnagramModel.Utils {
    public class MergeFilesHelper {
        public void Merge(String file1, String file2) {
            String fileName1 = Path.GetFileNameWithoutExtension(file1),
                fileName2 = Path.GetFileNameWithoutExtension(file2),
                folder = Path.GetDirectoryName(file1);
            String tmpFileName = String.Format("{0}\\{1}_{2}.txt", folder, fileName1, fileName2);

            using (StreamWriter sw = File.CreateText(tmpFileName)) {
                using (StreamReader sr1 = new StreamReader(file1),
                                    sr2 = new StreamReader(file2)) {
                    String line1 = sr1.ReadLine();
                    String line2 = sr2.ReadLine();
                    while (true) {
                        // #Начало
                        if (line1 == null && line2 == null) {
                            break;
                        } else if (line1 == null && line2 != null) {
                            sw.WriteLine(line2);
                            while ((line2 = sr2.ReadLine()) != null) sw.WriteLine(line2);
                            break;
                        } else if (line1 != null && line2 == null) {
                            sw.WriteLine(line1);
                            while ((line1 = sr1.ReadLine()) != null) sw.WriteLine(line1);
                            break;
                        }
                        String word1 = GetWordFromLine(line1);
                        String word2 = GetWordFromLine(line2);
                        Int32 cmp = AnagramClassesCmp(word1, word2);
                        if (cmp == 0) {
                            String line = MergeLines(line1, line2);
                            sw.WriteLine(line);
                            line1 = sr1.ReadLine();
                            line2 = sr2.ReadLine();
                        } else if (cmp > 0) {
                            // #1
                            while(true) {
                                while (AnagramClassesCmp(word1, word2) > 0) {
                                    sw.WriteLine(line2);
                                    line2 = sr2.ReadLine();
                                    if(line2 == null) break;
                                    word2 = GetWordFromLine(line2);
                                }
                                while (AnagramClassesCmp(word1, word2) < 0) {
                                    sw.WriteLine(line1);
                                    line1 = sr1.ReadLine();
                                    if (line1 == null) break;
                                    word1 = GetWordFromLine(line1);
                                }
                                if (AnagramClassesCmp(word1, word2) == 0)
                                    break; // goto Начало
                            }                            
                        } else {
                            // #2
                            while(true) {
                                while (AnagramClassesCmp(word1, word2) < 0) {
                                    sw.WriteLine(line1);
                                    line1 = sr1.ReadLine();
                                    if (line1 == null) break;
                                    word1 = GetWordFromLine(line1);
                                }
                                while (AnagramClassesCmp(word1, word2) > 0) {
                                    sw.WriteLine(line2);
                                    line2 = sr2.ReadLine();
                                    if (line2 == null) break;
                                    word2 = GetWordFromLine(line2);
                                }
                                if (AnagramClassesCmp(word1, word2) == 0)
                                    break;
                            }                          
                        }
                    }
                }
            }
            File.Delete(file1); // Удаление file1            
            File.Delete(file2); // Удаление file2            
            File.Move(tmpFileName, file1); // Переименование tmpFile в file1
        }

        public String GetWordFromLine(String line) {
            return line.Contains(",") ? line.Substring(0, line.IndexOf(',')) : line;
        }

        public String MergeLines(String line1, String line2) {
            var separ = new String[] { ", "};
            String[] arrFromLine1 = line1.Split(separ, StringSplitOptions.RemoveEmptyEntries);
            String[] arrFromLine2 = line2.Split(separ, StringSplitOptions.RemoveEmptyEntries);
            String[] mergeArr = arrFromLine1.Union(arrFromLine2).ToArray<String>();
            return String.Join(", ", mergeArr);
        }

        public Int32 AnagramClassesCmp(String word1, String word2) {
            return AnagramMaker.AnagramClass(word1).CompareTo(
                        AnagramMaker.AnagramClass(word2)
                   );
        }
    }
}
