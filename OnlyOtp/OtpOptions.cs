using System;

namespace OnlyOtp
{
    public class OtpOptions
    {
        private OtpContents otpContents;
        public int Length { get; set; }
        public bool ShouldBeCryptographicallyStrong { get; set; }
        public OtpContents OtpContents
        {
            get
            {
                return otpContents;
            }

            set
            {
                if (value.HasFlag(OtpContents.Alphabets) || value.HasFlag(OtpContents.SpecialCharacters))
                {
                    throw new NotImplementedException();
                }
                otpContents = value;
            }
        }

        public const int DefaultOtpLength = 6;
        public const bool DefaultCryptographicOption = false;
        public const OtpContents DefaultOtpContents = OtpContents.Number;
    }
}
