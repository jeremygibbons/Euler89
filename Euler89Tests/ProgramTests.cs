using Microsoft.VisualStudio.TestTools.UnitTesting;
using Euler89;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler89.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void RomanStringToIntTest2015()
        {
            int actual = Program.RomanStringToInt("MMXV");
            int expected = 2015;

            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod()]
        public void RomanStringToIntTestMAppearsLate()
        {
            int actual = Program.RomanStringToInt("MMXVM");
            int expected = -1;

            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod()]
        public void IntToRoman_SingleDigit5()
        {
            string actual = Program.IntToRoman(5);
            string expected = "V";

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod()]
        public void IntToRoman_SingleDigit4()
        {
            string actual = Program.IntToRoman(4);
            string expected = "IV";

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod()]
        public void IntToRoman_SingleDigit9()
        {
            string actual = Program.IntToRoman(9);
            string expected = "IX";

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod()]
        public void IntToRoman_SingleDigit3()
        {
            string actual = Program.IntToRoman(3);
            string expected = "III";

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod()]
        public void IntToRoman_DoubleDigit10()
        {
            string actual = Program.IntToRoman(10);
            string expected = "X";

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod()]
        public void IntToRoman_DoubleDigit27()
        {
            string actual = Program.IntToRoman(27);
            string expected = "XXVII";

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod()]
        public void IntToRoman_FourDigit1938()
        {
            string actual = Program.IntToRoman(1938);
            string expected = "MCMXXXVIII";

            Assert.AreEqual<string>(expected, actual);
        }
    }
}