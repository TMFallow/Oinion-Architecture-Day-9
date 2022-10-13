using Microsoft.EntityFrameworkCore;
using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;

        private DbSet<T> entities;

        string errorString = string.Empty;

        public Repository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        
        public void Delete(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            else
            {
                entities.Remove(entity);
                context.SaveChanges();
            }
        }

        public T Get(long? id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            { 
                throw new ArgumentNullException("Entity");
            }
            else
            {
                entities.Add(entity);
                context.SaveChanges();
            }
        }

        public void Remove(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            context.SaveChanges();
        }
    }
}
