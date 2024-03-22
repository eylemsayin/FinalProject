using Core.DataAccess;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstracts
{
    public interface IProductDal :IEntityRepository<Product> //Dal => Data Acces Layer yani IProductDal => Dal katmanında demek.
    {
        List<ProductDetailDTO> GetProductDetails();
       
    }

    //Code Refactoring
}
