using System;

namespace LoginCodeFirst.Models
{
    public class Oder
    {
        public int OderId { get; set; }
        public int CustomerId { get; set; }
        public bool OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int StoreId { get; set; }
        public int StaffId { get; set; }
    }
}