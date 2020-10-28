using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HashMAC
/// </summary>
public class HashMAC
{
    public static string CreateTamperProofQryStringURL(string Page)
    {
        string strpage = Page.Remove(0, 2);

        try
        {
            return string.Concat(Page + "&Digest=", GetDigest(strpage));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static bool EnsureURLNotTampered(string Url, string tamperProofParams)
    {
        try
        {
            string expectedDigest = GetDigest(Url);
            string receivedDigest = tamperProofParams;

            if(receivedDigest == null)
            {
                return false;
            }
            else
            {
                receivedDigest = receivedDigest.Replace(" ", "+");
                if (string.Compare(expectedDigest, receivedDigest) != 0)
                {
                    return false;
                }
                else
                    return true;
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    public static string GetDigest(string tampeProofParams)
    {
        try
        {
            string SecretSalt = "F4F951354F5A494A";
            string Digest = string.Empty;
            string input = string.Concat(SecretSalt, tampeProofParams, SecretSalt);
            byte[] hashedDataBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            hashedDataBytes = md5Hasher.ComputeHash(encoder.GetBytes(input));
            Digest = Convert.ToBase64String(hashedDataBytes).TrimEnd("=".ToCharArray());
            return Digest;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}