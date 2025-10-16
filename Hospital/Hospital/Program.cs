using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                Console.WriteLine();

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
                        AsignarMedicoAPaciente(hospital);
                        break;
                    case 6:
                        ListarMedicos(hospital);
                        break;
                    case 7:
                        ListarPacientes(hospital);
                        break;
                    case 8:
                        ListarPacientesDeMedico(hospital);
                        break;
                    case 9:
                        ListarPersonasDelHospital(hospital);
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
            //Console.Clear();
            Console.WriteLine("=======================================================");
            Console.WriteLine();
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
            Console.WriteLine("6. Listar los médicos del Hospital");
            Console.WriteLine("7. Listar los pacientes del Hospital");
            Console.WriteLine("8. Listar los pacientes de un médico");
            Console.WriteLine("9. Listar medicos y pacientes del hospital");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("10. Gestión de citas");
            Console.WriteLine("11. Gestión de historial médico");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("escriba *exit* para salir");
            Console.WriteLine();
            Console.WriteLine("=======================================================");
        }
        static void DarAltaMedico(Hospital hospital)
        {
            //Console.Clear();

            Console.WriteLine("=========================================== ALTA MEDICO");
            Console.Write("Ingrese el nombre del medico: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el apellido del medico: ");
            string apellido = Console.ReadLine();

            Console.Write("Ingrese la especialidad del medico: ");
            string especialidad = Console.ReadLine();

            Medico medico = new Medico(nombre, apellido, especialidad);
            hospital.AltaMedico(medico);

            Console.Write("Medico agregado exitosamente: ");
            Console.WriteLine(medico.ToString());
            VolverAlMenuPrincipal();
        }

        static void DarBajaMedico(Hospital hospital)
        {
            //Console.Clear();
            Console.WriteLine("=========================================== BAJA MEDICO");
            Console.Write("Ingrese el nombre del medico a dar de baja: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el apellido del medico a dar de baja: ");
            string apellido = Console.ReadLine();

            Medico medico = hospital.Medicos
                .FirstOrDefault(m => m.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) &&
                                     m.Apellido.Equals(apellido, StringComparison.OrdinalIgnoreCase));
            
            if (medico != null)
            {
                hospital.BajaMedico(medico);
                Console.Write("Medico dado de baja exitosamente: ");
                Console.WriteLine(medico.ToString());
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No se encontró un medico con ese nombre y apellido.");
            }

            VolverAlMenuPrincipal();
        }

        static void DarAltaPaciente(Hospital hospital)
        {
            //Console.Clear();
            Console.WriteLine("========================================= ALTA PACIENTE");
            Console.Write("Ingrese el nombre del paciente: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el apellido del paciente: ");
            string apellido = Console.ReadLine();

            Console.Write("Ingrese el nombre del medico asignado: ");
            string nombreMedico = Console.ReadLine();

            Console.Write("Ingrese el apellido del medico asignado: ");
            string apellidoMedico = Console.ReadLine();

            Medico medicoAsignado = hospital.Medicos
                .FirstOrDefault(m => m.Nombre.Equals(nombreMedico, StringComparison.OrdinalIgnoreCase) &&
                                     m.Apellido.Equals(apellidoMedico, StringComparison.OrdinalIgnoreCase));
            if (medicoAsignado == null)
                {
                Console.WriteLine("No se encontró un medico con ese nombre y apellido. El paciente no tendrá medico asignado.");
            }

            Paciente paciente = new Paciente(nombre, apellido);

            paciente.MedicoAsignado = medicoAsignado;

            hospital.AltaPaciente(paciente);

            Console.Write("Paciente agregado exitosamente: ");
            Console.WriteLine(paciente.ToString());
            Console.WriteLine();

            VolverAlMenuPrincipal();
        }

        static void DarBajaPaciente(Hospital hospital)
        {
            //Console.Clear();
            Console.WriteLine("========================================= BAJA PACIENTE");
            Console.Write("Ingrese el nombre del paciente a dar de baja: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el apellido del paciente a dar de baja: ");
            string apellido = Console.ReadLine();

            Paciente paciente = hospital.Pacientes
                .FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) &&
                                     p.Apellido.Equals(apellido, StringComparison.OrdinalIgnoreCase));
            
            if (paciente != null)
            {
                hospital.BajaPaciente(paciente);
                Console.Write("Paciente dado de baja exitosamente: ");
                Console.WriteLine(paciente.ToString());
            }
            else
            {
                Console.WriteLine("No se encontró un paciente con ese nombre y apellido.");
            }

            VolverAlMenuPrincipal();
        }
        
        static void AsignarMedicoAPaciente(Hospital hospital)
        {
            //Console.Clear();
            Console.WriteLine("============================= ASIGNAR MEDICO A PACIENTE");
            Console.Write("Ingrese el nombre del paciente: ");
            string nombrePaciente = Console.ReadLine();

            Console.Write("Ingrese el apellido del paciente: ");
            string apellidoPaciente = Console.ReadLine();

            Paciente paciente = hospital.Pacientes
                .FirstOrDefault(p => p.Nombre.Equals(nombrePaciente, StringComparison.OrdinalIgnoreCase) &&
                                     p.Apellido.Equals(apellidoPaciente, StringComparison.OrdinalIgnoreCase));
            
            if (paciente == null)
            {
                Console.WriteLine("No se encontró un paciente con ese nombre y apellido.");
                VolverAlMenuPrincipal();
                return;
            }

            Console.Write("Ingrese el nombre del medico a asignar: ");
            string nombreMedico = Console.ReadLine();

            Console.Write("Ingrese el apellido del medico a asignar: ");
            string apellidoMedico = Console.ReadLine();

            Medico medico = hospital.Medicos
                .FirstOrDefault(m => m.Nombre.Equals(nombreMedico, StringComparison.OrdinalIgnoreCase) &&
                                     m.Apellido.Equals(apellidoMedico, StringComparison.OrdinalIgnoreCase));
            
            if (medico == null)
            {
                Console.WriteLine("No se encontró un medico con ese nombre y apellido.");
                VolverAlMenuPrincipal();
                return;
            }

            paciente.MedicoAsignado = medico;
            if (!medico.PacientesAsignados.Contains(paciente))
            {
                medico.PacientesAsignados.Add(paciente);
            }

            Console.Write($"Medico {medico.ToString()} asignado exitosamente al paciente: {paciente.ToString()}");
            VolverAlMenuPrincipal();
        }

        static void ListarMedicos(Hospital hospital)
        {
            //Console.Clear();
            Console.WriteLine("====================================== LISTA DE MEDICOS");
            int index = 1;
            foreach (var medico in hospital.Medicos)
            {
                Console.WriteLine($"{index} - {medico.ToString()}");
            }
            VolverAlMenuPrincipal();
        }
        static void ListarPacientes(Hospital hospital)
        {
            //Console.Clear();
            Console.WriteLine("Lista de Pacientes:");
            int index = 1;
            foreach (var paciente in hospital.Pacientes)
            {
                Console.WriteLine($"{index} - {paciente.ToString()}");
            }
            VolverAlMenuPrincipal();
        }

        static void ListarPacientesDeMedico(Hospital hospital)
        {
            //Console.Clear();
            Console.WriteLine("======================= LISTA DE PACIENTES DE UN MEDICO");
            Console.WriteLine("Ingrese el nombre del medico:");
            string nombreMedico = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido del medico:");
            string apellidoMedico = Console.ReadLine();

            Medico medico = hospital.Medicos
                .FirstOrDefault(m => m.Nombre.Equals(nombreMedico, StringComparison.OrdinalIgnoreCase) &&
                                     m.Apellido.Equals(apellidoMedico, StringComparison.OrdinalIgnoreCase));
            
            if (medico == null)
            {
                Console.WriteLine("No se encontró un medico con ese nombre y apellido.");
                VolverAlMenuPrincipal();
                return;
            }

            Console.WriteLine($"Lista de Pacientes del Médico {medico.ToString()}: ");
            int index = 1;
            foreach (var paciente in medico.PacientesAsignados)
            {
                Console.WriteLine($"{index} - {paciente.ToString()}");
            }

            VolverAlMenuPrincipal();
        }

        static void ListarPersonasDelHospital(Hospital hospital)
        {
            //Console.Clear();
            Console.WriteLine("============= LISTA DE MEDICOS Y PACIENTES DEL HOSPITAL");
            Console.WriteLine("Médicos:");
            int indexMedicos = 1;
            foreach (var medico in hospital.Medicos)
            {
                Console.WriteLine($"{indexMedicos} - {medico.ToString()}");
            }
            Console.WriteLine();
            Console.WriteLine("Pacientes:");
            int indexPacientes = 1;
            foreach (var paciente in hospital.Pacientes)
            {
                Console.WriteLine($"{indexPacientes} - {paciente.ToString()}");
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
