using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Service
{
    public class DataAcces
    {
        private SqlConnection conection;
        private SqlCommand comand;
        private SqlDataReader reader;
        public SqlDataReader Reader
        {
            get { return reader; }
        }
        public DataAcces()
        {
            conection = new SqlConnection("server=DESKTOP-6NCI6TM\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true");
            comand = new SqlCommand();
        }
        public void setearConsulta(string consulta)
        {
            comand.CommandType = System.Data.CommandType.Text;
            comand.CommandText = consulta;
        }
        public void setearProcedimiento(string sp)
        {
            comand.CommandType = System.Data.CommandType.StoredProcedure;
            comand.CommandText = sp;
        }
        public void ejecutarLectura()
        {
            comand.Connection = conection;
            try
            {
                conection.Open();
                reader = comand.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }

        public int ejecutarAccionScalar()
        {
            comand.Connection = conection;
            try
            {
                conection.Open();
                return int.Parse(comand.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

            public void ejecutarAccion()
        {
                comand.Connection = conection;
            try
            {
                conection.Open();
                comand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   
        public void setearParametro(string nombre, object valor)
        {
            comand.Parameters.AddWithValue(nombre, valor);
        }
        public void cerrarConection()
        {
            if (reader != null)
                reader.Close();
            conection.Close();
        }
    }
}
