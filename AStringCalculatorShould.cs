using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace RealDealStringCalculator
{
    [TestFixture]
    public class AStringCalculatorShould
    {
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        [TestCase("3,1", 4)]
        [TestCase("2,2", 4)]
        [TestCase("5,4", 9)]
        [TestCase("4,4,4", 12)]


        public void AddNumbersInAStringTogther(string number, int expected)
        {
            var stringCalculator = new StringCalculator();
            int result = stringCalculator.Add(number);
            Assert.That(result, Is.EqualTo(expected));
        }
    }

    public class StringCalculator
    {
        public int Add(string number)
        {
            if (number.Length == 1)
            {
                return int.Parse(number);
            }
            else
            {
                int[] numbersArray = number.Split(',').Select(int.Parse).ToArray();

                int arrayResult = numbersArray.Sum();

                return arrayResult;
            }
        }
    }
}
