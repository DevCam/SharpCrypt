using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCrypt.Engine
{
    static class CaesarCipher
    {
        public static string Encrypt(Key key, Alphabet alphabet, string plaintext)
        {
            var k = key.GetCaesarKey() % alphabet.GetSize();
            var m = plaintext;
            var c = new StringBuilder();

            foreach (var sym in m.ToLower())
            {
                var newId = alphabet.GetId(sym);
                if (newId != -1)
                {
                    //character belongs to the alphabet and is encodable
                    newId = (newId + k)%alphabet.GetSize();
                    var newC = alphabet.GetSymbol(newId);
                    c.Append(newC);
                }
                else
                    c.Append(sym); //character does not exist in the alphabet, pass trough
                
            }

            return c.ToString();
        }

        public static string Decrypt(Key key, Alphabet alphabet, string encodtext)
        {
            var k = key.GetCaesarKey() % alphabet.GetSize();
            var c = encodtext;
            var m = new StringBuilder();

            foreach (var sym in c)
            {
                var newId = alphabet.GetId(sym);
                if (newId != -1)
                {
                    //character belongs to the alphabet and is decodable
                    newId = ((newId + alphabet.GetSize()) - k)%alphabet.GetSize();
                    var newC = alphabet.GetSymbol(newId);
                    m.Append(newC);
                }
                else
                    m.Append(sym);
            }

            return m.ToString();
        }
    }
}
