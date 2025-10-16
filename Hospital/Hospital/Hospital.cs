using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Hospital
    {
        public List<Medico> Medicos { get; set; }
        public List<Paciente> Pacientes { get; set; }
        public Hospital()
        {
            Medicos = new List<Medico>();
            Pacientes = new List<Paciente>();
        }

        public void AltaMedico()
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
            this.Medicos.Add(medico);

            Console.Write("Medico agregado exitosamente: ");
            Console.WriteLine(medico.ToString());
        }

        public void BajaMedico()
        {
            //Console.Clear();
            Console.WriteLine("=========================================== BAJA MEDICO");
            Console.Write("Ingrese el nombre del medico a dar de baja: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el apellido del medico a dar de baja: ");
            string apellido = Console.ReadLine();

            Medico medico = this.Medicos
                .FirstOrDefault(m => m.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) &&
                                     m.Apellido.Equals(apellido, StringComparison.OrdinalIgnoreCase));

            if (medico != null)
            {
                this.Medicos.Remove(medico);
                Console.Write("Medico dado de baja exitosamente: ");
                Console.WriteLine(medico.ToString());
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No se encontró un medico con ese nombre y apellido.");
            }
        }

        public void AltaPaciente()
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

            Medico medicoAsignado = this.Medicos
                .FirstOrDefault(m => m.Nombre.Equals(nombreMedico, StringComparison.OrdinalIgnoreCase) &&
                                     m.Apellido.Equals(apellidoMedico, StringComparison.OrdinalIgnoreCase));
            if (medicoAsignado == null)
            {
                Console.WriteLine("No se encontró un medico con ese nombre y apellido. El paciente no tendrá medico asignado.");
            }

            Paciente paciente = new Paciente(nombre, apellido);

            paciente.MedicoAsignado = medicoAsignado;

            this.Pacientes.Add(paciente);

            Console.Write("Paciente agregado exitosamente: ");
            Console.WriteLine(paciente.ToString());
            Console.WriteLine();

        }

        public void BajaPaciente()
        {
            //Console.Clear();
            Console.WriteLine("========================================= BAJA PACIENTE");
            Console.Write("Ingrese el nombre del paciente a dar de baja: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el apellido del paciente a dar de baja: ");
            string apellido = Console.ReadLine();

            Paciente paciente = this.Pacientes
                .FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) &&
                                     p.Apellido.Equals(apellido, StringComparison.OrdinalIgnoreCase));

            if (paciente != null)
            {
                this.Pacientes.Remove(paciente);
                Console.Write("Paciente dado de baja exitosamente: ");
                Console.WriteLine(paciente.ToString());
            }
            else
            {
                Console.WriteLine("No se encontró un paciente con ese nombre y apellido.");
            }

        }

        public void AsignarMedicoAPaciente()
        {
            //Console.Clear();
            Console.WriteLine("============================= ASIGNAR MEDICO A PACIENTE");
            Console.Write("Ingrese el nombre del paciente: ");
            string nombrePaciente = Console.ReadLine();

            Console.Write("Ingrese el apellido del paciente: ");
            string apellidoPaciente = Console.ReadLine();

            Paciente paciente = this.Pacientes
                .FirstOrDefault(p => p.Nombre.Equals(nombrePaciente, StringComparison.OrdinalIgnoreCase) &&
                                     p.Apellido.Equals(apellidoPaciente, StringComparison.OrdinalIgnoreCase));

            if (paciente == null)
            {
                Console.WriteLine("No se encontró un paciente con ese nombre y apellido.");
                return;
            }

            Console.Write("Ingrese el nombre del medico a asignar: ");
            string nombreMedico = Console.ReadLine();

            Console.Write("Ingrese el apellido del medico a asignar: ");
            string apellidoMedico = Console.ReadLine();

            Medico medico = this.Medicos
                .FirstOrDefault(m => m.Nombre.Equals(nombreMedico, StringComparison.OrdinalIgnoreCase) &&
                                     m.Apellido.Equals(apellidoMedico, StringComparison.OrdinalIgnoreCase));

            if (medico == null)
            {
                Console.WriteLine("No se encontró un medico con ese nombre y apellido.");
                return;
            }

            paciente.MedicoAsignado = medico;
            if (!medico.PacientesAsignados.Contains(paciente))
            {
                medico.PacientesAsignados.Add(paciente);
            }

            Console.Write($"Medico {medico.ToString()} asignado exitosamente al paciente: {paciente.ToString()}");
        }

        public void ListarMedicos()
        {
            //Console.Clear();
            Console.WriteLine("====================================== LISTA DE MEDICOS");
            int index = 1;
            foreach (var medico in this.Medicos)
            {
                Console.WriteLine($"{index++} - {medico.ToString()}");
            }
        }
        public void ListarPacientes()
        {
            //Console.Clear();
            Console.WriteLine("Lista de Pacientes:");
            int index = 1;
            foreach (var paciente in this.Pacientes)
            {
                Console.WriteLine($"{index++} - {paciente.ToString()}");
            }
        }

        public void ListarPacientesDeMedico()
        {
            //Console.Clear();
            Console.WriteLine("======================= LISTA DE PACIENTES DE UN MEDICO");
            Console.WriteLine("Ingrese el nombre del medico:");
            string nombreMedico = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido del medico:");
            string apellidoMedico = Console.ReadLine();

            Medico medico = this.Medicos
                .FirstOrDefault(m => m.Nombre.Equals(nombreMedico, StringComparison.OrdinalIgnoreCase) &&
                                     m.Apellido.Equals(apellidoMedico, StringComparison.OrdinalIgnoreCase));

            if (medico == null)
            {
                Console.WriteLine("No se encontró un medico con ese nombre y apellido.");
                return;
            }

            Console.WriteLine($"Lista de Pacientes del Médico {medico.ToString()}: ");
            int index = 1;
            foreach (var paciente in medico.PacientesAsignados)
            {
                Console.WriteLine($"{index} - {paciente.ToString()}");
            }

        }

        public void ListarPersonasDelHospital()
        {
            //Console.Clear();
            Console.WriteLine("============= LISTA DE MEDICOS Y PACIENTES DEL HOSPITAL");
            Console.WriteLine("Médicos:");
            int indexMedicos = 1;
            foreach (var medico in this.Medicos)
            {
                Console.WriteLine($"{indexMedicos} - {medico.ToString()}");
            }
            Console.WriteLine();
            Console.WriteLine("Pacientes:");
            int indexPacientes = 1;
            foreach (var paciente in this.Pacientes)
            {
                Console.WriteLine($"{indexPacientes} - {paciente.ToString()}");
            }
        }
    }
}
