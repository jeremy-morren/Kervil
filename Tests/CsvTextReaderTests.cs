using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kervil.Csv;
using System.Text;

namespace Tests
{
    [TestClass]
    public class CsvTextReaderTests
    {
        [TestMethod]
        public void TestReadCharacter()
        {
            string str = GetRandomString(1000);
            var sr = new StringReader(str);
            var textReader = new CsvTextReader(sr, 3);
            for (int i = 0; i < str.Length; i++)
            {
                char c = textReader.Read(1)[0];
                Assert.AreEqual(str[i], c);
            }
        }

        [TestMethod]
        public void TestReadStringWithEqualBufferSize()
        {
            int stringLength = new Random().Next(5, 25);
            var str = GetRandomString(stringLength * 1000);
            var sr = new StringReader(str);
            var textReader = new CsvTextReader(sr, stringLength);
            for (int i = 0, iterations = str.Length / stringLength; i < iterations; i++)
            {
                string actual = textReader.Read(stringLength);
                string expected = str.Substring(i * stringLength, stringLength);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestReadStringWithLargerBufferSize()
        {
            int stringLength = new Random().Next(5, 25);
            var str = GetRandomString(stringLength * 1000);
            var sr = new StringReader(str);
            var textReader = new CsvTextReader(sr, (int)(stringLength * 1.5));
            for (int i = 0, iterations = str.Length / stringLength; i < iterations; i++)
            {
                string actual = textReader.Read(stringLength);
                string expected = str.Substring(i * stringLength, stringLength);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestReadStringWithSmallerBufferSize()
        {
            int stringLength = new Random().Next(5, 25);
            var str = GetRandomString(stringLength * 1000);
            var sr = new StringReader(str);
            var textReader = new CsvTextReader(sr, (int)(stringLength * 0.5));
            for (int i = 0, iterations = str.Length / stringLength; i < iterations; i++)
            {
                string actual = textReader.Read(stringLength);
                string expected = str.Substring(i * stringLength, stringLength);
                Assert.AreEqual(expected, actual);
            }
        }

        string GetRandomString(int length)
        {
            string chars = "01234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
                sb.Append(chars[random.Next(0, chars.Length)]);
            return sb.ToString();
        }
    }
}
