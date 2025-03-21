
using GenAI_ImageGenerator.Factory.Interfaces;

namespace GenAI_ImageGenerator.Factory
{
    public class AbstractFactory<T> : IAbstractFactory<T> where T : class
    {
        private readonly Func<T> _factory;

        public AbstractFactory(Func<T> factory) => _factory = factory;

        public T Create() => _factory();
    }
}
