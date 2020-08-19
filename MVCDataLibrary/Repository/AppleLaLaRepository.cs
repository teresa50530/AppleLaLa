using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDataLibrary.DB_Model;

namespace MVCDataLibrary.Repository
{
    public class AppleLaLaRepository<T> where T : class
    {
        public AppleLaLaModel _context;

        public AppleLaLaRepository(AppleLaLaModel context)
        {
            if(context == null)
            {
                throw new ArgumentException();
            }
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
    }
}
