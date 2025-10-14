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
        public Medico(string nombre, string apellido, int edad, string especialidad)
            : base(nombre, apellido, edad)
        {
            Especialidad = especialidad;
            PacientesAsignados = new List<Paciente>();
        }
    }
}
