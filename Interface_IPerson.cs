using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public interface IPerson
    {
        int СardNumber { get; }
         string Name { get; }
         DateTime Bithday { get; }

         string displayText { get; }
         bool calcAge(DateTime date, out int age);
    }
   
}
