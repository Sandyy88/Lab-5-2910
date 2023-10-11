using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_2910
{
    public class Name
    {
        public string Title { get; set; } = string.Empty;
        public string First { get; set; } = string.Empty;
        public string Last { get; set; } = string.Empty;

        public Name() { }
        public Name(string title, string first, string last)
        {
            Title = title;
            First = first;
            Last = last;
        }

        public override string ToString()
        {
            string s = " ";
            s += $"\n\n\tNAME INFO:" +
                $"\n\t\tTitle: {Title}" +
                $"\n\t\tFirst: {First}" +
                $"\n\t\tLast: {Last}";

            return s;
        }
    }
}
