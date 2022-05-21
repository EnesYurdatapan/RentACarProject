using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NewdbContext>, ICarDal  // ICarDal'ın istediği tüm imzalar zaten EfEntity...'nin içinde olduğu için aşağıya yazmamıza gerek yok
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (NewdbContext Context = new NewdbContext())
            {
                var result = from c in Context.Cars
                             join o in Context.Colors
                             on c.ColorId equals o.ColorId 
                             join b in Context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto { CarId = c.CarId, CarName = c.CarName, ColorName = o.ColorName, BrandName=b.BrandName,DailyPrice=c.DailyPrice};
                return result.ToList();
            }
        }
    }
}
