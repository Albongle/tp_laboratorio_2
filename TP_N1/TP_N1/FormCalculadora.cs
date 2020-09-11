using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace TP_N1
{
    public partial class FormCaluladora : Form
    {
        public FormCaluladora()
        {
            InitializeComponent();
        }
        private void FormCaluladora_Load(object sender, EventArgs e)
        {
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
        }
        private void buttonOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = (Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text)).ToString();
            this.btnConvertirABinario.Enabled = true;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Borra los datos de la pantalla
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.Text = string.Empty;
            this.lblResultado.Text = "0";
            this.btnConvertirADecimal.Enabled = true;
            this.btnConvertirABinario.Enabled = true;
        }
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero operadorA = new Numero(numero1);
            Numero operadorB = new Numero(numero2);
            return Calculadora.Operar(operadorA, operadorB, operador);
        }
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
                this.lblResultado.Text = new Numero().BinarioDecimal(this.lblResultado.Text);
                this.btnConvertirADecimal.Enabled = false;
                this.btnConvertirABinario.Enabled = true;
        }
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
                this.lblResultado.Text = new Numero().DecimalBinario(this.lblResultado.Text);
                this.btnConvertirABinario.Enabled = false;
                this.btnConvertirADecimal.Enabled = true;
        }
        private void txtNumero1_Leave(object sender, EventArgs e)
        {
            double aux;
            if (!(double.TryParse(this.txtNumero1.Text, out aux)))
            {
                MessageBox.Show("Solo puede ingresar numeros", "Ingreso de operandos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNumero1.Focus();
            }
        }
        private void txtNumero2_Leave(object sender, EventArgs e)
        {
            double aux;
            if (!(double.TryParse(this.txtNumero2.Text, out aux)))
            {
                MessageBox.Show("Solo puede ingresar numeros", "Ingreso de operandos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNumero2.Focus();
            }
        }
        private void cmbOperador_Leave(object sender, EventArgs e)
        {
            foreach (char charAux in this.cmbOperador.Text)
            {
                if (char.IsNumber(charAux) || char.IsWhiteSpace(charAux) || char.IsLetter(charAux))
                {
                    MessageBox.Show("Seleccione un operador", "Ingreso de operador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.cmbOperador.Focus();
                    break;
                }
            }
        }
    }
}
