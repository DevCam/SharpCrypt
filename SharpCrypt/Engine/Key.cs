using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpCrypt.Engine.CipherLibrary;
using Matrix = SharpCrypt.Engine.CipherLibrary.Matrix;

namespace SharpCrypt.Engine
{
    class Key
    {
        private readonly string _keyCore;
        private readonly int _hillKeySize;
        private readonly int _hillValRange;

        public Key(string keyInput)
        {
            _keyCore = keyInput;
            _hillKeySize = 3;
            _hillValRange = 10;
        }
        public Key(string keyInput, int hillKeySize, int hillValRange)
        {
            _keyCore = keyInput;
            _hillKeySize = hillKeySize;
            _hillValRange = hillValRange;
        }
    

        public int GetCaesarKey()
        {
            return Math.Abs(_keyCore.GetHashCode());
        }

        public string GetVigenereKey()
        {
            return _keyCore;
        }

        public Matrix GetHillKey()
        {
            int dropDet;
            Matrix dropCofs;
            return GetHillKey(out dropDet, out dropCofs);
        }

        public Matrix GetHillKey(out int determinant, out Matrix cof)
        {
            Matrix l;
            Matrix u;
            int det;

            var k = GetHillKey(out det, out l, out u);

            //generate cofactor matrix from LU decomposition

            var lcof = CryptoMath.LowerTriangularCofactor(l);
            var ucof = CryptoMath.LowerTriangularCofactor(u.Transpose()).Transpose();

            determinant = det;
            cof = lcof * ucof;
            return k;
        }

        private Matrix GetHillKey(out int determinant, out Matrix L, out Matrix U)
        {
            //Consider (n^3) + 2(n^2) + n complexity for key generation

            var gen = new Random(_keyCore.GetHashCode());

            var l = new Matrix(_hillKeySize, _hillKeySize);
            var u = new Matrix(_hillKeySize, _hillKeySize);

            for (var i = 0; i < _hillKeySize; i++)
                for (var j = i; j < _hillKeySize; j++)
                    l[i, j] = gen.Next(_hillValRange * -1, _hillValRange);

            for (var i = 0; i < _hillKeySize; i++)
                for (var j = 0; j < i; j++)
                    u[i, j] = gen.Next(_hillValRange * -1, _hillValRange);

            var det = 1;
            for (var i = 0; i < _hillKeySize; i++)
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
