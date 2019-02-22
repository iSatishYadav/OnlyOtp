using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyOtp
{
    interface IOtp
    {
        string GenerateOtp(int length);        
        (string Otp, string OtpVerificationToken) GenerateAndStoreOtp(int length);
        bool IsOtpMached(string otpUnderTest, string OtpVerificationToken);        
    }
}
