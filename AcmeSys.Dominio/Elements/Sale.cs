using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSys.Dominio.Elements
{
    public class Sale
    {
        // Propiedades
        public int SaleId { get; private set; }
        public int ProductId { get; private set; }
        public int SubsidiaryId { get; private set; }
        public int QuantitySold { get; private set; }
        public DateTime SaleDate { get; private set; }

        // Constructor
        public Sale(int productId, int subsidiaryId, int quantitySold, DateTime saleDate)
        {
            if (productId <= 0)
                throw new ArgumentException("El ID del producto no es válido.", nameof(productId));

            if (subsidiaryId <= 0)
                throw new ArgumentException("El ID de la sucursal no es válido.", nameof(subsidiaryId));

            if (quantitySold <= 0)
                throw new ArgumentException("La cantidad vendida debe ser mayor que cero.", nameof(quantitySold));

            ProductId = productId;
            SubsidiaryId = subsidiaryId;
            QuantitySold = quantitySold;
            SaleDate = saleDate;
        }

    }
}
