namespace CharacterCopy
{
    public interface ISource
    {
        char ReadChar();

        char[] ReadChars(int count);
    }
}