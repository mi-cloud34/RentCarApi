using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validation.FluentValidation
{
    public class PaymentValidation:AbstractValidator<Payment>
    {
        public PaymentValidation()
        {
            RuleFor(p => p.Total).NotEmpty();
           
           
            RuleFor(p => p.Total).GreaterThan(0);
        }
    }
}
