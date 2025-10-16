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

        // se hace un override del metodo ToString para mostrar la informacion del medico
        // o sino el metodo ToString devuelve el nombre completo de la clase
        public override string ToString()
        {
            return base.ToString() + $", Especialidad: {Especialidad}";
        }
    }
}
