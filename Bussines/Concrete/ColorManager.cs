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
    internal class ColorManager : IColorService
    {
        IColorDal _colordDal;
        public ColorManager(IColorDal colordDal)
        {
            _colordDal = colordDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ColorValidation))]
      
       
        public IResult Add(Color color)
        {
            _colordDal.Add(color);
            return new SuccessResult("Color eklendi");
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Color color)
        {
            _colordDal.Delete(color);
            return new SuccessResult("Color silindi");
        }


        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colordDal.GetAll(), "Color listelendi");
        }

        public IDataResult<Color> Get(int id)
        {
            return new SuccessDataResult<Color>(_colordDal.Get(c => c.ColorId == id), "Color idye göre getirildi");
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ColorValidation))]
        public IResult Update(Color color)
        {
            _colordDal.Update(color);
            return new SuccessResult("Color Silindi");
        }
    }
}

