using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CardbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {

            using (CardbContext context = new CardbContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 //ImagePath = (from image in context.CarImages where image.CarId.Equals(car.Id) select image.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
            public List<CarDetailDto> GetCarDetailsById(int id)
            {
                using CardbContext context = new();
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             join rental in context.Rentals
                             on car.CarId equals rental.CarId
                             where car.CarId.Equals(id)
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 Description = car.Description,
                                 ImagePath = (from image in context.CarImages where image.CarId.Equals(car.CarId) select image.ImagePath ?? new String('-', 20)).ToList()
                             };
                return result.ToList();
            }

            public List<CarDetailDto> GetCarsDetailsByBrandId(int brandId)
            {
                using CardbContext context = new();
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             where brand.BrandId.Equals(brandId)
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 //ImagePath = (from image in context.CarImages where image.CarId.Equals(car.Id) select image.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }

            public List<CarDetailDto> GetCarsDetailsByColorId(int colorId)
            {
                using CardbContext context = new();
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             where color.ColorId.Equals(colorId)
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 //ImagePath = (from image in context.CarImages where image.CarId.Equals(car.Id) select image.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
            public List<CarDetailDto> GetCarDetailsByBrandIdAndColorId(int brandId, int colorId)
            {
                using CardbContext context = new();
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             where brand.BrandId.Equals(brandId) || color.ColorName.Equals(colorId)
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 //ImagePath = (from image in context.CarImages where image.CarId.Equals(car.Id) select image.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }


        }
    }

