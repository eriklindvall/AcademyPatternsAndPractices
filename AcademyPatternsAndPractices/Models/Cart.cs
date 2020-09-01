using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
