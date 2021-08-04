using System;
using System.Collections.Generic;
using System.Text;

namespace Lab15_4
{
    class Graph
    {
        List<Vertex> Vertexes = new List<Vertex>();
        List<Edge> Edges = new List<Edge>();
        public int VertexCount => Vertexes.Count;
        public int EdgeCount => Edges.Count;

        public Graph()
        {

        }

        public void AddVertex(Vertex vertex)
        {
            Vertexes.Add(vertex);
        }

        public void AddEdge(Vertex from, Vertex to)
        {
            var edge = new Edge(from, to);
            Edges.Add(edge);
        }

        //public int[,] GetAdjacencyMatrix()
        //{
        //    var matrix = new int[Vertexes.Count, Edges.Count];

        //    foreach (var edge in Edges)
        //    {
        //        var row = edge.From.Number - 1;
        //        var column = edge.To.Number - 1;

        //        matrix[row, column] = edge.Weight;
        //    }

        //    return matrix;
        //}
        public int[,] GetAdjacencyMatrix()
        {
            var n = VertexCount;
            var matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (AreAdjacent(Vertexes[i], Vertexes[j]))
                    {
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            return matrix;
        }
        public bool AreAdjacent(Vertex nodeA, Vertex nodeB)
        {
            foreach (var edge in Edges)
            {
                if (edge.IsContains(nodeA, nodeB))
                    return true;
            }
            return false;
        }
        public int[,] GetIncidenceMatrix()
        {
            var matrix = new int[Vertexes.Count, Edges.Count];

            for (int i = 0; i < Vertexes.Count; i++)
            {
                for (int j = 0; j < Edges.Count; j++)
                {
                    if (Edges[i].Weight != 0)
                    {
                        if (Vertexes[i] == Edges[j].From)
                        {
                            matrix[i, j] = 1;
                        }
                        else if (Vertexes[i] == Edges[j].To)
                        {
                            matrix[i, j] = -1;
                        }
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            return matrix;
        }
        public Dictionary<int, (Vertex, Vertex)> GetVertexList()
        {
            var dict = new Dictionary<int, (Vertex, Vertex)>();

            for (int i = 0; i < EdgeCount; i++)
            {
                dict.Add(i + 1, (Edges[i].From, Edges[i].To));
            }

            return dict;
        }
        //public List<Vertex> GetVertexList(Vertex vertex)
        //{
        //    var result = new List<Vertex>();

        //    foreach (var edge in Edges)
        //    {
        //        if (edge.From == vertex)
        //        {
        //            result.Add(edge.To);
        //        }
        //    }

        //    return result;
        //}
    }
}
