namespace TransitiveDependenciesGraph.Models
{
    public record ResultMessage(ResultType ResultType, string Message="");
    public enum ResultType
    {
        Success,
        NoGraphFound,
        InvalidInput,
        NoDependencies
    }
}