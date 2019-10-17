using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Uplift.DataAccess.Data.Repository.IRepository
{
    // type T makes it a generic class - so any object can call it (menu, order etc.)
    // T is a class in this case as we will be using it for the Category class
    public interface IRepository<T> where T : class
    {
        // here a single item/object of class (T) will be called (e.g Category) will be returned
        T Get(int id);

        // gets a list of objects
        IEnumerable<T> GetAll(
            // this is a query that filters for null object
            //https://www.tutorialsteacher.com/linq/linq-expression 
            Expression<Func<T, bool>> filter = null,

            // good for querying from out-memory > remote database, service collections etc
            // IEnumerable good for querying in memory 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,

            string includeProperties = null
            );

        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        void Add(T entity);

        void Remove(int id);

        void Remove(T entity);
    }
}
