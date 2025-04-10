using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Parcial_2
{
    internal class Libro
    {
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string Identificacion { get; set; }

        public Libro(string nombre, string autor, string identificacion)
        {
            Nombre = nombre;
            Autor = autor;
            Identificacion = identificacion;
        }
    }

    internal class LibroArchivo
    {
        public void Guardar(string archivo, List<Libro> libros)
        {
            string json = JsonConvert.SerializeObject(libros, Formatting.Indented);
            File.WriteAllText(archivo, json);
        }

        public List<Libro> Leer(string archivo)
        {
            if (!File.Exists(archivo)) return new List<Libro>();

            string json = File.ReadAllText(archivo);
            return JsonConvert.DeserializeObject<List<Libro>>(json) ?? new List<Libro>();
        }
    }
}
