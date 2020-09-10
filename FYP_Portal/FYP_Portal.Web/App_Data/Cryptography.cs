using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Cryptography
/// </summary>
public static class Cryptography
{
    //private static string Key = "ABC123DEF456GH78";//"ABC123DEF456G+/=";
    //private static string hash = "f0xle@rn";//Create a hash key
    //private static string key = "sblw-3hn8-sqoy19";//Create a hash key
    private static string key = "b14ca5898a4e4133bbce2ea2315a1916";

    private static byte[] Getbyte(string data)
    {
        return Encoding.UTF8.GetBytes(data);
    }

    //public static string EncryptString(string dataToEncypt)
    //{
    //    //byte[] byteData = Getbyte(data);
    //    //SymmetricAlgorithm algo = SymmetricAlgorithm.Create();
    //    //algo.Key = Getbyte(Key);
    //    //algo.GenerateIV();

    //    //MemoryStream ms = new MemoryStream();
    //    //ms.Write(algo.IV, 0, algo.IV.Length);

    //    //CryptoStream cs = new CryptoStream(ms,algo.CreateEncryptor(), CryptoStreamMode.Write);
    //    //cs.Write(byteData, 0, byteData.Length);
    //    //cs.FlushFinalBlock();

    //    //return ms.ToArray();
    //}

    //public static string DecryptString(byte[] data)
    //{

    //    //SymmetricAlgorithm algo = SymmetricAlgorithm.Create();
    //    //algo.Key = Getbyte(Key);
    //    //     MemoryStream ms = new MemoryStream();

    //    //byte[] byteData = new byte[algo.IV.Length];
    //    //Array.Copy(data, byteData, byteData.Length);
    //    //algo.IV = byteData;

    //    //int readFrom = 0;
    //    //readFrom += algo.IV.Length;

    //    //CryptoStream cs = new CryptoStream(ms, algo.CreateDecryptor(), CryptoStreamMode.Write);
    //    //cs.Write(data, readFrom, data.Length - readFrom);
    //    //cs.FlushFinalBlock();

    //    //return Encoding.UTF8.GetString(ms.ToArray());

    //}

    //public static string GetEncryptedQueryString(string dataToEncypt)
    //{
    //    byte[] data = UTF8Encoding.UTF8.GetBytes(dataToEncypt);
    //    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
    //    {
    //        byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));//Get hash key
    //                                                                        //Encrypt data by hash key
    //        using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
    //        {
    //            ICryptoTransform transform = tripDes.CreateEncryptor();
    //            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
    //            return Convert.ToBase64String(results, 0, results.Length);
    //        }
    //    }

    //}

    //public static string GetDecryptedQueryString(string dataToDecrypt)
    //{
    //    //byte[] byteData = Convert.FromBase64String(data.Replace(" ", "+"));
    //    ////byte[] byteData = Convert.FromBase64String(data);
    //    //return DecryptString(byteData);

    //    //Convert a string to byte array
    //    byte[] data = Convert.FromBase64String(dataToDecrypt);
    //    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
    //    {
    //        byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));//Get hash key
    //                                                                        //Decrypt data by hash key
    //        using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
    //        {
    //            ICryptoTransform transform = tripDes.CreateDecryptor();
    //            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
    //            return UTF8Encoding.UTF8.GetString(results);
    //        }
    //    }
    //}


    //    public static string GetEncryptedQueryString(string input)
    //    {
    //        byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
    //        TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
    //        tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
    //        tripleDES.Mode = CipherMode.ECB;
    //        tripleDES.Padding = PaddingMode.PKCS7;
    //        ICryptoTransform cTransform = tripleDES.CreateEncryptor();
    //        byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
    //        tripleDES.Clear();
    //        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    //    }
    //    public static string GetDecryptedQueryString(string input)
    //    {
    //        byte[] inputArray = Convert.FromBase64String(input);
    //        TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
    //        tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
    //        tripleDES.Mode = CipherMode.ECB;
    //        tripleDES.Padding = PaddingMode.PKCS7;
    //        ICryptoTransform cTransform = tripleDES.CreateDecryptor();
    //        byte[] resultArray = cTransform.Transform
    //FinalBlock(inputArray, 0, inputArray.Length);
    //        tripleDES.Clear();
    //        return UTF8Encoding.UTF8.GetString(resultArray);
    //    }

    public static string GetEncryptedQueryString(string plainText)
    {
        byte[] iv = new byte[16];
        byte[] array;

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                    {
                        streamWriter.Write(plainText);
                    }

                    array = memoryStream.ToArray();
                }
            }
        }

        return Convert.ToBase64String(array);
    }

    public static string GetDecryptedQueryString(string cipherText)
    {
        if (cipherText.Count(Char.IsWhiteSpace) <= 3)
        {
            if (cipherText.Contains(" "))
            {
                cipherText = cipherText.Replace(" ", "+");
            }
        }
        byte[] iv = new byte[16];
        if (cipherText.Contains("#"))
        {
            int place = cipherText.LastIndexOf('#');
            cipherText.Substring(0, place);
        }

            byte[] buffer = Convert.FromBase64String(cipherText);

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }

            
        }
    }
}
