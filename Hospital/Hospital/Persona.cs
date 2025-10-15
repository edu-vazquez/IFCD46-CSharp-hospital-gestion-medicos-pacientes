using System;

namespace Hospital
{
    public abstract class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        protected Persona(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        // se hace un override del metodo ToString para mostrar la informacion de la persona
        // o sino el metodo ToString devuelve el nombre completo de la clase
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Apellido: {Apellido}";
        }
    }
}
