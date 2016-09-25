using System;
using NUnit.Framework;

using AnagramModel;

[TestFixture]
public class WordTests {
    [TestCase("word", "dorw")]
    [TestCase("ток", "кот")]
    public void AnagramClass_GetAnagramClass_ReturnsCorrectClass(String str, String expected) {
        Word word = new Word(str);

        Assert.AreEqual(expected, word.AnagramClass);
    }
}
