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
    public partial class Prestamos : Form
    {
        private List<Libro> listaLibros = new List<Libro>();
        private List<Lector> listaLectores = new List<Lector>();
        private List<Prestamo> listaPrestamos = new List<Prestamo>();
        private PrestamoArchivo prestamoArchivo = new PrestamoArchivo();
        private string rutaArchivoPrestamos = Path.Combine(Application.StartupPath, "prestamo.json");
        private string rutaArchivoLibros = Path.Combine(Application.StartupPath, "libros.json");
        private string rutaArchivoLectores = Path.Combine(Application.StartupPath, "Lector.json");

        public Prestamos()
        {
            InitializeComponent();
            
        }

        private void CargarLibros()
        {
            LibroArchivo libroArchivo = new LibroArchivo();
            listaLibros = libroArchivo.Leer(rutaArchivoLibros);
            comboBoxLibros.DataSource = listaLibros;
            comboBoxLibros.DisplayMember = "Nombre";             
            comboBoxLibros.ValueMember = "Identificacion";
        }

        private void CargarLectores()
        {
            LectorArchivo lectorArchivo = new LectorArchivo();
            listaLectores = lectorArchivo.Leer(rutaArchivoLectores);
            comboBoxLectores.DataSource = listaLectores;
            comboBoxLectores.DisplayMember = "Nombre";          
            comboBoxLectores.ValueMember = "Identificacion";
        }

        private void CargarPrestamos()
        {
            listaPrestamos = prestamoArchivo.Leer(rutaArchivoPrestamos);
            dataGridView1.DataSource = listaPrestamos;
        }


        private void Prestamos_Load(object sender, EventArgs e)
        {
            CargarLibros();
            CargarLectores();
            CargarPrestamos();
        }
        private void LimpiarCampos()
        {
            comboBoxLibros.SelectedIndex = -1;
            comboBoxLectores.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (comboBoxLectores.SelectedValue == null || comboBoxLibros.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un lector y un libro.");
                return;
            }

            DateTime fechaPrestamo = dateTimePicker1.Value;
            string nombreLector = comboBoxLectores.Text;
            string nombreLibro = comboBoxLibros.Text;

            // Crear nuevo préstamo
            Prestamo nuevoPrestamo = new Prestamo(nombreLector, nombreLibro, fechaPrestamo);
            listaPrestamos.Add(nuevoPrestamo);

            // Guardar en archivo JSON
            prestamoArchivo.Guardar(rutaArchivoPrestamos, listaPrestamos);

            // Actualizar el DataGridView
            CargarPrestamos();

            // Limpiar los campos del formulario
            LimpiarCampos();
        }

    }
}
