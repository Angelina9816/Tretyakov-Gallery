using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Moscow_Car_Dealership
{
    class HASH
    {
        public static string Hashing(string input)
        {
            byte[] hash;
            using (var sb = new SHA1CryptoServiceProvider())
            {
                hash = sb.ComputeHash(Encoding.Unicode.GetBytes(input));
            }
            var h = new StringBuilder();
            foreach (byte b in hash) h.AppendFormat("{0:x2}", b);
            return h.ToString();
        }
    }
}
