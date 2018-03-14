using System;
using System.Security.Cryptography;

namespace Schedule.IntIta.DataAccess.Addons
{
    public class Crypto
    {
        private readonly RijndaelManaged _myRijndael = new RijndaelManaged();
        private readonly int _iterations;
        private readonly byte[] _salt;

        public Crypto(string strPassword, string specString, string saltString)
        {
            _myRijndael.BlockSize = 128;
            _myRijndael.KeySize = 128;
            _myRijndael.IV = HexStringToByteArray(specString);
            _myRijndael.Padding = PaddingMode.PKCS7;
            _myRijndael.Mode = CipherMode.CBC;
            _iterations = 1000;
            _salt = System.Text.Encoding.UTF8.GetBytes(saltString);
            _myRijndael.Key = GenerateKey(strPassword);
        }

        public string Encrypt(string strPlainText)
        {
            byte[] strText = new System.Text.UTF8Encoding().GetBytes(strPlainText);
            ICryptoTransform transform = _myRijndael.CreateEncryptor();
            byte[] cipherText = transform.TransformFinalBlock(strText, 0, strText.Length);
            return Convert.ToBase64String(cipherText);
        }

        public string Decrypt(string encryptedText)
        {
            dynamic encryptedBytes = Convert.FromBase64String(encryptedText);
            ICryptoTransform transform = _myRijndael.CreateDecryptor();
            byte[] cipherText = transform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            return System.Text.Encoding.UTF8.GetString(cipherText);
        }

        public static byte[] HexStringToByteArray(string strHex)
        {
            byte[] r = new byte[strHex.Length / 2];

            for (int i = 0; i <= strHex.Length - 1; i += 2)
                r[i / 2] = Convert.ToByte(Convert.ToInt32(strHex.Substring(i, 2), 16));

            return r;
        }

        private byte[] GenerateKey(string strPassword)
        {
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(System.Text.Encoding.UTF8.GetBytes(strPassword), _salt, _iterations);
            return rfc2898.GetBytes(128 / 8);
        }

        public static string RandomString(int length)
        {
            const string chars = "abcdef0123456789";
            Random random = new Random();
            string result = string.Empty;

            while (result.Length < length)
                result += chars[random.Next(chars.Length)];

            return result;
        }
    }
}