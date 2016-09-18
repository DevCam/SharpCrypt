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

            return Operate(k, alphabet, m);
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

            return Operate(k, alphabet, m);
        }

        private static string Operate(Matrix key, Alphabet alphabet, string text)
        {
            var c = new StringBuilder();

            //get n sized tuples - since text is clean, perfect tuples are guaranteed
            for (var i = 0; i < text.Length; i += key.Width)
            {
                var tuple = text.Substring(i, key.Width);
                var content = tuple.Select(alphabet.GetId).ToList();
                var toEncode = new Matrix(key.Height, 1, content);

                var encoded = (key * toEncode) % (alphabet.GetSize() + 1);;

                for (var j = 0; j < key.Width; j++)
                    c.Append(alphabet.GetSymbol(encoded[j, 0]));
            }

            return c.ToString();
        }

        
    }
}
