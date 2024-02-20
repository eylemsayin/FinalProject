using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstracts
{
    public interface IProductDal :IEntitiyRepository<Product> //Dal => Data Acces Layer yani IProductDal => Dal katmanında demek.
    {
       
    }
}
