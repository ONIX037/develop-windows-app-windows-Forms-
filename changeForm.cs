using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class changeForm : Form
    {

        //создаем свойство которое передает результаты в mainform
        
        public IPerson PersonResult { get; private set; }


        public changeForm()
        {
            InitializeComponent();
            this.KeyPreview = true;


        }


        public changeForm(IPerson person,bool isAuth = false) : this()
        {
                cardNumber_txtBox.Text = person.СardNumber.ToString();
                name_txtBox.Text = person.Name;
                dateTimePicker.Value = person.Bithday;
            
                cardNumber_txtBox.Enabled = isAuth;
                dateTimePicker.Enabled = isAuth;
            
        }

        
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void nameLabel_Enter(object sender, EventArgs e)
        {

        }

        
        private void agreeButton_Click(object sender, EventArgs e)
        {

            //проверка введеных данных
            if (!int.TryParse(cardNumber_txtBox.Text, out int cardNumber) || 
                cardNumber_txtBox.Text.Length != 5 || cardNumber < 10000 || cardNumber > 99999)
            {
                MessageBox.Show("Неверный формат ввода номера карты.",
                    "ошибка!",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            // проверка возраста
            IPerson candidate = new Person(cardNumber, name_txtBox.Text, dateTimePicker.Value);
            if (!candidate.calcAge(DateTime.Now, out int age))
            {
                MessageBox.Show("Неверный формат ввода даты рождения.",
                    "ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            //сохранение введенных данных
            PersonResult = candidate;
            DialogResult = DialogResult.OK;
            this.Close();   
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void changeForm_Load(object sender, EventArgs e)
        { }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void name_txtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void changeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.L)
            {
                loginForm login = new loginForm();
                
                using (login)
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    cardNumber_txtBox.Enabled = login.IsAuth;
                    dateTimePicker.Enabled = login.IsAuth;
                        BackColor = login.backColor;
                        agreeButton.BackColor = login.btnBackColor;
                        cancelButton.BackColor = login.btnBackColor;
                        cardNumber_txtBox.BackColor = login.btnBackColor;
                        name_txtBox.BackColor = login.btnBackColor;
                        dateTimePicker.CalendarForeColor = login.btnBackColor;

                        

                }
            }
            

            }
        }
    }
}
