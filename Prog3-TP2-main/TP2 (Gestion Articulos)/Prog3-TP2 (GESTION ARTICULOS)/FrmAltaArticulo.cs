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
        private Articulo articulo = null;
        public FrmAltaArticulo()
        {
            InitializeComponent();
        }

        public FrmAltaArticulo(Articulo articulo)
        {
            ///constructor utilizado para modificar
            InitializeComponent();
            Text = "Modificar Articulo";
            this.articulo = articulo;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        //JOaquin
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Articulo articulo = new Articulo();
            articuloNegocio negocio = new articuloNegocio();

            try
            {
                if(articulo == null)
                {
                    articulo = new Articulo();
                }
                articulo.Codigo = txbCodigo.Text;
                articulo.Nombre = txbNombre.Text;
                articulo.Descripcion = txbDescripcion.Text;
                articulo.marca = (Marca)cbMarca.SelectedItem;
                articulo.categoria = (Categoria)cbCategoria.SelectedItem;
                articulo.Precio = decimal.Parse(txbPrecio.Text);

                if (articulo.Id != 0)
                {
                    negocio.Modificar(articulo);
                    MessageBox.Show("Articulo modificado exitosamente. ");
                }
                else
                {
                    negocio.Agregar(articulo);
                    MessageBox.Show("Articulo agregado exitosamente. ");
                }

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
                cbMarca.ValueMember = "Id";
                cbMarca.DisplayMember = "Descripcion";
                cbCategoria.DataSource = categoriaNegocio.listar();
                cbCategoria.ValueMember = "Id";
                cbCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    txbNombre.Text = articulo.Nombre;
                    txbCodigo.Text = articulo.Codigo;
                    txbDescripcion.Text = articulo.Descripcion;
                    txbPrecio.Text = articulo.Precio.ToString();

                    cbMarca.SelectedValue = articulo.marca.Id;
                    cbCategoria.SelectedValue = articulo.categoria.Id;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
