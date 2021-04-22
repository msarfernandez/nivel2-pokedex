using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ElementoNegocio
    {
        public List<Elemento> listar()
        {
            List<Elemento> elementos = new List<Elemento>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, Descripcion From ELEMENTOS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    elementos.Add(new Elemento((int)datos.Lector["Id"], (string)datos.Lector["Descripcion"]));
                }

                return elementos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
