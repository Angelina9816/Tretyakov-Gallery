using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tretyakov_Gallery
{
    class SHA1
    {
        public static string Hashing(string input)
        {
            byte[] hash;
            using (var s = new SHA1CryptoServiceProvider())
            {
                hash = s.ComputeHash(Encoding.Unicode.GetBytes(input));
            }
            var a = new StringBuilder();
            foreach (byte b in hash) a.AppendFormat("{0:x2}", b);
            return a.ToString();
        }
    }
}
