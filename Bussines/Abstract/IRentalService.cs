using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<Rental> GetById(int id);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<CarRentalDetailDto>> GetRentalDetails();
        //IResult CheckIfCarIsAvailable(int carId, DateTime rentDate, DateTime returnDate);
        //IResult CheckRentalCar(Rental rental);
    }
}
