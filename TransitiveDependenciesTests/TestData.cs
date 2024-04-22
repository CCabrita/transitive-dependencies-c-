using TransitiveDependenciesGraph;

namespace TransitiveDependenciesTests;

internal class TestData
{
    public static IEnumerable<Node> Nodes
    {
        get
        {

            var nodeA = new Node("A");
            var nodeB = new Node("B");
            var nodeC = new Node("C");
            var nodeD = new Node("D");
            var nodeE = new Node("E");
            var nodeF = new Node("F");
            var nodeG = new Node("G");
            var nodeH = new Node("H");
            var nodeI = new Node("I"); // not part of the original test data spec, here to cater for the edge case for when a token does not depend on anything  


            nodeA.TryAddChild(nodeC);
            nodeC.TryAddChild(nodeG);
            nodeA.TryAddChild(nodeB);
            nodeB.TryAddChild(nodeC);
            nodeB.TryAddChild(nodeE);
            nodeD.TryAddChild(nodeA);
            nodeD.TryAddChild(nodeF);
            nodeE.TryAddChild(nodeF);
            nodeE.TryAddChild(nodeH);
            nodeF.TryAddChild(nodeH);
            nodeC.TryAddChild(nodeA); //Added for Part 2

            return new List<Node>()
        {
            nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, nodeH, nodeI
        };
        }
    }
}
