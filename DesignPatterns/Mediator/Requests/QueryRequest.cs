using DesignPatterns.Mediator;

namespace DesignPatterns.Mediator.Requests
{
    public record QueryRequest : IRequest<List<string>>;
}
