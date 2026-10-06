using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{





    internal class Person : IPerson
    {
        public int СardNumber { get; }
        public string Name { get; }
        public DateTime Bithday { get; }

        //инициализация значений свойсвт при создании обьекта
        public Person(int cardNumber, string name, DateTime bithday)
        {
            СardNumber = cardNumber;
            Name = name;
            Bithday = bithday;
        }


        //функция подсчета возраста
        public bool calcAge(DateTime date, out int age)
        {
            age = 0;

            if (date < Bithday)
                return false;

            age = date.Year - Bithday.Year;

            if (date.Month < Bithday.Month ||
                (date.Month == Bithday.Month && date.Day < Bithday.Day))
            {
                age--;
            }

            if (age > 150)
            {
                age = 0;
                return false;
            }

            return true;
        }

        //вывод имени и возраста в listBox

        public string displayText
        {
            get
            {
                if ( calcAge(DateTime.Now, out int age))
                    return $"{Name} — {age} лет";

                return $"{Name} — возраст не указан";
            }
        }


    }
}
        
    
    

