using DesignPatterns.Mediator;

namespace DesignPatterns.Features
{
    public class GetInfoRequestHandler : IRequestHandler<QueryRequest, List<string>>
    {
        public Task<List<string>> Handle(QueryRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new List<string>
                {
                    "This is a sample response from the GetInfo feature.",
                    "You can customize this response as needed."
                });
        }
    }
}
