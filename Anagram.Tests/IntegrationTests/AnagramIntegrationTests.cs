using System;
using NUnit.Framework;

using AnagramModel;
using AnagramModel.Fakes;

[TestFixture]
class AnagramIntegrationTests {
    [Test]
    public void Scenario_Behavoir() {
        var anagramIO = new AnagramIO(new FakeWordReader());
        anagramIO.CreateAnagramClasses();
        
        Assert.True(false);
    }
}
