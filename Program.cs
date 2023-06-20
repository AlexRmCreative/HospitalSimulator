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

            for (int i = 0; i < paciente.Enfermedades.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {paciente.Enfermedades[i]}");
            }
            int seleccion = -1;
            while (seleccion < 1 || seleccion > paciente.Enfermedades.Length)
            {
                Console.Write("Seleccione una opción: ");
                if (int.TryParse(Console.ReadLine(), out seleccion))
                {
                    if (seleccion < 1 || seleccion > paciente.Enfermedades.Length)
                    {
                        Console.WriteLine("Opción inválida. Inténtelo nuevamente.");
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Inténtelo nuevamente.");
                }
            }

            paciente.Enfermedad = paciente.Enfermedades[seleccion - 1];

            Console.Clear();
            paciente.MostrarValores();
            return paciente;
        }
        public static Medico AltaMedico(Persona persona)
        {
            Medico medico = persona as Medico;

            Console.WriteLine("Cual es su especialidad? (Introduzca el número correspondiente a su especialidad)");

            for (int i = 0; i < medico.Especialidades.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {medico.Especialidades[i].Nombre}");
            }

            // Pedir al usuario que elija una especialidad
            int seleccion = -1;
            while (seleccion < 1 || seleccion > medico.Especialidades.Count)
            {
                Console.Write("Seleccione una opción: ");
                if (int.TryParse(Console.ReadLine(), out seleccion))
                {
                    if (seleccion < 1 || seleccion > medico.Especialidades.Count)
                    {
                        Console.WriteLine("Opción inválida. Inténtelo nuevamente.");
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Inténtelo nuevamente.");
                }
            }
            // Obtener la especialidad seleccionada por el usuario y eliminar demas especialdiades
            medico.Especialidad = medico.Especialidades[seleccion - 1].Nombre;
            medico.Especialidades.Clear();

            medico.NumeroColegiado = new Random().Next(1000, 9999).ToString();

            medico.MostrarValores();
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
                    if(persona.Edad > 120 || persona.Edad < 3) throw new Exception("Introduzca otra edad.");
                    if(persona is Medico && persona.Edad < 22) throw FormatError("Usted es demasiado joven...(Introduzca una edad valida)");
                    edadValida = true;
                }
                catch (FormatException)
                {
                    FormatError("La edad debe ser un número entero. Inténtelo nuevamente.");
                }
                catch (Exception){ }
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
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                if (key.KeyChar == 'M' || key.KeyChar == 'm')
                {
                    persona.Sexo = 'M';
                    sexoValido = true;
                }
                else if (key.KeyChar == 'F' || key.KeyChar == 'f')
                {
                    persona.Sexo = 'F';
                    sexoValido = true;
                }
                else
                {
                    Console.WriteLine("Sexo no definido. Inténtelo nuevamente.");
                }
            } while (!sexoValido);

            return persona;
        }
        public static Persona RellenarDatos(Persona persona)
        {
            return persona;
        }
   
        public static Exception FormatError(string error)
        {
            Exception exception = new Exception(error);
            Console.Clear();
            WriteHeader();
            Console.WriteLine($"Error: {error}");
            return exception;
        }
    }
}
