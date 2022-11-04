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
    public class EfRentalDal: EfEntityRepositoryBase<Rental, NewdbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (NewdbContext Context = new NewdbContext())
            {
                var result = from r in Context.Rentals
                             join cu in Context.Customers on r.CustomerId equals cu.UserId
                             join u in Context.Users on cu.UserId equals u.Id
                             join c in Context.Cars on r.CarId equals c.CarId
                             join b in Context.Brands on c.BrandId equals b.BrandId
                             select new RentalDetailDto { Id=r.Id, BrandName=b.BrandName,FirstName=u.FirstName,LastName=u.LastName, RentDate=r.RentDate, ReturnDate=r.ReturnDate  };
                return result.ToList();

            }
        }
    }
}
