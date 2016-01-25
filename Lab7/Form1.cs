using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Security.Cryptography;
namespace Lab7
{
    public partial class DESEncryptor : Form
    {
        public byte[] key = new byte[8];
        public DESEncryptor()
        {
            InitializeComponent();
        }
        private void Browse_Click(object sender, EventArgs e)
        {
            if (FileBox.Text == "File") { FileBox.Text = ""; }
            OpenFileDialog BrowseDialog = new OpenFileDialog();
            if (BrowseDialog.ShowDialog() == DialogResult.OK)
            {
                FileBox.Text = BrowseDialog.FileName;
            }
        }

        private void File_Click(object sender, EventArgs e)
        {
            if (FileBox.Text == "File") { FileBox.Text = ""; }
            if (Key.Text == "") { Key.Text = "Key"; }
        }
        private void Key_Click(object sender, EventArgs e)
        {
            if (Key.Text == "Key") { Key.Text = ""; }
            if (FileBox.Text == "") { FileBox.Text = "File"; }
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            if (Key.Text == "") { Key.Text = "Key"; }
            if (FileBox.Text == "") { FileBox.Text = "File"; }
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            if (Key.Text == "")
            {
                Key.Text = "Key";
                MessageBox.Show("Please provide an encryption key", "Error: No Key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FileBox.Text == "")
            {
                FileBox.Text = "File";
                MessageBox.Show("Please select a file to encrypt", "Error: No File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(FileBox.Text.EndsWith(".des"))
            {
                if (MessageBox.Show("This file is already encrypted. Continue?", "Encrypted File Encountered", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }
            //set key array
            int i = 0;
            for (int j = 0; j < Key.Text.Length; j++)
            {
                key[i] = (byte)(key[i] + (byte)this.Key.Text[j]);
                i = ((i + 1) % 8);
            }
            // add .des file type
            string addDES = string.Concat(FileBox.Text, ".des");
            //perform encryption if file does not exist or if overwrite
            if(File.Exists(addDES))
            {
                if(MessageBox.Show("Output file exists. Overwrite?", "File Exists", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }
            //encrypt here, base on DESCryptoServiceProvider example
            FileStream inStream = null;
            FileStream outStream = null;
            try
            {
                inStream = new FileStream(FileBox.Text, FileMode.Open, FileAccess.Read);
                outStream = new FileStream(addDES, FileMode.OpenOrCreate, FileAccess.Write); //create only
                outStream.SetLength((long)0);
            }
            catch
            {
                MessageBox.Show("Could not open source or destination file.", "Error: Could Not Open File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (inStream != null)
                    inStream.Close();
                if (outStream != null)
                    outStream.Close();
                return;
            }
            byte[] arr = new byte[100];
            long l = (long)0;
            long len = inStream.Length;
            DES des = new DESCryptoServiceProvider(); //now stream encrypted to output
            CryptoStream encryptedStream = new CryptoStream(outStream, des.CreateEncryptor(key, key), CryptoStreamMode.Write);
            while (l < len)
            {
                int k = inStream.Read(arr, 0, 100);
                encryptedStream.Write(arr, 0, (int)k);
                l = l + k;
            }
            encryptedStream.Close();
            inStream.Close();
            outStream.Close();
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            if (Key.Text == "")
            {
                Key.Text = "Key";
                MessageBox.Show("Please provide a decryption key", "Error: No Key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FileBox.Text == "")
            {
                FileBox.Text = "File";
                MessageBox.Show("Please select a file to decrypt", "Error: No File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!FileBox.Text.EndsWith(".des"))
            {
                MessageBox.Show("This file is unencrypted. Continue?", "Unencrypted File Encountered", MessageBoxButtons.OK);
                return;
            }
            //set key array
            int i = 0;
            for (int j = 0; j < Key.Text.Length; j++)
            {
                key[i] = (byte)(key[i] + (byte)this.Key.Text[j]);
                i = ((i + 1) % 8);
            }
            //remove .des file type
            string RemoveDES = FileBox.Text.Remove(FileBox.Text.Length - 3);
            if(File.Exists(RemoveDES))
            {
                if(MessageBox.Show("Output file exists. Overwrite?", "File Exists", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }
            //decrypt here, base on DESCryptoServiceProvider example
            //same as encryption, but writing out in a try statement below
            FileStream inStream = null;
            FileStream outStream = null;
            try
            {
                inStream = new FileStream(FileBox.Text, FileMode.Open, FileAccess.Read);
                outStream = new FileStream(RemoveDES, FileMode.OpenOrCreate, FileAccess.Write); //create only
                outStream.SetLength((long)0);
            }
            catch
            {
                MessageBox.Show("Could not open source or destination file.", "Error: Could Not Open File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (inStream != null)
                    inStream.Close();
                if (outStream != null)
                    outStream.Close();
                return;
            }
            byte[] arr = new byte[100];
            long l = (long)0;
            long len = inStream.Length;
            DES des = new DESCryptoServiceProvider();
            CryptoStream encryptedStream = new CryptoStream(outStream, des.CreateDecryptor(key, key), CryptoStreamMode.Write);
            try
            {
                while (l < len)
                {
                    int k = inStream.Read(arr, 0, 16);
                    encryptedStream.Write(arr, 0, (int)k);
                    l = l + k;
                }
                encryptedStream.Close();
            }
            catch //cannot decrypt
            {
                MessageBox.Show("Key cannot decrypt file.", "Error: Bad Key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.Delete(RemoveDES); //delete partially-decrypted file
                outStream.Close();
                inStream.Close();
                return;
            }
            outStream.Close();
            inStream.Close();
        }
    }
}
