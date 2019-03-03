using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyOtp
{
    interface IOtp
    {
        string GenerateOtp();
        string GenerateOtp(OtpOptions otpOptions);        
        (string Otp, string OtpVerificationToken) GenerateAndStoreOtp();
        (string Otp, string OtpVerificationToken) GenerateAndStoreOtp(OtpOptions otpOptions);
        bool IsOtpMached(string otpUnderTest, string OtpVerificationToken);        
    }
}
