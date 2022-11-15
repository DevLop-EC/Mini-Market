using Minimarket.Data;
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

    }
}
