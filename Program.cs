using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteHeader();
            MenuInicio();
            Console.ReadLine();
        }
        public static void MenuInicio()
        {
            Persona persona = null; // Variable para almacenar la persona según la opción elegida

            do
            {
                Console.WriteLine("Bienvenido a Hospital Besukon\n\n- Si eres un paciente pulsa P\n- Si quieres darte de alta pulsa A\n- Si eres medico o enfermera de este hospital pulse M");
                ConsoleKeyInfo respuesta = Console.ReadKey();

                switch (respuesta.Key)
                {
                    case ConsoleKey.P:
                        persona = new Paciente();
                        break;
                    case ConsoleKey.M:
                        persona = new Medico();
                        break;
                    case ConsoleKey.A:
                        DarAlta();
                        return; // Salir del método después de dar de alta
                    default:
                        FormatError("Tecla inválida.");
                        break;
                }
            }
            while (persona == null); // Bucle continuará hasta que se elija una opción válida
        }

        public static void WriteHeader()
        {
            Console.WriteLine(@"
                    _  _  ___  ___ ___ ___ _____ _   _      ___ ___ ___ _   _ _  _____  _  _ 
                   | || |/ _ \/ __| _ \_ _|_   _/_\ | |    | _ ) __/ __| | | | |/ / _ \| \| |
                   | __ | (_) \__ \  _/| |  | |/ _ \| |__  | _ \ _|\__ \ |_| | ' < (_) | .` |
                   |_||_|\___/|___/_| |___| |_/_/ \_\____| |___/___|___/\___/|_|\_\___/|_|\_|
                                                                           ");
        }
        public static Persona DarAlta()
        {
            Persona persona = null;
            Console.WriteLine("¿Sera usted un medico o un paciente? (M/P)");
            ConsoleKeyInfo respuesta = Console.ReadKey();

            switch (respuesta.Key)
            {
                case ConsoleKey.M:
                    persona = new Medico();
                    break;
                case ConsoleKey.P:
                    persona = new Paciente();
                    break;
                default:
                    FormatError("Opción inválida.");
                    return null;
            }
            persona = RellenarDatosComunes(persona);

            if (persona is Paciente)
            {
                AltaPaciente(persona);
            }
            else if (persona is Medico)
            {
                AltaMedico(persona);
            }

            return persona;
        }
        public static Paciente AltaPaciente(Persona persona)
        {
            Paciente paciente = persona as Paciente;
            int separador = 4;
            for (int i = 0; i < separador; i++)
            {
                //sumar 4 a separador y decir cual es mi especialistaaaaa
            }

            Console.WriteLine("Cual es el motivo de su cita? (Escriba el número)");

            /*//Escribir lista de enfermedades
            for (int i = 0; i < enfermedades.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {enfermedades[i]}[{i + 1}]");
            }

            int seleccion = -1;
            while (seleccion < 1 || seleccion > enfermedades.Length)
            {
                Console.Write("Seleccione una opción: ");
                if (int.TryParse(Console.ReadLine(), out seleccion))
                {
                    if (seleccion < 1 || seleccion > enfermedades.Length)
                    {
                        Console.WriteLine("Opción inválida. Inténtelo nuevamente.");
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Inténtelo nuevamente.");
                }
            }
            paciente.Enfermedad = enfermedades[seleccion - 1];
            if(listaMedicos.Count > 0)
            {
                foreach (Medico medico in listaMedicos)
                {

                    //switch case de especialidades, según mi enfermedad,  se me asignara a la lista de pacientes del Medico correspondiente, lista llamada "ListaPacientes"
                }
            }*/
            return paciente;
        }
        public static Medico AltaMedico(Persona persona)
        {
            Medico medico = persona as Medico;

            Console.WriteLine("Cual es su especialidad? (Escriba el número)");

            //Escribir lista de especialidades
            for (int i = 0; i < medico.Especialidades.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {medico.Especialidades[i].Nombre}[{i + 1}]");
            }

            int seleccion = -1;
            /*while (seleccion < 1 || seleccion > especialidades.Length)
            {
                Console.Write("Seleccione una opción: ");
                if (int.TryParse(Console.ReadLine(), out seleccion))
                {
                    if (seleccion < 1 || seleccion > especialidades.Length)
                    {
                        Console.WriteLine("Opción inválida. Inténtelo nuevamente.");
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Inténtelo nuevamente.");
                }
            }
            medico.Especialidad = especialidades[seleccion - 1];*/
            medico.NumeroColegiado = new Random().Next(1000, 9999).ToString();
            return medico;
        }
        public static Persona RellenarDatosComunes(Persona persona)
        {
            do
            {
                try
                {
                    Console.Write("Introduzca su nombre: ");
                    persona.Nombre = Console.ReadLine();
                    if (persona.Nombre.Length < 2)
                        throw new FormatException();
                }
                catch (FormatException)
                {
                    FormatError("Nombre demasiado corto.");
                }
            }
            while (persona.Nombre.Length < 2);

            bool edadValida = false, DNIValido = false, sexoValido = false;
            do
            {
                try
                {
                    Console.Write("Introduzca su apellido: ");
                    persona.Apellido = Console.ReadLine();
                    persona.Apellido.ToUpper();
                    if (persona.Apellido.Length < 2)
                        throw new FormatException();
                }
                catch (FormatException)
                {
                    FormatError("Apellido demasiado corto.");
                }
            }
            while (persona.Apellido.Length < 2);

            do
            {
                Console.Write("Introduzca su Edad: ");
                try
                {
                    persona.Edad = Int32.Parse(Console.ReadLine());
                    edadValida = true;
                }
                catch (FormatException)
                {
                    FormatError("La edad debe ser un número entero. Inténtelo nuevamente.");
                }
            } while (!edadValida);

            do
            {
                Console.Write("Introduzca su DNI: ");
                try
                {
                    persona.DNI = Console.ReadLine().ToUpper();
                    if (persona.DNI.Length != 9)
                    {
                        throw new FormatException();
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        if (!Char.IsDigit(persona.DNI[i]))
                        {
                            throw new FormatException();
                        }
                    }
                    if (!Char.IsLetter(persona.DNI[8]))
                    {
                        throw new FormatException();
                    }
                    DNIValido = true;
                }
                catch (FormatException)
                {
                    FormatError("DNI Incorrecto. Inténtelo nuevamente.");
                }
            } while (!DNIValido);

            do
            {
                Console.WriteLine("Introduzca su Sexo: (M / F)");
                try
                {
                    persona.Sexo = Char.Parse(Console.ReadLine().ToUpper());
                    if (persona.Sexo == 'M' || persona.Sexo == 'F')
                    {
                        sexoValido = true;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    FormatError("Sexo no definido.Inténtelo nuevamente.");
                }
            } while (!sexoValido);
            return persona;
        }
        public static Persona RellenarDatos(Persona persona)
        {
            return persona;
        }
   
        public static void FormatError(string error)
        {
            Console.Clear();
            WriteHeader();
            Console.WriteLine($"Error: {error}");
        }
    }
}
