using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSimulator
{
    internal class Paciente : Persona
    {
        public int NumeroOrden { get; set; }
        public string Enfermedades { get; set; }

        public override string ToString()
        {
            return $"Nombre: {Nombre}\nEdad: {Edad}\nSexo: {Sexo}\nDNI: {DNI}";
        }
    }
}
