using System.Reflection;

namespace DesignPatterns.Mediator
{
    public static class Mediator
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, Assembly? assemlby =null)
        {
            assemlby ??= Assembly.GetCallingAssembly();

            services.AddScoped<ISender, Sender>();

            //tipo base de request handlers que sabemos que serão usados para receberem mensagens do mediator
            var handlerInterfaceType = typeof(IRequestHandler<,>);

            var handlerTypes = assemlby.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract) //os tipos são apenas classes concretas
                .SelectMany(type => type.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterfaceType) //encontrando interfaces do nosso tipo de Handler
                    .Select(i => new { Interface = i, Implementation = type })); //colocando elas em uma lista anônima com a interface e a implementação

            foreach (var handler in handlerTypes)
            {
                services.AddScoped(handler.Interface, handler.Implementation); //registrando a interface e a implementação no container de DI
            }

            return services;
        }
    }
}
