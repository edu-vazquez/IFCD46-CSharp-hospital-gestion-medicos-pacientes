using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Paciente : Persona
    {
        public static Medico MedicoAsignado { get; set; }
        public static List<Cita> Citas { get; set; }
        public Paciente(string nombre, string apellido) : base(nombre, apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
            MedicoAsignado = null;
            Citas = new List<Cita>();
        }

        public static Paciente Crear()
        {
            Console.WriteLine("Ingrese el nombre del paciente:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido del paciente:");
            string apellido = Console.ReadLine();

            return new Paciente(nombre, apellido);
        }

        public void AsignarMedico(Medico medico)
        {
            MedicoAsignado = medico;
        }

        public void AgregarCita(Cita cita)
        {
            Citas.Add(cita);
        }

        // se hace un override del metodo ToString para mostrar la informacion del paciente
        // o sino el metodo ToString devuelve el nombre completo de la clase
        public override string ToString()
        {
            return  $"Nombre: {Nombre}, " +
                    $"Apellido: {Apellido}, " +
                    $"Medico Asignado: {(MedicoAsignado == null ? "Ninguno" : MedicoAsignado.Nombre + " " + MedicoAsignado.Apellido)}.";
        }
    }
}
