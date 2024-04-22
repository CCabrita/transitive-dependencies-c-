namespace TransitiveDependenciesGraph;

public class Node(string name)
{
    public HashSet<Node> Children { get; } = [];
    public string Name { get; } = name;

    public bool TryAddChild(Node n)
    {
        // If adding a child creates a cyclic dependency, return false.
        if (n.AllDescendants().Contains(this))
        {
            return false;
        }
        else
        {
            Children.Add(n);
            return true;
        }
    }

    public HashSet<Node> AllDescendants()
    {
        var nodeDescendants = new HashSet<Node>();

        foreach (var child in Children)
        {
            nodeDescendants.Add(child);
            nodeDescendants.UnionWith(child.AllDescendants());
        }
        return nodeDescendants;
    }
    public override string ToString()
    {
        return $"{Name}  {string.Join(" ", AllDescendants().OrderBy(x => x.Name).Select(x => x.Name))}";
    }
}
