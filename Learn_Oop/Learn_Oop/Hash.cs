using System;
using System.Security.Cryptography;
using System.Text;

namespace Learn_Oop
{
    class Hash
    {
        public static void Md5(string data)
        {
            StringBuilder md5 = new StringBuilder();
            MD5CryptoServiceProvider prov = new MD5CryptoServiceProvider();
            byte[] var = prov.ComputeHash(new UTF8Encoding().GetBytes(data));

            for (int i=0; i<var.Length; i++)
            {
                md5.Append(var[i].ToString("x2"));
            }
            Console.WriteLine(md5);
        }

        public static void Sha1(string data)
        {
            StringBuilder sha1 = new StringBuilder();
            SHA1CryptoServiceProvider prov = new SHA1CryptoServiceProvider();
            byte[] var = prov.ComputeHash(new UTF8Encoding().GetBytes(data));

            for (int i = 0; i < var.Length; i++)
            {
                sha1.Append(var[i].ToString("x2"));
            }
            Console.WriteLine(sha1);
        }

        public static void Sha256(string data)
        {
            StringBuilder sha256 = new StringBuilder();
            SHA256CryptoServiceProvider prov = new SHA256CryptoServiceProvider();
            byte[] var = prov.ComputeHash(new UTF8Encoding().GetBytes(data));

            for (int i = 0; i < var.Length; i++)
            {
                sha256.Append(var[i].ToString("x2"));
            }
            Console.WriteLine(sha256);
        }

        public static void Sha512(string data)
        {
            StringBuilder sha512 = new StringBuilder();
            SHA512CryptoServiceProvider prov = new SHA512CryptoServiceProvider();
            byte[] var = prov.ComputeHash(new UTF8Encoding().GetBytes(data));

            for (int i = 0; i < var.Length; i++)
            {
                sha512.Append(var[i].ToString("x2"));
            }
            Console.WriteLine(sha512);
        }
    }
}
