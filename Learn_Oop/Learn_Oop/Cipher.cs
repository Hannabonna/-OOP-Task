using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Learn_Oop
{
    public class Cipher
    {
        public static string Encrypt(string data, string pass)
        {
            string a = data;
            byte[] bytes = Encoding.UTF8.GetBytes(a);
            string Code = pass;
            MD5CryptoServiceProvider mdhash = new MD5CryptoServiceProvider();
            byte[] keyarray = mdhash.ComputeHash(Encoding.UTF8.GetBytes(Code));
            TripleDESCryptoServiceProvider tds = new TripleDESCryptoServiceProvider();
            tds.Key = keyarray;
            tds.Mode = CipherMode.ECB;
            tds.Padding = PaddingMode.PKCS7;
            ICryptoTransform itransform = tds.CreateEncryptor();
            byte[] result = itransform.TransformFinalBlock(bytes, 0, bytes.Length);
            string encryptresult = Convert.ToBase64String(result);
            return encryptresult;
        }

        public static string Decrypt(string data, string pass)
        {
            string y = data.Replace("\0", null);
            byte[] text = Convert.FromBase64String(y);
            string key = pass;
            MD5CryptoServiceProvider mdhash = new MD5CryptoServiceProvider();
            byte[] keyarray = mdhash.ComputeHash(Encoding.UTF8.GetBytes(key));
            TripleDESCryptoServiceProvider tds = new TripleDESCryptoServiceProvider();
            tds.Key = keyarray;
            tds.Mode = CipherMode.ECB;
            tds.Padding = PaddingMode.PKCS7;

            ICryptoTransform itransform = tds.CreateDecryptor();
            byte[] result = itransform.TransformFinalBlock(text, 0, text.Length);
            string dencryptresult = Encoding.UTF8.GetString(result);
            return dencryptresult;

        }
    }
}
