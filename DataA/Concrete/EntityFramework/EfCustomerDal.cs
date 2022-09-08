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
    public class EfCustomerDal: EfEntityRepositoryBase<Customer, CardbContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using CardbContext context = new();
            var result = from customer in context.Customers
                         join user in context.Users
                         on customer.UserId equals user.UserId
                         select new CustomerDetailDto
                         {
                             Id = customer.CustomerId,
                            FirstName = user.FirstName,
                             LastName = user.LastName,
                             EmailAdress = user.Email,
                             CompanyName = customer.CustomerName
                         };
            return result.ToList();
        }
    }
}
