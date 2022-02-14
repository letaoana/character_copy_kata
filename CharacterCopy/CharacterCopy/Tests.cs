using NSubstitute;
using NUnit.Framework;

namespace CharacterCopy.Tests
{
    public class Tests
    {
        private ISource source;
        private IDestination destination;
        private Copier service;

        [SetUp]
        public void Initialise()
        {
            source = Substitute.For<ISource>();
            destination = Substitute.For<IDestination>();
            service = new Copier(source, destination);
        }

        [Test]
        public void Given_NewLineIsTheThirdCharacter_When_CopyIsCalled_Then_ShouldCallWriteCharOnlyTwice()
        {
            source.ReadChar().Returns('k', 'a', '\n', 'm', 'o');

            service.Copy();

            destination.Received(2).WriteChar(Arg.Any<char>());
        }

        [Test]
        public void Given_CharactersStartWithANewLine_When_CopyIsCalled_Then_ShouldNotCallWriteChar()
        {
            source.ReadChar().Returns('\n', 'k', 'a', 'm', 'o');

            service.Copy();

            destination.DidNotReceive().WriteChar(Arg.Any<char>());
        }

        [Test]
        public void Given_OnlyNewLine_When_CopyIsCalled_Then_ShouldNotCallWriteChar()
        {
            source.ReadChar().Returns('\n');

            service.Copy();

            destination.DidNotReceive().WriteChar(Arg.Any<char>());
        }

        
        [TestCaseSource(typeof(TestData), nameof(TestData.CopyNthOfChars))]
        public void Given_TenCharacters_When_CopyNthIsCalled_Then_ShouldCallWriteChars(char[] first, char[] second, char[] third, int numOfCharsToCopy, int expectedNoOfCallsReceived)
        {
            source.ReadChars(numOfCharsToCopy).Returns(b => first, b => second, b => third);

            service.Copy(numOfCharsToCopy);

            destination.Received(expectedNoOfCallsReceived).WriteChars(Arg.Any<char[]>());
        }
    }
}