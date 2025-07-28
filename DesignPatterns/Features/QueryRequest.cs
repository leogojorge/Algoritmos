using DesignPatterns.Mediator;

namespace DesignPatterns.Features
{
    public record QueryRequest : IRequest<List<string>>;
}
