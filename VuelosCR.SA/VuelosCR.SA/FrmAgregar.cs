using BLL;
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
    public partial class FrmAgregar : Form
    {
        private Conexion _conexion = null;
        private Tiquete _tiquete = null;
        private Cliente _cliente = null;
        public FrmAgregar()
        {
            InitializeComponent();
            _conexion = new Conexion(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);

        }

        private void FrmAgregar_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCedula.Text)||
                string.IsNullOrEmpty(txtNombreCompleto.Text)||
                string.IsNullOrEmpty(cbAerolinea.Text)||
                string.IsNullOrEmpty(cbDestino.Text)||
                string.IsNullOrEmpty(txtImpuesto.Text)||
                string.IsNullOrEmpty(txtPagoTiquete.Text)||
                string.IsNullOrEmpty(txtPrecioFinal.Text))
            {
                MessageBox.Show("Debe insertar todos los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    GuardarTiquete();
                    MessageBox.Show("Usuario registrado correctamente", "Ingreso realizado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            }

        }
        private void GuardarTiquete()
        {
            try
            {
                this._tiquete = new Tiquete();
                this._cliente = new Cliente();

                this._tiquete.cedula = this.txtCedula.Text.Trim();
                this._tiquete.nombreCompleto = this.txtNombreCompleto.Text.Trim();
                this._tiquete.lugarDestino = this.cbDestino.Text.Trim();
                this._tiquete.aerolinea = this.cbAerolinea.Text.Trim();
                this._tiquete.pagoTiquete = decimal.Parse(this.txtPagoTiquete.Text.Trim());
                this._tiquete.impuesto = decimal.Parse(this.txtImpuesto.Text.Trim());
                this._tiquete.precioFinal = decimal.Parse(this.txtPrecioFinal.Text.Trim());

                this._cliente.cedula = this.txtCedula.Text.Trim();
                this._cliente.nombreCompleto = this.txtNombreCompleto.Text.Trim();
                this._cliente.lugarDestino = this.cbDestino.Text.Trim();

                _conexion.GuardarTiquete(this._tiquete);
                _conexion.GuardarCliente(this._cliente);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ModificarTiquete()
        {
            try
            {
                this._tiquete = new Tiquete();
                this._cliente = new Cliente();

                this._tiquete.nombreCompleto = this.txtNombreCompleto.Text.Trim();
                this._tiquete.lugarDestino = this.cbDestino.Text.Trim();
                this._tiquete.aerolinea = this.cbAerolinea.Text.Trim();
                this._tiquete.pagoTiquete = decimal.Parse(this.txtPagoTiquete.Text.Trim());
                this._tiquete.impuesto = decimal.Parse(this.txtImpuesto.Text.Trim());
                this._tiquete.precioFinal = decimal.Parse(this.txtPrecioFinal.Text.Trim());

                this._cliente.nombreCompleto = this.txtNombreCompleto.Text.Trim();
                this._cliente.lugarDestino = this.cbDestino.Text.Trim();

                _conexion.ModificarTiquete(this._tiquete);
                _conexion.ModificarCliente(this._cliente);
                    

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ModificarTiquete();

                MessageBox.Show("Datos actualizado correctamente", "Proceso realizado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtPagoTiquete_TextChanged(object sender, EventArgs e)
        {



        }

        private void cbAerolinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal calculoLugar = CalculoLugar();
            decimal calculoAero = CalculoAerolinea();
            decimal totalTiquete = calculoLugar * calculoAero;

            txtPagoTiquete.Text = totalTiquete.ToString();

        }
        private decimal CalculoLugar()
        {
            decimal pLugar = 0;
             
            if (cbDestino.Text.ToString() == "Argentina $200")
            {

                pLugar = 200;
            }
            else
            if (cbDestino.Text.ToString() == "Bolivia $250")
            {

                pLugar = 250;
            }
            else
            if (cbDestino.Text.ToString() == "Brasil $325")
            {

                pLugar = 325;
            }
            else
            if (cbDestino.Text.ToString() == "Chile $275")
            {

                pLugar = 275;

            }
            else
            if (cbDestino.Text.ToString() == "Colombia $205")
            {

                pLugar = 205;
            }
            else
            if (cbDestino.Text.ToString() == "Ecuador $230")
            {

                pLugar = 230;
            }
            else
            if (cbDestino.Text.ToString() == "Guyana $270")
            {

                pLugar = 270;


            }
            else
            if (cbDestino.Text.ToString() == "Nicaragua $120")
            {

                pLugar = 120;
            }
            return pLugar;

        }



        private decimal CalculoAerolinea()
        {
             decimal pAero=0;
            if (cbAerolinea.Text.ToString() == "Avianca 24%")
            {

                pAero = 1.24M;


            }
            else
            if (cbAerolinea.Text.ToString() == "Despegar 18%")
            {

                pAero = 1.18M;


            }
            else
            if (cbAerolinea.Text.ToString() == "American Airlines 32%")
            {
                pAero = 1.32M;


            }
            else
            if (cbAerolinea.Text.ToString() == "Japan Airlines 25%")
            {
                pAero = 1.25M;


            }
            else
            if (cbAerolinea.Text.ToString() == "Qatar Airways 27%")
            {
                pAero = 1.27M;


            }
            return pAero;

        }

        private void cbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal calculoLugar = CalculoLugar();
            decimal calculoAero = CalculoAerolinea();
            decimal totalTiquete = calculoLugar * calculoAero;

            txtPagoTiquete.Text = totalTiquete.ToString();
        }

        private void btnTarifa_Click(object sender, EventArgs e)
        {
            decimal pagoTiquete = decimal.Parse(txtPagoTiquete.Text);
            decimal impuesto = 1.13M;
            
            decimal pagoTotal = pagoTiquete * impuesto;
            decimal impuestoTotal = pagoTotal - pagoTiquete;
            txtImpuesto.Text = impuestoTotal.ToString();
            txtPrecioFinal.Text = pagoTotal.ToString();

        }

        private void txtImpuesto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {


            
        }
    }
}
