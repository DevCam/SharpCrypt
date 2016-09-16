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

namespace SharpCrypt
{
    public partial class SharpCrypt : Form
    {
        public SharpCrypt()
        {
            InitializeComponent();
        }

        private void encode_Click(object sender, EventArgs e)
        {

            if (keyInput.Text.Length < 1)
                keyInput.Text = @"DefaultKey";
            var key = new Key(keyInput.Text);
            var alphabet = new Alphabet("abcdefghijklmnopqrstuvwxyz !ñ");

            var caesar = CaesarCipher.Encrypt(key, alphabet, input.Text);
            output.Text = VigenereCipher.Encrypt(key, alphabet, caesar);
        }

        private void decode_Click(object sender, EventArgs e)
        {
            var key = new Key(keyInput.Text);
            var alphabet = new Alphabet("abcdefghijklmnopqrstuvwxyz !ñ");

            var vigenere = VigenereCipher.Decrypt(key, alphabet, input.Text);
            output.Text = CaesarCipher.Decrypt(key, alphabet, vigenere);
            
        }
    }
}
