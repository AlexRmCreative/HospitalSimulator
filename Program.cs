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
            Persona persona = DarAlta();
            Console.Clear();
            WriteHeader();
            Console.Write(persona.ToString());
            Console.ReadLine();
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
        {/*
            ConsoleKeyInfo input = Console.ReadKey();*/
            Persona persona;
            persona = new Paciente();
            RellenarDatos(persona);
            return persona;
        }
        public static Persona ModificarDatos(Persona persona)
        {
            persona = RellenarDatos(persona);
            return persona;
        }
        public static Persona RellenarDatos(Persona persona)
        {
            bool edadValida = false, DNIValido = false, sexoValido = false;
            Console.Write("Introduzca su nombre: ");
            persona.Nombre = Console.ReadLine();

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
                    edadValida = false;
                    Console.Clear();
                    WriteHeader();
                    Console.WriteLine("Error: La edad debe ser un número entero. Inténtelo nuevamente.");
                }
            } while (!edadValida);

            do
            {
                Console.Write("Introduzca su DNI: ");
                try
                {
                    persona.DNI = Console.ReadLine().ToUpper();
                    if (persona.DNI.Length < 9)
                        throw new FormatException();
                    for (int i = 0; i < 8; i++)
                    {
                        if (persona.DNI[i] < '0' || persona.DNI[i] > '9')
                        {
                            throw new FormatException();
                        }
                    }
                    if (!Char.IsLetter(persona.DNI[8]))
                    {
                        throw new FormatException();
                    }
                    else
                    {
                        DNIValido = true;
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    WriteHeader();
                    Console.WriteLine("Error: DNI Incorrecto. Inténtelo nuevamente.");
                }
            } while (!DNIValido);

            do
            {
                Console.WriteLine("Introduzca su Sexo: (M / F)");
                try
                {
                    persona.Sexo = Char.Parse(Console.ReadLine().ToUpper());
                    if(persona.Sexo == 'M' || persona.Sexo == 'F')
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
                    Console.Clear();
                    WriteHeader();
                    Console.WriteLine("Error: Sexo no definido. Inténtelo nuevamente.");
                }
            }
            while (!sexoValido);

            return persona;
        }
    }
}
