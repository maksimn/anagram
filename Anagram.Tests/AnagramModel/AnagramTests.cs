using System;
using NUnit.Framework;

using AnagramModel;

[TestFixture]
public class AnagramTests {
    [Test]
    public void GetAnagramClass_GetAnagramClass_ReturnsCorrectClass() {
        Anagram anagram = new Anagram("word");

        Assert.AreEqual("dorw", anagram.Class);
    }
}
