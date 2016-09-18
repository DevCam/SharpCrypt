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
                var y = ((alphabetSize*i) + 1)/(double)determinant;
                if (y%1 < epsilon && y > 0 && y < alphabetSize)
                    return (int)y; //found the inverse
            }

            throw new Exception("Determinant does not have inverse over mod alphabet");
        }
        public static Matrix LowerTriangularCofactor(Matrix m)
        {
            var cof = new Matrix(m.Height, m.Width);

            for(var i=0; i<m.Height;i++)
                for (var j = 0; j <= i; j++)
                    cof[i, j] = new Matrix(m, i, j).Determinant() * (int)Math.Pow(-1, i+j);

            return cof;
        }
    }
}
