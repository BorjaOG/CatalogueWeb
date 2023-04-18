using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Service
{
    public class UsuarioNegocio
    {

		public int InsertarNuevo(User nuevo)
		{
			DataAcces data = new DataAcces();
			try
			{
				data.setearProcedimiento("InsertNew");
				data.setearParametro("@email", nuevo.Email);
				data.setearParametro("@pass", nuevo.Pass);
				return data.ejecutarAccionScalar();				
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
	public bool logIn (User user)
	{
		DataAcces data = new DataAcces();
		try
		{
			data.setearConsulta("Select Id, email, pass, admin from user where email = @email and pass = @pass");
			data.setearParametro("@email", user.Email);
            data.setearParametro("pass", user.Pass);
			data.ejecutarLectura();
			if (data.Reader.Read())
			{
				user.Id = (int)data.Reader["Id"];
				user.Admin = (bool)data.Reader["admin"];
				return true;

			}
			return false;
        }
		catch (Exception ex)
		{

			throw ex ;
		}
			finally
			{
				data.cerrarConection();
			}
	}
       
  }

}
