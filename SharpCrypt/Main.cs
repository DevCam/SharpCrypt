using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpCrypt.Engine;
using SharpCrypt.Engine.CipherLibrary;

namespace SharpCrypt
{
    public partial class SharpCrypt : Form
    {
        private const int KEY_SIZE = 8;
        private const int VAL_RANGE = 5;

        public SharpCrypt()
        {
            InitializeComponent();
        }

        private void encode_Click(object sender, EventArgs e)
        {
            if (keyInput.Text.Length < 1)
                keyInput.Text = @"DefaultKey";
            var key = new Key(keyInput.Text, KEY_SIZE, VAL_RANGE);
            var alphabet = new Alphabet("abcdefghijklmnopqrstuvwxyz !ñ0123456789.");

            var plaintext = input.Text;
            plaintext = CleanText(plaintext, KEY_SIZE);
            var caesar = CaesarCipher.Encrypt(key, alphabet, plaintext);
            var vigenere = VigenereCipher.Encrypt(key, alphabet, caesar);
            var hill = HillCipher.Encrypt(key, alphabet, vigenere);

            output.Text = hill;
        }

        private void decode_Click(object sender, EventArgs e)
        {
            if (keyInput.Text.Length < 1)
                keyInput.Text = @"DefaultKey";
            var key = new Key(keyInput.Text, KEY_SIZE, VAL_RANGE);
            var alphabet = new Alphabet("abcdefghijklmnopqrstuvwxyz !ñ0123456789.");

            var codedtext = input.Text;
            var hill = HillCipher.Decrypt(key, alphabet, codedtext);
            var vigenere = VigenereCipher.Decrypt(key, alphabet, hill);
            var caesar = CaesarCipher.Decrypt(key, alphabet, vigenere);

            output.Text = caesar;
        }

        private static string CleanText(string dirtyText, int kSize)
        {
            var builder = new StringBuilder(dirtyText);
            while (builder.Length%kSize != 0)
                builder.Append(" ");

            return builder.ToString();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            input.Text = "";
            output.Text = "";
            keyInput.Text = "";
        }
    }
}
