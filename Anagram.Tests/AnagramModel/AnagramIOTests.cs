using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using Moq;

using AnagramModel;

[TestFixture]
class AnagramIOTests {
    [Test]
    public void CreateAnagramClasses_DataFromEmptyMoqObject() {
        var anagramIO = new AnagramIO();
        var emptyWordReader = new Mock<IWordReader>();
        emptyWordReader.Setup(wr => wr.NextWord()).Returns((String)null);

        var anagrams = anagramIO.CreateAnagramClasses(emptyWordReader.Object);

        var data = anagrams.Classes;
        Assert.True(data.Keys.Count == 0);
    }
    [Test]
    public void CreateAnagramClasses_DataFromMoqWordReader() {
        var anagramIO = new AnagramIO();
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

        var anagrams = anagramIO.CreateAnagramClasses(mockWordReader.Object);

        var data = anagrams.Classes;
        Assert.True(
            data.IsContainKeyAndElements("клноу", "колун", "уклон") &&
            data.IsContainKeyAndElements("кот", "кот", "кто", "ток") &&
            data.IsContainKeyAndElements("авеиклрть", "вертикаль", "кильватер")
        );
    }
    [Test]
    public void CreateAnagramClasses_DataFromRealFile_IntegrationTest() {
        var anagramIO = new AnagramIO();

        var anagrams = anagramIO.CreateAnagramClasses(
            new FileWordReader(@"F:\Dev\Anagram\TestData\example1.txt")    
        );

        var data = anagrams.Classes;
        Assert.True(
            data.IsContainKeyAndElements("клноу", "колун", "уклон") &&
            data.IsContainKeyAndElements("кот", "кот", "кто", "ток") &&
            data.IsContainKeyAndElements("авеиклрть", "вертикаль", "кильватер")
        );
    }
}

static internal class Extensions {
    public static Boolean IsContainKeyAndElements(
                        this IDictionary<String, SortedSet<String>> data,
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