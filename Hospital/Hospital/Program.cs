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
                    case 0:
                        Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                        break;
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
    }
}
