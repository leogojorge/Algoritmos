
namespace DesignPatterns.Mediator
{
    public class Sender : ISender
    {
        private IServiceProvider _serviceProvider;

        public Sender(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            //encontra o tipo do handler dinamicamente para o request e o TResponse correspondente
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            
            //resolve o handler do tipo encontrado
            dynamic handler = _serviceProvider.GetRequiredService(handlerType);

            //chama o método Handle do handler correspondente
            return handler.Handle((dynamic)request, cancellationToken);
        }
    }
}
