using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSys.Dominio.Elements
{
    public class Product
    {
        // Propiedades
        public int ?ProductId { get; protected set; }
        public string ?Name { get; protected set; }
        public string ?Code { get; protected set; }
        public decimal ?UnitPrice { get; protected set; }

        // Constructor para crear una nueva instancia de Product
        public Product()
        {
        }

        public Product(string name, string code, decimal unitPrice)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre del producto no puede estar vacío.", nameof(name));

            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("El código del producto no puede estar vacío.", nameof(code));

            if (unitPrice <= 0)
                throw new ArgumentException("El precio unitario debe ser mayor que cero.", nameof(unitPrice));

            Name = name;
            Code = code;
            UnitPrice = unitPrice;
        }


        // Método para actualizar el precio unitario
        public void UpdateUnitPrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("El nuevo precio debe ser mayor que cero.", nameof(newPrice));

            UnitPrice = newPrice;
        }
    }

}
