using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCrypt.Engine.CipherLibrary
{
    static class HillCipher
    {
        public static string Encrypt(Key key, Alphabet alphabet, string plaintext)
        {
            var k = key.GetHillKey(3);
            var m = plaintext;
            var c = new StringBuilder();


            return c.ToString();
        }
    }
}
