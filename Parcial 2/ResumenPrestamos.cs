using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class ResumenPrestamos : Form
    {
        private List<Prestamo> listaPrestamos = new List<Prestamo>();
        private string rutaArchivoPrestamos = Path.Combine(Application.StartupPath, "prestamo.json");

        public ResumenPrestamos()
        {
            InitializeComponent();
        }

        private void ResumenPrestamos_Load(object sender, EventArgs e)
        {
            CargarPrestamos();
            MostrarPrestamosOrdenados();
            MostrarTotalPrestamos();
        }

        private void CargarPrestamos()
        {
            if (File.Exists(rutaArchivoPrestamos))
            {
                string json = File.ReadAllText(rutaArchivoPrestamos);
                listaPrestamos = JsonConvert.DeserializeObject<List<Prestamo>>(json);
            }
        }

        private void MostrarPrestamosOrdenados()
        {
            var prestamosOrdenados = listaPrestamos.OrderBy(p => p.Fecha).ToList();
            dataGridViewResumen.DataSource = null;
            dataGridViewResumen.DataSource = prestamosOrdenados;
        }

        private void MostrarTotalPrestamos()
        {
            labelTotalPrestamos.Text = listaPrestamos.Count.ToString();
        }
    }
}
