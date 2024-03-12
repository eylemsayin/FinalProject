﻿using Core.Utilities.Results;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IProductService
{
    IDataResult<List<Product>> GetAll();
    IDataResult<List<Product>> GetAllByCategoryId(int id);
    IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

    IDataResult<List<ProductDetailDTO>> GetProductDetails();
    IDataResult<Product> GetById(int productId);

    IResult Add(Product product);
    IResult Update(Product product);
}
