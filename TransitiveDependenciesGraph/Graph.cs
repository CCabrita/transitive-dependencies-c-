using TransitiveDependenciesGraph;

public class Graph
{
    private readonly Dictionary<string, Node> nodesMap = [];
   
    
    public Graph AddNode(Node node)
    {
        nodesMap.TryAdd(node.Name, node);
        return this;
    }


    public HashSet<Node> GetAllNodes(string name)
    {
       return this.nodesMap[name].AllDescendants();
    }


    public override string ToString()
    {
        foreach (var name in nodesMap.Keys)
        {
           return nodesMap[name].ToString();
        }

        return "";
    }
}
