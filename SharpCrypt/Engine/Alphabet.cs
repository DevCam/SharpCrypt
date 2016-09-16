using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCrypt.Engine
{
    class Alphabet
    {
        private static Dictionary<int, char> _alphabet;
        private static string _core;

        public Alphabet(string alphabet)
        {
            var i = 0;
            _core = alphabet;
            _alphabet = new Dictionary<int, char>();
            foreach (var c in alphabet)
                _alphabet.Add(i++, c);
        }

        public char GetSymbol(int id)
        {
            char c;
            var valid = _alphabet.TryGetValue(id, out c);
            return valid ? c : char.MaxValue;
        }

        public int GetId(char c)
        {
            var id = _alphabet.FirstOrDefault(x => Equals(x.Value, c)).Key;
            return (id == 0 && c != GetSymbol(0)) ? -1 : id;
        }

        public int GetSize()
        {
            return _alphabet.Keys.Count;
        }

        public string GetCore()
        {
            return _core;
        }
    }
}
