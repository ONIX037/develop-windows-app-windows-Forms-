using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class mainForm : Form
    {   
        private BindingList <IPerson> peopleList = new BindingList<IPerson>();
        public mainForm()
        {
            InitializeComponent();
            listBox1.DataSource = peopleList;

            // adding new persons
            peopleList.Add(new Person(12701, "Петр", new DateTime(2007, 11, 16)));
            peopleList.Add(new Person(12355, "Кирилл", new DateTime(2007, 7, 12)));
        }


        
        
        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить запись?", 
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                if (listBox1.SelectedItem is IPerson selectedPerson)
                {
                    peopleList.Remove(selectedPerson);
                }
            }
            
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void changeButton_click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is IPerson selectedPerson)
            {
                //using (loginForm login = new loginForm(selectedPerson))
                using (changeForm changeForm = new changeForm(selectedPerson))
                {
                    if (changeForm.ShowDialog() == DialogResult.OK)
                    {
                        int index = peopleList.IndexOf(selectedPerson);
                        peopleList[index] = changeForm.PersonResult;
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись для изменения.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
        }

        private void createButton_click(object sender, EventArgs e)
        {
            using (changeForm changeForm = new changeForm())
            {
                if (changeForm.ShowDialog() == DialogResult.OK)
                {
                    peopleList.Add(changeForm.PersonResult);
                }
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
