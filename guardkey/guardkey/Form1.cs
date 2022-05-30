using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace guardkey
{
    public partial class Form1 : Form
    {
        private string appId = "27116";
        private string privateKey = string.Empty;
        private bool devMode = false;
        public Form1()
        {
            InitializeComponent();
            this.Text = "App ID " + appId;
        }

        public void generateGuardKey()
        {
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            int minutes = Convert.ToInt32(datevalue.Minute.ToString());

            string remaining = Convert.ToString(60 - minutes);

            String hr = datevalue.Hour.ToString();
            String dy = datevalue.Day.ToString();
            String mn = datevalue.Month.ToString();
            String yy = datevalue.Year.ToString();

            string computedHash = sha512(_username.Text) + sha512(_password.Text) + sha512(hr + dy + mn + yy) + sha512(privateKey);

            if (devMode)
            {
                MessageBox.Show("username->" + sha512(_username.Text));
                MessageBox.Show("password->" + sha512(_password.Text));
                MessageBox.Show("privateKey->" + sha512(privateKey));
                MessageBox.Show("dateTime->" + sha512(hr + dy + mn + yy));
                MessageBox.Show(hr + dy + mn + yy);
            }
            _guardKey.Text =sha512(computedHash);
            Clipboard.SetText(_guardKey.Text);
            _generate_label.Text = "Generated Guard Key (COPIED TO CLIPBOARD!)" + "\n" + "valid for " + remaining + " minutes";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string sha512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }

        private void _username_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void _password_TextChanged(object sender, EventArgs e)
        {

        }

        private void _password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                generateGuardKey();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            generateGuardKey();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IList<String> fullNames = new List<String>();
            foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
            {
                if (driveInfo.DriveType == DriveType.Removable)
                {
                    fullNames.Add(driveInfo.RootDirectory.FullName);
                }
            }

            foreach(string driveAddres in fullNames)
            {
                if(File.Exists(driveAddres + "guardKey.pem"))
                {
                    privateKey = File.ReadAllText(driveAddres + "guardkey.pem");
                }
            }

            if (privateKey.Length == 0)
            {
                MessageBox.Show("Error unable to load guardkey usb drive.");
                this.Close();
            }
        }
    }
}
