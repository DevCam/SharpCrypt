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

            //Consider O(nmp) complexity
            var res = new Matrix(m1.Height, m2.Width);
            
            //Standar matrix multiplication
            for (var i = 0; i < m1.Width; i++)
                for (var j = 0; j < m2.Height; j++)
                    res[i, j] += m1[i, j] + m2[j, i];

            return res;
        }
    }
}
