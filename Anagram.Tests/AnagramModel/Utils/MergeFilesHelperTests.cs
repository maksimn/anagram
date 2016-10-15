using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

using AnagramModel.Utils;

[TestFixture]
class MergeFilesHelperTests {
    [TestCase(null, null)]
    [TestCase("word1", "word1")]
    [TestCase("word1, word2, word3", "word1")]
    public void GetWordFromLine_IsWordCorrect(String line, String word) {
        var mfh = new MergeFilesHelper();

        Assert.AreEqual(word, mfh.GetWordFromLine(line));
    }

    [Test]
    public void MergeLines_IsCorrect_Test1() {
        String line1 = "a", line2 = "b";
        var mfh = new MergeFilesHelper();

        var res = mfh.MergeLines(line1, line2);

        var split = res.Split(new String[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

        Assert.True(split.Contains("a"));
        Assert.True(split.Contains("b"));
        Assert.True(split.Count() == 2);
    }

    [Test]
    public void MergeLines_IsCorrect_Test2() {
        String line1 = "aaa, bbb, ccc", line2 = "b, aaa, ccc, z";
        var mfh = new MergeFilesHelper();

        var res = mfh.MergeLines(line1, line2);

        var split = res.Split(new String[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

        Assert.True(split.Contains("aaa"));
        Assert.True(split.Contains("bbb"));
        Assert.True(split.Contains("ccc"));
        Assert.True(split.Contains("b"));
        Assert.True(split.Contains("z"));
        Assert.True(split.Count() == 5);
    }

    [TestCase("abc", "bac", 0)]
    [TestCase("abc", "xyz", -1)]
    [TestCase("tre", "zzaaaa", 1)]
    public void AnagramClassesCmp_Test(String word1, String word2, Int32 res) {
        var mfh = new MergeFilesHelper();
        var realRes = mfh.AnagramClassesCmp(word1, word2);
        Assert.AreEqual(res, realRes != 0 ? realRes / Math.Abs(realRes) : realRes);
    }

    [TestCase(@"F:\1.txt", @"F:\2.txt")]
    [TestCase(@"F:\2.txt", @"F:\1.txt")]
    public void Merge_IntegrationTest1(String file1, String file2) {
        // Arrange
        using (StreamWriter sw = File.CreateText(file1)) {
            sw.WriteLine("a");
            sw.WriteLine("abc, cab");
            sw.WriteLine("c");
        }
        using(StreamWriter sw = File.CreateText(file2)) {
            sw.WriteLine("bac");
            sw.WriteLine("c");
            sw.WriteLine("x");
        }
        var mfh = new MergeFilesHelper();

        // Act
        mfh.Merge(file1, file2);

        // Assert
        List<String> result = new List<String>();
        using (StreamReader sr = new StreamReader(file1)) {
            String line;
            while((line = sr.ReadLine()) != null) {
                result.Add(line);
            }
        }
        String[] separ = new String[] { ", " };
        Assert.True(
            result.GetWordsArrayForLine(0).Contains("a")
        );
        Assert.True(
            result.GetWordsArrayForLine(1).Contains("abc") &&
            result.GetWordsArrayForLine(1).Contains("cab") &&
            result.GetWordsArrayForLine(1).Contains("bac")
        );
        Assert.True(
            result.GetWordsArrayForLine(2).Contains("c")
        );
        Assert.True(
            result.GetWordsArrayForLine(3).Contains("x")
        );
        Assert.True(result.Count == 4);
        Assert.True(result.GetWordsArrayForLine(0).Count() == 1);
        Assert.True(result.GetWordsArrayForLine(1).Count() == 3);
        Assert.True(result.GetWordsArrayForLine(2).Count() == 1);
        Assert.True(result.GetWordsArrayForLine(3).Count() == 1);
    }
}

static class ListStringExtensions {
    public static String[] GetWordsArrayForLine(this List<String> collection, Int32 num) {
        String[] separ = new String[] { ", " };
        return collection[num].Split(separ, StringSplitOptions.RemoveEmptyEntries);
    }
}