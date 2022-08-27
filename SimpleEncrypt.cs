using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMExtension.Xamarin
{
    public static class EncryptData
    {
        private static List<byte> KeyList
        {
            get
            {
                return new List<byte>()
                {
                    120,
                    99,
                    114,
                    10,
                    7,
                    23,
                    63,
                    80,
                    111
                };
            }
        }
        public static string Translate(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            try
            {
                byte[] BytesArray = Encoding.ASCII.GetBytes(str);
                byte[] ConvertedBytes = new byte[BytesArray.Count()];

                for (int i = 0; i < BytesArray.Count(); i++)
                {
                    foreach (var key in KeyList)
                    {
                        ConvertedBytes[i] = (byte)(BytesArray[i] ^ key);
                    }
                }
                return Encoding.ASCII.GetString(ConvertedBytes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
