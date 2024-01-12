using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSys.Dominio.Elements
{
    public class Purchase
    {
        // Propiedades
        public int PurchaseId { get; private set; }
        public int ProductId { get; private set; }
        public int SubsidiaryId { get; private set; }
        public int QuantityPurchased { get; private set; }
        public DateTime PurchaseDate { get; private set; }

        // Constructor
        public Purchase(int productId, int subsidiaryId, int quantityPurchased, DateTime purchaseDate)
        {
            if (productId <= 0)
                throw new ArgumentException("El ID del producto no es válido.", nameof(productId));

            if (subsidiaryId <= 0)
                throw new ArgumentException("El ID de la sucursal no es válido.", nameof(subsidiaryId));

            if (quantityPurchased <= 0)
                throw new ArgumentException("La cantidad comprada debe ser mayor que cero.", nameof(quantityPurchased));

            ProductId = productId;
            SubsidiaryId = subsidiaryId;
            QuantityPurchased = quantityPurchased;
            PurchaseDate = purchaseDate;
        }

    }
}
