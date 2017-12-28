using SendEncryptedEmail.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace SendEncryptedEmail.Libraries
{
    public class FileOperationsHelper
    {
        string entry;
        List<string> entriesList;
        FileStream fileStream;

        readonly string Password = "@1#$%ACB1g4aAb@#@a*234BNaa98";

        /// <summary>
        /// Write into Binary file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="publicAddress"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public bool WriteBinaryFile(string fileName, EthereumUser user)
        {
            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);
                fileStream = new FileStream(fileName, FileMode.CreateNew, FileAccess.ReadWrite);

                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(EncryptString(user.PublicAddress, Password));
                streamWriter.WriteLine(EncryptString(user.PrivateKey, Password));
                streamWriter.Close();
                fileStream.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Read from Binary file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public EthereumUser ReadBinaryFile(string fileName)
        {
            EthereumUser user = new EthereumUser();
            try
            {
                
                fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                StreamReader streamReader = new StreamReader(fileStream);
                entriesList = new List<string>();
                string decryptedValue = "";
                while ((entry = streamReader.ReadLine()) != null)
                {
                    decryptedValue = DecryptString(entry, Password);
                    entriesList.Add(decryptedValue);
                }
                user.PublicAddress = entriesList[0];
                user.PrivateKey = entriesList[1];

                streamReader.Close();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                
            }
            return user;
        }

        /// <summary>
        /// Encryption of file entries
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Passphrase"></param>
        /// <returns></returns>
        private string EncryptString(string Message, string Passphrase)
        {

            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToEncrypt = UTF8.GetBytes(Message);
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }

            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            return Convert.ToBase64String(Results);
        }

        /// <summary>
        /// Decryption of file entries
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Passphrase"></param>
        /// <returns></returns>
        private string DecryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return UTF8.GetString(Results);
        }

        /// <summary>
        /// Generates local path for stored files
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string FilePathGenerator(string fileName)
        {
            //Get the assembly information
            System.Reflection.Assembly assemblyInfo = System.Reflection.Assembly.GetExecutingAssembly();

            //CodeBase is the location of the ClickOnce deployment files
            Uri uriCodeBase = new Uri(assemblyInfo.CodeBase);

            string location = Path.GetDirectoryName(uriCodeBase.LocalPath.ToString());
            string path = location + "\\"+ fileName;

            return path;
        }
    }
}
