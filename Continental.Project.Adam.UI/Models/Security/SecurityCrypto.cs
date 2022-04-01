using System;
using System.Security.Cryptography;
using System.Text;

namespace Continental.Project.Adam.UI.Models.Security
{
    public class SecurityCrypto
    {
        //'Code Crypt Class
        string myKey = "Adam";
        TripleDESCryptoServiceProvider _descrypto = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider _hashmd5 = new MD5CryptoServiceProvider();

        public string clsCrypt(string value, bool operation)
        {
            if (operation)
                return Crypt(value);
            else
                return Decrypt(value);
        }

        public string Decrypt(string value)
        {
            _descrypto.Key = _hashmd5.ComputeHash(Encoding.ASCII.GetBytes(myKey));
            _descrypto.Mode = CipherMode.ECB;
            ICryptoTransform dcrypt = _descrypto.CreateDecryptor();
            byte[] buff = Convert.FromBase64String(value);

            return ASCIIEncoding.ASCII.GetString(dcrypt.TransformFinalBlock(buff, 0, buff.Length));
        }

        public string Crypt(string value)
        {
            _descrypto.Key = _hashmd5.ComputeHash(Encoding.ASCII.GetBytes(myKey));
            _descrypto.Mode = CipherMode.ECB;
            ICryptoTransform dcrypt = _descrypto.CreateEncryptor();
            byte[] buff = ASCIIEncoding.ASCII.GetBytes(value);

            return Convert.ToBase64String(dcrypt.TransformFinalBlock(buff, 0, buff.Length));
        }
    }
}
