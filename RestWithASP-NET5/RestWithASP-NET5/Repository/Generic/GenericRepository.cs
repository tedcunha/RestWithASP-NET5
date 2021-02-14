using Microsoft.EntityFrameworkCore;
using RestWithASP_NET5.Model.Base;
using RestWithASP_NET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP_NET5.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySqlContext _context;
        private DbSet<T> dataSet;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool Delete(int Id)
        {
            bool valido = false;
            var result = dataSet.SingleOrDefault(p => p.Id == Id);
            if (result != null)
            {
                try
                {
                    dataSet.Remove(result);
                    _context.SaveChanges();
                    valido = true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return valido;
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T FindByID(int Id)
        {
            return dataSet.SingleOrDefault(p => p.Id == Id);
        }

        public T Update(T item)
        {
            if (!Exists(item.Id))
            {
                return null;
            }

            var result = dataSet.SingleOrDefault(p => p.Id == item.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            } else
            {
                return null;
            }
        }

        public bool Exists(int Id)
        {
            return dataSet.Any(p => p.Id == Id);
        }
    }
}
