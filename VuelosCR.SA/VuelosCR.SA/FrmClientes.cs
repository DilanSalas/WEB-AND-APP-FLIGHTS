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
    public partial class FrmClientes : Form
    {
        private Conexion _conexion = null;
        public FrmClientes()
        {
            InitializeComponent();
            _conexion = new Conexion(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
                this.dtgDatos.DataSource = _conexion.BuscarCliente(pNombre).Tables[0];
                this.dtgDatos.AutoResizeColumns();
                this.dtgDatos.ReadOnly = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
