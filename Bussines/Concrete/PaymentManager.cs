using Bussines.Abstract;
using Bussines.BussinesAspects.Autofac;
using Bussines.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(PaymentValidation))]
      
        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult("Marka eklendi");
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult("Marka silindi");
        }

      

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(), "Markalar listelendi");
        }

        public IDataResult<Payment> Get(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(c => c.PaymentId == id), "Marka idye göre getirildi");
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(PaymentValidation))]
        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult("Marka Silindi");
        }
    }
}
