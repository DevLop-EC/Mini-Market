using Minimarket.Data;
using Minimarket.Entity;
using System.Data;

namespace Minimarket.Business
{
    public class N_Categoria
    {
        public static DataTable Listado_ca(string cTexto)
        {
            D_Categorias Datos = new();
            return Datos.Listado_ca(cTexto);
        }

        public static string Guardar_ca(int opcion, E_Categorias categorias)
        {
            D_Categorias datos = new();
            return datos.Guardar_ca(opcion, categorias);
        }

    }
}
