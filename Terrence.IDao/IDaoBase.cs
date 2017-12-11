using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Terrence.IDao
{
    public interface IDaoBase<T> where T:class
    {
        int Insert(T entity);

        bool Delete(int id);

        bool Delete(T entity);

        bool Update(T entity);

        T SelectById(int id);

        IEnumerable<T> SelectAll();

        IPagedList<T> SelectPageList(int? pageIndex = 1, int? pageSize = 10);
    }
}
