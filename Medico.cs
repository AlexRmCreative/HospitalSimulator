using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSimulator
{
    internal class Medico : Persona
    {
        public string NumeroColegiado { get; set; }
        public string Especialidad { get; set; }
        public string NumeroTelefono { get; set; }
    }
}
