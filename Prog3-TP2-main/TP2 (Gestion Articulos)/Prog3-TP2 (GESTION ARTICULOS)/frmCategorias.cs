using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Prog3_TP2__GESTION_ARTICULOS_
{
    public partial class frmCategorias : Form
    {
        public frmCategorias()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                categoria.Descripcion = txbNombre.Text;

                categoriaNegocio.Agregar(categoria);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            cargarCategorias();
        }

        private void cargarCategorias(){
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                cbCategorias.DataSource = categoriaNegocio.listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            Categoria seleccionada;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro que desea eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionada = (Categoria)cbCategorias.SelectedItem;
                    categoriaNegocio.eliminar(seleccionada.Id);
                    cargarCategorias();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
