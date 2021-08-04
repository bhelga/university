class Vertex:
    def __init__(self, name) -> None:
        self.name = name

    def toStr(self):
        return f"{self.name}"

    def __repr__(self):
        return f"{self.name}"


class Edge:
    def __init__(self, ffrom, to, weight=0) -> None:
        self.ffrom = Vertex(ffrom)
        self.to = Vertex(to)
        self.weight = weight

    def Contains(self, elem1, elem2):
        return elem1 == self.ffrom.name and elem2 == self.to.name


class Graph:
    def __init__(self, vertexes=[], edges=[]) -> None:
        self.vertexes = vertexes
        self.edges = edges

    def add_vertex(self, vertex):
        self.vertexes.append(vertex)

    def add_edge(self, ffrom, to, weight=1):
        self.edges.append(Edge(ffrom, to, weight))

    def are_adjacent(self, item1, item2):
        for edge in self.edges:
            if (edge.Contains(item1, item2)):
                return True
        return False

    def get_adjacency_matrix(self):
        n = len(self.vertexes)
        matrix = [[0] * n for i in range(n)]
        for i in range(n):
            for j in range(n):
                if (self.are_adjacent(self.vertexes[i], self.vertexes[j])):
                    matrix[i][j] = 1
                else:
                    matrix[i][j] = 0
        return matrix

    def get_inccidence_matrix(self):
        matrix = [[0] * len(self.edges) for i in range(len(self.vertexes))]
        for i in range(len(self.vertexes)):
            for j in range(len(self.edges)):
                if self.edges[i].weight != 0:
                    if self.vertexes[i] == self.edges[j].ffrom.name:
                        matrix[i][j] = 1
                    elif self.vertexes[i] == self.edges[j].to.name:
                        matrix[i][j] = -1
                else:
                    matrix[i][j] = 0
        return matrix

    def get_vertex_list(self):
        dictionary = {}
        for i in range(len(self.edges)):
            dictionary.update({i + 1: (self.edges[i].ffrom.toStr(), self.edges[i].to.toStr())})
        return dictionary


graph = Graph()

a = Vertex('a')
b = Vertex('b')
c = Vertex('c')
d = Vertex('d')
e = Vertex('e')
f = Vertex('f')

graph.add_vertex(a)
graph.add_vertex(b)
graph.add_vertex(c)
graph.add_vertex(d)
graph.add_vertex(e)
graph.add_vertex(f)

graph.add_edge(a, b)
graph.add_edge(b, c)
graph.add_edge(c, f)
graph.add_edge(e, f)
graph.add_edge(d, e)
graph.add_edge(a, d)
graph.add_edge(b, d)
graph.add_edge(d, c)
graph.add_edge(a, e)
graph.add_edge(b, e)
graph.add_edge(b, f)
graph.add_edge(c, e)

print("Adjacency Matrix")
adjacency_matrix = graph.get_adjacency_matrix()
for row in adjacency_matrix:
    print(' '.join([str(elem) for elem in row]))

print("\n\nIncidence Matrix")
incidence_matrix = graph.get_inccidence_matrix()
for row in incidence_matrix:
    print(' '.join(["{0:>3}".format(str(elem)) for elem in row]))

print("\n\nVertex List")
vertex_list = graph.get_vertex_list()
for i, j in vertex_list.items():
    print(i, j)





