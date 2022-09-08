using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        Type Get<Type>(String key);
        object Get(String key);
        void Add(String key, object value, int duration);
        bool IsAdd(String key);
        void Remove(String key);
        void RemoveByPattern(String pattern); //with regex
    }
}
