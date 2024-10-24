using System.Text;
using System.Security.Cryptography;

// credit: https://medium.com/@chris.mckee/how-to-match-hmacsha256-between-c-python-f7b42d01cbf5
public static class Hasher 
{
  public static string HmacSHA256(string data)
  {
      string hash;
      ASCIIEncoding encoder = new ASCIIEncoding();
      Byte[] code = encoder.GetBytes("justanarbitrarysecretkey");
      using (HMACSHA256 hmac = new HMACSHA256(code))
      {
          Byte[] hmBytes = hmac.ComputeHash(encoder.GetBytes(data));
          hash = ToHexString(hmBytes);
      }
      return hash;
  }
  public static string ToHexString(byte[] array)
  {
      StringBuilder hex = new StringBuilder(array.Length * 2);
      foreach (byte b in array)
      {
          hex.AppendFormat("{0:x2}", b);
      }
      return hex.ToString();
  }
}
