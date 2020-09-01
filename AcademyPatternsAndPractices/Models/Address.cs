using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyPatternsAndPractices.Models
{
    public class Address
    {
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; }
    }
}
