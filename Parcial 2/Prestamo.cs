using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace Parcial_2
{
    public class Prestamo
    {
        public string NombreLector { get; set; }
        public string NombreLibro { get; set; }
        public DateTime Fecha { get; set; }

        public Prestamo(string nombreLector, string nombreLibro, DateTime fechaPrestamo) 
        {
            NombreLector = nombreLector;
            NombreLibro = nombreLibro;
            Fecha = fechaPrestamo;
        }  
        public Prestamo() { }
        

    }
    public class PrestamoArchivo
    {
        public void Guardar(string archivo, List<Prestamo> alquileres)
        {
            string json = JsonConvert.SerializeObject(alquileres, Formatting.Indented);
            File.WriteAllText(archivo, json);
        }

        public List<Prestamo> Leer(string archivo)
        {
            if (!File.Exists(archivo)) return new List<Prestamo>();

            string json = File.ReadAllText(archivo);
            return JsonConvert.DeserializeObject<List<Prestamo>>(json) ?? new List<Prestamo>();
        }
    }
}
