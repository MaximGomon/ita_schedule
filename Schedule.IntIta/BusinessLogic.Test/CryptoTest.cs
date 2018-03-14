using System;
using System.Linq;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.DataAccess.Addons;
using Schedule.IntIta.Domain.Models;

namespace BusinessLogic.Test
{
    [TestClass]
    public class CryptoTest
    {
        [TestMethod]
        public void CryptDecryptTest()
        {
            string password = "PDFJSCS";

            Crypto crypto = new Crypto(password, Crypto.RandomString(32), Crypto.RandomString(16));

            string somepass = "boberESTmashu";

            var superSecretPassword = crypto.Encrypt(somepass);
            var returnPass = crypto.Decrypt(superSecretPassword);

            Assert.IsNotNull(returnPass);
            Assert.AreEqual(somepass, returnPass);
        }
    }
}