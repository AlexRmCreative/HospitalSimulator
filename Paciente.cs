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
        public string[] Enfermedades = { "Resfriado común", "Gripe", "Diabetes tipo 2", "Colesterol elevado", "Asma", "Bronquitis crónica", "Tuberculosis pulmonar","Neumonía","Cáncer","Leucemia","Linfoma","Melanoma","Epilepsia","Alzheimer","Trastornos del sueño","Migraña","Acné","Psoriasis","Infecciones cutáneas","Dermatitis","Hipertensión arterial","Insuficiencia cardíaca","Infarto de miocardio","Cardiopatía congénita" };
        public string Enfermedad { get; set; }
        public Medico Medico{ get; set; }

        public override string ToString()
        {
            return $"Nombre: {Nombre}\nEdad: {Edad}\nSexo: {Sexo}\nDNI: {DNI}";
        }
    }
}
