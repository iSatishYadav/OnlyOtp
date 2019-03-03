using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyOtp.Tests
{
    [TestClass]    
    public class OtpOptionsTest
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void OtpContents_Should_OnlyBeRetricted_ToAlphabetsAsOfNow()
        {
            var otpOptions1 = new OtpOptions { OtpContents = OtpContents.Alphabets };
            var otpOptions2 = new OtpOptions { OtpContents = OtpContents.SpecialCharacters};            
        }
    }
}
