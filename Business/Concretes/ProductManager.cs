using Business.Abstracts;
using Entities.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ProductManager : IProductService

    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
            
        }
        public List<Product> GetAll()
        {
            //iş kodları 
            //Yetkisi var mı?
            return _productDal.GetAll();
        }
    }
}
