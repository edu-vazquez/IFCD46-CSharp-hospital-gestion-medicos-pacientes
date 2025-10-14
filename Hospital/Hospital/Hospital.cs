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

        public void AltaMedico(Medico medico)
        {
            Medicos.Add(medico);
        }

        public void BajaMedico(Medico medico)
        {
            Medicos.Remove(medico);
        }   

        public void AltaPaciente(Paciente paciente)
        {
            Pacientes.Add(paciente);
        }

        public void BajaPaciente(Paciente paciente)
        {
            Pacientes.Remove(paciente);
        }

        
    }
}
