namespace OnlyOtp.Storage
{
    public interface IOtpStorage
    {
        /// <summary>
        /// Puts an OTP into storage and returns OtpVerificationToken, which will be used to retrieve token later.
        /// </summary>
        /// <param name="otp"></param>
        /// <returns></returns>
        string PutOtp(string otp);
        string GetOtp(string otpVerificationToken);
    }
}