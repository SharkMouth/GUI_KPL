using Main.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login _login = new Login();
            string _username = textBox2.Text;
            string _password = textBox3.Text;
            string _nama = textBox1.Text;

            List<Akun> _dataAkun = ReadJSON();


            if (string.IsNullOrEmpty(_username) || string.IsNullOrEmpty(_password))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong.");
            }
            else
            {
                Boolean _akunDitemukan = ValidateUser(_dataAkun, _username, _password);
                if (_akunDitemukan)
                {
                    MessageBox.Show("Akun sudah ada");
                }
                else
                {
                    Boolean _statusPassword = ValidatePassword(_password);
                    if (_statusPassword)
                    {
                        Akun newAkun = new Akun(_username, _password, _nama);
                        _dataAkun.Add(newAkun);
                        WriteJSON(_dataAkun);
                        MessageBox.Show("Akun berhasil dibuat");
                        this.Dispose();
                        _login.Show();
                    }
                    else
                    {
                        MessageBox.Show("Password harus berisi lebih dari 6 dan kurang dari 10 karakter");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public List<Akun> ReadJSON()
        {
            string filePathDataAkun = "C:\\Users\\harit\\OneDrive\\Documents\\TEL-U SEM 4\\TP KPL\\KPL_GUI\\Main\\Data";
            List<Akun> dataAkun = new List<Akun>();
            try
            {
                string configJsonData = File.ReadAllText(filePathDataAkun);
                dataAkun = JsonSerializer.Deserialize<List<Akun>>(configJsonData);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return dataAkun;

        }
        private void WriteJSON(List<Akun> newDataAkun)
        {
            string filePathDataAkun = "C:\\Users\\harit\\OneDrive\\Documents\\TEL-U SEM 4\\TP KPL\\KPL_GUI\\Main\\Data";
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(newDataAkun, options);
            File.WriteAllText(filePathDataAkun, jsonString);
        }
        private Boolean ValidateUser(List<Akun> newDataAkun, string username, string password)
        {
            for (int i = 0; i < newDataAkun.Count; i++)
            {
                if (newDataAkun[i].Password.Equals(password) && newDataAkun[i].Username.Equals(username))
                {
                    return true;
                }
            }
            return false;
        }

        private Boolean ValidatePassword(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
