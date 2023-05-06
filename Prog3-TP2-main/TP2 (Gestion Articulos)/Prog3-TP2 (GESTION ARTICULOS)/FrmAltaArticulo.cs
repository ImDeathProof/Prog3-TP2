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

        /*private void btnGuardar_Click(object sender, EventArgs e)
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
        */

        //JOaquin
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            articuloNegocio negocio = new articuloNegocio();

            try
            {
                articulo.Codigo = txbCodigo.Text;
                articulo.Nombre = txbNombre.Text;
                articulo.Descripcion = txbDescripcion.Text;
                articulo.marca = (Marca)cbMarca.SelectedItem;
                articulo.categoria = (Categoria)cbCategoria.SelectedItem;
                articulo.Precio = decimal.Parse(txbPrecio.Text);

                negocio.Agregar(articulo);
                MessageBox.Show("Articulo agregado exitosamente. ");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        //Joaquin
        private void FrmModificiar_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();

            cbCategoria.DataSource = categoriaNegocio.listar();
            cbMarca.DataSource = marcaNegocio.listar();

        }


        private void FrmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                cbMarca.DataSource = marcaNegocio.listar();
                cbCategoria.DataSource = categoriaNegocio.listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
