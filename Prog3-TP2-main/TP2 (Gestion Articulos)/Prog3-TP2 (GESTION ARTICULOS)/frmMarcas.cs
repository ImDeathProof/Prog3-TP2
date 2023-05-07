using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog3_TP2__GESTION_ARTICULOS_
{
    public partial class frmMarcas : Form
    {
        public frmMarcas()
        {
            InitializeComponent();
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            MarcaNegocio negocio = new MarcaNegocio();

            try
            {
                marca.Descripcion = txbNombre.Text;

                negocio.Agregar(marca);
                MessageBox.Show("Marca agregada exitosamente. ");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            Marca seleccionada;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro que desea eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionada = (Marca)cbMarcas.SelectedItem;
                    marcaNegocio.eliminar(seleccionada.Id);
                    cargarMarca();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cargarMarca()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();

            try
            {
                cbMarcas.DataSource = marcaNegocio.listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            cargarMarca();
        }
    }
}
