using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validation.FluentValidation
{
    public class CardValidation:AbstractValidator<Card>
    {
        public CardValidation()
        {
            RuleFor(p => p.CardOwnerName).NotEmpty();
            RuleFor(p => p.CardOwnerName).MinimumLength(8);
            RuleFor(p => p.CardCvv).NotEmpty();
            RuleFor(p=>p.CardNumber).NotEmpty();
            RuleFor(p => p.CardNumber).GreaterThan(0);
        }
    }
}
