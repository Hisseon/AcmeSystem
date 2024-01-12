using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSys.App.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ?Name { get; set; }
        public string ?Code { get; set; }
        public decimal UnitPrice { get; set; }
    }

}
