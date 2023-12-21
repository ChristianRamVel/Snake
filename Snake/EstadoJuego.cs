using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Snake
{
    public class EstadoJuego
    {
        public int Filas { get; }
        public int Columnas { get; }
        public Tablero[,] Grid { get; }
        public Direccion Dir { get; private set; }
        public int Score { get; private set; }
        public bool GameOver { get; private set; }

        private readonly LinkedList<Posicion> posicionesSerpiente = new LinkedList<Posicion>();
        private readonly Random random = new Random();

        public EstadoJuego(int filas, int columnas)
        {
            Filas = filas;
            Columnas = columnas;
            Grid = new Tablero[ Filas, Columnas];
            Dir = Direccion.Derecha;

            anadirSnake();
            anadirComida();

        }

        private void anadirSnake() {
            int r = Filas / 2;

            for (int c = 1; c <= 3; c++) {
                Grid[r, c] = Tablero.Snake;
                posicionesSerpiente.AddFirst(new Posicion(r, c));
            }
        }

        private IEnumerable<Posicion> PosicionesVacias()
        {

            for (int f = 0; f < Filas; f++)
            {
                for (int c = 0; c < Columnas; c++) {

                    if (Grid[f, c] == Tablero.Empty) {
                        yield return new Posicion(f, c);
                    }
                }
            }
        }

        private void anadirComida()
        { 
         List<Posicion> empty = new List<Posicion>(PosicionesVacias());

            if (empty.Count == 0)
            {
                return;
            }

            Posicion pos = empty[random.Next(empty.Count)];
            Grid[pos.Fila, pos.Columna] = Tablero.Food;
        }

        public Posicion PosicionCabeza()
        {

            return posicionesSerpiente.First.Value;

        }

        public Posicion PosicionCola() {

            return posicionesSerpiente.Last.Value;
        
        }

        public IEnumerable<Posicion> PosicionesSnake() {

            return posicionesSerpiente;

        }

        private void AnadirCabeza(Posicion pos)
        {
            posicionesSerpiente.AddFirst(pos);
            Grid[pos.Fila, pos.Columna] = Tablero.Snake;
        }

        private void BorrarCola() {

            Posicion cola = posicionesSerpiente.Last.Value;
            Grid[cola.Fila, cola.Columna] = Tablero.Empty;
            posicionesSerpiente.RemoveLast();
        }

        public void CambioDeDireccion(Direccion dir)
        {
            Dir = dir;
        }

        private bool Limites(Posicion pos)
        {
            return pos.Fila < 0 || pos.Fila >= 0 || pos.Columna < 0 || pos.Columna >= Columnas;
        }

        private Tablero VaAChocar(Posicion nuevaPosicionCabeza)
        {

            if (Limites(nuevaPosicionCabeza))
            {
                return Tablero.Pared;
            }

            if (nuevaPosicionCabeza == PosicionCola())
            {
                return Tablero.Empty;
            }

            return Grid[nuevaPosicionCabeza.Fila, nuevaPosicionCabeza.Columna];
        }


        public void Mover()
        {
            Posicion nuevaPosicionCabeza = PosicionCabeza().Translate(Dir);
            Tablero hit = VaAChocar(nuevaPosicionCabeza);

            if (hit == Tablero.Pared || hit == Tablero.Snake)
            {
                GameOver = true;
            }
            else if (hit == Tablero.Empty)
            {
                BorrarCola();
                AnadirCabeza(nuevaPosicionCabeza);

            }
            else if (hit == Tablero.Food)
            {
                AnadirCabeza(nuevaPosicionCabeza);
                Score++;
                anadirComida();
            }


        }
        




    }
}
