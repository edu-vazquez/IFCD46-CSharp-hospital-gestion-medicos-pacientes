using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Paciente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Medico MedicoAsignado { get; set; }
        public Paciente(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
            MedicoAsignado = null;
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
