using Bussines.Abstract;
using Bussines.BussinesAspects.Autofac;
using Bussines.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Bussines;
using Core.Utilities.Helpers.FileHelpers;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class CarImageManager:ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        private readonly IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper) : this(carImageDal) => _fileHelper = fileHelper;
        public CarImageManager(ICarImageDal carImageDal) => _carImageDal = carImageDal;

        [SecuredOperation("admin")]
       
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult? result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarId));
            if (result != null) return result;
            carImage.ImagePath = _fileHelper.Upload(file, Paths.ImagesPath);
            //carImage.Date = DateTime.Now; //Entities/CarImage.cs içinde default değer atandı
            _carImageDal.Add(carImage);
            return new SuccessResult(Message.CarImageAdded);
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete($"{ Paths.ImagesPath + carImage.ImagePath }");
            _carImageDal.Delete(carImage);
            return new SuccessResult(Message.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(carImage => carImage.CarImageId.Equals(id)));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            return result is null ?
                new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(carImage => carImage.CarId.Equals(carId))) :
                //new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data,result.Message);
                new SuccessDataResult<List<CarImage>>(GetDefaultImage(carId).Data, result.Message);
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        [SecuredOperation("admin")]
       
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, $"{ Paths.ImagesPath + carImage.ImagePath }", Paths.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Message.CarImageUpdated);
        }
        //static yapıldı resimde hata olursa bak
        private static IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new();
            carImage.Add(new CarImage
            {
                CarId = carId,
                //Date = DateTime.Now, //Entities/CarImage.cs içinde default değer atandı
                ImagePath = $"{Paths.DefaultImagePath}"
            });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(carImage => carImage.CarId.Equals(carId)).Any();
            return result ? new SuccessResult() : new ErrorResult();
        }

        private IResult CheckIfCarImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(carImage => carImage.CarId.Equals(carId)).Count;
            return result >= 5 ? new ErrorResult(Message.CarImageLimitExceded) : new SuccessResult();
        }
    }
}
