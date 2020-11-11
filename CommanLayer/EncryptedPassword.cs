using System;
using System.Collections.Generic;
using System.Text;

namespace CommanLayer
{
    public class EncryptedPassword
    {
        /// <summary>
        /// Encrypt the Password logic
        /// </summary>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static string EncodePasswordToBase64(string Password)
        {
            try
            {
                byte[] encData_byte = new byte[Password.Length];
                encData_byte = Encoding.UTF8.GetBytes(Password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;                                         //Return Encrypted Data
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

    }
}
