using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public interface ICardService
    {
        IResult Add(Card card);
        IResult Delete(Card card);
        IResult Update(Card card);

        IResult Payment(Card card, int carId);

        IDataResult<Card> GetByCustomerId(int customerId);
        IDataResult<List<Card>> GetAll();
    }
}
