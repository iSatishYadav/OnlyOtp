using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace OnlyOtp.Tests
{
    [TestClass]
    public class OtpTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OtpStorageShouldNotBeNull()
        {
            var otp = new Otp(null);
        }
        [TestMethod]
        public void GenerateOtp_Should_Return6DigitNumericOtp_When_NoOptionsArePassed()
        {
            var otp = new Otp();
            string testOtp = otp.GenerateOtp();
            foreach (var test in testOtp.ToCharArray())
            {
                Assert.IsTrue(char.IsDigit(test));
            }
        }

        [TestMethod]
        public void GenerateOtp_Should_ReturnNumbers_When_NumberOptionIsPassed()
        {
            var number = new Random().Next(1, 100);

            var otp = new Otp();
            string testOtp = otp.GenerateOtp(new OtpOptions { Length = number, OtpContents = OtpContents.Number, ShouldBeCryptographicallyStrong = false });
            Assert.AreEqual(number, testOtp.Length);
            foreach (var test in testOtp.ToCharArray())
            {
                Assert.IsTrue(char.IsDigit(test));
            }
        }
        [TestMethod]
        public void GenerateAndStoreOtp_Should_Return6DigitNumericOtpAndNotNullToken_When_NoOptionsArePassed()
        {
            var otp = new Otp();
            (string testOtp, string token) = otp.GenerateAndStoreOtp();
            Assert.IsNotNull(token);
            foreach (var test in testOtp.ToCharArray())
            {
                Assert.IsTrue(char.IsDigit(test));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsOtpMatched_Should_ThrowArgumentException_WhenOtpIsNull()
        {
            var otp = new Otp().IsOtpMached(null, "sdasfasdf");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsOtpMatched_Should_ThrowArgumentException_WhenOtpIsEmpty()
        {
            var otp = new Otp().IsOtpMached(string.Empty, "sdasfasdf");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsOtpMatched_Should_ThrowArgumentException_WhenOtpIsWhitespaces()
        {
            var otp = new Otp().IsOtpMached("    ", "sdasfasdf");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsOtpMatched_Should_ThrowArgumentException_WhenOtpVerificationTokenIsNull()
        {
            var otp = new Otp().IsOtpMached("asdfasfd", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsOtpMatched_Should_ThrowArgumentException_WhenOtpVerificationTokenIsEmpty()
        {
            var otp = new Otp().IsOtpMached("asdfasfd", string.Empty);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsOtpMatched_Should_ThrowArgumentException_WhenOtpVerificationTokenIsWhitespaces()
        {
            var otp = new Otp().IsOtpMached("asdfasdf", "  ");
        }

        [TestMethod]
        public void GenerateStoreAndMatching_Should_BeSuccessfull_WhenDefaultOptionsArePassed()
        {
            var otpProvider = new Otp();
            (string otp, string token ) = otpProvider.GenerateAndStoreOtp();
            Assert.IsTrue(otpProvider.IsOtpMached(otp, token));
        }

        [TestMethod]
        public void GenerateStoreAndMatching_Should_BeSuccessfull_WhenRandomLengthWithCryptoCheckedArePassed()
        {
            var length = new Random().Next(1, 100);
            var otpProvider = new Otp();            
            (string otp, string token) = otpProvider.GenerateAndStoreOtp(new OtpOptions { Length = length, ShouldBeCryptographicallyStrong = true });
            foreach (var test in otp.ToCharArray())
            {
                Assert.IsTrue(char.IsDigit(test));
            }
            Assert.IsTrue(otpProvider.IsOtpMached(otp, token));
        }
    }
}
