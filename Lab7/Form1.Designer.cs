namespace Lab7
{
    partial class DESEncryptor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DESEncryptor));
            this.Encrypt = new System.Windows.Forms.Button();
            this.Decrypt = new System.Windows.Forms.Button();
            this.Browse = new System.Windows.Forms.Button();
            this.FileBox = new System.Windows.Forms.TextBox();
            this.Key = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Encrypt
            // 
            this.Encrypt.Location = new System.Drawing.Point(53, 97);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(75, 23);
            this.Encrypt.TabIndex = 0;
            this.Encrypt.Text = "Encrypt";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // Decrypt
            // 
            this.Decrypt.Location = new System.Drawing.Point(179, 97);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(75, 23);
            this.Decrypt.TabIndex = 1;
            this.Decrypt.Text = "Decrypt";
            this.Decrypt.UseVisualStyleBackColor = true;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // Browse
            // 
            this.Browse.Image = ((System.Drawing.Image)(resources.GetObject("Browse.Image")));
            this.Browse.Location = new System.Drawing.Point(401, 12);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(42, 40);
            this.Browse.TabIndex = 2;
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // FileBox
            // 
            this.FileBox.Location = new System.Drawing.Point(53, 23);
            this.FileBox.Name = "FileBox";
            this.FileBox.Size = new System.Drawing.Size(342, 20);
            this.FileBox.TabIndex = 3;
            this.FileBox.Text = "File";
            this.FileBox.Click += new System.EventHandler(this.File_Click);
            // 
            // Key
            // 
            this.Key.Location = new System.Drawing.Point(53, 61);
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(100, 20);
            this.Key.TabIndex = 4;
            this.Key.Text = "Key";
            this.Key.Click += new System.EventHandler(this.Key_Click);
            // 
            // DESEncryptor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 150);
            this.Controls.Add(this.Key);
            this.Controls.Add(this.FileBox);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.Decrypt);
            this.Controls.Add(this.Encrypt);
            this.Name = "DESEncryptor";
            this.Text = "DES Encryptor";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.Button Decrypt;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.TextBox FileBox;
        private System.Windows.Forms.TextBox Key;
    }
}

