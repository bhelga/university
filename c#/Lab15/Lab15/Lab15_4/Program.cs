using System;
using System.Collections.Generic;

namespace Lab15_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            var a = new Vertex('a');
            var b = new Vertex('b');
            var c = new Vertex('c');
            var d = new Vertex('d');
            var e = new Vertex('e');
            var f = new Vertex('f');

            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddVertex(c);
            graph.AddVertex(d);
            graph.AddVertex(e);
            graph.AddVertex(f);

            graph.AddEdge(a, b);
            graph.AddEdge(b, c);
            graph.AddEdge(c, f);
            graph.AddEdge(e, f);
            graph.AddEdge(d, e);
            graph.AddEdge(a, d);
            graph.AddEdge(b, d);
            graph.AddEdge(d, c);
            graph.AddEdge(a, e);
            graph.AddEdge(b, e);
            graph.AddEdge(b, f);
            graph.AddEdge(c, e);

            Console.WriteLine("Adjacency Matrix");
            int[,] adjacencyMatrix = graph.GetAdjacencyMatrix();
            for (int i = 0; i < graph.VertexCount; i++)
            {
                for (int j = 0; j < graph.VertexCount; j++)
                {
                    string print = String.Format("{0,3} ", adjacencyMatrix[i, j]);
                    Console.Write(print);
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n\nIncidence Matrix");
            int[,] incidenceMatrix = graph.GetIncidenceMatrix();
            for (int i = 0; i < graph.VertexCount; i++)
            {
                for (int j = 0; j < graph.EdgeCount; j++)
                {
                    string print = String.Format("{0,3} ", incidenceMatrix[i, j]);
                    Console.Write(print);
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n\nVertex List");
            Dictionary<int, (Vertex, Vertex)> VertexList = graph.GetVertexList();
            foreach (var item in VertexList)
            {
                Console.WriteLine($"{item.Key} : ({item.Value.Item1}, {item.Value.Item2})");
            }
        }
    }
}
