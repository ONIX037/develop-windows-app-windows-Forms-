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

        //свойство которое передает результаты в mainform
        
        public IPerson PersonResult { get; private set; }

        //поля для убегающей кнопки 
        private readonly Timer fleeTimer = new Timer { Interval = 8 };  //таймер анимации 
        private Point fleeTarget;               //точка куда убегает кнопка
        private const int fleeDistance = 50;    //на сколько пикселей кнопка отскакивает от курсора
        private bool isEditMode = false;        //форма открыта для изменения существующей записи
        private string originalCardNumber = ""; //номер карты до изменений


        public changeForm()
        {
            InitializeComponent();
            this.KeyPreview = true;

            //подписка на события убегающей кнопки
            fleeTimer.Tick += FleeTimer_Tick;
            agreeButton.MouseEnter += AgreeButton_MouseEnter;
            agreeButton.MouseMove += AgreeButton_MouseMove;
        }


        public changeForm(IPerson person,bool isAuth = false) : this()
        {
                isEditMode = true;
                originalCardNumber = person.CardNumber.ToString();
                cardNumber_txtBox.Text = person.CardNumber.ToString();
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
            string name = name_txtBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(name) || name.Length <2 || name.Length > 50 )
            {
                MessageBox.Show("Неверный формат ввода имени", "ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //вход в кнопку и движение над ней ведут к одному и тому же побегу
        private void AgreeButton_MouseEnter(object sender, EventArgs e) => StartFlee();
        private void AgreeButton_MouseMove(object sender, MouseEventArgs e) => StartFlee();

        //кнопка Принять убегает только когда номер карты изменён 
        private void StartFlee()
        {
            if (!isEditMode || !cardNumber_txtBox.Enabled ||
                cardNumber_txtBox.Text == originalCardNumber) return;

            fleeTarget = PickFleeTarget(this.PointToClient(Cursor.Position));
            fleeTimer.Start();
        }

        //подбираем точку для рывка: перебираем веер направлений от курсора и два радиуса.
        //вариант годится, если кнопка реально сдвинется И курсор останется снаружи —
        //иначе у границы кнопка "наезжает" на курсор и замирает под ним
        private Point PickFleeTarget(Point cursor)
        {
            //координаты центра кнопки по x и y
            double dx = agreeButton.Left + agreeButton.Width / 2 - cursor.X;
            double dy = agreeButton.Top + agreeButton.Height / 2 - cursor.Y;
            //угол направления от курсора к центру кнопки 
            double baseAngle = Math.Atan2(dy, dx) * 180 / Math.PI;

            double[] spread = { 0, 45, -45, 90, -90, 135, -135, 180 };

            foreach (double shift in spread)
            {
                double rad = (baseAngle + shift) * Math.PI / 180;

                //у границы обычного рывка может не хватить, чтобы вынести курсор
                //из-под большой кнопки, — тогда пробуем рывок вдвое длиннее
                foreach (int dist in new int[] { fleeDistance, fleeDistance * 2 })
                {
                    Point candidate = ClampToForm(new Point(
                        agreeButton.Left + (int)(Math.Cos(rad) * dist),
                        agreeButton.Top + (int)(Math.Sin(rad) * dist)));

                    bool moved = GetDistance(candidate, agreeButton.Location) >= fleeDistance / 2;
                    bool cursorOutside = !new Rectangle(candidate, agreeButton.Size).Contains(cursor);

                    if (moved && cursorOutside)
                        return candidate;
                }
            }

            return agreeButton.Location;   //годного варианта нет — остаёмся на месте
        }

        //плавно ведём кнопку к цели: каждый тик проходим 1/2 оставшегося пути
        private void FleeTimer_Tick(object sender, EventArgs e)
        {
            Point current = agreeButton.Location;
            Point newPosition = new Point(
                current.X + (fleeTarget.X - current.X) / 2,
                current.Y + (fleeTarget.Y - current.Y) / 2);

            agreeButton.Location = newPosition;

            //дошли до цели — останавливаем анимацию
            if (Math.Abs(newPosition.X - fleeTarget.X) < 2 &&
                Math.Abs(newPosition.Y - fleeTarget.Y) < 2)
            {
                agreeButton.Location = fleeTarget;
                fleeTimer.Stop();
            }
        }

        //расстояние между двумя точками
        private static double GetDistance(Point a, Point b)
        {
            int dx = a.X - b.X, dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        //не даём точке выйти за пределы клиентской области формы
        private Point ClampToForm(Point p)
        {
            return new Point(
                Math.Max(0, Math.Min(p.X, this.ClientSize.Width - agreeButton.Width)),
                Math.Max(0, Math.Min(p.Y, this.ClientSize.Height - agreeButton.Height)));
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
