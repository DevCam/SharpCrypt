using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix = SharpCrypt.Engine.CipherLibrary.Matrix;

namespace SharpCrypt.Engine
{
    class Key
    {
        private readonly string _keyCore;

        public Key(string keyInput)
        {
            _keyCore = keyInput;
        }

        public int GetCaesarKey()
        {
            return Math.Abs(_keyCore.GetHashCode());
        }

        public string GetVigenereKey()
        {
            return _keyCore;
        }

        public Matrix GetHillKey(int kSize, int valRange)
        {
            int dropDet;
            Matrix dropCofs;
            return GetHillKey(kSize, valRange, out dropDet, out dropCofs);
        }

        public Matrix GetHillKey(int kSize, int valRange, out int determinant, out Matrix cof)
        {
            Matrix l;
            Matrix u;
            int det;

            var k = GetHillKey(kSize, valRange, out det, out l, out u);

            //generate cofactor matrix from LU decomposition

            determinant = det;
            cof = null;
            return null;
        }

        private Matrix GetHillKey(int kSize, int valRange, out int determinant, out Matrix L, out Matrix U)
        {
            //Consider (n^3) + 2(n^2) + n complexity for key generation

            var gen = new Random(_keyCore.GetHashCode());

            var l = new Matrix(kSize, kSize);
            var u = new Matrix(kSize, kSize);

            for (var i = 0; i < kSize; i++)
                for (var j = i; j < kSize; j++)
                    l[i, j] = gen.Next(valRange * -1, valRange);

            for (var i=0; i < kSize;i++)
                for (var j = 0; j < i; j++)
                    u[i, j] = gen.Next(valRange * -1, valRange);

            var det = 1;
            for (var i = 0; i < kSize; i++)
            {
                if (l[i, i] == 0)
                    l[i, i] = 1; //L main diagonal may not have cero (det would be cero).
                det *= l[i, i];
                u[i, i] = 1;
            }

            var key = l*u;
            determinant = det;
            L = l;
            U = u;
            return key;
        }
    }
}
