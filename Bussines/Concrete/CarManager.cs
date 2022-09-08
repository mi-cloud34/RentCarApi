using Bussines.Abstract;
using Bussines.BussinesAspects.Autofac;
using Bussines.Constants;
using Bussines.Validation.FluentValidation;
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
    public class CarManager:ICarService
    {
        ICarDal _cardal;
        public CarManager(ICarDal carDal)
        {
            _cardal=carDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CardValidation))]
      
       
        public IResult Add(Car car)
        {
            _cardal.Add(car);
            return new SuccessResult(Message.CarAddedd);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new  SuccessDataResult<List<Car>>(_cardal.GetAll(),Message.CarList);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_cardal.Get(c=>c.CarId==carId));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(c=>c.DailyPrice<=min&&c.DailyPrice>=max));
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidation))]
        public IResult Update(Car car)
        {
            _cardal.Update(car);
            return new SuccessResult(Message.UpdatedCar);
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _cardal.Delete(car);
            return new SuccessResult(Message.DeletedCar);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarsDetailsByBrandId(brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarsDetailsByColorId(colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetail());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetailsById(id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandIdAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetailsByBrandIdAndColorId(brandId, colorId));
        }
    }
}
