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
            var k = key.GetHillKey();
            var m = plaintext;

            return Operate(k, m);
        }

        public static string Decrypt(Key key, Alphabet alphabet, string encodtext)
        {
            int determinant;
            Matrix cofactor;
            var encoK = key.GetHillKey(out determinant, out cofactor);
            var m = encodtext;

            //Find det inverse
            determinant = CryptoMath.Mod(determinant, alphabet.GetSize() + 1);
            var inverse = CryptoMath.Invert(determinant, alphabet.GetSize() + 1);

            var k = (inverse*cofactor.Transpose())% (alphabet.GetSize() + 1);
            //var lolz = ((k % (alphabet.GetSize() + 1)) * (encoK % (alphabet.GetSize() + 1))) % (alphabet.GetSize()+1);

            return Operate(k, m);
        }

        private static string Operate(Matrix key, string text)
        {
            var c = new StringBuilder();

            return c.ToString();
        }

        
    }
}
