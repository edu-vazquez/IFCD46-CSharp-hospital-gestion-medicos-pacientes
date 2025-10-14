using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Program
    {
        Hospital hospital = new Hospital();
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al sistema de Gestión de Médicos y Pacientes");
            Console.WriteLine("-------------------------------------------------------");

            Console.WriteLine("Seleccione una opcion:");
            Console.WriteLine("1. Dar de alta / baja un medico");
            Console.WriteLine("2. Dar de alta / baja un paciente");
            Console.WriteLine("3. Asignar medico a paciente");
            Console.WriteLine("4. Listar los médicos, pacientes, o pacientes de un medico");
            Console.WriteLine("5. Ver la lista de todas las personas del hospital");
            Console.WriteLine("-------------------------------------------------------");

            int opcion = 0;

            while (opcion < 1 || opcion > 5)
            {
                Console.Write("Ingrese una opción (1-5): ");
                string input = Console.ReadLine();
                int.TryParse(input, out opcion);
                switch (opcion)
                {
                    case 1:
                        //DarDeAltaBajaMedico();
                        break;
                    case 2:
                        //DarDeAltaBajaPaciente();
                        break;
                    case 3:
                        //AsignarMedicoAPaciente();
                        break;
                    case 4:
                        //ListarInformacion();
                        break;
                    case 5:
                        //VerListaDePersonas();
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                        break;
                }

                Console.ReadKey();
            }

            
        }

        static void DarDeAltaBajaMedico()
        {
            Console.Clear();
            Console.WriteLine("Dar de alta / baja un medico");
            Console.WriteLine("-----------------------------");
            
            Console.WriteLine("Seleccione una opcion:");
            Console.WriteLine("1. Dar de alta un medico");
            Console.WriteLine("2. Dar de baja un medico");
            Console.WriteLine("-----------------------------");

            int opcion = 0;

            while (opcion < 1 || opcion > 2)
            {
                Console.Write("Ingrese una opción (1-2): ");
                string input = Console.ReadLine();
                int.TryParse(input, out opcion);
                switch (opcion)
                {
                    case 1:
                        AltaMedico();
                        break;
                    case 2:
                        //BajaMedico();
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                        break;
                }

            }

            void AltaMedico()
            {
                Console.Clear();
                Console.WriteLine("Alta de un medico");
                Console.WriteLine("--------------------------");

                Console.Write("Ingrese el nombre del medico: ");
                string nombre = Console.ReadLine();

                Console.Write("Ingrese el apellido del medico: ");
                string apellido = Console.ReadLine();

                int edad = 0;
                while (edad <= 0 || edad > 100)
                {
                    Console.Write("Ingrese la edad del medico: ");
                    string inputEdad = Console.ReadLine();
                    int.TryParse(inputEdad, out edad);
                    if (edad <= 0)
                    {
                        Console.WriteLine("Edad inválida. Por favor, intente de nuevo.");
                    }
                }

                Console.Write("Ingrese la especialidad del medico: ");
                string especialidad = Console.ReadLine();

                Medico nuevoMedico = new Medico(nombre, apellido, edad, especialidad);
                Hospital.medicos.Add(nuevoMedico);
                Console.WriteLine($"Medico {nombre} {apellido} dado de alta exitosamente.");
            }

            void BajaMedico()
            {
                Console.Clear();
                Console.WriteLine("Baja de un medico");
                Console.WriteLine("--------------------------");
                Console.Write("Ingrese el nombre del medico a dar de baja: ");
                string nombre = Console.ReadLine();
                Console.Write("Ingrese el apellido del medico a dar de baja: ");
                string apellido = Console.ReadLine();
                // Buscar el médico en la lista de médicos (suponiendo que existe una lista llamada medicos)
                // Medico medicoABaja = medicos.Find(m => m.Nombre == nombre && m.Apellido == apellido);
                // if (medicoABaja != null)
                // {
                //     medicos.Remove(medicoABaja);
                //     Console.WriteLine($"Medico {nombre} {apellido} dado de baja exitosamente.");
                // }
                // else
                // {
                //     Console.WriteLine($"Medico {nombre} {apellido} no encontrado.");
                // }
            }
        }
}
