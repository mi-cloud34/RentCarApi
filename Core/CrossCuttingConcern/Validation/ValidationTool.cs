using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcern.Validation
{
    public static class ValidationTool
    {
       public static void Validate(IValidator validator,object entity)
        {
            var contect = new ValidationContext<object>(entity);
            //ProductValidator productValidator = new ProductValidator();
            var result = validator.Validate(contect);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
}
}
