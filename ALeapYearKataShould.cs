
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace TotallyAwesomeLeapYearKata
{
    [TestFixture]
    public class ALeapYearKataShould
    {
        [TestCase(1996, "true")]
        [TestCase(2001, "false")]
        [TestCase(1900, "false")]
        [TestCase(2000, "true")]
        [TestCase(1600, "true")]
        [TestCase(1700, "false")]
        [TestCase(2400, "true")]

        public void ReturnTrueForLeapYears(int year, string expected)
        {
            var leapYear = new LeapYear();
            var result = leapYear.ReturnTypeOfYear(year);
            Assert.That(result, Is.EqualTo(expected));
        }

    }

    public class LeapYear
    {
        public string ReturnTypeOfYear(int year)
        {
            if (year % 4 == 0 && year % 100 != 0)
            {
                return "true";
            }
            if(year % 4 == 0 && year % 400 == 0)
            {
                return "true";
            }
            else
            {
                return "false";
            }
            
        }
    }
}
