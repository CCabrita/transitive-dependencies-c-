using TransitiveDependenciesGraph.Data;
using TransitiveDependenciesGraph.Models;

namespace TransitiveDependenciesTests.Unit;


public class TransitiveDependenciesServiceTests
{
    private readonly GraphDataRepository _graphData;
    private readonly TransitiveDependenciesService _sut;
    public TransitiveDependenciesServiceTests()
    {
        _graphData = new GraphDataRepository(TestData.Nodes);
        _sut = new TransitiveDependenciesService(_graphData);
    }

    [Theory]
    [InlineData("A B C", "A  B C E F G H")]
    [InlineData("B C E", "B  C E F G H")]
    [InlineData("C", "C  G")]
    [InlineData("D A F", "D  A B C E F G H")]
    [InlineData("E", "E  F H")]
    [InlineData("F", "F  H")]
    [InlineData("A B", "A  B C E F G H")]
    [InlineData("B C", "B  C E F G H")]
    [InlineData("C A", "C  G")]
    public void DependenciesGraph_ShouldBe_Correct(string input, string expectedOutput)
    {

        var result = _sut.DependenciesGraphByName(input);

        Assert.NotNull(result);
        Assert.NotNull(result.ResultMessage);
        Assert.Equal(ResultType.Success, result.ResultMessage.ResultType);
        Assert.Equal(expectedOutput, result.Data.ToString());

    }

    [Fact]
    public void DependenciesGraph_InvalidInput()
    {
        var result = _sut.DependenciesGraphByName(string.Empty);

        Assert.NotNull(result);
        Assert.Equivalent(new Graph(), result.Data);
        Assert.NotNull(result.ResultMessage);
        Assert.Equal(ResultType.InvalidInput, result.ResultMessage.ResultType);
        Assert.Equal("Dependencies input cannot be null or empty.", result.ResultMessage.Message);
    }

    [Fact]
    public void DependenciesGraph_NoGraphFound()
    {
        var result = _sut.DependenciesGraphByName("Z");

        Assert.NotNull(result);
        Assert.Equivalent(new Graph(), result.Data);
        Assert.NotNull(result.ResultMessage);
        Assert.Equal(ResultType.NoGraphFound, result.ResultMessage.ResultType);
        Assert.Equal("There is no dependencies definition set for Z.", result.ResultMessage.Message);
    }


    [Fact]
    public void DependenciesGraph_NoDependenciesFound()
    {
        var result = _sut.DependenciesGraphByName("I");

        Assert.NotNull(result);
        Assert.Equivalent(new Graph(), result.Data);
        Assert.NotNull(result.ResultMessage);
        Assert.Equal(ResultType.NoDependencies, result.ResultMessage.ResultType);
        Assert.Equal("There are no dependencies defined for I.", result.ResultMessage.Message);
    }
}