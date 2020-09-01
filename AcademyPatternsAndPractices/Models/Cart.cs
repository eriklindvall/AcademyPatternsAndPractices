using System.Collections.Generic;

namespace AcademyPatternsAndPractices.Models
{
    public class Cart
    {
        public IList<LineItem> LineItems { get; set; }
        public Address Address { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalGoodsAmount { get; set; }
        public decimal Tax { get; set; }

        public decimal TotalAmount { get; set; }


    }
}
