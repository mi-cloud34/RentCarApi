using Core.Entities.Concrete;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
        /* 
         IResult Add(User user);
         IResult Delete(User user);
         IResult Update(User user);
         IDataResult<User> GetById(int id);
         IDataResult<List<User>> GetAll();

         IDataResult<List<OperationClaim>> GetClaims(User user);
         IDataResult<User> GetByMail(String emailAdress);*/
    }
}
