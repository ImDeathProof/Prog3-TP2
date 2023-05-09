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
        private List<Imagen> listaImagen;
        private Articulo seleccionado;
        private int idSeleccionada = 0;
        private int nroImagen=0;
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
        void cargarImagenes()
        {

            try
            {
                if(dgvArticulos.CurrentRow != null)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    if (seleccionado.imagenes.Count > 0)
                    {
                        loadImagen(seleccionado.imagenes[0].ImagenUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                nroImagen = 0;
                idSeleccionada = 0;
                cargarImagenes();
                lblDescripcion.Text = seleccionado.Descripcion;
            }
            
        }
        //-------------------------------------------------------------------------

        private void button2_Click(object sender, EventArgs e)//BOTON DE ELIMINAR
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar el articulo que desea eliminar. ");
                return;
            }

            articuloNegocio articulo = new articuloNegocio();
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro que desea eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                   
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    articulo.eliminar(seleccionado.Id);
                    cargarLista();
                    
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
            else
            {
                MessageBox.Show("Debe seleccionar un articulo. ");

            }
        }

        //Botones para el cambio de imagenes
        private void btnFlechaIzquierda_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
                seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            if (nroImagen > 0)
            {
                nroImagen--;
            }
            cambiarImagen(nroImagen);
        }

        private void btnFlechaDerecha_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
                seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            if (nroImagen < seleccionado.imagenes.Count - 1)
            {
                nroImagen++;
            }
            cambiarImagen(nroImagen);
            
        }
        void cambiarImagen(int nro_Imagen)
        {
            if (dgvArticulos.CurrentRow != null)
                seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            if ((nro_Imagen >= 0) && (nro_Imagen <= seleccionado.imagenes.Count - 1))
            {
                loadImagen(seleccionado.imagenes[nro_Imagen].ImagenUrl);
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Articulo articuloSeleccionado = new Articulo();

            try
            {
                if(dgvArticulos.CurrentRow != null)
                {
                    articuloSeleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    frmDetalle detalle = new frmDetalle(articuloSeleccionado);
                    detalle.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un articulo. ");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
