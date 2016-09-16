namespace SharpCrypt
{
    partial class SharpCrypt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharpCrypt));
            this.input = new System.Windows.Forms.RichTextBox();
            this.keyPicture = new System.Windows.Forms.PictureBox();
            this.encode = new System.Windows.Forms.Button();
            this.decode = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.keyInput = new System.Windows.Forms.RichTextBox();
            this.output = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.keyPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(12, 12);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(609, 168);
            this.input.TabIndex = 0;
            this.input.Text = "";
            // 
            // keyPicture
            // 
            this.keyPicture.Image = ((System.Drawing.Image)(resources.GetObject("keyPicture.Image")));
            this.keyPicture.InitialImage = ((System.Drawing.Image)(resources.GetObject("keyPicture.InitialImage")));
            this.keyPicture.Location = new System.Drawing.Point(12, 186);
            this.keyPicture.Name = "keyPicture";
            this.keyPicture.Size = new System.Drawing.Size(39, 38);
            this.keyPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.keyPicture.TabIndex = 1;
            this.keyPicture.TabStop = false;
            // 
            // encode
            // 
            this.encode.Location = new System.Drawing.Point(339, 186);
            this.encode.Name = "encode";
            this.encode.Size = new System.Drawing.Size(87, 38);
            this.encode.TabIndex = 3;
            this.encode.Text = "Encode";
            this.encode.UseVisualStyleBackColor = true;
            this.encode.Click += new System.EventHandler(this.encode_Click);
            // 
            // decode
            // 
            this.decode.Location = new System.Drawing.Point(437, 186);
            this.decode.Name = "decode";
            this.decode.Size = new System.Drawing.Size(87, 38);
            this.decode.TabIndex = 4;
            this.decode.Text = "Decode";
            this.decode.UseVisualStyleBackColor = true;
            this.decode.Click += new System.EventHandler(this.decode_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(534, 186);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(87, 38);
            this.clear.TabIndex = 5;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            // 
            // keyInput
            // 
            this.keyInput.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyInput.Location = new System.Drawing.Point(58, 186);
            this.keyInput.Name = "keyInput";
            this.keyInput.Size = new System.Drawing.Size(268, 38);
            this.keyInput.TabIndex = 6;
            this.keyInput.Text = "";
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(12, 251);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(609, 168);
            this.output.TabIndex = 7;
            this.output.Text = "";
            // 
            // SharpCrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 431);
            this.Controls.Add(this.output);
            this.Controls.Add(this.keyInput);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.decode);
            this.Controls.Add(this.encode);
            this.Controls.Add(this.keyPicture);
            this.Controls.Add(this.input);
            this.Name = "SharpCrypt";
            this.Text = "SharpCrypt";
            ((System.ComponentModel.ISupportInitialize)(this.keyPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox input;
        private System.Windows.Forms.PictureBox keyPicture;
        private System.Windows.Forms.Button encode;
        private System.Windows.Forms.Button decode;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.RichTextBox keyInput;
        private System.Windows.Forms.RichTextBox output;
    }
}

