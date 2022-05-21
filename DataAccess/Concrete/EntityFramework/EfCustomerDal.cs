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
    public class EfCustomerDal: EfEntityRepositoryBase<Customer, NewdbContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (NewdbContext Context = new NewdbContext())
            {
                var result = from u in Context.Users
                             join c in Context.Customers
                             on u.Id equals c.UserId

                             select new CustomerDetailDto { UserId = u.Id, FirstName = u.FirstName, LastName = u.LastName, CompanyName = c.CompanyName };
                return result.ToList();
            }
        }
    }
}
