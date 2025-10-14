using System;

namespace Hospital
{
    public abstract class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        protected Persona(string nombre, string apellido, int edad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }

        // se hace un override del metodo ToString para mostrar la informacion de la persona
        // o sino el metodo ToString devuelve el nombre completo de la clase
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Apellido: {Apellido}, Edad: {Edad}";
        }
    }
}
