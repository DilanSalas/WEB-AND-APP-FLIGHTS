using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VuelosCR.SA
{
    public partial class FrmBuscar : Form
    {
        private Conexion _conexion = null;
        public FrmBuscar()
        {
            InitializeComponent();
            _conexion = new Conexion(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);
        }

        private void FrmBuscar_Load(object sender, EventArgs e)
        {

        }

        private void txtNombreCompleto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Buscar(this.txtNombreCompleto.Text.Trim());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscar(string pNombre)
        {
            try
            {
                this.dtgDatos.DataSource = _conexion.BuscarTiquete(pNombre).Tables[0];
                this.dtgDatos.AutoResizeColumns();
                this.dtgDatos.ReadOnly = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtgDatos.SelectedRows.Count > 0)
                {
                    _conexion.EliminarTiquete(this.dtgDatos.SelectedRows[0].Cells["nombreCompleto"].Value.ToString());
                    _conexion.EliminarCliente(this.dtgDatos.SelectedRows[0].Cells["nombreCompleto"].Value.ToString());

                    this.Buscar("");
                }
                else
                {
                    throw new Exception("Seleccione la fila del tiquete que desea eliminar");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
