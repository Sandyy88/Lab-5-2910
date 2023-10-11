using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_2910
{
    public class ID
    {
        public string Name { get; set; } = string.Empty;
        public object Value { get; set; } = string.Empty;

        public ID() { }
        public ID(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            string s = " ";
            s += $"\n\n\tID INFO:" +
               $"\n\t\tName: {Name}" +
               $"\n\t\tValue: {Value}";

            return s;
        }
    }
}
