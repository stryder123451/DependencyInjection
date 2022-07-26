using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Interfaces
{
    public interface IEmployee<T> where T : class
    {
        public Task<T> FullInfo(int id);
        public Task<bool> Delete(int id);
        public Task<T> Add(T data);
        public Task<T> Update(T data);
    }
}
