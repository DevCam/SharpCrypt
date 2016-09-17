﻿using System;
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
        public SharpCrypt()
        {
            InitializeComponent();
        }

        private void encode_Click(object sender, EventArgs e)
        {
            if (keyInput.Text.Length < 1)
                keyInput.Text = @"DefaultKey";
            var key = new Key(keyInput.Text);
            var alphabet = new Alphabet("abcdefghijklmnopqrstuvwxyz !ñ0123456789?.");
            var caesar = CaesarCipher.Encrypt(key, alphabet, input.Text);
            var vigenere = VigenereCipher.Encrypt(key, alphabet, caesar);
            var hill = HillCipher.Encrypt(key, alphabet, vigenere);

        }

        private void decode_Click(object sender, EventArgs e)
        {
            if (keyInput.Text.Length < 1)
                keyInput.Text = @"DefaultKey";
            var key = new Key(keyInput.Text);
            var alphabet = new Alphabet("abcdefghijklmnopqrstuvwxyz !ñ0123456789?.");

            var vigenere = VigenereCipher.Decrypt(key, alphabet, input.Text);
            output.Text = CaesarCipher.Decrypt(key, alphabet, vigenere);
            
        }
    }
}
