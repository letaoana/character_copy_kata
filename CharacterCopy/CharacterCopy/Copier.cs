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
                if (character == '\n')
                    read = false;
                else
                    dest.WriteChar(character);
            }
        }

        public void Copy(int count)
        {
            if (!(count <= 0))
            {
                bool read = true;
                while (read)
                {
                    var characters = src.ReadChars(count);
                    var indexOfNewLine = Array.IndexOf(characters, '\n');
                    if (indexOfNewLine.Equals(0)) break;
                  
                    var numOfCharsToCopy = !indexOfNewLine.Equals(-1) ? indexOfNewLine : count;
                    var charsToCopy = new char[numOfCharsToCopy];
                    for (int i = 0; i < characters.Length; i++)
                    {
                        if (i.Equals(indexOfNewLine))
                        {
                            read = false;
                            break;
                        }
                        charsToCopy[i] = characters[i];
                    }
                    dest.WriteChars(charsToCopy);
                }
            }
        }
    }
}