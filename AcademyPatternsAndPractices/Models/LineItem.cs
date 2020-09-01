using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyPatternsAndPractices.Models
{
    public class LineItem
    {
        public int SkuId { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
