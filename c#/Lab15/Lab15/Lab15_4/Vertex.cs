using System;
using System.Collections.Generic;
using System.Text;

namespace Lab15_4
{
    class Vertex
    {
        public char Name { get; set; }
        public int Number { get; set; }

        public Vertex(char name)
        {
            Name = name;
            Number++;
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
