using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VuelosCR.SA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmAgregar formulario = new FrmAgregar();
            formulario.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmBuscar formulario = new FrmBuscar();
            formulario.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmClientes formulario = new FrmClientes();
            formulario.ShowDialog();
        }
    }
}
