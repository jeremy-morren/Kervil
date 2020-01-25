using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kervil.Csv.Serialization
{
    internal class CsvReader
    {
        //public CsvReader(TextReader reader, string delimiter = ",", string aggregate = "\"", string lineBreak = "\r\n")
        //{
        //    Reader = reader;
        //    Delimiter = delimiter;
        //    Aggregate = aggregate;
        //    LineBreak = lineBreak;
        //    MaxDelimiterLength = new int[] { Delimiter.Length, Aggregate.Length, LineBreak.Length }.Max();
        //    Buffer = new char[BufferSize];
        //}

        //readonly TextReader Reader;

        //readonly string Delimiter;

        //readonly string Aggregate;

        //readonly string LineBreak;

        //const int BufferSize = 1024 * 16;

        ///// <summary>
        ///// Stores the maximum Delimiter Length (for peeking)
        ///// </summary>
        //readonly int MaxDelimiterLength;

        //public List<string> ReadLine()
        //{
        //    List<string> cells = new List<string>();
        //    while (Peek(LineBreak.Length) != LineBreak || Reader.en)
        //    {
        //        cells.Add(ReadCell());
        //    }
                
        //    return cells;
        //}

        //public string ReadCell()
        //{

        //    StringBuilder sb = new StringBuilder();
        //    bool cell = true;
        //    while (cell)
        //    {
        //        sb.Append();
                
        //    }
        //}

        //string ReadCell(bool inAggregate)
        //{
        //    if (!inAggregate)
        //    {
        //        string s = ReadTo(Delimiter, Aggregate, LineBreak); //Read to next control character
        //        if (CheckPeek(Delimiter)) //We read a cell
        //        {
        //            Read(Delimiter.Length); //Read over delimiter
        //            return s;
        //        }
        //        if (CheckPeek(LineBreak)) //Reached end of line
        //        {
        //            Read(LineBreak.Length);

        //        }
        //    }
        //    StringBuilder sb = new StringBuilder();
        //}

        //string ReadTo(string str)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    while (Peek(str.Length) != str)
        //        sb.Append(Read());
        //    return sb.ToString();
        //}

        //string ReadTo(string str1, string str2, string str3)
        //{
        //    StringBuilder sb = new StringBuilder(20);
        //    while (!CheckPeek(str1) && !CheckPeek(str2) && !CheckPeek(str3))
        //        sb.Append(Read());
        //    return sb.ToString();
        //}

        ///// <summary>
        ///// Peeks <see cref="Reader"/> to check if
        ///// it matches <paramref name="str"/>
        ///// </summary>
        ///// <param name="str">String to check</param>
        ///// <returns>Value indicating whether the peeked string matches <paramref name="str"/></returns>
        //bool CheckPeek(string str) => Peek(str.Length) == str;

        ///// <summary>
        ///// Stores the Buffer which we have
        ///// read from <see cref="Reader"/>
        ///// but not processed in CSV
        ///// </summary>
        //readonly char[] Buffer;

        //int Position = 0;

        //int BufferLength;

        //bool EOS = false;

        //void ReadFromStream()
        //{
        //    EOS = Reader.Read()
        //}

        ///// <summary>
        ///// Peeks a string from <see cref="Reader"/>
        ///// of the specified length
        ///// </summary>
        ///// <param name="length"></param>
        ///// <returns></returns>
        //string Peek(int length)
        //{
        //    while (PeekBuffer.Length < length)
        //        PeekBuffer.Append((char)Reader.Read());
        //    char[] arr = new char[] { };
        //    PeekBuffer.CopyTo(0, arr, 0, length);
        //    return new string(arr);
        //}

        ///// <summary>
        ///// Reads the next character from <see cref="TextReader"/>
        ///// or <see cref="PeekBuffer"/> if necessary
        ///// </summary>
        ///// <returns></returns>
        //char Read()
        //{
        //    if (PeekBuffer.Length > 0)
        //    {
        //        char c = PeekBuffer[0];
        //        PeekBuffer.Remove(0, 1); //Remove first character
        //        return c;
        //    }
        //    return (char)Reader.Read();
        //}

        ///// <summary>
        ///// Reads the specified number of 
        ///// characters from <see cref="Reader"/>
        ///// </summary>
        ///// <param name="length">Number of characters to read</param>
        ///// <returns></returns>
        //string Read(int length)
        //{
        //    if (PeekBuffer.Length == length)
        //    {
        //        string s = PeekBuffer.ToString();
        //        PeekBuffer.Clear();
        //        return s;
        //    }
        //    if (PeekBuffer.Length > length)
        //    {
        //        char[] arr = new char[] { };
        //        PeekBuffer.CopyTo(0, arr, 0, length);
        //        PeekBuffer.Remove(0, length);
        //        return new string(arr);
        //    }
        //    StringBuilder sb = new StringBuilder();
        //    if (PeekBuffer.Length < length)
        //    {
        //        sb.Append(PeekBuffer.ToString());
        //        PeekBuffer.Clear();
        //    }
        //    for (int i = sb.Length; i < length; i++)
        //        sb.Append((char)Reader.Read());
        //    return sb.ToString();
        //}
    }
}
