using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using negocio;

namespace presentacion_consola
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pokemon> lista;
            PokemonNegocio negocio = new PokemonNegocio();

            lista = negocio.listar();

            foreach (Pokemon pokemon in lista)
            {
                Console.WriteLine(pokemon.Nombre);
            }
            Console.ReadKey();

        }
    }
}
