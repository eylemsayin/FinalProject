using Entities.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    //Generic constraint: Generic kısıtlama where T:class, IEntity demek IEntity olabilir ya da onu implemete eden class
    //class referans tip olabilir.
    //IEntity: IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new(): new'lenebilir olmalı demek
    public interface IEntitiyRepository<T> where T:class, IEntity, new()
    {

        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        List<Product> GetAllByCategory(int categoryId);
    }
}
