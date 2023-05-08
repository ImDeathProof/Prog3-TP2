using Dominio;
using Negocio;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog3_TP2__GESTION_ARTICULOS_
{
    public partial class FrmPrincipal : Form
    {
        private List<Articulo> listaArticulo;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            cargarLista();

            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripcion");

        }
        void cargarLista()
        {
            articuloNegocio negocio = new articuloNegocio();
            //ImagenNegocio image = new ImagenNegocio();
            try
            {
                listaArticulo = negocio.listar();
                //listaImages = image.listar();
                dgvArticulos.DataSource = listaArticulo;
                //dgvArticulos.Columns["Imagen"].Visible = false;
                dgvArticulos.Columns["Id"].Visible = false;
                dgvArticulos.Columns["Descripcion"].Visible = false;
                //loadImagen(listaImages[0].ImagenUrl);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //CARGAR IMAGENES----------------------------------------------------------
        void cargarImagenes(int id)
        {
            ImagenNegocio image = new ImagenNegocio();
            List<string> seleccionadas = new List<string>();
            List<Imagen> listaImages = new List<Imagen>();
            try
            {
                listaImages = image.listar();
                int cant = listaImages.Count;

                for (int i = 0; i < cant; i++)
                {
                    if (listaImages[i].IdArticulo == id)
                    {
                        seleccionadas.Add(listaImages[i].ImagenUrl);
                    }
                }

                /* foreach (Imagen item in listaImages)
                 {
                     if (item.IdArticulo == seleccionado.Id)
                     {
                         seleccionadas.Add(item);
                     }

                 }
                */
                //MessageBox.Show("Cant " + seleccionadas.Count());
                loadImagen(seleccionadas);
            }
            catch (Exception)
            {

                pbxImagen.Load("https://kinsta.com/wp-content/uploads/2022/06/error-establishing-a-database-connection-in-chrome.png");
            }

        }

        private void loadImagen(List<string> lista)
        {

            try
            {
                //MessageBox.Show("cant " + lista.Count());
                pbxImagen.Load(lista[0]);

            }
            catch (Exception)
            {
                pbxImagen.Load("https://static.thenounproject.com/png/2879926-200.png");
            }
        }
        private void loadImagen(string imagen)
        {
            try
            {
                pbxImagen.Load(imagen);
            }
            catch (Exception)
            {
                pbxImagen.Load("https://static.thenounproject.com/png/2879926-200.png");
            }
        }
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagenes(seleccionado.Id);
                lblDescripcion.Text = seleccionado.Descripcion;

            }
            //loadImagen(seleccionado.imagen.ImagenUrl);
        }
        //-------------------------------------------------------------------------
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModificar modificar = new FrmModificar();
            modificar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            articuloNegocio articulo = new articuloNegocio();
            Articulo seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro que desea eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    if(dgvArticulos.CurrentRow != null)
                    {
                        seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                        articulo.eliminar(seleccionado.Id);
                        cargarLista();

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void tsAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaArticulo altaArticulo = new FrmAltaArticulo();
            altaArticulo.ShowDialog();
            cargarLista();
        }

        //Validacion de la busqueda
        //Validar los filtros
        private bool validarFiltro()
        {
            if (cboCampo.SelectedIndex<0)
            {
                MessageBox.Show("Seleccione el campo por favor. ");
                return true;
            }
            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el criterio por favor");
                return true;
            }
            if(cboCampo.SelectedItem.ToString() == "Precio")
            {
                if (!(soloNumeros(txtFiltro.Text)))
                {
                    MessageBox.Show("Debe filtrar por numeros");
                    return true;
                }

            }

                return false;
        }
        
        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if(!(char.IsNumber(caracter)))
                    return false;
            }

            return true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();

            try
            {
                if (validarFiltro())
                {
                    return;
                }

                string campo= cboCampo.SelectedItem.ToString();
                string criterio= cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltro.Text;

                dgvArticulos.DataSource= negocio.Filtrar(campo,criterio, filtro);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();

            if (opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a: ");
                cboCriterio.Items.Add("Menor a: ");
                cboCriterio.Items.Add("Igual a: ");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con: ");
                cboCriterio.Items.Add("Termina con: ");
                cboCriterio.Items.Add("Contiene: ");
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void agregarEliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategorias frmCategorias = new frmCategorias();
            frmCategorias.ShowDialog();
        }

        private void agregarEliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMarcas frmMarcas = new frmMarcas();  
            frmMarcas.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                
                FrmAltaArticulo modificarArticulo = new FrmAltaArticulo(seleccionado);
                modificarArticulo.ShowDialog();
                cargarLista();
            }
        }

        private void btnFlechaIzquierda_Click(object sender, EventArgs e)
        {

        }

        private void btnFlechaDerecha_Click(object sender, EventArgs e)
        {

        }
    }
}
