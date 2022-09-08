using Bussines.Abstract;
using Bussines.BussinesAspects.Autofac;
using Bussines.Constants;
using Bussines.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Payments;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class CardManager : ICardService
    {
        ICardDal _cardDal;
        public CardManager(ICardDal cardDal)
        {
            _cardDal=cardDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CardValidation))]
       
        public IResult Add(Card card)
        {
            _cardDal.Add(card);
            return new  SuccessResult("Card eklendi");
        }
        [CacheRemoveAspect("ICardService.Get")]
        public IResult Delete(Card card)
        {
            _cardDal.Delete(card);
            return new SuccessResult("Card silindi");
        }

        public IDataResult<List<Card>> GetAll()
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll());
        }

        public IDataResult<Card> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<Card>(_cardDal.Get(c=>c.CustomerId==customerId),Message.CardGetByIdCustomer);
        }

        public IResult Payment(Card card, int carId)
        {
            throw new NotImplementedException();
        }

        /* public IResult Payment(Card card, int carId)
         {
             //Core.Utilities.Payment.Payment.Pay(creditCard);
             //return new SuccessResult("Ödeme başarılı");
             return new Paymets(Card);
         }*/

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CardValidation))]
        public IResult Update(Card card)
        {
            _cardDal.Update(card);
            return new SuccessResult("Ürün Güncellendi");
        }
    }
}
