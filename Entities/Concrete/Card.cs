using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Card:IEntity
    {
        public int CardId { get; set; }
        public int CustomerId { get; set; }
        public string CardOwnerName { get; set; }
        public int CardNumber { get; set; }
        public DateTime CardExpirationDate { get; set; }
        public int CardCvv { get; set; }
    }
}
