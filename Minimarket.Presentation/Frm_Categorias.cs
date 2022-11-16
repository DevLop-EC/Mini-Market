using Minimarket.Business;
using Minimarket.Entity;

namespace Minimarket.Presentation
{
    public partial class Frm_Categorias : Form
    {
        #region "Variables"
        private int nOpcion = 0; //Sin opcion
        #endregion

        public Frm_Categorias()
        {
            InitializeComponent();
        }


        #region "Metodos"

        private void FormatoCategorias()
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "Código";
            Dgv_principal.Columns[1].Width = 300;
            Dgv_principal.Columns[1].HeaderText = "Categoria";
        }

        private void ListarCategorias(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Categoria.Listado_ca(cTexto);

                this.FormatoCategorias();
                //    Lbl_total.Text = "Total de Registros: " + Convert.ToString(String.IsNullOrEmpty(Dgv_principal.Rows[0].Cells[0].Value.ToString()) ? 0 : Dgv_principal.Rows.Count);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void EstadoBotones(bool estado)
        {
            Btn_nuevo.Enabled = estado;
            Btn_actualizar.Enabled = estado;
            Btn_eliminar.Enabled = estado;
            Btn_reporte.Enabled = estado;
            Btn_salir.Enabled = estado;
        }

        private void EstadoBotonesProcesos(bool estado)
        {
            this.Btn_guardar.Visible = estado;
            this.Btn_cancelar.Visible = estado;
            this.Btn_regresar.Visible = !estado;
        }
        #endregion

        private void Frm_Categorias_Load(object sender, EventArgs e)
        {
            this.ListarCategorias("%");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_ca.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar una categoria", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Txt_descripcion_ca.Focus();
                return;
            }
            else
            {
                E_Categorias categorias = new();
                string respuesta = string.Empty;
                categorias.Codigo_ca = 0;
                categorias.Descripcion_ca = Txt_descripcion_ca.Text.Trim();
                respuesta = N_Categoria.Guardar_ca(nOpcion, categorias);
                if (respuesta == "OK")
                {
                    this.ListarCategorias("%");
                    MessageBox.Show("Se guardo correctamente el registro", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    nOpcion = 0;
                    this.EstadoBotones(true);
                    this.EstadoBotonesProcesos(false);
                    Txt_descripcion_ca.Text = "";
                    Txt_descripcion_ca.ReadOnly = true;
                    Tbp_principal.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show(respuesta, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            nOpcion = 1; //Nuevo registro
            this.EstadoBotones(false);
            this.EstadoBotonesProcesos(true);
            Txt_descripcion_ca.Focus();
            Txt_descripcion_ca.Text = "";
            Txt_descripcion_ca.ReadOnly = false;
            Tbp_principal.SelectedIndex = 1;
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            nOpcion = 2; //Actualizar registro
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            nOpcion = 0; //Sin opcion
            Txt_descripcion_ca.Text = "";
            Txt_descripcion_ca.ReadOnly = true;
            this.EstadoBotones(true);
            this.EstadoBotonesProcesos(false);
            Tbp_principal.SelectedIndex = 0;
        }
    }
}
