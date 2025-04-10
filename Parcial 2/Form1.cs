using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            Libros libros = new Libros(); 
            libros.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lectores lectores = new Lectores();
            lectores.Show();
        }
    }
}
