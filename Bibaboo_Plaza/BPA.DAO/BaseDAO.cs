using BPA.DAO.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPA.DAO
{
    public class BaseDAO<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseDAO()
        {
            _context = new ApplicationDbContext();
            _dbSet = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }
        public T? GetById(Guid id)
        {
            return _dbSet.Find(id);
        }
        public void Add(T entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }
        public void Update(T entity)
        {
                _dbSet.Update(entity);
                _context.SaveChanges();        
        }
        public void Update2(T entity, T baseValue)
        {
            try
            {
                _context.Entry(baseValue).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
            }
        }
        public void Delete(T entity)
        {
            try
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
