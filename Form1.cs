using System;
using System.Windows.Forms;

namespace Fase3_AndersonMolina
{
    public partial class Form1 : Form
    {
        private const string CONTRASENA = "1234";

        public Form1()
        {
            InitializeComponent();

            // Asignar eventos a los botones numéricos
            btn1.Click += NumButton_Click;
            btn2.Click += NumButton_Click;
            btn3.Click += NumButton_Click;
            btn4.Click += NumButton_Click;
            btn5.Click += NumButton_Click;
            btn6.Click += NumButton_Click;
            btn7.Click += NumButton_Click;
            btn8.Click += NumButton_Click;
            btn9.Click += NumButton_Click;
            btn0.Click += NumButton_Click;

            // Asignar evento al botón Acerca de
            btnAcercaDe.Click += BtnAcercaDe_Click;
        }

        private void NumButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                txtPassword.Text += button.Text;
            }
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.Text == CONTRASENA)
            {
                this.Hide();
                var Datos = new Datos();
                Datos.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta.");
                txtPassword.Clear();
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            txtPassword.Clear();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAcercaDe_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario AcercaDe como diálogo
            var acercaDe = new AcercaDe();
            this.Hide(); // Opcional: ocultar el formulario actual
            acercaDe.ShowDialog();
            this.Show(); // Volver a mostrar el formulario de login
        }
    }
}