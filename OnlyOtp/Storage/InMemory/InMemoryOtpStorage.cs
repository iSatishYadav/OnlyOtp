using System;
using System.Collections.Concurrent;

namespace OnlyOtp.Storage.InMemory
{
    public class InMemoryOtpStorage : IOtpStorage
    {
        private static readonly ConcurrentDictionary<Guid, string> _otpStorage = new ConcurrentDictionary<Guid, string>();
        public string PutOtp(string otp)
        {
            otp = otp?.Trim();
            if (string.IsNullOrEmpty(otp))
            {
                throw new ArgumentException();
            }

            var token = Guid.NewGuid();
            if (_otpStorage.TryAdd(token, otp))
            {
                return token.ToString();
            }
            else
            {
                return null;
            }
        }

        public string GetOtp(string otpVerificationToken)
        {
            otpVerificationToken = otpVerificationToken?.Trim();
            if (string.IsNullOrEmpty(otpVerificationToken))
            {
                throw new ArgumentException();
            }

            if (!Guid.TryParse(otpVerificationToken, out Guid token))
            {
                //throw new ArgumentException($"Invalid {nameof(otpVerificationToken)}");
                return null;
            }
            if (!_otpStorage.TryGetValue(token, out string otp))
            {
                //throw new ArgumentException($"No OTP found corresponding to {otpVerificationToken}", nameof(otpVerificationToken));
                return null;
            }
            return otp;
        }

    }
}
