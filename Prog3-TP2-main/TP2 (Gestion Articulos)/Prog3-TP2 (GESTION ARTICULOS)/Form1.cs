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
    public partial class FrmPrincipal : Form
    {
        private List<Articulo> listaArticulo;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();
            listaArticulo = negocio.listar();
            dgvArticulos.DataSource = listaArticulo;
            pbxArticulo.Load(listaArticulo[0].imagen.ImagenUrl);

        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModificiar modificar = new FrmModificiar();
            modificar.Show();
        }

        private void verListadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          FrmArticulos articulos = new FrmArticulos();
            articulos.Show();   
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBoxArticulo_Click(object sender, EventArgs e)
        {

        }
    }
}
