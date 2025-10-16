using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Cita
    {
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }

        public Cita(DateTime inicio, DateTime fin, Medico medico, Paciente paciente)
        {
            Inicio = inicio;
            Fin = fin;
            Medico = medico;
            Paciente = paciente;
        }
    }
}
