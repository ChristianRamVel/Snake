using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Snake
{
    public class Direccion
    {
        public static Direccion Izquierda = new Direccion(0, -1);
        public static Direccion Derecha = new Direccion(0, 1);
        public static Direccion Arriba = new Direccion(-1, 0);
        public static Direccion Abajo = new Direccion(1, 0);

        public int Fila { get; }
        public int Columna { get; }


        private Direccion(int fila, int columna) { 

            this.Fila = fila;
            this.Columna = columna;
        
        }

        public Direccion Opposite() {
            return new Direccion(-Fila, -Columna);
        }

        public override bool Equals(object? obj)
        {
            return obj is Direccion direccion &&
                   Fila == direccion.Fila &&
                   Columna == direccion.Columna;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Fila, Columna);
        }

        public static bool operator ==(Direccion? left, Direccion? right)
        {
            return EqualityComparer<Direccion>.Default.Equals(left, right);
        }

        public static bool operator !=(Direccion? left, Direccion? right)
        {
            return !(left == right);
        }
    }
}
