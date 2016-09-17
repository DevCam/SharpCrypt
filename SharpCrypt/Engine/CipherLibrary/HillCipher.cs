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
            var k = key.GetHillKey(3, 10);
            var m = plaintext;

            return Operate(k, m);
        }

        public static string Decrypt(Key key, Alphabet alphabet, string encodtext)
        {
            int determinant;
            Matrix cofactor;
            var k = key.GetHillKey(3, 10, out determinant, out cofactor);
            var m = encodtext;

            //Find det inverse
            var inverse = CryptoMath.Invert(determinant, alphabet.GetSize());

            return Operate(k, m);
        }

        private static string Operate(Matrix key, string text)
        {
            var c = new StringBuilder();

            return c.ToString();
        }

        
    }
}
