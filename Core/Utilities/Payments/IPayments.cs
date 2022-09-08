using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Payments
{
    public interface IPayments<T>
    {
        public  IResult Pay(T t)
        {
            return new SuccessResult("The payment has been made successfully.");
        }
    }
}
