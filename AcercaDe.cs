using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fase3_AndersonMolina
{
    public partial class AcercaDe : Form
    {
        public AcercaDe()
        {
            InitializeComponent();
            DiseñarFormulario();
        }

        private void DiseñarFormulario()
        {
            // Configuración básica del formulario
            this.Text = "Acerca del Sistema";
            this.Size = new Size(600, 400); // Un poco menos de 600x400
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 240); // Fondo gris claro
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Panel contenedor para mejor organización
            Panel panelContenedor = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(panelContenedor);

            // Título principal
            Label lblTitulo = new Label
            {
                Text = "INFORMACIÓN DEL DESARROLLADOR",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(70, 130, 180), // Azul acero
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };
            lblTitulo.Location = new Point(30, 20);
            panelContenedor.Controls.Add(lblTitulo);

            // Información del desarrollador
            string[] info = {
                "Nombre: Anderson Molina",
                "Programa: Ingeniería de Sistemas",
                "Materia: Estructura de Datos",
                "Universidad: UNAD",
                "Año: 2025",
            };

            int yPos = 70;
            foreach (string item in info)
            {
                Label lblInfo = new Label
                {
                    Text = item,
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.FromArgb(50, 50, 50), // Gris oscuro
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleLeft
                };
                lblInfo.Location = new Point(50, yPos);
                panelContenedor.Controls.Add(lblInfo);
                yPos += 30;
            }

            // Botón Volver
            Button btnVolver = new Button
            {
                Text = "VOLVER",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(70, 130, 180), // Azul acero
                FlatStyle = FlatStyle.Flat,
                Size = new Size(120, 40),
                Cursor = Cursors.Hand
            };
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Location = new Point((panelContenedor.Width - btnVolver.Width) / 2, yPos + 20);
            btnVolver.Click += (s, e) => this.Close();
            panelContenedor.Controls.Add(btnVolver);

            // Efecto hover para el botón
            btnVolver.MouseEnter += (s, e) =>
            {
                btnVolver.BackColor = Color.FromArgb(65, 105, 225); // Azul más claro
            };
            btnVolver.MouseLeave += (s, e) =>
            {
                btnVolver.BackColor = Color.FromArgb(70, 130, 180); // Azul original
            };
        }
    }
}