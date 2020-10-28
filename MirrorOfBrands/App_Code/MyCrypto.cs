using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for MyCrypto
/// </summary>
namespace MirrorOfBrands
{
    public static class Crypto
    {
        private static string Key = "F4F951354F5A494A";

        public static object Symmetric { get; private set; }

        private static byte[] GetByte(string data)
        {
            return Encoding.UTF8.GetBytes(data); 
        }

        public static byte[] EncryptString(string data)
        {
            byte[] byteData = GetByte(data);
            SymmetricAlgorithm algo = SymmetricAlgorithm.Create();
            algo.Key = GetByte(Key);
            algo.GenerateIV();

            MemoryStream mStream = new MemoryStream();
            mStream.Write(algo.IV, 0, algo.IV.Length);

            CryptoStream myCrypto = new CryptoStream(mStream, algo.CreateEncryptor(), CryptoStreamMode.Write);
            myCrypto.Write(byteData, 0, byteData.Length);
            myCrypto.FlushFinalBlock();

            return mStream.ToArray();
        }

        public static string DecryptString(byte[] data)
        {
            SymmetricAlgorithm algo = SymmetricAlgorithm.Create();
            algo.Key = GetByte(Key);
            MemoryStream mStream = new MemoryStream();

            byte[] byteData = new byte[algo.IV.Length];
            Array.Copy(data, byteData, byteData.Length);
            algo.IV = byteData;
            int readFrom = 0;
            readFrom += algo.IV.Length;

            CryptoStream myCrypto = new CryptoStream(mStream, algo.CreateDecryptor(), CryptoStreamMode.Write);
            myCrypto.Write(data, readFrom, data.Length - readFrom);
            myCrypto.FlushFinalBlock();

            return Encoding.UTF8.GetString(mStream.ToArray());
        }

        public static string GetencryptedQueryString(string data)
        {
            Console.WriteLine(data);
            return Convert.ToBase64String(EncryptString(data));
        }

        public static string GetdecryptQueryString(string data)
        {
            byte[] byteData = null;
            try
            {
                byteData = Convert.FromBase64String(data.Replace(" ", "+"));
            }
            catch(Exception)
            {
                byteData = null;
                HttpContext.Current.Server.Transfer("Error.aspx", true);
            }
            return DecryptString(byteData);
        }
    }
}