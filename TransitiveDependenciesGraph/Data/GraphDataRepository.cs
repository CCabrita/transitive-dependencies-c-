namespace TransitiveDependenciesGraph.Data;
public class GraphDataRepository(IEnumerable<Node> nodes)
{
    private readonly IEnumerable<Node> _nodes = nodes;

    public Graph? GetGraphByName(string name)
    {
        var nodeName = _nodes.FirstOrDefault(node => node.Name == name);

        if (nodeName is null)
        {
            return null;
        }

        var graph = new Graph();
        graph.AddNode(nodeName);
        return graph;
    }
}