using System;
using NUnit.Framework;

using AnagramModel;
using AnagramModel.Fakes;

[TestFixture]
class AnagramIOTests {
    [Test]
    public void AnagramIO_CreateAnagramClasses_AreClassesCorrect () {
        var anagramIO = new AnagramIO();

        anagramIO.CreateAnagramClasses(new FakeWordReader());
        
        Assert.True(false);
    }
}
