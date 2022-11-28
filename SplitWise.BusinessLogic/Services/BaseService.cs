using Microsoft.EntityFrameworkCore;
using SplitWise.BusinessLogic.Abstraction;
using SplitWise.BusinessLogic.CustomExceptions;
using SplitWise.Domain.Enteties;
using SplitWise.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.BusinessLogic.Services
{
    public abstract class BaseService<T> : IBaseServise<T> where T : class
    {
        protected readonly splitwiseContext _db;
        public BaseService(splitwiseContext db)
        {
            _db = db;
        }

        public async Task<bool> DeleteAsync(T item)
        {
            if (item == null)
                throw new ArgumentNullException("Invalid data.");

            _db.Entry(item).State = EntityState.Deleted;
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetByKeysAsync(params object[] keyValues)
        {
            return await _db.Set<T>().FindAsync(keyValues);
        }

        public async Task<T> SaveAsync(T item)
        {
            if (item == null)
                throw new ArgumentNullException("Invalid data.");

            _db.Update<T>(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task<T> UpdateAsync(T item, params object[] keyValues)
        {
            if (item == null)
                throw new ArgumentNullException("Invalid data.");

            var oldEntity = await _db.Set<T>().FindAsync(keyValues);

            if (oldEntity == null)
                throw new EntityNotFoundException($"{typeof(T).Name} not found.", (int)keyValues[0]);

            _db.Entry(oldEntity).CurrentValues.SetValues(item);
            await _db.SaveChangesAsync();
            return oldEntity;
        }
    }
}
