using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Payments
{
    public class Payments<T> where T : class, IEntity, new()
    {
        public static IResult Payy(T t){

            return new SuccessResult("ödeme yapıldı");

        }
    }
}
