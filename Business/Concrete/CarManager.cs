using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.CrossCuttingConcerns;
using Core1.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;
       
        public CarManager(ICarDal carDal,IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
           
        }
        [SecuredOperation("admin,car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
                IResult result=BusinessRules.Run(CheckIfBrandLimitExceeded(car.BrandId), CheckIfColorOfModelSame(car),CheckIfCountOfBrandIsSuitable());
            if (result!=null)
            {
                return result;
            }    
            _carDal.Add(car);
                return new SuccessResult("Başarılı !, eklendi");

           
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Başarılı ! silindi.");
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.ProductsListed);
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId),Messages.ProductsListed);
        }
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Başarılı,Güncellendi");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.ProductsListed);
        }

        private IResult CheckIfBrandLimitExceeded(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result > 10)
            {
                return new ErrorResult("Bu marka için en fazla 10 araba ekleyebilirsiniz !!");
            }
            return new SuccessResult();
        }

      private IResult CheckIfColorOfModelSame(Car car)
        {
            var result = _carDal.GetAll(c => c.ColorId == car.ColorId && c.BrandId==car.BrandId).Any();
            if (result)
            {
                return new ErrorResult("Bu marka için aynı renkten araba zaten var !! ");
            }
            return new SuccessResult();
        }
        private IResult CheckIfCountOfBrandIsSuitable()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count == 15)
            {
                return new ErrorResult("Marka sayısı 15'i geçtiği için bu arabayı ekleyemezsiniz !!");
            }
            return new SuccessResult();
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult("Cache Güncellendi");
        }

        public IDataResult<List<Car>> GetByBrand(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }
    }
}
