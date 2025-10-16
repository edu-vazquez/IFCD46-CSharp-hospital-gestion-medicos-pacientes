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
                        hospital.AltaMedico();
                        break;
                    case 2:
                        hospital.BajaMedico();
                        break;
                    case 3:
                        hospital.AltaPaciente();
                        break;
                    case 4:
                        hospital.BajaPaciente();
                        break;
                    case 5:
                        hospital.AsignarMedicoAPaciente();
                        break;
                    case 6:
                        hospital.ListarMedicos();
                        break;
                    case 7:
                        hospital.ListarPacientes();
                        break;
                    case 8:
                        hospital.ListarPacientesDeMedico();
                        break;
                    case 9:
                        hospital.ListarPersonasDelHospital();
                        break;
                    case 10:
                        //GestionCitas(hospital);
                        break; 
                    case 11:
                        //GestionHistorialMedico(hospital);
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                        break;
                }
                VolverAlMenuPrincipal();
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
        

        static void VolverAlMenuPrincipal()
        {
            Console.WriteLine();
            Console.WriteLine("Presiona cualquier tecla para volver al menu principal");
            Console.ReadKey();
        }

    }
}
