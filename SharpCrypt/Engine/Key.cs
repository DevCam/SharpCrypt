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

        public Matrix GetHillKey(int kSize)
        {
            var key = new Matrix(kSize, kSize);

            return key;
        }
    }
}
