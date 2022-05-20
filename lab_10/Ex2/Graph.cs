using System.Text;

namespace Ex2;

public class Graph
{
    /// <summary>
    /// Матрица смежности.
    /// </summary>
    private int[,] _adjacencyMatrix;

    /// <summary>
    /// Количесво рёбер.
    /// </summary>
    private int _countVert;

    /// <summary>
    /// Число - решение задачи о клике.
    /// </summary>
    private int _k;

    public Graph(string fileName)
    {
        var linesList = File.ReadAllLines(fileName);
        _k = int.Parse(linesList[0]);
        var listGraph = linesList
            .Skip(1)
            .Select(item =>
        {
            var edge = item.Split(" ").Select(int.Parse);
            return new {First = edge.First(), Second = edge.Last()};
        });

        var countVert1 = listGraph.Max(item => item.First);
        var countVert2 = listGraph.Max(item => item.Second);

        _countVert = Math.Max(countVert1, countVert2);

        _adjacencyMatrix = new int[_countVert, _countVert];

        foreach (var edge in listGraph)
        {
            _adjacencyMatrix[edge.First - 1, edge.Second - 1] = 1;
        }
    }

    /// <summary>
    /// Инвертирование значений матрицы смежности графа.
    /// </summary>
    /// <returns></returns>
    public int[,] GetInvertGraph()
    {
        var result = new int[_countVert, _countVert];

        for (var i = 0; i < _countVert; i++)
        {
            for (var j = 0; j < _countVert; j++)
            {
                if (i == j)
                {
                    continue;
                }

                result[i, j] = (_adjacencyMatrix[i, j] + 1) %2;
            }
        }

        return result;
    }

    public override string ToString()
    {
        return GetEdgeString(_adjacencyMatrix);
    }

    /// <summary>
    /// Перевод графа в строку.
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns></returns>
    public static string GetEdgeString(int[,] matrix)
    {
        var result = new StringBuilder();

        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = i+1; j < matrix.GetLength(0); j++)
            {
                if (matrix[i,j] == 1)
                {
                    result.AppendLine($"{i + 1} {j + 1}");
                }
            }
        }

        return result.ToString();
    }
    
    /// <summary>
    /// Получение количесва вершин в задаче о ВП.
    /// </summary>
    /// <returns></returns>
    public int GetNewK()
    {
        return _countVert-_k;
    }
}