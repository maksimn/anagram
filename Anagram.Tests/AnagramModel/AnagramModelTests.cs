using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using Moq;

using AnagramModel;

[TestFixture]
class AnagramModelTests {
    [TestCase("word", "dorw")]
    [TestCase("ток", "кот")]
    [TestCase("", "")]
    public void AnagramClass_GetAnagramClass_ReturnsCorrectClass(String str, String expected) {
        var anagramMaker = new AnagramMaker();

        Assert.AreEqual(expected, anagramMaker.AnagramClass(str));
    }
    [Test]
    public void CreateAnagramClasses_DataFromEmptyMoqObject() {
        var anagramMaker = new AnagramMaker();
        var emptyWordReader = new Mock<IWordReader>();
        emptyWordReader.Setup(wr => wr.NextWord()).Returns((String)null);

        var anagrams = anagramMaker.CreateAnagramClasses(emptyWordReader.Object);

        var data = anagrams;
        Assert.True(data.Keys.Count == 0);
    }
    [Test]
    public void CreateAnagramClasses_DataFromMoqWordReader() {
        var anagramMaker = new AnagramMaker();
        var mockWordReader = new Mock<IWordReader>();
        mockWordReader.SetupSequence(wr => wr.NextWord())
            .Returns("колун")
            .Returns("ток")
            .Returns("кильватер")
            .Returns("кот")
            .Returns("уклон")
            .Returns("ток")
            .Returns("кто")
            .Returns("ток")
            .Returns("вертикаль")
            .Returns((String)null);

        var anagrams = anagramMaker.CreateAnagramClasses(mockWordReader.Object);

        var data = anagrams;
        Assert.True(
            data.IsContainKeyAndElements("клноу", "колун", "уклон") &&
            data.IsContainKeyAndElements("кот", "кот", "кто", "ток") &&
            data.IsContainKeyAndElements("авеиклрть", "вертикаль", "кильватер")
        );
    }
    [Test]
    public void CreateAnagramClasses_DataFromRealFile_IntegrationTest() {
        var anagramMaker = new AnagramMaker();

        var anagrams = anagramMaker.CreateAnagramClasses(
            new FileWordReader(@"F:\Dev\Anagram\TestData\example1.txt")    
        );

        var data = anagrams;
        Assert.True(
            data.IsContainKeyAndElements("клноу", "колун", "уклон") &&
            data.IsContainKeyAndElements("кот", "кот", "кто", "ток") &&
            data.IsContainKeyAndElements("авеиклрть", "вертикаль", "кильватер") &&
            data.IsContainKeyAndElements("епрст", "епрст") &&
            data.Keys.Count == 4
        );
    }
}

static internal class Extensions {
    public static Boolean IsContainKeyAndElements(
                        this IDictionary<String, ICollection<String>> data,
                        String key,
                        params String[] values
    ) {
        if (!data.Keys.Contains(key)) {
            return false;
        }
        foreach (String word in values) {
            if (!data[key].Contains(word)) {
                return false;
            }
        }
        return data[key].Count() == values.Length;
    }
}