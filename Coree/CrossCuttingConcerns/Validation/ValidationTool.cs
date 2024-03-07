using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation;

public static class ValidationTool
{
    //Cross Cutting Concerns => Uygulamayı dikine kesen ilgi alanları örneğin loglama, yetkilendirme (authorization), hata yönetimi (error handling), oturum yönetimi (session management), caching gibi işlevler "cross-cutting concerns" olarak adlandırılır. Bunlar her yerde kullanıldığı için core da yazarız.
    public static void Validate(IValidator validator, object entity)
    {
        var context = new ValidationContext<Object>(entity);
       
        var result = validator.Validate(context);

        if (!result.IsValid) //Geçersizse
        {
            throw new FluentValidation.ValidationException(result.Errors);
        }
    }
}
