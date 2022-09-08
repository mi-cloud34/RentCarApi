using Bussines.Abstract;
using Bussines.BussinesAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [SecuredOperation("admin")]
        
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new  SuccessResult("Arac kiralandı");
        }

        /*  public IResult CheckIfCarIsAvailable(int carId, DateTime rentDate, DateTime returnDate)
          {
              var result = _rentalDal.GetAll(r => r.CarId.Equals(carId) && r.ReturnDate >= rentDate);

              return result.IsNullOrEmpty() ?
                  new SuccessResult("This car is available") :
                  new ErrorResult($"This car is not available. It is going to be available in:" +
                  $" { result[result.Count - 1].ReturnDate.Value.ToString("yyyy-MM-dd") }");
          }*/
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult("Kiralık Arac silindi");
        }

        public IDataResult<List<Rental>> GetAll()
        {
           return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),"Kiralık araclar listelendi");
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentalId==id),"Arac idye gire getirlid ");
        }

        public IDataResult<List<CarRentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<CarRentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
        [SecuredOperation("admin")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult("Arac güncellendi");
        }
    }
}
