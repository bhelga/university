using System;
using System.Collections.Generic;
using System.Text;

namespace Lab15_4
{
    class Edge
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }
        public bool Orienred { get; set; }
        public int Orientation { get; set; }
        public int Weight { get; set; }

        public Edge(Vertex from, Vertex to, int orietation = 1, int weight = 1)
        {
            From = from;
            To = to;
            Weight = weight;
            Orientation = orietation;
        }
        public bool IsContains(Vertex a, Vertex b)
        {
            return a.Equals(From) && b.Equals(To);
        }

        public override string ToString()
        {
            return $"({From}, {To})";
        }
    }
}
