using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int calcAge(DateTime date) {
        int age = date.Year - Bithday.Year;
            if (date.Month < Bithday.Month || (date.Month == Bithday.Month && date.Day < Bithday.Day))
        {
            age--;
        }
        
        return age;
        }


        //переопределение tostring для нормального вывода записей в listbox
        public override string ToString()
        {
            return $"{Name} - {calcAge(DateTime.Now)} лет";

        }
    }
}
            
    
    

