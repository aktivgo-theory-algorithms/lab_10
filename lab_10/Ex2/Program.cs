using Ex2;

const string fileName = "graph_1.txt";
var graph = new Graph(fileName);
Console.WriteLine();
Console.WriteLine(graph.GetNewK());
Console.WriteLine(Graph.GetEdgeString(graph.GetInvertGraph()));