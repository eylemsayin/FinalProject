using Business.Abstracts;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using Entities.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        // [LogAspet]--AOP
        //[Validate]

        //AOP => Örneğin metotlarınızı loglamak istiyorsunuz,bir metot başında sonunda veya hata verdiğinde loglanır.Uygulamanın başında sonunda hata verdiğinde çalışmasını istediğin kodların varsa onları aop yöntemi ile design edersin.interception anlamı araya girmek.

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
          
            //validation -->adın min max kaç karakter olmalı gibi...
            //business rules--> bankada kredi verirken kişinin krediye uygun olup olmaması gibi...

            //ValidationTool.Validate(new ProductValidator(), product);
            if(CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            {
                if (CheckIfProductNameExists(product.ProductName).Success)
                {
                    _productDal.Add(product);
                    return new SuccessResult(Messages.ProductAdded);
                }
               
            }
            return new ErrorResult();

            _productDal.Add(product);

                return new SuccessResult(Messages.ProductAdded);

            
           
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları 
            //Yetkisi var mı?
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>>  GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>( _productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>>  GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.UnitPrice <= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDTO>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDTO>> (_productDal.GetProductDetails());
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;

            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);

        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;

            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();

            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
