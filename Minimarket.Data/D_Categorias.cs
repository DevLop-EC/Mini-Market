using Minimarket.Entity;
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

        public string Guardar_ca(int opcion, E_Categorias categorias)
        {
            string respuesta = "";
            SqlConnection conn = new();
            try
            {

                conn = Connection.GetConnection().CreateConnection();
                SqlCommand Command = new("USP_Guardar_ca", conn);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@nOpcion", SqlDbType.Int).Value = opcion;
                Command.Parameters.Add("@nCodigo_ca", SqlDbType.Int).Value = categorias.Codigo_ca;
                Command.Parameters.Add("@cDescripcion_ca", SqlDbType.VarChar).Value = categorias.Descripcion_ca;
                conn.Open();
                respuesta = Command.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el registro";

            }
            catch (SqlException ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }

            return respuesta;


        }

    }
}
