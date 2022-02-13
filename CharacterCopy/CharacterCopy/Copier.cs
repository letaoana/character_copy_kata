using System;

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

        public void Copy(int count)
        {
            bool read = true;
            while (read)
            {
                var characters = src.ReadChars(count);
                if (!Array.IndexOf(characters, '\n').Equals(-1))
                    read = false;
                else
                    dest.WriteChars(characters);
            }
        }
    }
}