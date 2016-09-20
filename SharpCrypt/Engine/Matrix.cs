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

        public Matrix(int n, int m, IReadOnlyList<int> content)
        {
            Height = n;
            Width = m;
            _core = new int[n,m];
            var counter = 0;
            for(var i=0; i < Height; i++)
                for (var j = 0; j < Width; j++)
                    _core[i, j] = content[counter++];
        }

        public Matrix(Matrix m, int dropRow, int dropCol)
        {
            //Build a matrix, minus row #dropRow and col #dropCol
            //Consider n^2 complexity for this constructor
            Height = m.Height - 1;
            Width = m.Width - 1;
            _core = new int[Height,Width];

            for (int i = 0, j = 0; i < m.Height; i++)
            {
                if (i == dropRow)
                    continue;
                for (int k = 0, u = 0; k < m.Width; k++)
                {
                    if (k == dropCol)
                        continue;
                    this[j, u] = m[i, k];
                    u++;
                }
                j++;
            }

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
            var res = new Matrix(m.Height, m.Width);
            for (var i = 0; i < m.Height; i++)
                for (var j = 0; j < m.Width;j++)
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

        public int Determinant()
        {
            if(Width != Height)
                throw new Exception("Matrix does not have determinant");
            if (Width == 2)
                return (this[0, 0]*this[1, 1]) - (this[0, 1]*this[1, 0]);
            if (Width == 3)
                return (this[0, 0]*this[1, 1]*this[2, 2])+(this[0,1]*this[1,2]*this[2,0])+(this[0,2]*this[1,0]*this[2,1])
                    -(this[0,2]*this[1,1]*this[2,0]) - (this[0,1]*this[1,0]*this[2,2]) - (this[0,0]*this[1,2]*this[2,1]);
            
            //4x4 <= 
            var det = 0;
            for (var i = 0; i < Width; i++)
            {
                var tempNewM = new Matrix(this, 0, i);
                det += this[0, i] * (tempNewM.Determinant() * (int)Math.Pow(-1, i));
            }
                
            return det;

        }
    }
}
