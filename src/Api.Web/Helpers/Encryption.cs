using Core.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.Helpers
{
    public static class Encryption
    {
        public static string EncryptString(string text)
        {
            var key = Convert.FromBase64String("AAECAwQFBgcICQoLDA0ODw==");
            byte[] IV = Encoding.ASCII.GetBytes("HR$2pIjHR$2pIj12");

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[IV.Length + decryptedContent.Length];

                        Buffer.BlockCopy(IV, 0, result, 0, IV.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, IV.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        public static string DecryptString(string cipherText)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            var key = Convert.FromBase64String("AAECAwQFBgcICQoLDA0ODw==");
            byte[] IV = Encoding.ASCII.GetBytes("HR$2pIjHR$2pIj12");
            var cipher = new byte[fullCipher.Length - IV.Length];

            Buffer.BlockCopy(fullCipher, 0, IV, 0, IV.Length);
            Buffer.BlockCopy(fullCipher, IV.Length, cipher, 0, fullCipher.Length - IV.Length);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, IV))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }
    }
}
