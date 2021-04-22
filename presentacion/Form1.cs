using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;


namespace presentacion
{
    public partial class Form1 : Form
    {

        private List<Pokemon> listaPokemons;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmPokemon agregar = new frmPokemon();
            agregar.ShowDialog();
            Form1_Load(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PokemonNegocio pokemonNegocio = new PokemonNegocio();

            try
            {
                //listaPokemons = pokemonNegocio.listar();
                //listaPokemons = pokemonNegocio.listar2();
                listaPokemons = pokemonNegocio.listar3();

                dgvPokemons.DataSource = listaPokemons;

                //Oculto Columnas de la grilla.
                //Puedo poner el indice de la columna o el nombre de la propiedad.
                dgvPokemons.Columns["Ficha"].Visible = false;
                dgvPokemons.Columns["Descripcion"].Visible = false;
                dgvPokemons.Columns["UrlImagen"].Visible = false;
                dgvPokemons.Columns["Evolucion"].Visible = false;

                RecargarImg(listaPokemons[0].UrlImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvPokemons_MouseClick(object sender, MouseEventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            RecargarImg(seleccionado.UrlImagen);
        }

        private void RecargarImg(string img)
        {
            pbxPokemon.Load(img);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Explicacion de seleccion, no va a ir acá-
            //Pokemon elemento = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            //MessageBox.Show(elemento.Nombre);
            
        }
    }
}
