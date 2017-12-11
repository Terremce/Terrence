using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terrence.Domain;
using Terrence.IDao;
using System.Data.Entity;
using PagedList;
using Terrence.DataMapping;

namespace Terrence.Dao
{
    public class DaoBase<T> : IDisposable, IDaoBase<T> where T : DomainBase
    {
        protected readonly DbContext DbContext;

        public DaoBase()
        {
            DbContext = new DataBaseContext();
        }

        public int Insert(T entity)
        {
            entity.CreateTime = DateTime.Now;
            DbContext.Entry<T>(entity);
            DbContext.Set<T>().Add(entity);
            return SaveChanges();
        }

        public bool Delete(int id)
        {
            T domain = DbContext.Set<T>().FirstOrDefault(s => s.Id == id);
            if (domain == null)
                return false;
            DbContext.Set<T>().Attach(domain);
            DbContext.Set<T>().Remove(domain);
            return SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            DbContext.Set<T>().Attach(entity);
            DbContext.Set<T>().Remove(entity);
            return SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            DbContext.Set<T>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            return SaveChanges() > 0;
        }

        public T SelectById(int id)
        {
            return DbContext.Set<T>().FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> SelectAll()
        {
            return DbContext.Set<T>();
        }

        public IPagedList<T> SelectPageList(int? pageIndex, int? pageSize)
        {
            IEnumerable<T> list = DbContext.Set<T>().OrderByDescending(s => s.CreateTime);
            return list.ToPagedList(pageIndex ?? 1, pageSize ?? 10);
        }

        private int SaveChanges()
        {
            try
            {
                int result = DbContext.SaveChanges();
                return result;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                string message = "error:";
                if (ex.InnerException == null)
                    message += ex.Message + ",";
                else if (ex.InnerException.InnerException == null)
                    message += ex.InnerException.Message + ",";
                else if (ex.InnerException.InnerException.InnerException == null)
                    message += ex.InnerException.InnerException.Message + ",";
                throw new Exception(message);
            }
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

    }
}
