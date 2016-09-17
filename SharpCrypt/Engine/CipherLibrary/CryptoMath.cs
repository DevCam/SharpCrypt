using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCrypt.Engine.CipherLibrary
{
    static class CryptoMath
    {
        public static int Mod(int x, int m)
        {
            return (x % m + m) % m;
        }

        public static int Invert(int determinant, int alphabetSize)
        {
            //return the 'y' val for a satisfied equation
            //y = (alphabetSize * x + 1) / determinant

            const double epsilon = 0.0000001;
            for (var i = 0; i <= alphabetSize; i++)
            {
                var y = ((alphabetSize*i) + 1)/determinant;
                if (y%1 < epsilon && y > 0 && y < alphabetSize)
                    return y; //found the inverse
            }

            throw new Exception("Determinant does not have inverse over mod alphabet");
        }
    }
}
