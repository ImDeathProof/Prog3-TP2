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
    public partial class FrmAltaArticulo : Form
    {
        public FrmAltaArticulo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            articuloNegocio negocio = new articuloNegocio();
            try
            {
                nuevo.Nombre = txbNombre.Text;
                nuevo.Codigo = txbCodigo.Text;
                nuevo.Descripcion = txbDescripcion.Text;
                nuevo.Precio = decimal.Parse(txbPrecio.Text);
                //nuevo.categoria = int.Parse(txbCategoria.Text);
                //nuevo.marca = txbMarca.Text;
                //nuevo.imagen = new Imagen();
                //nuevo.imagen.ImagenUrl = txbImagen.Text;

                //nuevo.Precio

                negocio.agregar(nuevo);
                MessageBox.Show("El articulo ha sido agregado");
                Close();
            }
            catch (Exception ex)
            {
                throw ex;
                //MessageBox.Show(ex.ToString());
            }
        }
    }
}
