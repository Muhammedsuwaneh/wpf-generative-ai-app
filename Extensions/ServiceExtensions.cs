

using GenAI_ImageGenerator.Factory;
using GenAI_ImageGenerator.Factory.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GenAI_ImageGenerator.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterService<T>(this IServiceCollection services) where T : class
        {
            services.AddTransient<T>(); ;
            services.AddSingleton<Func<T>>(x => () => x.GetService<T>()!);
            services.AddSingleton<IAbstractFactory<T>, AbstractFactory<T>>();
        }
    }
}
