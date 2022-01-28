namespace CharacterCopy
{
    public class Copier
    {
        private readonly ISource src;
        private readonly IDestination dest;

        public Copier(ISource src, IDestination dest)
        {
            this.src = src;
            this.dest = dest;
        }

        public void Copy()
        {
            bool read = true;
            while (read)
            {
                char character = src.ReadChar();
                if (character.Equals('\n'))
                    read = false;
                else
                    dest.WriteChar(character);
            }
        }
    }
}