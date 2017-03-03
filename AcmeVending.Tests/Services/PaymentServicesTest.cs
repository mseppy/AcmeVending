using AcmeVending.Domain;
using AcmeVending.Domain.Interfaces;
using AcmeVending.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcmeVending.Tests.Services
{
    [TestClass]
    public class PaymentServicesTest
    {
        IPaymentService classUnderTest = new PaymentService();


        [TestMethod]
        public void SubmitCredit_NullCCNumber_InvalidCCNumber()
        {
            var price = 1M;
            var credit = new CreditCard();


            var result = classUnderTest.SubmitCreditPayment(credit, price);

            Assert.IsNotNull(result);
            Assert.AreEqual("INVALID", result.Message);
        }

        [TestMethod]
        public void SubmitCredit_ShortCCNumber_InvalidCCNumber()
        {
            var price = 1M;
            var credit = new CreditCard
            {
                CardNumber = "1234"
            };


            var result = classUnderTest.SubmitCreditPayment(credit, price);

            Assert.IsNotNull(result);
            Assert.AreEqual("INVALID", result.Message);
        }
    }
}
