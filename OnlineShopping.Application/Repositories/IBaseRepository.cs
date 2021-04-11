using OnlineShopping.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Application.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task<ICollection<TEntity>> GetAll();
        Task<TEntity> Find(int Id);
        Task<TEntity> Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity);
        Task<int> SaveChanges();
    }
}
