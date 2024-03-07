using Entities.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation;

public class ProductValidator : AbstractValidator<Product>
{
    //Fluent Validation, doğrulama (validation) kütüphanesidir.Bu kütüphane, özellikle karmaşık doğrulama senaryolarını ele almak için kullanışlıdır. Örneğin, bir formdan gelen verilerin, bir nesnenin belirli bir durumda olması gerektiği gibi kriterlere uygun olup olmadığını kontrol etmek gibi durumlarda sıklıkla kullanılır.
    public ProductValidator()
    {
        RuleFor(p => p.ProductName).NotEmpty();
        RuleFor(p => p.ProductName).MinimumLength(2);
        RuleFor(p => p.UnitPrice).NotEmpty();
        RuleFor(p => p.UnitPrice).GreaterThan(0); //"UnitPrice" adlı bir özelliğin 0'dan büyük olması gerektiğini belirtir.Bu tür bir doğrulama, genellikle girdilerin veya nesnelerin belirli kriterlere uymasını sağlamak için kullanılır. Örneğin, "UnitPrice" negatif bir değer olamaz veya sıfırdan küçük olamazsa bu kuralı kullanabilirsiniz.

        RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); //Eğer bir nesnenin "CategoryId" özelliği 1 ise, o zaman "UnitPrice" özelliğinin 10 veya daha büyük olması gerekmektedir.
        RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı"); // Kendimiz StartWithA diye method oluşturduk
    }

    private bool StartWithA(string arg)
    {
        return arg.StartsWith("A");
    }
}
