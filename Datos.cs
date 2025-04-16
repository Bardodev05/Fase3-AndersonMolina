using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fase3_AndersonMolina
{
    public partial class Datos : Form
    {
        // Variables para las estructuras de datos
        private Stack<EstructuraDatosAfiliado> pilaAfiliados = new Stack<EstructuraDatosAfiliado>();
        private Queue<EstructuraDatosAfiliado> colaAfiliados = new Queue<EstructuraDatosAfiliado>();
        private List<EstructuraDatosAfiliado> listaAfiliados = new List<EstructuraDatosAfiliado>();

        public Datos()
        {
            InitializeComponent();
            ConfigurarDataGridViews();
        }

        private void ConfigurarDataGridViews()
        {
            dataGridViewPila.AutoGenerateColumns = true;
            dataGridViewCola.AutoGenerateColumns = true;
            dataGridViewLista.AutoGenerateColumns = true;
        }

        public class EstructuraDatosAfiliado
        {
            public string TipoIdentificacion { get; set; }
            public string NumeroIdentificacion { get; set; }
            public string NombreCompleto { get; set; }
            public decimal Salario { get; set; }
            public int Estrato { get; set; }
            public bool AfiliadoSISBEN { get; set; }
            public decimal ValorSubsidio { get; set; }
            public DateTime FechaAfiliacion { get; set; }
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrEmpty(comboBoxTipoIdentificacion.Text) ||
                string.IsNullOrEmpty(textBoxNumeroIdentificacion.Text) ||
                string.IsNullOrEmpty(textBoxNombreCompleto.Text) ||
                string.IsNullOrEmpty(textBox1.Text) ||
                comboBoxEstrato.SelectedIndex == -1 ||
                (!radioButtonSi.Checked && !radioButtonNO.Checked))
            {
                MessageBox.Show("Por favor complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que el número de identificación sea numérico
            if (!long.TryParse(textBoxNumeroIdentificacion.Text, out _))
            {
                MessageBox.Show("El número de identificación debe contener solo números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que el nombre solo contenga letras
            if (!textBoxNombreCompleto.Text.All(c => char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("El nombre debe contener solo letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que el salario sea numérico
            if (!decimal.TryParse(textBox1.Text, out decimal salario))
            {
                MessageBox.Show("El salario debe ser un valor numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calcular el subsidio
            decimal subsidio = CalcularSubsidio(salario, comboBoxEstrato.SelectedIndex + 1, radioButtonSi.Checked);
            textBoxValorSubsidio.Text = subsidio.ToString("C");

            // Crear el objeto afiliado
            var afiliado = new EstructuraDatosAfiliado
            {
                TipoIdentificacion = comboBoxTipoIdentificacion.Text,
                NumeroIdentificacion = textBoxNumeroIdentificacion.Text,
                NombreCompleto = textBoxNombreCompleto.Text,
                Salario = salario,
                Estrato = comboBoxEstrato.SelectedIndex + 1,
                AfiliadoSISBEN = radioButtonSi.Checked,
                ValorSubsidio = subsidio,
                FechaAfiliacion = dateTimePickerFechaAfiliacion.Value
            };

            // Registrar según la estructura seleccionada
            switch (comboBoxEstructura.Text.ToLower())
            {
                case "pila":
                    pilaAfiliados.Push(afiliado);
                    ActualizarDataGridViewPila();
                    tabControl1.SelectedTab = tabPage1;
                    break;
                case "cola":
                    colaAfiliados.Enqueue(afiliado);
                    ActualizarDataGridViewCola();
                    tabControl1.SelectedTab = tabPage2;
                    break;
                case "lista":
                    listaAfiliados.Add(afiliado);
                    ActualizarDataGridViewLista();
                    tabControl1.SelectedTab = tabPage3;
                    break;
                default:
                    MessageBox.Show("Seleccione una estructura de datos válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private decimal CalcularSubsidio(decimal salario, int estrato, bool afiliadoSISBEN)
        {
            decimal subsidio = 0;

            if (afiliadoSISBEN)
            {
                switch (estrato)
                {
                    case 1: subsidio = 450000; break;
                    case 2: subsidio = 350000; break;
                    case 3: subsidio = 250000; break;
                    case 4: subsidio = 150000; break;
                        // Estratos 5 y 6 no tienen subsidio
                }

                if (salario < 500000)
                    subsidio += 50000;
            }
            else
            {
                switch (estrato)
                {
                    case 1: subsidio = 300000; break;
                    case 2: subsidio = 200000; break;
                    case 3: subsidio = 100000; break;
                    case 4: subsidio = 50000; break;
                        // Estratos 5 y 6 no tienen subsidio
                }

                if (salario < 1000000)
                    subsidio += 150000;
            }

            return subsidio;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar todos los campos
            comboBoxTipoIdentificacion.SelectedIndex = -1;
            textBoxNumeroIdentificacion.Clear();
            textBoxNombreCompleto.Clear();
            textBox1.Clear();
            comboBoxEstrato.SelectedIndex = -1;
            radioButtonSi.Checked = false;
            radioButtonNO.Checked = false;
            textBoxValorSubsidio.Clear();
            dateTimePickerFechaAfiliacion.Value = DateTime.Now;
            comboBoxEstructura.SelectedIndex = -1;
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show("¿Deseas salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar == DialogResult.Yes)
                Application.Exit();
        }

        private void ActualizarDataGridViewPila()
        {
            dataGridViewPila.DataSource = null;
            dataGridViewPila.DataSource = pilaAfiliados.Reverse().ToList();
        }

        private void ActualizarDataGridViewCola()
        {
            dataGridViewCola.DataSource = null;
            dataGridViewCola.DataSource = colaAfiliados.ToList();
        }

        private void ActualizarDataGridViewLista()
        {
            dataGridViewLista.DataSource = null;
            dataGridViewLista.DataSource = listaAfiliados.ToList();
        }

        private void buttonReportePila_Click(object sender, EventArgs e)
        {
            if (pilaAfiliados.Count == 0)
            {
                textBoxReporte.Text = "No hay registros en la pila";
                return;
            }

            decimal sumaSubsidios = pilaAfiliados.Sum(a => a.ValorSubsidio);
            textBoxReporte.Text = $"Suma de subsidios (Pila): {sumaSubsidios:C}";
        }

        private void buttonReporteCola_Click(object sender, EventArgs e)
        {
            if (colaAfiliados.Count == 0)
            {
                textBoxReporte.Text = "No hay registros en la cola";
                return;
            }

            int cantidad = colaAfiliados.Count;
            textBoxReporte.Text = $"Cantidad de registros (Cola): {cantidad}";
        }

        private void buttonReporteLista_Click(object sender, EventArgs e)
        {
            if (listaAfiliados.Count == 0)
            {
                textBoxReporte.Text = "No hay registros en la lista";
                return;
            }

            decimal promedio = listaAfiliados.Average(a => a.Salario);
            textBoxReporte.Text = $"Promedio de salarios (Lista): {promedio:C}";
        }

        private void buttonEliminarPila_Click(object sender, EventArgs e)
        {
            if (pilaAfiliados.Count == 0)
            {
                MessageBox.Show("La pila está vacía.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar el último registro de la pila?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pilaAfiliados.Pop();
                ActualizarDataGridViewPila();
            }
        }

        private void buttonEliminarCola_Click(object sender, EventArgs e)
        {
            if (colaAfiliados.Count == 0)
            {
                MessageBox.Show("La cola está vacía.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar el primer registro de la cola?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                colaAfiliados.Dequeue();
                ActualizarDataGridViewCola();
            }
        }

        private void buttonEliminarLista_Click(object sender, EventArgs e)
        {
            if (listaAfiliados.Count == 0)
            {
                MessageBox.Show("La lista está vacía.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string id = textBoxNumeroIdentificacion.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Ingrese el número de identificación del afiliado a eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var afiliado = listaAfiliados.FirstOrDefault(a => a.NumeroIdentificacion == id);
            if (afiliado == null)
            {
                MessageBox.Show("No se encontró un afiliado con ese número de identificación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"¿Está seguro de eliminar a {afiliado.NombreCompleto} de la lista?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listaAfiliados.Remove(afiliado);
                ActualizarDataGridViewLista();
            }
        }

        private void comboBoxEstructura_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mostrar el DataGridView correspondiente a la estructura seleccionada
            switch (comboBoxEstructura.Text.ToLower())
            {
                case "pila":
                    tabControl1.SelectedTab = tabPage1;
                    break;
                case "cola":
                    tabControl1.SelectedTab = tabPage2;
                    break;
                case "lista":
                    tabControl1.SelectedTab = tabPage3;
                    break;
            }
        }
    }
}