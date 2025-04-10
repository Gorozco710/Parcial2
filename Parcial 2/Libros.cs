using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class Libros : Form
    {
        private List<Libro> listaLibro = new List<Libro>();
        private LibroArchivo libroArchivo = new LibroArchivo();
        private string rutaArchivo = Path.Combine(Application.StartupPath, "libros.json");

        public Libros()
        {
            InitializeComponent();
            CargarLibros();
        }

        private void CargarLibros()
        {
            listaLibro = libroArchivo.Leer(rutaArchivo);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaLibro;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtAutor.Text = "";
            txtIdentificacion.Text = "";
        }

       

        private void Libros_Load(object sender, EventArgs e)
        {
            CargarLibros();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string autor = txtAutor.Text.Trim();
            string identificacion = txtIdentificacion.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(autor) || string.IsNullOrEmpty(identificacion))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            // Verificar si ya existe un libro con esa identificación
            if (listaLibro.Exists(l => l.Identificacion == identificacion))
            {
                MessageBox.Show("Ya existe un libro con esa identificación.");
                return;
            }

            Libro nuevoLibro = new Libro(nombre, autor, identificacion);
            listaLibro.Add(nuevoLibro);
            libroArchivo.Guardar(rutaArchivo, listaLibro);

            LimpiarCampos();
            CargarLibros();
        }
    }
}
