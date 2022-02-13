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

        [Test]
        public void Given_TenCharacters_When_CopyNthIsCalled_Then_ShouldCallWriteChars()
        {
            source.ReadChars(2).Returns(b => new[] { 'a', 'b' }, b => new[] { 'c', 'd' }, b => new[] { 'e', '\n' });

            service.Copy(2);

            destination.Received(2).WriteChars(Arg.Any<char[]>());
        }
    }
}