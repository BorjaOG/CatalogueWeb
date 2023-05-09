using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;
using Domain;
using Service;
using System.Data.SqlTypes;
using System.Xml.Schema;
using System.Runtime.Remoting.Messaging;
using System.Configuration;

namespace Catalogo
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar( string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conection = new SqlConnection();
            SqlCommand comand = new SqlCommand();
            SqlDataReader reader;

            try
            {
                conection = new SqlConnection(ConfigurationManager.AppSettings["cadenaConexion"]);
                comand = new SqlCommand();
                comand.CommandText = "Select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, A.Precio, A.IdMarca, A.IdCategoria, M.Id, C.Id\r\nFrom ARTICULOS A, CATEGORIAS C, MARCAS M \r\nwhere C.Id = A.IdCategoria and M.id = A.IdMarca ";
                if(id != "")
                    comand.CommandText += " and A.Id = " + id;
                comand.Connection = conection;

                conection.Open();
                reader = comand.ExecuteReader();

                while (reader.Read())
                {
                    Articulo aux = new Articulo();
                    if (!(reader["Codigo"] is DBNull))
                        aux.Codigo = (string)reader["Codigo"];
                    if (!(reader["Nombre"] is DBNull))
                        aux.Nombre = (string)reader["Nombre"];
                    if (!(reader["Descripcion"] is DBNull))
                        aux.Descripcion = (string)reader["Descripcion"];
                    if (!(reader["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)reader["ImagenUrl"];
                    aux.Id = (int)reader["Id"];
                    aux.Precio = (decimal)reader["Precio"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)reader["IdMarca"];
                    aux.Marca.Descripcion = (string)reader["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)reader["IdCategoria"];
                    aux.Categoria.Descripcion = (string)reader["Categoria"];

                    lista.Add(aux);
                }
                conection.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Articulo> listarSP()
        {
            List<Articulo> lista = new List<Articulo>();
            DataAcces data = new DataAcces();
            try
            {

                data.setearProcedimiento("StoredListar");
                data.ejecutarLectura();
                while (data.Reader.Read())
                {
                    Articulo aux = new Articulo();
                    if (!(data.Reader["Codigo"] is DBNull))
                        aux.Codigo = (string)data.Reader["Codigo"];
                    if (!(data.Reader["Nombre"] is DBNull))
                        aux.Nombre = (string)data.Reader["Nombre"];
                    if (!(data.Reader["Descripcion"] is DBNull))
                        aux.Descripcion = (string)data.Reader["Descripcion"];
                    if (!(data.Reader["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)data.Reader["ImagenUrl"];
                    aux.Id = (int)data.Reader["Id"];
                    aux.Precio = (decimal)data.Reader["Precio"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)data.Reader["IdMarca"];
                    aux.Marca.Descripcion = (string)data.Reader["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)data.Reader["IdCategoria"];
                    aux.Categoria.Descripcion = (string)data.Reader["Categoria"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Articulo> listarArtById(List<int> listaArtId)
        {
            List<Articulo> lista = new List<Articulo>();
            DataAcces datos = new DataAcces();
            try
            {
                string consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion TipoMarca, " +
                    "C.Descripcion TipoCategoria, ImagenUrl, A.Precio, A.IdMarca, A.IdCategoria " +
                    "FROM ARTICULOS A, CATEGORIAS C, MARCAS M " +
                    "WHERE C.Id = A.IdCategoria AND A.IdCategoria = M.Id AND A.Id IN (" + string.Join(",", listaArtId) + ")";
                datos.setearConsulta(consulta);

                datos.ejecutarLectura();
                while (datos.Reader.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Reader["Id"];
                    aux.Codigo = (string)datos.Reader["Codigo"];
                    aux.Nombre = (string)datos.Reader["Nombre"];
                    if (!(datos.Reader["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Reader["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Reader["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Reader["TipoMarca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Reader["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Reader["TipoCategoria"];
                    if (!(datos.Reader["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Reader["ImagenUrl"];
                    aux.Precio = (decimal)datos.Reader["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void agregar(Articulo nuevo)
        {
            DataAcces data = new DataAcces();

            try
            {  
                string consulta = "insert into ARTICULOS (Codigo, Nombre, Descripcion, ImagenUrl, Precio, IdMarca, IdCategoria)" +
                                  "values (@Codigo, @Nombre, @Descripcion, @UrlImagen, @Precio, @IdMarca, @IdCategoria)";

                data.setearConsulta(consulta);
                data.setearParametro("@Codigo", nuevo.Codigo);
                data.setearParametro("@Nombre", nuevo.Nombre);
                data.setearParametro("@Descripcion", nuevo.Descripcion);
                data.setearParametro("@UrlImagen", nuevo.UrlImagen);
                data.setearParametro("@Precio", nuevo.Precio);
                data.setearParametro("@IdMarca", nuevo.Marca.Id);
                data.setearParametro("@IdCategoria", nuevo.Categoria.Id);
               
                data.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.cerrarConection();
            }
        }
        public void modificar(Articulo article)
        {
                DataAcces data = new DataAcces();
            try
            {
                data.setearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio where Id = @Id");
                data.setearParametro("@Codigo", article.Codigo);
                data.setearParametro("@Nombre", article.Nombre);
                data.setearParametro("@Descripcion", article.Descripcion);
                data.setearParametro("@IdMarca", article.Marca.Id);
                data.setearParametro("@IdCategoria", article.Categoria.Id);
                data.setearParametro("@ImagenUrl", article.UrlImagen);
                data.setearParametro("@Precio", article.Precio);
                data.setearParametro("@Id", article.Id);

                data.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.cerrarConection();
            }
        }
        public void delete (int Id)
        {
            try
            {
                
                DataAcces data = new DataAcces();
                data.setearConsulta("delete from articulos where Id = @Id");
                data.setearParametro("@Id", Id);
                data.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Advanced Filter //

        public List<Articulo> filtrar(string field, string criteria, string filter)
        {
            List<Articulo> lista = new List<Articulo>();
            DataAcces data = new DataAcces();
            try
            {
                string consulta = "Select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, A.Precio, A.IdMarca, A.IdCategoria, M.Id, C.Id\r\nFrom ARTICULOS A, CATEGORIAS C, MARCAS M \r\nwhere C.Id = A.IdCategoria and M.id = A.IdMarca and ";

                if (field == "Name")
                {
                    switch (criteria)
                    {
                        case "Start with":
                            consulta += "A.Nombre like '" + filter + "%' ";
                            break;
                        case "Ends with":
                            consulta += "A.Nombre like '%" + filter + "'";
                            break;
                        default:
                            consulta += "A.Nombre like '%" + filter + "%'";
                            break;
                    }
                }
                else if (field == "Brand")
                {
                    switch (criteria)
                    {
                        case "Start with":
                            consulta += "M.Descripcion like '" + filter + "%' ";
                            break;
                        case "Ends with":
                            consulta += "M.Descripcion like '%" + filter + "'";
                            break;
                        default:
                            consulta += "M.Descripcion like '%" + filter + "%'";
                            break;
                    }
                }
                else if (field == "Price")
                {
                    switch (criteria)
                    {
                        case "More than":
                            consulta += "A.Precio > " + filter;
                            break;
                        case "Less than":
                            consulta += "A.Precio < " + filter;
                            break;
                        default:
                            consulta += "A.Precio = " + filter;
                            break;
                    }
                }
                data.setearConsulta(consulta);
                data.ejecutarLectura();
                while (data.Reader.Read())
                {
                    Articulo aux = new Articulo();
                    if (!(data.Reader["Codigo"] is DBNull))
                        aux.Codigo = (string)data.Reader["Codigo"];
                    if (!(data.Reader["Nombre"] is DBNull))
                        aux.Nombre = (string)data.Reader["Nombre"];
                    if (!(data.Reader["Descripcion"] is DBNull))
                        aux.Descripcion = (string)data.Reader["Descripcion"];
                    if (!(data.Reader["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)data.Reader["ImagenUrl"];
                    aux.Id = (int)data.Reader["Id"];
                    aux.Precio = (decimal)data.Reader["Precio"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)data.Reader["IdMarca"];
                    aux.Marca.Descripcion = (string)data.Reader["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)data.Reader["IdCategoria"];
                    aux.Categoria.Descripcion = (string)data.Reader["Categoria"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    public void AgregarSP(Articulo nuevo)
    {
        DataAcces data = new DataAcces();

        try
        {
            data.setearProcedimiento("StoredNewArticle");
            data.setearParametro("@Codigo", nuevo.Codigo);
            data.setearParametro("@Nombre", nuevo.Nombre);
            data.setearParametro("@Descripcion", nuevo.Descripcion);
            data.setearParametro("@IdMarca", nuevo.Marca.Id);
            data.setearParametro("@IdCategoria", nuevo.Categoria.Id);
            data.setearParametro("@UrlImagen", nuevo.UrlImagen);
            data.setearParametro("@Precio", nuevo.Precio);

            data.ejecutarAccion();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            data.cerrarConection();
        }
    }
        public void modificarSP(Articulo article)
        {
            DataAcces data = new DataAcces();
            try
            {
                data.setearProcedimiento("StoredModifyArticle");
                data.setearParametro("@Codigo", article.Codigo);
                data.setearParametro("@Nombre", article.Nombre);
                data.setearParametro("@Descripcion", article.Descripcion);
                data.setearParametro("@IdMarca", article.Marca.Id);
                data.setearParametro("@IdCategoria", article.Categoria.Id);
                data.setearParametro("@UrlImagen", article.UrlImagen);
                data.setearParametro("@Precio", article.Precio);
                data.setearParametro("@Id", article.Id);

                data.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.cerrarConection();
            }
        }
    }
}

