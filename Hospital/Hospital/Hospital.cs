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

        public void AgregarMedico(Medico medico)
        {
            Medicos.Add(medico);
        }

        public void EliminarMedico(Medico medico)
        {
            Medicos.Remove(medico);
        }   

        public void AgregarPaciente(Paciente paciente)
        {
            Pacientes.Add(paciente);
        }

        public void EliminarPaciente(Paciente paciente)
        {
            Pacientes.Remove(paciente);
        }

        
    }
}
