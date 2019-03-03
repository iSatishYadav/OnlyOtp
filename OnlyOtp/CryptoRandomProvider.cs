using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace OnlyOtp
{
    internal class CryptoRandomProvider : IRandomProvider
    {        
        public string GetRandom(int length, char[] charset)
        {
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                var random = new byte[length];
                rngCsp.GetNonZeroBytes(random);
                int randomNumber = BitConverter.ToInt32(random, 0);
                return randomNumber.ToString();
            }
        }
    }
}
