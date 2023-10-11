using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_2910
{
    public class Street
    {
        public int Number { get; set; } = 0;
        public string Name { get; set; } = string.Empty;

        public Street() { }
        public Street(int number, string name)
        {
            Number = number;
            Name = name;
        }
    }
}
