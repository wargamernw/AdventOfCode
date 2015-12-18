using System;
using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTest
{
    [TestClass]
    public class AdventTests
    {
        [TestMethod]
        public void Day8Test()
        {
            int literal;
            int memory;
            int encoded;
            int i = 0;

            char[] word = new char[100];
            word[i++] = '"';
            word[i++] = '"';
            Day8.CountWord(word, out literal, out memory, out encoded);
            Assert.AreEqual(2, literal);
            Assert.AreEqual(0, memory);
            Assert.AreEqual(6, encoded);

            i = 0;
            word[i++] = '"';
            word[i++] = 'a';
            word[i++] = 'b';
            word[i++] = 'c';
            word[i++] = '"';
            Day8.CountWord(word, out literal, out memory, out encoded);
            Assert.AreEqual(5, literal);
            Assert.AreEqual(3, memory);
            Assert.AreEqual(9, encoded);

            i = 0;
            word[i++] = '"';
            word[i++] = 'a';
            word[i++] = 'a';
            word[i++] = 'a';
            word[i++] = '\\';
            word[i++] = '"';
            word[i++] = 'a';
            word[i++] = 'a';
            word[i++] = 'a';
            word[i++] = '"';
            word[i++] = (char)0;
            Day8.CountWord(word, out literal, out memory, out encoded);
            Assert.AreEqual(10, literal);
            Assert.AreEqual(7, memory);
            Assert.AreEqual(16, encoded);

            i = 0;
            word[i++] = '"';
            word[i++] = '\\';
            word[i++] = 'x';
            word[i++] = '2';
            word[i++] = '7';
            word[i++] = '"';
            word[i++] = (char)0;
            Day8.CountWord(word, out literal, out memory, out encoded);
            Assert.AreEqual(6, literal);
            Assert.AreEqual(1, memory);
            Assert.AreEqual(11, encoded);

            i = 0;
            word[i++] = '"';
            word[i++] = '\\';
            word[i++] = '\\';
            word[i++] = '2';
            word[i++] = '7';
            word[i++] = '"';
            word[i++] = (char)0;
            Day8.CountWord(word, out literal, out memory, out encoded);
            Assert.AreEqual(6, literal);
            Assert.AreEqual(3, memory);
            Assert.AreEqual(12, encoded);
        }
    }
}
