using TransitiveDependenciesGraph.Data;
using TransitiveDependenciesGraph.Models;


public class TransitiveDependenciesGraphService
{
    private readonly GraphDataRepository _graphData;

    public TransitiveDependenciesGraphService(GraphDataRepository graphData)
    {
        _graphData = graphData;
    }

    public DependenciesGraphOutput DependenciesGraphByName(string dependenciesInput, char separator = ' ')
    {

        if (string.IsNullOrWhiteSpace(dependenciesInput))
        {
            return DependenciesGraphOutput(ResultType.InvalidInput, new Graph());
        }

        var dependencies = dependenciesInput.Split(separator);
        var graphName = dependencies.First();
        var graph = _graphData.GetGraphByName(graphName);

        if (graph is null)
        {
            return DependenciesGraphOutput(ResultType.NoGraphFound, new Graph(), graphName);
        }

        if (graph.GetAllNodes(graphName).Count == 0)
        {
            return DependenciesGraphOutput(ResultType.NoDependencies, graph, graphName);
        }

        return DependenciesGraphOutput(ResultType.Success, graph);
    }

    private static DependenciesGraphOutput DependenciesGraphOutput(ResultType resultType, Graph graph, string graphName = "")
    {
        return resultType switch
        {
            ResultType.InvalidInput => new DependenciesGraphOutput(graph, new ResultMessage(resultType, "Dependencies input cannot be null or empty.")),
            ResultType.NoGraphFound => new DependenciesGraphOutput(graph, new ResultMessage(resultType, $"There is no dependencies definition set for {graphName}.")),
            ResultType.NoDependencies => new DependenciesGraphOutput(graph, new ResultMessage(resultType, $"There are no dependencies defined for {graphName}.")),
            ResultType.Success => new DependenciesGraphOutput(graph, new ResultMessage(resultType)),
            _ => throw new ArgumentException($"{graphName} produced an invalid DependenciesGraphOutput response."),
        };
    }
}
