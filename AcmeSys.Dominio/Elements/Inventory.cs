using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSys.Dominio.Elements
{
    public class Inventory
    {
        // Propiedades
        public int InventoryId { get; private set; }
        public int ProductId { get; private set; }
        public int SubsidiaryId { get; private set; }
        public int Stock { get; private set; }

        // Constructor
        public Inventory(int productId, int subsidiaryId, int initialStock)
        {
            if (productId <= 0)
                throw new ArgumentException("El ID del producto no es válido.", nameof(productId));

            if (subsidiaryId <= 0)
                throw new ArgumentException("El ID de la sucursal no es válido.", nameof(subsidiaryId));

            if (initialStock < 0)
                throw new ArgumentException("El stock inicial no puede ser negativo.", nameof(initialStock));

            ProductId = productId;
            SubsidiaryId = subsidiaryId;
            Stock = initialStock;
        }

        // Métodos
        public void UpdateStock(int quantity)
        {
            if (quantity < 0)
                throw new ArgumentException("La cantidad no puede ser negativa.", nameof(quantity));

            Stock = quantity;
        }

        // Método para agregar stock
        public void AddStock(int quantityToAdd)
        {
            if (quantityToAdd <= 0)
                throw new ArgumentException("La cantidad a agregar debe ser mayor que cero.", nameof(quantityToAdd));

            Stock += quantityToAdd;
        }

        // Método para reducir stock
        public void RemoveStock(int quantityToRemove)
        {
            if (quantityToRemove <= 0)
                throw new ArgumentException("La cantidad a remover debe ser mayor que cero.", nameof(quantityToRemove));

            if (quantityToRemove > Stock)
                throw new InvalidOperationException("No hay suficiente stock para remover la cantidad solicitada.");

            Stock -= quantityToRemove;
        }
    }

}
