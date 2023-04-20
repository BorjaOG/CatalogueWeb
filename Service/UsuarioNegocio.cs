using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Service;


namespace Service
{
    public class UsuarioNegocio
    {
        public void actualizar(User user)
        {
            DataAcces data = new DataAcces();
            try
            {
                data.setearConsulta("Update Users set urlImagenPerfil = @urlImagenPerfil, email = @email, nombre = @nombre, apellido = @apellido where Id = @Id");
                data.setearParametro("@urlImagenPerfil", user.UrlImagenPerfil);
                data.setearParametro("@Id", user.Id);
                data.setearParametro("@email", user.Email);
                data.setearParametro("@nombre", user.Nombre);
                data.setearParametro("@apellido", user.Apellido);

                data.ejecutarAccion();
                data.cerrarConection();


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

        public User obtenerPorId(int id)
        {                      
                DataAcces data = new DataAcces();
                try
                {
                    data.setearConsulta("SELECT Id, email, urlImagenPerfil, nombre, apellido FROM Users WHERE Id = @id");
                    data.setearParametro("@id", id);
                    data.ejecutarLectura();

                    User user = new User();
                    if (data.Reader.HasRows && data.Reader.Read())
                    {
                        user.Id = (int)data.Reader["Id"];
                        user.Email = (string)data.Reader["email"];
                        user.UrlImagenPerfil = data.Reader.IsDBNull(2) ? string.Empty : (string)data.Reader["urlImagenPerfil"];
                        user.Nombre = data.Reader.IsDBNull(3) ? string.Empty : (string)data.Reader["nombre"];
                        user.Apellido = data.Reader.IsDBNull(4) ? string.Empty : (string)data.Reader["apellido"];
                    }
                    return user;
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


            private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public int InsertarNuevo(User nuevo)
        {
            DataAcces data = new DataAcces();
            try
            {
                if (!IsValidEmail(nuevo.Email))
                {
                    throw new ArgumentException("Correo electrónico inválido.");
                }
                data.setearProcedimiento("InsertNew");
                data.setearParametro("@email", nuevo.Email);
                data.setearParametro("@pass", nuevo.Pass);
                return data.ejecutarAccionScalar();


            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar nuevo usuario: " + ex.Message);
            }

            finally
            {
                data.cerrarConection();
            }
        }
        public bool logIn(User user)
        {
            DataAcces data = new DataAcces();
            try
            {
                data.setearConsulta("Select Id, email, pass, admin,urlImagenPerfil from users where email = @email and pass = @pass");
                data.setearParametro("@email", user.Email);
                data.setearParametro("@pass", user.Pass);
                data.ejecutarLectura();
                if (data.Reader.Read())
                {
                    user.Id = (int)data.Reader["Id"];
                    user.Admin = (bool)data.Reader["admin"];
                    if (!(data.Reader["urlImagenPerfil"] is DBNull))
                        user.UrlImagenPerfil = (string)data.Reader["urlImagenPerfil"];

                    return true;
                }
                return false;
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