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

                if (input == "exit")
                {
                    break;
                }        

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
                        DarAltaPaciente(hospital);
                        break;
                    case 4:
                        DarBajaPaciente(hospital);
                        break;
                    case 5:
                        //VerListaDePersonas();
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                        break;
                }
            }
            Console.WriteLine("Haz CERRADO del programa. Presiona cualquier tecla para continuar...");
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
            Console.WriteLine();
            Console.WriteLine("escriba *exit* para salir");
            Console.WriteLine();
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
            VolverAlMenuPrincipal();
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

            VolverAlMenuPrincipal();
        }

        static void DarAltaPaciente()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del paciente:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido del paciente:");
            string apellido = Console.ReadLine();

            Console.WriteLine("Ingrese la edad del paciente:");
            int edad = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre del medico asignado:");
            string nombreMedico = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido del medico asignado:");
            string apellidoMedico = Console.ReadLine();

            Medico medicoAsignado = hospital.Medicos
                .FirstOrDefault(m => m.Nombre.Equals(nombreMedico, StringComparison.OrdinalIgnoreCase) &&
                                     m.Apellido.Equals(apellidoMedico, StringComparison.OrdinalIgnoreCase));
            if (medicoAsignado == null)
                {
                Console.WriteLine("No se encontró un medico con ese nombre y apellido. El paciente no tendrá medico asignado.");
            }

            Paciente paciente = new Paciente(nombre, apellido, edad);

            paciente.MedicoAsignado = medicoAsignado;

            hospital.AltaPaciente(paciente);
            Console.WriteLine("Paciente agregado exitosamente:");
            Console.WriteLine(paciente.ToString());

            VolverAlMenuPrincipal();
        }

        static void DarBajaPaciente(Hospital hospital)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del paciente a dar de baja:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido del paciente a dar de baja:");
            string apellido = Console.ReadLine();

            Paciente paciente = hospital.Pacientes
                .FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) &&
                                     p.Apellido.Equals(apellido, StringComparison.OrdinalIgnoreCase));
            
            if (paciente != null)
            {
                hospital.BajaPaciente(paciente);
                Console.WriteLine("Paciente dado de baja exitosamente:");
                Console.WriteLine(paciente.ToString());
            }
            else
            {
                Console.WriteLine("No se encontró un paciente con ese nombre y apellido.");
            }

            VolverAlMenuPrincipal();
        }

        static void VolverAlMenuPrincipal()
        {
            Console.WriteLine();
            Console.WriteLine("Presiona cualquier tecla para volver al menu principal");
            Console.ReadKey();
        }

    }
}
