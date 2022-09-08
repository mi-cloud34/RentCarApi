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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal= brandDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidation))]
       
       
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new  SuccessResult("Marka eklendi");
        }
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult("Marka silindi");
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),"Markalar listelendi");
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(c=>c.BrandId==id),"Marka idye göre getirildi");
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidation))]
        public IResult Update(Brand brand)
        {
           _brandDal.Update(brand);
            return new  SuccessResult("Marka Silindi");
        }
    }
}
