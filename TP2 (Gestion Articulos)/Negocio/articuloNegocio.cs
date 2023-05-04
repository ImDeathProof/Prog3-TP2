using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using Negocio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrate security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT Id, Codigo, Nombre, Descripcion, Precio FROM ARTICULOS";
                comando.Connection = conexion;

                conexion.Open();

                //CONTINUA EN 
                //5 - PRIMERA  LECTURA A DB : MIN 22:31"

                //DISCULPEN EL NO PODER TERMINARLO EMPEZE TARDE HOY

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}