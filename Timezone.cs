using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_2910
{
    public class Timezone
    {
        public string Offset { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Timezone (string offset, string description)
        {
            Offset = offset;
            Description = description;
        }
    }
}
