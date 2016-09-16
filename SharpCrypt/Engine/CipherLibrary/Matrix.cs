using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCrypt.Engine.CipherLibrary
{
    class Matrix
    {
        public int[,] Core { get; private set; }

        public Matrix(int n, int m)
        {
            Core = new int[n,m];
        }
    }
}
