using System;
using CheckoutTests.CheckoutService;
using NUnit.Framework;

namespace CheckoutTests
{
    [TestFixture]
    public class UnsuccessfulTests
    {
        [Test]
        [TestCase("AG","G")]
        public void TestCalculateSingleSKUTotalPrice(string scanValues, string invalidValue)
        {
            try
            {
                var proxy = new CheckoutClient();

                proxy.Scan(scanValues);
            }
            catch (Exception e)
            {
                var expectedError = string.Format("The SKU {0} is not a valid value", invalidValue);

                if (e.Message != expectedError)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
