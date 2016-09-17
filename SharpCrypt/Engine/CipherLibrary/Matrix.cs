using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCrypt.Engine.CipherLibrary
{
    class Matrix
    {
        private readonly int[,] _core;
        public int Height { get; private set; }
        public int Width { get; private set; }

        public Matrix(int n, int m)
        {
            Height = n;
            Width = m;
            _core = new int[n,m];
        }

        public int this[int i, int j]
        {
            get { return _core[i, j]; } set { _core[i, j] = value; }
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.Width != m2.Height)
                return null; //operation is not defined

            var res = new Matrix(m1.Height, m2.Width);

            //textbook matrix multiplication,Consider O(nmp) complexity
            for(var i=0; i<res.Height; i++)
                for (var j = 0; j < res.Width; j++)               
                    for (var k = 0; k < m1.Width; k++)
                        res[i, j] += m1[i, k]*m2[k, j]; //get the product of the ith row and the jth col

            return res;
        }

        public static Matrix operator *(Matrix m, int n)
        {
            //Consider n^2 complexity
            var res = new Matrix(m.Height, m.Width);

            for(var i=0; i<res.Height;i++)
                for (var j = 0; j < res.Width; j++)
                    res[i, j] = m[i, j]*n;

            return res;
        }

        public static Matrix operator *(int n, Matrix m)
        {
            return m*n;
        }

        public static Matrix operator %(Matrix m, int mod)
        {
            //Consider n^2 complexity
            var res = new Matrix(m.Width, m.Height);
            for(var i =0; i < m.Width;i++)
                for (var j = 0; j < m.Height;j++)
                    res[i, j] = CryptoMath.Mod(m[i, j], mod);

            return res;
        }

        public Matrix Transpose()
        {
            //Consider n^2 complexity
            var res = new Matrix(Width, Height);

            for(var i=0; i<Height; i++)
                for (var j = 0; j < Width; j++)
                    res[j, i] = this[i, j];

            return res;
        }
    }
}
