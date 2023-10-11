using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_2910
{   public class DOB
    {
        public string Date { get; set; } = string.Empty;
        public int Age { get; set; } = 0;

        public DOB() { }
        public DOB(string date, int age)
        {
            Date = date;
            Age = age;
        }
    }
}
