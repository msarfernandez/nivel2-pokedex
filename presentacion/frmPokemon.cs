using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using dominio;

namespace presentacion
{
    public partial class frmPokemon : Form
    {
        public frmPokemon()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPokemon_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("De verad querés salir? Perderás los datos", "Saliendo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            //    return;

            //Dispose();
        }

        private void frmPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();
            //List<Elemento> lista = elementoNegocio.listar();
            cboTipo.DataSource = elementoNegocio.listar();
            cboDebilidad.DataSource = elementoNegocio.listar();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Pokemon nuevo = new Pokemon();
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                nuevo.Nombre = txtNombre.Text;
                nuevo.Numero = (int)numNumero.Value;
                nuevo.Descripcion = txtNombre.Text.Trim();
                nuevo.UrlImagen = txtUrlImagen.Text;
                nuevo.Tipo = (Elemento)cboTipo.SelectedItem;
                nuevo.Debilidad = (Elemento)cboDebilidad.SelectedItem;

                negocio.agregar(nuevo);
                MessageBox.Show("Agregado Okey");
                Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
