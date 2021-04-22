using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pokemon
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }

        public FichaTecnica Ficha { get; set; } //en construccion

        public Elemento Tipo { get; set; }
        public Elemento Debilidad { get; set; }
        public Pokemon Evolucion { get; set; }

    }
}
