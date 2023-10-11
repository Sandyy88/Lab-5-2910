using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_2910
{
    internal class RandomPerson
    {
        public List<ResultsR> Results { get; set; } = new List<ResultsR>();

        public RandomPerson(List<ResultsR> results)
        {
            Results = results;
        }

        public override string ToString()
        {
            string s = "";
            s += "\n\t\t\t\tDATA:";
            s += $"{String.Join(',', Results)}";

            return s;
        }
    }
}
