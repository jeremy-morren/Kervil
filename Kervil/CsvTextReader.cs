using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Tests")]

namespace Kervil.Csv
{
    internal class CsvTextReader
    {
        public CsvTextReader(TextReader reader, int bufferSize = 1024 * 16)
        {
            Reader = reader;
            BufferSize = bufferSize;
            Buffer = new char[BufferSize];
            Position = BufferSize; //'Start' at end
        }

        public readonly TextReader Reader;

        public readonly int BufferSize;

        char[] Buffer;

        /// <summary>
        /// Represents the position of the next
        /// character that will be read from <see cref="Buffer"/>
        /// </summary>
        int Position;

        /// <summary>
        /// Stores the length of characters
        /// from <see cref="Reader"/> stored
        /// in <see cref="Buffer"/>
        /// </summary>
        int BufferLength = -1;

        void ReadIntoBuffer()
        {
            //Copy unread characters from existing buffer
            char[] newBuffer = new char[BufferSize];
            int length = BufferSize - Position ;
            Array.Copy(Buffer, Position, newBuffer, 0, length);
            //Fill rest of buffer from Stream
            int count = BufferSize - length;
            int read = Reader.Read(newBuffer, length, count);
            if (count == read)
                BufferLength = BufferSize;
            else
                BufferLength = read + length;
            Position = 0; //Reset to start of Buffer
            Buffer = newBuffer;
        }

        public bool EOF => Position != BufferLength && BufferLength != -1 && Position != BufferSize;

        char[] ReadFromBuffer(int length)
        {
            if ((BufferSize - Position) < length)
                ReadIntoBuffer(); //Reset Buffer
            if ((BufferLength - Position) < length)
                length = BufferLength - Position + 1; //Set length to only read what we can
            char[] arr = new char[length];
            Array.Copy(Buffer, Position, arr, 0, length);
            Position += length;
            return arr;
        }

        public string Read(int length)
        {
            if (length <= BufferSize)
                return new string(ReadFromBuffer(length));
            StringBuilder sb = new StringBuilder();
            int read = 0;
            while (!EOF && read < length)
            {
                int toRead = Math.Min(BufferSize, length);
                sb.Append(ReadFromBuffer(toRead));
                read += toRead;
            }
            return sb.ToString();
        }
    }
}
