using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace REZReport.Core.Helpers
{
    public class CryptoUtils
    {
        private const CipherMode cipherMode = CipherMode.CBC;
        private const PaddingMode paddingMode = PaddingMode.ISO10126;
        private const string defaultVector = "fdsah12345678901";
        private const int iterations = 2;
        private const string saltKey = "ym2+FhS5WHVL0t6pifBVo0OSKd0=";
        private const string siteKey = "AAECAwQFBgcICQoLDA0ODw==";

        public static string CreateSalt()
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[20];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }
        public static string Encrypt(string toEncrypt)
        {
            string securityKey = siteKey;
            var key = securityKey;
            var keyArray = Encoding.UTF8.GetBytes(key);

            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var cTransform = tdes.CreateEncryptor();
            var toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string cipherString)
        {
            string securityKey = siteKey;
            var key = securityKey;
            var keyArray = Encoding.UTF8.GetBytes(key);

            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var cTransform = tdes.CreateDecryptor();
            var toEncryptArray = Convert.FromBase64String(cipherString);
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Encoding.UTF8.GetString(resultArray);
        }
        //public static string Encrypt(string plainText)
        //{
        //    byte[] clearData = Encoding.Unicode.GetBytes(plainText);
        //    byte[] encryptedData;
        //    var crypt = GetCrypto(saltKey);
        //    using (var ms = new MemoryStream())
        //    {
        //        using (var cs = new CryptoStream(ms, crypt.CreateEncryptor(), CryptoStreamMode.Write))
        //        {
        //            cs.Write(clearData, 0, clearData.Length);
        //            //cs.FlushFinalBlock(); //Have tried this active and commented with no change.
        //        }
        //        encryptedData = ms.ToArray();
        //    }
        //    //Changed per Xint0's answer.
        //    return Convert.ToBase64String(encryptedData);
        //}

        //public static string Decrypt(string cipherText)
        //{
        //    //Changed per Xint0's answer.
        //    if (!String.IsNullOrEmpty(cipherText))
        //    {
        //        byte[] encryptedData = Convert.FromBase64String(cipherText);
        //        byte[] clearData;
        //        var crypt = GetCrypto(saltKey);
        //        using (var ms = new MemoryStream())
        //        {
        //            using (var cs = new CryptoStream(ms, crypt.CreateDecryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(encryptedData, 0, encryptedData.Length);
        //                //I have tried adding a cs.FlushFinalBlock(); here as well.
        //            }
        //            clearData = ms.ToArray();
        //        }
        //        return Encoding.Unicode.GetString(clearData);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        private static Rijndael GetCrypto(string passphrase)
        {
            var crypt = Rijndael.Create();
            crypt.Mode = cipherMode;
            crypt.Padding = paddingMode;
            crypt.BlockSize = 128;
            crypt.KeySize = 128;
            crypt.Key =
                new Rfc2898DeriveBytes(passphrase, Encoding.Unicode.GetBytes(defaultVector), iterations).GetBytes(32);
            crypt.IV = new Rfc2898DeriveBytes(passphrase, Encoding.Unicode.GetBytes(defaultVector), iterations).GetBytes(32);
            return crypt;
        }
    }
}
