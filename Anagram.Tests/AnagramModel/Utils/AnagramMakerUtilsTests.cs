using System;
using System.IO;

using NUnit.Framework;

using AnagramModel.Utils;

[TestFixture]
class AnagramMakerUtilsTests {
    [Test]
    public void CreateTmpFolderTest() {
        String inFile = @"F:\Dev\Anagram\TestData\example1.txt";
        var utils = new AnagramMakerUtils(inFile, inFile + ".result.txt");
        
        utils.CreateTmpFolder();

        Assert.True(
            Directory.Exists(utils.TmpFolderName)
        );
    }
    [Test]
    public void NextTmpFileName_Test() {
        String inFile = @"F:\Dev\Anagram\TestData\example1.txt";
        var utils = new AnagramMakerUtils(inFile, inFile + ".result.txt");
        utils.CreateTmpFolder();

        String s = utils.NextTmpFileName();
        Assert.AreEqual(utils.TmpFolderName + "\\0.txt", s);

        s = utils.NextTmpFileName();
        Assert.AreEqual(utils.TmpFolderName + "\\1.txt", s);

        s = utils.NextTmpFileName();
        Assert.AreEqual(utils.TmpFolderName + "\\2.txt", s);
    }
}