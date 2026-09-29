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
using System.Security.Cryptography;

namespace lab1
{
    public partial class loginForm : Form
    {
        public bool IsAuth { get; private set; } = false;
        public Color backColor { get; private set; }  
        public Color btnBackColor { get; private set; }
        private readonly Dictionary<string, string> users = new Dictionary<string, string>();
        private IPerson personToEdit;

        public IPerson PersonResult { get; private set; }


        public loginForm(IPerson selectedPerson) : this()
        {
            personToEdit = selectedPerson;
        }

        public loginForm()
        {
            InitializeComponent();
            LoadUsersFromEnv("C:\\Users\\xbox3\\source\\repos\\lab1\\.env");
            userComboBox.SelectedItem = "user";
            
        }

        private string ComputeMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        private void LoadUsersFromEnv (string envFilePath = ".env")
        {
            if (!File.Exists(envFilePath))
            {
                MessageBox.Show("файл не найден", "ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach(string line in File.ReadAllLines(envFilePath))
            {
                //строка без лишних знаков
                string trimmedLine = line.Trim();
                
                if (string.IsNullOrEmpty(trimmedLine) || trimmedLine.StartsWith("#") ) {
                    continue;
                }
                string[] parts = trimmedLine.Split(new[] { '=' }, 2);
                    if (parts.Length == 2 )
                    {
                        string login = parts[0].Trim();
                        string hash = parts[1].Trim();

                        users[login] = hash;
                    }
                }

            }

        

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void userComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userComboBox.Text.ToString() == "admin")
            {
                passwordTextBox.Enabled = true;
            }
            else
            {
                passwordTextBox.Enabled = false;
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string selectedLogin = userComboBox.Text.ToString();
            string password = passwordTextBox.Text;

            if (users.TryGetValue(selectedLogin, out string storageMD5Hash))
            {
                string inputHash = selectedLogin + password;
                if (storageMD5Hash == ComputeMD5Hash(inputHash))
                {

                    DialogResult = DialogResult.OK;
                    IsAuth = true;
                    backColor = Color.LightBlue;
                    btnBackColor = Color.LightSteelBlue;
                    Close();
                }

                else
                {
                    MessageBox.Show("Неверный пароль!",
                                           "ошибка!",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    passwordTextBox.Clear();
                    passwordTextBox.Focus();
                }
                }
            }
        

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
