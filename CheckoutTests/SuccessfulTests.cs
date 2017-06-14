using System;
using CheckoutTests.CheckoutService;
using NUnit.Framework;

namespace CheckoutTests
{
    [TestFixture]
    public class SuccessfulTests
    {
        [Test]
        [TestCase("AAA")]
        [TestCase("BBB")]
        [TestCase("CCC")]
        [TestCase("DDD")]
        public void TestScan(string scanValues)
        {
            try
            {
                var proxy = new CheckoutClient();

                proxy.Scan(scanValues);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Test]
        public void TestGetTotalPrice()
        {
            try
            {
                var proxy = new CheckoutClient();

                var result = proxy.GetTotalPrice();

                if (result != 0)
                {
                    throw new Exception("GetTotalPrice Does Not Return 0");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Test]
        [TestCase("A", 50)]
        [TestCase("AA", 100)]
        [TestCase("AAA", 130)]
        [TestCase("AAAA", 180)]
        [TestCase("AAAAA", 230)]
        [TestCase("AAAAAA", 260)]
        [TestCase("B", 30)]
        [TestCase("BB", 45)]
        [TestCase("BBB", 75)]
        [TestCase("BBBB", 90)]
        [TestCase("BBBBB", 120)]
        [TestCase("C", 20)]
        [TestCase("CC", 40)]
        [TestCase("CCC", 60)]
        [TestCase("D", 15)]
        [TestCase("DD", 30)]
        [TestCase("DDD", 45)]
        public void TestCalculateSingleSKUTotalPrice(string scanValues, int expectedResult)
        {
            try
            {
                var proxy = new CheckoutClient();

                proxy.Scan(scanValues);

                var result = proxy.GetTotalPrice();

                if (result != expectedResult)
                {
                    var error = string.Format(
                        "For the input of {0}, the expected the value of {1} should be returned. Returned values from the service was {2}", scanValues, expectedResult, result);

                    throw new Exception(error);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Test]
        [TestCase("AB", 80)]
        [TestCase("AAB", 130)]
        [TestCase("AAAB", 160)]
        [TestCase("AC", 70)]
        [TestCase("AAAC", 150)]
        [TestCase("AD", 65)]
        [TestCase("AAAD", 145)]
        [TestCase("BBC", 65)]
        [TestCase("BBD", 60)]
        [TestCase("CD", 35)]
        [TestCase("ABABA", 175)]
        [TestCase("CABCBDA", 195)]
        [TestCase("DDABACAD", 225)]
        public void TestCalculateMixedSKUTotalPrice(string scanValues, int expectedResult)
        {
            try
            {
                var proxy = new CheckoutClient();

                proxy.Scan(scanValues);

                var result = proxy.GetTotalPrice();

                if (result != expectedResult)
                {
                    var error = string.Format(
                        "For the input of {0}, the expected the value of {1} should be returned. Returned values from the service was {2}", scanValues, expectedResult, result);

                    throw new Exception(error);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
