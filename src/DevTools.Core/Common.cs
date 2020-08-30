using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace DevTools
{
    public static class Common
    {
        public static string ConvertRgbToHex(string rStr, string gStr, string bStr)
        {
            if (int.TryParse(rStr, out int r) && int.TryParse(gStr, out int g) && int.TryParse(bStr, out int b))
            {
                if (r >= 0 && r <= 255 && g >= 0 && g <= 255 && b >= 0 && b <= 255)
                {
                    return r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public static string JsonPathTest(string document, string jsonPathExpression)
        {
            if (string.IsNullOrEmpty(document)) return "Json document is empty";
            if (string.IsNullOrEmpty(jsonPathExpression)) return "JsonPath expression is empty";

            JObject sourceJson;

            try
            {
                sourceJson = JObject.Parse(document);
            }
            catch (Exception ex)
            {
                return "Error parsing Json document: " + ex.Message;
            }

            try
            {
                JToken token = sourceJson.SelectToken(jsonPathExpression);
                if (token != null)
                {
                    string jsonResult = token.ToString();

                    return jsonResult;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string SHA1Hash(string input)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }

        public static string SHA512Hash(string input)
        {
            byte[] data = Encoding.UTF8.GetBytes(input);
            using (var alg = SHA512.Create())
            {
                alg.ComputeHash(data);
                return BitConverter.ToString(alg.Hash);
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private static readonly char[] Punctuations = "!@#$%^&*()_-+=[{]};:>|./?".ToCharArray();

        public static string GeneratePassword(int length, int numberOfNonAlphanumericCharacters)
        {
            if (length < 1 || length > 128)
            {
                throw new ArgumentException(nameof(length));
            }

            if (numberOfNonAlphanumericCharacters > length || numberOfNonAlphanumericCharacters < 0)
            {
                throw new ArgumentException(nameof(numberOfNonAlphanumericCharacters));
            }

            using var rng = RandomNumberGenerator.Create();
            var byteBuffer = new byte[length];

            rng.GetBytes(byteBuffer);

            var count = 0;
            var characterBuffer = new char[length];

            for (var iter = 0; iter < length; iter++)
            {
                var i = byteBuffer[iter] % 87;

                if (i < 10)
                {
                    characterBuffer[iter] = (char)('0' + i);
                }
                else if (i < 36)
                {
                    characterBuffer[iter] = (char)('A' + i - 10);
                }
                else if (i < 62)
                {
                    characterBuffer[iter] = (char)('a' + i - 36);
                }
                else
                {
                    characterBuffer[iter] = Punctuations[i - 62];
                    count++;
                }
            }

            if (count >= numberOfNonAlphanumericCharacters)
            {
                return new string(characterBuffer);
            }

            int j;
            var rand = new Random();

            for (j = 0; j < numberOfNonAlphanumericCharacters - count; j++)
            {
                int k;
                do
                {
                    k = rand.Next(0, length);
                }
                while (!char.IsLetterOrDigit(characterBuffer[k]));

                characterBuffer[k] = Punctuations[rand.Next(0, Punctuations.Length)];
            }

            return new string(characterBuffer);
        }

        public static void EncryptFile(string inputFileName, string outputFileName, string password, string initVector, string saltValue, int iterations, Action<double> updateProgress = null)
        {
            using (FileStream fsInput = new FileStream(inputFileName,
                FileMode.Open,
                FileAccess.Read))
            using (BufferedStream bsInput = new BufferedStream(fsInput))
            {
                using (FileStream fsEncrypted = new FileStream(outputFileName,
                                FileMode.Create,
                                FileAccess.Write))
                using (BufferedStream bsEncrypted = new BufferedStream(fsEncrypted))
                {

                    byte[] salt = Encoding.ASCII.GetBytes(saltValue);
                    Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, iterations);
                    RijndaelManaged SymmetricKey = new RijndaelManaged();
                    SymmetricKey.Padding = PaddingMode.PKCS7;
                    SymmetricKey.KeySize = 256;
                    SymmetricKey.Mode = CipherMode.CBC;
                    SymmetricKey.Key = key.GetBytes(SymmetricKey.KeySize / 8);

                    GCHandle gch = GCHandle.Alloc(SymmetricKey.Key, GCHandleType.Pinned);

                    SymmetricKey.IV = ASCIIEncoding.ASCII.GetBytes(initVector);
                    SymmetricKey.BlockSize = 128;

                    initVector = string.Empty;
                    saltValue = string.Empty;

                    FileInfo info = new FileInfo(inputFileName);

                    ICryptoTransform aesEncrypt = SymmetricKey.CreateEncryptor(SymmetricKey.Key, SymmetricKey.IV);
                    using (CryptoStream cryptostream = new CryptoStream(bsEncrypted,
                                        aesEncrypt,
                                        CryptoStreamMode.Write))
                    {
                        int readByte;
                        double i = 0.0;

                        while ((readByte = bsInput.ReadByte()) != -1)
                        {
                            cryptostream.WriteByte((byte)readByte);
                            i++;
                            if (i % 10 == 0)
                            {
                                updateProgress((i / (double)(info.Length)) * 100.0);
                            }
                        }
                    }
#if WIN64
                ZeroMemory(gch.AddrOfPinnedObject(), 32);
#endif
                    gch.Free();
                    SymmetricKey.Clear();
                }
            }
        }

        public static void DecryptFile(string inputFileName, string outputFileName, string password, string initVector, string saltValue, int iterations, Action<double> updateProgress = null)
        {
            byte[] salt = Encoding.ASCII.GetBytes(saltValue);
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, iterations);
            RijndaelManaged SymmetricKey = new RijndaelManaged();
            SymmetricKey.Padding = PaddingMode.PKCS7;
            SymmetricKey.KeySize = 256;
            SymmetricKey.Mode = CipherMode.CBC;
            SymmetricKey.Key = key.GetBytes(SymmetricKey.KeySize / 8);

            GCHandle gch = GCHandle.Alloc(SymmetricKey.Key, GCHandleType.Pinned);

            SymmetricKey.IV = ASCIIEncoding.ASCII.GetBytes(initVector);
            SymmetricKey.BlockSize = 128;

            initVector = string.Empty;
            saltValue = string.Empty;

            FileInfo info = new FileInfo(inputFileName);

            FileStream fsread = new FileStream(inputFileName,
                                    FileMode.Open,
                                    FileAccess.Read);

            ICryptoTransform aesDecrypt = SymmetricKey.CreateDecryptor(SymmetricKey.Key, SymmetricKey.IV);

            CryptoStream cryptostreamDecr = new CryptoStream(fsread,
                                                            aesDecrypt,
                                                            CryptoStreamMode.Read);
            if (File.Exists(outputFileName))
            {
                File.Delete(outputFileName);
            }

            FileStream fsOut = new FileStream(outputFileName, FileMode.Create);

            try
            {
                int data;
                double i = 0.0;

                while ((data = cryptostreamDecr.ReadByte()) != -1)
                {
                    fsOut.WriteByte((byte)data);

                    i++;
                    if (i % 10 == 0)
                    {
                        updateProgress((i / (double)(info.Length)) * 100.0);
                    }
                }

                cryptostreamDecr.Flush();
                cryptostreamDecr.Close();
                cryptostreamDecr.Dispose();
            }
            catch (CryptographicException ex)
            {
                throw new CryptographicException("There was a problem decrypting the file. Check the password and try again.", ex);
            }
            finally
            {
                if (fsOut != null)
                {
                    fsOut.Close();
                }

                fsread.Close();

#if WIN64
            ZeroMemory(gch.AddrOfPinnedObject(), 32);
#endif
                gch.Free();

                SymmetricKey.Clear();
            }
        }

        [System.Runtime.InteropServices.DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);

        public static string GenerateGuids(int numberToGenerate, bool uppercase, bool braces, bool hyphens, bool base64encode, bool rfc7515, bool urlencode, Action<double> updateProgress = null)
        {
            double progress = 0.0;

            StringBuilder sb = new StringBuilder(numberToGenerate * 38);

            for (int i = 0; i < numberToGenerate; i++)
            {
                string guid = System.Guid.NewGuid().ToString();

                if (uppercase)
                {
                    guid = guid.ToUpper();
                }
                if (!hyphens)
                {
                    guid = guid.Replace("-", string.Empty);
                }
                if (braces)
                {
                    guid = "{" + guid + "}";
                }
                if (base64encode)
                {
                    guid = Common.Base64Encode(guid);
                }
                if (base64encode && rfc7515)
                {
                    guid = guid.Split('=')[0]; // Remove any trailing '='s
                    guid = guid.Replace('+', '-'); // 62nd char of encoding
                    guid = guid.Replace('/', '_'); // 63rd char of encoding
                }
                if (urlencode)
                {
                    guid = WebUtility.UrlEncode(guid);
                }

                sb.Append(guid);
                sb.Append(Environment.NewLine);

                progress = ((double)i / (double)numberToGenerate) * 100.0;
                updateProgress?.Invoke(progress);
            }

            string result = sb.ToString();

            progress = 0.0;
            updateProgress?.Invoke(progress);

            return result;
        }
    }
}
