using ClasesArchivos;
using ClasesBBDD;
using ClasesExcepciones;
using ClasesVehiculos;
using ClasesEstacionamiento;
using System;
using System.Windows.Forms;
using System.Threading;

namespace TP_N4
{
    public partial class frmEstacionamiento : Form
    {
        private bool flagIngreso;
        private bool flagPrecios;
        private delegate void Callback(Vehiculo vehiculo);
        private Estacionamiento estacionamiento;
        private Random espacioRandom;
        private int lugaresOcupados;

        public frmEstacionamiento()
        {
            InitializeComponent();
        }

        private void frmEstacionamiento_Load(object sender, EventArgs e)
        {
            this.btnEncendido.ImageIndex = 0;
            this.estacionamiento = Estacionamiento.NuevoEstacionamiento;
            this.espacioRandom = new Random();
            this.flagIngreso = false;
            this.flagPrecios = false;
            this.estacionamiento.NombreEstacionamiento = "Plaza San Martin";
            this.estacionamiento.CapacidadEstacionamiento = this.espacioRandom.Next(100, 500);
            this.txtToolBar.Text = $"Capacidad: {this.estacionamiento.CapacidadEstacionamiento.ToString()}/Ocupados: {this.lugaresOcupados}";
            this.progressToolBar.Maximum = this.estacionamiento.CapacidadEstacionamiento;
            this.cmbTipoVehiculo.DataSource = Enum.GetValues(typeof(Vehiculo.ETipo));
            VehiculosDAO.EventoActualizar += HabilitarIngresoVehiculo;
        }
        /// <summary>
        /// Actualiza el reloj del Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerHora_Tick(object sender, EventArgs e)
        {
            this.lblHoraActual.Text = $"{DateTime.Now.ToString("HH:mm:ss")}";
        }
        /// <summary>
        /// Establece el importe de la hora para cada tipo de Vehiculo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEstablecerImporte_Click(object sender, EventArgs e)
        {
            this.BloqueaValorHora(this.flagPrecios);
        }
        /// <summary>
        /// Verifica el correcto ingreso de datos en el txtBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtImporteAuto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.Handled = this.VerificaIngresoTxtBox(sender, e)))
            {
                this.txtImporteAuto.Focus();
            }
        }
        /// <summary>
        /// Verifica el correcto ingreso de datos en el txtBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtImporteCamioneta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.Handled = this.VerificaIngresoTxtBox(sender, e)))
            {
                this.txtImporteCamioneta.Focus();
            }
        }
        /// <summary>
        /// Verifica el correcto ingreso de datos en el txtBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtImporteMoto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.Handled = this.VerificaIngresoTxtBox(sender, e)))
            {
                this.txtImporteMoto.Focus();
            }
        }
        /// <summary>
        /// Metodo generico para verificar el ingreso por teclado del los txtBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool VerificaIngresoTxtBox(object sender, KeyPressEventArgs e)
        {
            bool returnAux;
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || (e.KeyChar.ToString().Equals(",") && !(this.txtImporteMoto.Text.Contains(","))))
            {
                returnAux = false;
            }
            else
            {
                returnAux = true;
            }
            return returnAux;
        }
        /// <summary>
        /// Metodo generico para establecer el valor de la hora para ops vehiculos
        /// </summary>
        /// <param name="flag"></param>
        private void BloqueaValorHora(bool flag)
        {
            if (!this.flagIngreso)
            {
                if (!this.flagPrecios)
                {
                    this.txtImporteAuto.Enabled = false;
                    this.txtImporteCamioneta.Enabled = false;
                    this.txtImporteMoto.Enabled = false;
                    this.flagPrecios = true;
                    this.btnEstablecerImporte.ImageIndex = 0;
                    try
                    {
                        if (!string.IsNullOrEmpty(this.txtImporteAuto.Text))
                        {
                            Automovil.ValorHora = this.txtImporteAuto.Text;
                        }
                        if (!string.IsNullOrEmpty(this.txtImporteCamioneta.Text))
                        {
                            Camioneta.ValorHora = this.txtImporteCamioneta.Text;
                        }
                        if (!string.IsNullOrEmpty(this.txtImporteMoto.Text))
                        {
                            Moto.ValorHora = this.txtImporteMoto.Text;
                        }
                    }
                    catch (ImporteHoraException ex)
                    {
                        MessageBox.Show($"{ex.Message}", "Importe Ingresado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    this.txtImporteAuto.Enabled = true;
                    this.txtImporteCamioneta.Enabled = true;
                    this.txtImporteMoto.Enabled = true;
                    this.flagPrecios = false;
                    this.btnEstablecerImporte.ImageIndex = 1;
                }
            }
            else
            {
                MessageBox.Show("Debe interrumpir el ingreso para modificar los valores", "Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Es el boton que dispara el evento y habilita el ingreso de los vehiculos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncendido_Click(object sender, EventArgs e)
        {
            if (!this.flagPrecios)
            {
                MessageBox.Show("Debe establecer los precios para la Jornada", "Precios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!this.flagIngreso)
                {
                    VehiculosDAO.Activar = true;
                    this.btnEncendido.ImageIndex = 1;
                    this.flagIngreso = true;
                    this.btnNuevoIngreso.Visible = true;
                }
                else
                {
                    VehiculosDAO.Activar = false;
                    this.btnEncendido.ImageIndex = 0;
                    this.flagIngreso = false;
                    this.btnNuevoIngreso.Visible = false;
                }
            }
        }
        /// <summary>
        /// Si el proceso de ingreso se encuentra activo, lo detiene al cerrar el Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEstacionamiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (VehiculosDAO.Activar == true)
            {
                VehiculosDAO.Activar = false;
            }
        }
        /// <summary>
        /// Carga datos al hacer dobleclick sobre los elementos del ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstbVehiculos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(!object.ReferenceEquals(this.listBoxVehiculos.SelectedItem, null))
            {
                this.grpManual.Text = "Salida";
                this.grpManual.Visible = true;
                this.cmbTipoVehiculo.SelectedItem = ((Vehiculo)this.listBoxVehiculos.SelectedItem).TipoVehiculo;
                this.cmbTipoVehiculo.Enabled = false;
                this.txtHora.Text = lblHoraActual.Text;
                this.txtHora.Enabled = false;
                this.txtPatente.Text = ((Vehiculo)this.listBoxVehiculos.SelectedItem).Patente;
                this.txtPatente.Enabled = false;
            }
        }
        /// <summary>
        /// Habilita el ingreso manual de Vehiculos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevoIngreso_Click(object sender, EventArgs e)
        {
            this.grpManual.Visible = true;
            this.grpManual.Text = "Ingreso";
            this.txtHora.Visible = false;
            this.txtPatente.Enabled = true;
            this.cmbTipoVehiculo.Enabled = true;
        }
        /// <summary>
        /// El boton realizar 2 acciones diferentes dependiendo el motivo por el cual se lo este usando, ingreso o egreso de vehiculos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.grpManual.Text == "Ingreso")
            {
                Vehiculo vehiculoManual;
                try
                {
                    switch (this.cmbTipoVehiculo.SelectedItem)
                    {
                        case Vehiculo.ETipo.Auto:
                            {
                                vehiculoManual = new Automovil(this.txtPatente.Text, DateTime.Now);
                                break;
                            }
                        case Vehiculo.ETipo.Camioneta:
                            {
                                vehiculoManual = new Camioneta(this.txtPatente.Text, DateTime.Now);
                                break;
                            }
                        default:
                            {
                                vehiculoManual = new Moto(this.txtPatente.Text, DateTime.Now);
                                break;
                            }
                    }
                    this.IngresoAEstacionamiento(vehiculoManual);
                }
                catch (PatenteException ex)
                {
                    MessageBox.Show($"{ex.Message}", "Patente Ingresada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.txtPatente.Text = string.Empty;
                this.grpManual.Visible = false;
            }
            else
            {
                this.SalidaDelEstacionamiento((Vehiculo)this.listBoxVehiculos.SelectedItem);
                this.txtPatente.Text = string.Empty;
                this.grpManual.Visible = false;
            }
        }
        /// <summary>
        /// Es el metodo que va a manejar el evento y simulara el ingreso de vehiculos 
        /// </summary>
        /// <param name="vehiculo">Son los vehiculos a agregar al estacionamiento</param>
        private void HabilitarIngresoVehiculo(Vehiculo vehiculo)
        {
            if (this.listBoxVehiculos.InvokeRequired)
            {
                Callback callback = new Callback(this.HabilitarIngresoVehiculo);
                object[] objs = new object[] { vehiculo };
                this.Invoke(callback, objs);
            }
            else
            {
                if (this.estacionamiento.CapacidadEstacionamiento > this.listBoxVehiculos.Items.Count)
                {
                    this.IngresoAEstacionamiento(vehiculo);
                }
                else
                {
                    VehiculosDAO.Activar = false;
                }
            }
        }
        /// <summary>
        /// Ingresa vehiculos al estacionamiento
        /// </summary>
        /// <param name="vehiculo">Es el vehiculo a ingresar</param>
        private void IngresoAEstacionamiento(Vehiculo vehiculo)
        {
            string datosIngreso= string.Empty;
            try
            {
                datosIngreso = this.estacionamiento + vehiculo; //guarda los datos de ingreso para imprimior tck
                this.listBoxVehiculos.Items.Add(vehiculo);
                this.GenerarTicket(vehiculo.Patente, vehiculo.HoraIngreso,datosIngreso);
                this.ActualizarBarraEstado(++this.lugaresOcupados);
            }
            catch (VehiculoEstacionamientoException ex)
            {
                MessageBox.Show($"{ex.Message}", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Retira vehiculos del estacionamiento
        /// </summary>
        /// <param name="vehiculo">Es el vehiculo a retirar</param>
        private void SalidaDelEstacionamiento(Vehiculo vehiculo)
        {
            string datosEgreso = string.Empty;
            try
            {
                vehiculo.HoraEgreso = DateTime.Now;
                datosEgreso = this.estacionamiento - vehiculo; //guarda los datos de salida para imprimior tck
                VehiculosDAO.GuardarRegistros(vehiculo); //guarda los datos en la BD
                this.GenerarTicket(vehiculo.Patente, vehiculo.HoraIngreso, datosEgreso);
                this.listBoxVehiculos.Items.Remove(vehiculo);
                this.ActualizarBarraEstado(--this.lugaresOcupados);
            }
            catch (VehiculoEstacionamientoException ex)
            {
                MessageBox.Show($"{ex.Message}", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (BaseDeDatosException ex)
            {
                MessageBox.Show($"{ex.Message}", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Genera los tickets de ingreso y egreso
        /// </summary>
        /// <param name="patente"></param>
        /// <param name="hora"></param>
        /// <param name="datosVehiculo"></param>
        private void GenerarTicket(string patente, DateTime hora, string datosVehiculo)
        {
            Tickets tickets = new Tickets();
            string nombreArchivo = $"{patente}-{hora.ToString("yyyyMMdd HH.mm")}.txt";
            try
            {
                tickets.GuardarTicket(nombreArchivo, datosVehiculo);
            }
            catch (ArchivoException ex)
            {
                MessageBox.Show($"{ex.Message}", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Metodo generico para actualizar la barra de estados
        /// </summary>
        /// <param name="lugaresOcupados"></param>
        private void ActualizarBarraEstado(int lugaresOcupados)
        {
            this.progressToolBar.Value = lugaresOcupados;
            this.txtToolBar.Text = $"Capacidad: {this.estacionamiento.CapacidadEstacionamiento}/Ocupados: {lugaresOcupados}";
        }

    }
}
