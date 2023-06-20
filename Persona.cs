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

        public virtual void MostrarValores()
        {
            Type tipo = this.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();

            foreach (PropertyInfo propiedad in propiedades)
            {
                string nombre = propiedad.Name;
                object valor = propiedad.GetValue(this);

                Console.WriteLine($"{nombre}: {valor}");
            }
        }
    }
}
