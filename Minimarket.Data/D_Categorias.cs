using System.Data;
using System.Data.SqlClient;

namespace Minimarket.Data
{
    public class D_Categorias
    {
        public DataTable Listado_ca(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {

                SqlCon = Connection.GetConnection().CreateConnection();
                SqlCommand Command = new SqlCommand("USP_Listado_ca", SqlCon);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                SqlCon.Open();
                Resultado = Command.ExecuteReader();
                Tabla.Load(Resultado);

                return Tabla;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }


        }

    }
}
