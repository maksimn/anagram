using System;
using System.Linq;
using NUnit.Framework;

using AnagramModel.Utils;

[TestFixture]
class MergeFilesHelperTests {
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

    [TestCase("abc", "bac", 0)]
    [TestCase("abc", "xyz", -1)]
    [TestCase("tre", "zzaaaa", 1)]
    public void AnagramClassesCmp_Test(String word1, String word2, Int32 res) {
        var mfh = new MergeFilesHelper();
        var realRes = mfh.AnagramClassesCmp(word1, word2);
        Assert.AreEqual(res, realRes != 0 ? realRes / Math.Abs(realRes) : realRes);
    }
}