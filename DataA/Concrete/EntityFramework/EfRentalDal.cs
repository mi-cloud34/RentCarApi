using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental, CardbContext>, IRentalDal
    {
        public List<CarRentalDetailDto> GetRentalDetails()
        {
            using CardbContext context = new();
            var result = from car in context.Cars
                         join rental in context.Rentals on car.CarId equals rental.CarId
                         join brand in context.Brands on car.BrandId equals brand.BrandId
                         join color in context.Colors on car.ColorId equals color.ColorId
                         join customer in context.Customers on rental.CustomerId equals customer.CustomerId
                         join user in context.Users on customer.UserId equals user.UserId
                         select new CarRentalDetailDto
                         {
                             RentalId = rental.RentalId,
                             CustomerFirstName = user.FirstName,
                             CustomerLastName = user.LastName,
                             CustomerName = customer.CustomerName,
                             CarName = car.CarName,
                             BrandName = brand.BrandName,
                             ColorName = color.ColorName,
                             DailyPrice = car.DailyPrice,
                             RentDate = rental.RentDate,
                             ReturnDate = rental.ReturnDate
                         };
            return result.ToList();
        }
    }
}
