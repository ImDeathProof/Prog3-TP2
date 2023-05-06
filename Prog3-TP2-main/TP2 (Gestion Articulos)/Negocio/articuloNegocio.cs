using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class articuloNegocio
    {
        public List<Articulo> listar()
        {
            //hola 
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.IdMarca, A.IdCategoria, I.idArticulo, I.ImagenUrl from ARTICULOS A, IMAGENES I where I.idArticulo = A.Id");
                //datos.setearConsulta("SELECT DISTINCT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Descripcion Marca, C.Descripcion Categoria, I.ImagenUrl Imagen FROM ARTICULOS A LEFT JOIN IMAGENES I ON I.idArticulo = A.Id LEFT JOIN MARCAS M ON M.Id = A.IdMarca LEFT JOIN CATEGORIAS C ON C.Id = A.IdCategoria");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    //aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.imagen = new Imagen();
                    aux.imagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from articulos where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT into ARTICULOS(Codigo, Nombre, Descripcion, Precio) values('"+ nuevo.Codigo +"', '"+ nuevo.Nombre +"', '"+ nuevo.Descripcion +"', " + nuevo.Precio +" )");
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            //Joaquin
            /*public void Agregar(Articulo nuevo)
            {
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setearConsulta("insert into ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,Precio) values(@Codigo,@Nombre,@Descripcion,@idMarca,@idCategoria,@Precio)");
                    datos.setearParametros("@Codigo", nuevo.Codigo);
                    datos.setearParametros("@Nombre", nuevo.Nombre);
                    datos.setearParametros("@Descripcion", nuevo.Descripcion);
                    datos.setearParametros("@idMarca", nuevo.marca.Id);
                    datos.setearParametros("@idCategoria", nuevo.categoria.Id);
                    datos.setearParametros("@Precio", nuevo.Precio);

                    datos.ejecutarAccion();

                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally { datos.cerrarConexion(); }

            }*/
        }
    }
}
                                         