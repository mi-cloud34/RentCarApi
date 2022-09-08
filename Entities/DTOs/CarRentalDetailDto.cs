using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarRentalDetailDto : IDto
    {
        public int RentalId { get; set; }
        public String CustomerFirstName { get; set; }
        public String CustomerLastName { get; set; }
        public String CustomerName { get; set; }
        public String CarName { get; set; }
        public String BrandName { get; set; }
        public String ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
