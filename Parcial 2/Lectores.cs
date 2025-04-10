using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class Lectores : Form
    {
        private List<Lector> listaLector = new List<Lector>();
        private LectorArchivo lectorArchivo = new LectorArchivo();
        private string rutaArchivo = Path.Combine(Application.StartupPath, "Lector.json");
        public Lectores()
        {
            InitializeComponent();
            CargarLectores();
        }
        private void CargarLectores()
        {
            listaLector = lectorArchivo.Leer(rutaArchivo);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaLector;
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtIdentificacion.Text = "";
        }
        private void Lectores_Load(object sender, EventArgs e)
        {
            CargarLectores();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string identificacion = txtIdentificacion.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(identificacion))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            if (listaLector.Exists(l => l.Identificacion == identificacion))
            {
                MessageBox.Show("Ya existe un lector con esa identificación.");
                return;
            }

            Lector nuevoLector = new Lector(nombre, identificacion);
            listaLector.Add(nuevoLector);
            lectorArchivo.Guardar(rutaArchivo, listaLector);

            LimpiarCampos();
            CargarLectores();
        }
    }
}
