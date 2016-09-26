using System;
using System.Linq;
using NUnit.Framework;

using AnagramModel;
using AnagramModel.Fakes;

[TestFixture]
class AnagramIOTests {
    [Test]
    public void AnagramIO_CreateAnagramClasses_AreClassesCorrect () {
        var anagramIO = new AnagramIO();

        anagramIO.CreateAnagramClasses(new FakeWordReader());

        var data = anagramIO.anagramClasses.dataStucture;
        
        Assert.True(
            data.Keys.Contains("клноу") && 
            data.Keys.Contains("кот") && 
            data.Keys.Contains("авеиклрть") && 
            
            data["клноу"].Contains("колун") && 
            data["клноу"].Contains("уклон") &&
            data["клноу"].Count == 2 &&

            data["кот"].Contains("кот") &&
            data["кот"].Contains("кто") &&
            data["кот"].Contains("ток") &&
            data["кот"].Count == 3 &&

            data["авеиклрть"].Contains("вертикаль") &&
            data["авеиклрть"].Contains("кильватер") &&
            data["авеиклрть"].Count == 2
        );
    }
}
