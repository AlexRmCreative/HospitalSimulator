using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSimulator
{
    internal class Medico : Persona
    {
        public string NumeroColegiado { get; set; }
        public List<Especialidad> Especialidades { get; set; }
        public string Especialidad { get; set; }
        public List<Paciente> ListaPacientes { get; set; }

        public Medico()
        {
            Especialidades = new List<Especialidad>
            {
                new Especialidad("Médico de atención primaria")
                {
                    Enfermedades = new List<string>
                    {
                        "Resfriado común",
                        "Gripe",
                        "Diabetes tipo 2",
                        "Colesterol elevado"
                    }
                },
                new Especialidad("Neumólogo")
                {
                    Enfermedades = new List<string>
                    {
                        "Asma",
                        "Bronquitis crónica",
                        "Tuberculosis pulmonar",
                        "Neumonía"
                    }
                },
                new Especialidad("Oncólogo")
                {
                    Enfermedades = new List<string>
                    {
                        "Cáncer",
                        "Leucemia",
                        "Linfoma",
                        "Melanoma"
                    }
                },
                new Especialidad("Neurólogo")
                {
                    Enfermedades = new List<string>
                    {
                        "Epilepsia",
                        "Alzheimer",
                        "Trastornos del sueño",
                        "Migraña"
                    }
                },
                new Especialidad("Dermatólogo")
                {
                    Enfermedades = new List<string>
                    {
                        "Acné",
                        "Psoriasis",
                        "Infecciones cutáneas",
                        "Dermatitis"
                    }
                },
                new Especialidad("Cardiólogo")
                {
                    Enfermedades = new List<string>
                    {
                        "Hipertensión arterial",
                        "Insuficiencia cardíaca",
                        "Infarto de miocardio",
                        "Cardiopatía congénita"
                    }
                }
            };
        }
        public override void MostrarValores()
        {
            Type tipo = this.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();

            foreach (PropertyInfo propiedad in propiedades)
            {
                if (propiedad.Name != "Especialidades")  // Excluir la propiedad "Especialidades"
                {
                    string nombre = propiedad.Name;
                    object valor = propiedad.GetValue(this);

                    Console.WriteLine($"{nombre}: {valor}");
                }
            }
        }

    }

    internal class Especialidad
    {
        public string Nombre { get; set; }
        public List<string> Enfermedades { get; set; }

        public Especialidad(string nombre)
        {
            Nombre = nombre;
            Enfermedades = new List<string>();
        }
    }
}
