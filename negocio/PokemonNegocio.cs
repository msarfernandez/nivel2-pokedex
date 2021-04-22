using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector = null;

            try
            {
                conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=POKEDEX_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Id, Nombre, Descripcion, UrlImagen from POKEMONS";
                comando.Connection = conexion;

                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)lector["Id"];//lector.GetInt32(0)
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = lector.GetString(2);
                    aux.UrlImagen = (string)lector["UrlImagen"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(lector  != null)
                    lector.Close();
                conexion.Close();
            }
        }

        // LISTAR 2
        public List<Pokemon> listar2()
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector = null;

            try
            {
                conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=POKEDEX_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select P.Id, Numero, Nombre, P.Descripcion, UrlImagen, T.Descripcion as Tipo, D.Descripcion as Debilidad from POKEMONS P inner join ELEMENTOS T on P.IdTipo = T.Id inner join ELEMENTOS D on P.IdDebilidad = D.Id";
                comando.Connection = conexion;

                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)lector["Id"];//lector.GetInt32(0)
                    aux.Numero = (int)lector["Numero"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = lector.GetString(3);
                    aux.UrlImagen = (string)lector["UrlImagen"];
                    aux.Tipo = new Elemento((string)lector["Tipo"]);
                    aux.Debilidad = new Elemento((string)lector["Debilidad"]);


                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (lector != null)
                    lector.Close();
                conexion.Close();
            }
        }

        //LISTAR
        public List<Pokemon> listar3()
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select P.Id, Numero, Nombre, P.Descripcion, UrlImagen, T.Descripcion as Tipo, D.Descripcion as Debilidad from POKEMONS P inner join ELEMENTOS T on P.IdTipo = T.Id inner join ELEMENTOS D on P.IdDebilidad = D.Id");
                datos.ejecutarLectura();
                SqlDataReader lector = datos.Lector;

                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)lector["Id"];//lector.GetInt32(0)
                    aux.Numero = (int)lector["Numero"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = lector.GetString(3);
                    aux.UrlImagen = (string)lector["UrlImagen"];
                    aux.Tipo = new Elemento((string)lector["Tipo"]);
                    aux.Debilidad = new Elemento((string)lector["Debilidad"]);

                    lista.Add(aux);
                }

                return lista;
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


        public void agregar(Pokemon nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into POKEMONS (Nombre, Numero, Descripcion, UrlImagen, IdTipo, IdDebilidad)Values('" + nuevo.Nombre + "', "+ nuevo.Numero + ", '" + nuevo.Descripcion + "', '" + nuevo.UrlImagen + "', " + nuevo.Tipo.Id + ", " + nuevo.Debilidad.Id + ")");
                datos.ejecutarAccion();
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

        public void modificar(Pokemon modificar) { }

        public void eliminar(int id) { }
        
    }
}
