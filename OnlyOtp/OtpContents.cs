using System;

namespace OnlyOtp
{
    [Flags]
    public enum OtpContents
    {
        Number = 0,
        Alphabets = 1,
        SpecialCharacters = 2
    }
}
