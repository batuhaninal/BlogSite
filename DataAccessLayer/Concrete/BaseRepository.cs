﻿using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class BaseRepository<T> : IBaseDal<T> where T : class
    {
        public void Delete(T entity)
        {
            using (var c = new Context())
            {
                c.Remove(entity);
                c.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            using (var c = new Context())
            {
                return c.Set<T>().ToList();
            }
        }

        public T GetById(int id)
        {
            using (var c = new Context())
            {
                return c.Set<T>().Find(id);
            }
        }

        public void Insert(T entity)
        {
            using (var c = new Context())
            {
                c.Add(entity);
                c.SaveChanges();
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            using (var c = new Context())
            {
                return c.Set<T>().Where(filter).ToList();
            }
        }

        public void Update(T entity)
        {
            using (var c = new Context())
            {
                c.Update(entity);
                c.SaveChanges();
            }
        }
    }
}
