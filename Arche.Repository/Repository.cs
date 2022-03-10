using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arche.Domain;
using Arche.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace Arche.Repository
{
    public class Repository<T>:IRepository<T> where T:BaseEntity
    {
        private readonly ApplicationDb _db;
        private DbSet<T> entities;
        public Repository(ApplicationDb context)
        {
            this._db = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        T IRepository<T>.Get(int Id)
        {
            return entities.SingleOrDefault(x => x.Id == Id);
        }

        void IRepository<T>.Insert(T entity)
        {
            if (entity == null)
            {
                throw new NotImplementedException();
            }
            entities.Add(entity);
            _db.SaveChanges();
        }

        void IRepository<T>.Update(T entity)
        {
            if (entity == null)
            {
                throw new NotImplementedException();
            }
            _db.SaveChanges();
        }

        void IRepository<T>.Delete(T entity)
        {
            if (entity == null)
            {
                throw new NotImplementedException();
            }
            entities.Remove(entity);
            _db.SaveChanges();
        }

        void IRepository<T>.Remove(T entity)
        {
            if (entity == null)
            {
                throw new NotImplementedException();
            }
            entities.Remove(entity);
            
        }

        void IRepository<T>.SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
