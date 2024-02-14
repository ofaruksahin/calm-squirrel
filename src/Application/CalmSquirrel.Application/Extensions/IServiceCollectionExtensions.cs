using CalmSquirrel.Domain.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalmSquirrel.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection RegisterOptions(this IServiceCollection @this, IConfiguration configuration)
        {
            AppDomain
               .CurrentDomain
               .GetAssemblies()
               .Select(assembly => assembly.GetTypes())
               .Select(types =>
                   types.Where(type =>
                           type.GetInterface(nameof(IOptions)) is not null
                       )
                   )
               .SelectMany(types => types)
               .ToList()
               .ForEach(optionType =>
               {
                   var optionInstance = (IOptions)Activator.CreateInstance(optionType);
                   configuration.GetSection(optionInstance.Key).Bind(optionInstance);

                   @this.AddSingleton(optionType, optionInstance);
               });

            return @this;
        }
    }
}
