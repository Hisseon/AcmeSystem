using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSys.App.DTOs
{
    public class PurchaseDto
    {
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public int SubsidiaryId { get; set; }
        public int QuantityPurchased { get; set; }
        public DateTime PurchaseDate { get; set; }
    }

}
