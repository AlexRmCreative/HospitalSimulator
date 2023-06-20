using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSimulator
{
    internal class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public char Sexo { get; set; }
        public string DNI { get; set; }

        public void MostrarValores(Persona obj)
        {
            Type tipo = obj.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();

            foreach (PropertyInfo propiedad in propiedades)
            {
                string nombre = propiedad.Name;
                object valor = propiedad.GetValue(obj);

                Console.WriteLine($"{nombre}: {valor}");
            }
        }
    }
}
