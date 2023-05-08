using Dominio;
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
    public partial class frmDetalle : Form
    {
        public frmDetalle()
        {
            InitializeComponent();
        }

        public frmDetalle(Articulo articulo)
        {
            InitializeComponent();

            lblId.Text= articulo.Id.ToString();
            lblCodigo.Text = articulo.Codigo;
            lblNombre.Text = articulo.Nombre;
            lblDescripcion.Text= articulo.Descripcion;
            lblMarca.Text = articulo.marca.Descripcion;
            lblCategoria.Text = articulo.categoria.Descripcion;
            lblPrecio.Text= articulo.Precio.ToString();

        }

     
    }
}
