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

namespace Catalogo
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conection = new SqlConnection();
            SqlCommand comand = new SqlCommand();
            SqlDataReader reader;

            try
            {
                conection.ConnectionString = "server=DESKTOP-6NCI6TM\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                comand.CommandType = System.Data.CommandType.Text;
                comand.CommandText = "Select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, A.Precio, A.IdMarca, A.IdCategoria, M.Id, C.Id\r\nFrom ARTICULOS A, CATEGORIAS C, MARCAS M \r\nwhere C.Id = A.IdCategoria and M.id = A.IdMarca";
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

        //Filter advanced//

        public List<Articulo> filtrar(string campo, string criterio, string avanzado)
        {
            List<Articulo> lista = new List<Articulo>();
            DataAcces data = new DataAcces();
            try
            {
                string consulta = "Select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, A.Precio, A.IdMarca, A.IdCategoria, M.Id, C.Id\r\nFrom ARTICULOS A, CATEGORIAS C, MARCAS M \r\nwhere C.Id = A.IdCategoria and M.id = A.IdMarca and ";

                switch (campo)
                {
                    case "Price":
                        switch (criterio)
                        {
                            case "Higher of":
                                consulta += "Precio > " + avanzado;
                                break;
                            case "Lower of":
                                consulta += "Precio < " + avanzado;
                                break;
                            default:
                                consulta += "Precio = " + avanzado;
                                break;
                        }
                        break;

                    case "Name":
                        switch (criterio)
                        {
                            case "Start with":
                                consulta += "Nombre like '" + avanzado + "%'";
                                break;
                            case "End with":
                                consulta += "Nombre like '%" + avanzado + "'";
                                break;
                            default:
                                consulta += "Nombre like '%" + avanzado + "%'";
                                break;
                        }
                        break;

                    default:
                        switch (criterio)
                        {
                            case "Start with":
                                consulta += "A.Descripcion like '" + avanzado + "%'";
                                break;
                            case "End with":
                                consulta += "A.Descripcion like '%" + avanzado + "'";
                                break;
                            default:
                                consulta += "A.Descripcion like '%" + avanzado + "%'";
                                break;
                        }
                        break;
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
    }
}

