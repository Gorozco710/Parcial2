using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Parcial_2
{
    internal class Lector
    {
        public string Nombre { get; set; }
        public string Identificacion { get; set; }

        public Lector(string nombre, string identificacion)
        {
            Nombre = nombre;
            Identificacion = identificacion;
        }
    }

    internal class LectorArchivo
    {
        public void Guardar(string archivo, List<Lector> lectores)
        {
            string json = JsonConvert.SerializeObject(lectores, Formatting.Indented);
            File.WriteAllText(archivo, json);
        }

        public List<Lector> Leer(string archivo)
        {
            if (!File.Exists(archivo)) return new List<Lector>();

            string json = File.ReadAllText(archivo);
            return JsonConvert.DeserializeObject<List<Lector>>(json) ?? new List<Lector>();
        }
    }
}
