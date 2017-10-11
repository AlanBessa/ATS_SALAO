using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP.Domain.SharedKernel.Helpers
{
    public class ImageHelper
    {
        public static byte[] ConverterParaBytes(string base64String)
        {
            var base64 = base64String.Substring(base64String.IndexOf(',')+1);

            return Convert.FromBase64String(base64);
        }

        public static string ConverterParaBase64String(byte[] imageByte)
        {
            string base64String = Convert.ToBase64String(imageByte);

            return "data:image/jpeg;base64," + base64String;
        }
    }
}
