using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.BusinessLogic.Abstraction
{
    public interface IBaseServise<T> where T : class
    {
        public Task<IEnumerable<T>> GetAsync();
        public Task<T> GetByKeysAsync(params object[] keyValues);
        public Task<bool> DeleteAsync(T item);
        public Task<bool> DeleteAsync(params object[] keyValues);
        public Task<T> SaveAsync(T item);
        public Task<T> UpdateAsync(T item, params object[] keyValues);
    }
}
