using OnlyOtp.Storage;
using System;

namespace OnlyOtp
{
    public class Otp : IOtp
    {
        private readonly IOtpStorage _otpStorage;
        public Otp(IOtpStorage otpStorage)
        {
            otpStorage = _otpStorage;
        }

        public string GenerateOtp(int length)
        {
            return GenerateOtpInternal(length);
        }


        public (string Otp, string OtpVerificationToken) GenerateAndStoreOtp(int length)
        {
            //TODO: Generate an OTP.
            var otp = GenerateOtpInternal(length);

            //TODO: Store with OtpVerificationToken
            return (null, null);
        }

        public bool IsOtpMached(string otpUnderTest, string otpVerificationToken)
        {
            otpUnderTest = otpUnderTest?.Trim();
            otpVerificationToken = otpVerificationToken?.Trim();
            if (string.IsNullOrEmpty(otpUnderTest))
            {
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(otpVerificationToken))
            {
                throw new ArgumentException();
            }

            return otpUnderTest.Equals(_otpStorage.GetOtp(otpVerificationToken));
        }

        private string GenerateOtpInternal(int length)
        {
            throw new NotImplementedException();
        }        
    }
}
