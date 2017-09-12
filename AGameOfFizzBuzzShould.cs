using NUnit.Framework;

namespace BestFizzBuzzLikeEver
{
    [TestFixture]
    public class AGameOfFizzBuzzShould
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void ReturnsANumber(int expected)
        {
            var fizzBuzzGame = new NumberGame();
            var result = fizzBuzzGame.number(expected);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "Fizz")]
        [TestCase(4, "4")]
        [TestCase(5, "5")]
        [TestCase(6, "Fizz")]

        public void returnsFizzForMultipleOfThree(int number, string expected)
        {
            var fizzBuzzGame = new FizzGame();
            var result = fizzBuzzGame.fizz(number);
            Assert.That(result, Is.EqualTo(expected));
            }

        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "Fizz")]
        [TestCase(4, "4")]
        [TestCase(5, "Buzz")]
        [TestCase(6, "Fizz")]
        [TestCase(7, "7")]
        [TestCase(8, "8")]
        [TestCase(9, "Fizz")]
        [TestCase(10, "Buzz")]
        public void ReturnsFizzForMultiplesOfThreeAndBuzzForMultiplesOfFive(int number, string expected)
        {
            var fizzBuzzGame = new BuzzGame();
            var result = fizzBuzzGame.Fizz(number);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "FizzBuzz")]
        [TestCase(4, "4")]
        [TestCase(5, "FizzBuzz")]
        public void ReturnsFizzBuzzForMulitplesofThreeAndFive(int number, string expected)
        {
            var fizzBuzzGame = new fizzBuzzGame();
            var result = fizzBuzzGame.fizzBuzz(number);
            Assert.That(result, Is.EqualTo(expected));
        }



    }

    public class fizzBuzzGame
    {
        public string fizzBuzz(int number)
        {
            if (number % 3 == 0 || number % 5 == 0)
            {
                return "FizzBuzz";
            }
            else
            {
                return (number.ToString());
            }
        }
    }

    public class BuzzGame
    {
        public string Fizz(int number)
        {
            if (number % 3 == 0)
            {
                return "Fizz";
            }
            else if (number % 5 == 0)
            {
                return "Buzz";
            }
            else
            {
                return number.ToString();
            }
        }
    }

    public class NumberGame
    {
        public int number(int number)
        {
            for (int i = 0; i < 5; number++)
            {
                return number;
            }
            return 5;
        }
        }
    public class FizzGame
    {
        public string fizz(int number)
        {
            if (number % 3 == 0)
            {
                return "Fizz";
            }
            else 
            {
                return number.ToString();
            }
            return "bluh";
        }
    }
}
