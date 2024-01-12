using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSys.Dominio.Elements
{
    public class Subsidiary
    {
        // Propiedades
        public int SubsidiaryId { get; protected set; }
        public string Name { get; protected set; }

        public Subsidiary(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre de la sucursal no puede estar vacío.", nameof(name));

            Name = name;
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("El nuevo nombre de la sucursal no puede estar vacío.", nameof(newName));

            Name = newName;
        }

        public string GetName()
        {
            return Name;
        }

    }

}
