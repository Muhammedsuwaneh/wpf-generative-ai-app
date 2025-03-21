using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAI_ImageGenerator.Factory.Interfaces
{
    public interface IAbstractFactory<T> where T : class
    {
        T Create();
    }
}
