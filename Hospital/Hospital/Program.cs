using System;
using System.Linq;


namespace Hospital
{
    internal class Program
    {
        static Hospital hospital = new Hospital();
        static void Main(string[] args)
        {
            

            int opcion = 0;
            string input = "";

            while (input != "exit")
            {
                MostrarMenu();
                Console.Write("Ingrese una opción: ");
                input = Console.ReadLine();

                int.TryParse(input, out opcion);
                switch (opcion)
                {
                    case 1:
                        DarAltaMedico(hospital);
                        break;
                    case 2:
                        DarBajaMedico(hospital);
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
            }
            Console.WriteLine("Haz salido del programa. Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Bienvenido al sistema de Gestión de Médicos y Pacientes");
            Console.WriteLine("Seleccione una opcion:");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("1. Dar de alta un medico");
            Console.WriteLine("2. Dar de baja un medico");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("3. Dar de alta un paciente");
            Console.WriteLine("4. Dar de baja un paciente");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("5. Asignar medico a paciente");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("6. Listar los médicos");
            Console.WriteLine("7. Listar los pacientes");
            Console.WriteLine("8. Listar los pacientes de un médico");
            Console.WriteLine("10. Listar todas las personas del hospital");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("escriba *exit* para salir");
        }
        static void DarAltaMedico(Hospital hospital)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del medico:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido del medico:");
            string apellido = Console.ReadLine();

            Console.WriteLine("Ingrese la edad del medico:");
            int edad = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la especialidad del medico:");
            string especialidad = Console.ReadLine();

            Medico medico = new Medico(nombre, apellido, edad, especialidad);
            hospital.AltaMedico(medico);

            Console.WriteLine("Medico agregado exitosamente:");
            Console.WriteLine(medico.ToString());
            Continuar();
        }

        static void DarBajaMedico(Hospital hospital)
        {
            Console.Clear();

            Console.WriteLine("Ingrese el nombre del medico a dar de baja:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido del medico a dar de baja:");
            string apellido = Console.ReadLine();

            Medico medico = hospital.Medicos
                .FirstOrDefault(m => m.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) &&
                                     m.Apellido.Equals(apellido, StringComparison.OrdinalIgnoreCase));
            
            if (medico != null)
            {
                hospital.BajaMedico(medico);
                Console.WriteLine("Medico dado de baja exitosamente:");
                Console.WriteLine(medico.ToString());
            }
            else
            {
                Console.WriteLine("No se encontró un medico con ese nombre y apellido.");
            }

            Continuar();
        }

        static void Continuar()
        {
            Console.WriteLine("Presiona cualquier tecla para continuar para volver al menu principal");
            Console.ReadKey();
        }

    }
}
