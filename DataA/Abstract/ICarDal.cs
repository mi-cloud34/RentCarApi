using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal: IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetail();
        List<CarDetailDto> GetCarDetailsById(int id);
        List<CarDetailDto> GetCarsDetailsByBrandId(int brandId);
        List<CarDetailDto> GetCarsDetailsByColorId(int colorId);
        List<CarDetailDto> GetCarDetailsByBrandIdAndColorId(int brandId, int colorId);
    }
}
