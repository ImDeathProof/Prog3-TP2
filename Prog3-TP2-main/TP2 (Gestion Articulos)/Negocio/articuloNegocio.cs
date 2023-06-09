﻿using Dominio;
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
                //datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.IdMarca, A.IdCategoria, I.idArticulo, I.ImagenUrl from ARTICULOS A, IMAGENES I where I.idArticulo = A.Id");
                //datos.setearConsulta("SELECT DISTINCT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Descripcion Marca, C.Descripcion Categoria from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and C.Id = A.IdCategoria");
                datos.setearConsulta("SELECT A.Id, A.Precio, A.Codigo,A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion Marca , A.IdCategoria, C.Descripcion Categoria from ARTICULOS A inner join MARCAS M on M.Id=A.IdMarca inner join CATEGORIAS C on C.Id=A.IdCategoria");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.imagenes = new List<Imagen>();
                    aux.imagenes = this.cargarImagenes(aux.Id);
                    aux.categoria = new Categoria();
                    if (datos.Lector["Categoria"] is DBNull)
                    {
                        aux.categoria.Descripcion = " ";
                    }
                    else
                    {
                        aux.categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }
                    aux.categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.marca = new Marca();
                    aux.marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.marca.Id = (int)datos.Lector["IdMarca"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Imagen> cargarImagenes(int id) {
            List<Imagen> listaImg = new List<Imagen>();
            List<Imagen> listaImg2 = new List<Imagen>();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            try
            {
                listaImg = imagenNegocio.listar();
            
                foreach (Imagen item in listaImg)
                {
                    if (item.IdArticulo == id)
                    {
                        listaImg2.Add(item);
                    }
                }
                
                return listaImg2;

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
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Modificar(Articulo modificado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @Precio where Id = @Id");
                datos.setearParametros("@Codigo", modificado.Codigo);
                datos.setearParametros("@Nombre", modificado.Nombre);
                datos.setearParametros("@Descripcion", modificado.Descripcion);
                datos.setearParametros("@idMarca", modificado.marca.Id);
                datos.setearParametros("@idCategoria", modificado.categoria.Id);
                datos.setearParametros("@Precio", modificado.Precio);
                datos.setearParametros("@Id", modificado.Id);

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
        }
        public void Agregar(Articulo nuevo)
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

        }

       


        //Busqueda por distintos criterios
        public List<Articulo> Filtrar(string campo,string criterio,string filtro)
        {
            List<Articulo> lista= new List<Articulo>();
            AccesoDatos datos= new AccesoDatos();

            try
            {
                string consulta = "SELECT A.Id, A.Precio, A.Codigo,A.Nombre, A.Descripcion, M.Descripcion Marca ,C.Descripcion Categoria from ARTICULOS A inner join MARCAS M on M.Id=A.IdMarca inner join CATEGORIAS C on C.Id=A.IdCategoria and ";

                switch (campo)
                {
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a: ":
                                consulta += "Precio > " + filtro;
                                break;
                            case "Menor a: ":
                                consulta += "Precio < " + filtro;
                                break;
                            default:
                                consulta += "Precio = " + filtro;
                                break;
                        }

                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con: ":
                                consulta += "Nombre like '" + filtro + "%'";
                                break;
                            case "Termina con: ":
                                consulta += "Nombre like '%" + filtro + "' ";
                                break;
                            case "Contiene: ":
                                consulta += "Nombre like '%" + filtro + "%' ";
                                break;

                        }

                        break;
                    default:
                        switch (criterio)
                        {
                            case "Comienza con: ":
                                consulta += "A.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con: ":
                                consulta += "A.Descripcion like '%" + filtro + "' ";
                                break;
                            case "Contiene: ":
                                consulta += "A.Descripcion like '%" + filtro + "%' ";
                                break;
                        }
                        break;
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    //aux.imagen = new Imagen();
                    //aux.imagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.categoria = new Categoria();
                    if (datos.Lector["Categoria"] is DBNull)
                    {
                        aux.categoria.Descripcion = " ";
                    }
                    else
                    {
                        aux.categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }
                    aux.marca = new Marca();
                    aux.marca.Descripcion = (string)datos.Lector["Marca"];

                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
                                         