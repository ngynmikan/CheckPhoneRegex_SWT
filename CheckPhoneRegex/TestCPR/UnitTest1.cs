using System.Collections;
using CheckPhoneRegex.Models;
using NUnit.Framework;

namespace CheckPhoneRegex.Tests
{
    [TestFixture]
    public class PhoneNumberTests
    {
        [TestCaseSource(typeof(TestData), "DataTest")]
        public void PhoneNumber_Validations(PhoneNumber phoneNumber, string expectedMessage)
        {
            string actualMessage = PhoneNumber.checkPhoneRegex(phoneNumber);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }

    public static class TestData
    {
        public static IEnumerable DataTest()
        {
            PhoneNumber pn1 = new PhoneNumber("84", "64", "+84123456789");
            yield return new TestCaseData(pn1, pn1.GetNumber() + " is valid phone number");
            PhoneNumber pn2 = new PhoneNumber("84", "76", "084123456789");
            yield return new TestCaseData(pn2, pn2.GetNumber() + " is not valid phone number");
            PhoneNumber pn3 = new PhoneNumber("84", "50", "012345678");
            yield return new TestCaseData(pn3, pn3.GetNumber() + " is not valid phone number");
            PhoneNumber pn4 = new PhoneNumber("84", "77", "0-123456789");
            yield return new TestCaseData(pn4, pn4.GetNumber() + " is not valid phone number");
            PhoneNumber pn5 = new PhoneNumber("84", "36", "0 123 456 789");
            yield return new TestCaseData(pn5, pn5.GetNumber() + " is not valid phone number");
        }
    }
}