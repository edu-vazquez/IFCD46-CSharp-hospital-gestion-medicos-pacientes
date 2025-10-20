using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Medico : Persona
    {
        public string Especialidad { get; set; }

        public List<Paciente> PacientesAsignados { get; set; }
        public List<Cita> Citas { get; set; }

        public Medico(string nombre, string apellido, string especialidad)
            : base(nombre, apellido)
        {
            Especialidad = especialidad;
            PacientesAsignados = new List<Paciente>();
            Citas = new List<Cita>();
        }

        public static Medico CrearMedico()
        {
            Console.WriteLine("Ingrese el nombre del medico:");
            string nombre = Console.ReadLine();
            
            Console.WriteLine("Ingrese el apellido del medico:");
            string apellido = Console.ReadLine();
            
            Console.WriteLine("Ingrese la especialidad del medico:");
            string especialidad = Console.ReadLine();
            
            return new Medico(nombre, apellido, especialidad);
        }

        // se hace un override del metodo ToString para mostrar la informacion del medico
        // o sino el metodo ToString devuelve el nombre completo de la clase
        public override string ToString()
        {
            return base.ToString() + $", Especialidad: {Especialidad}";
        }
    }
}
