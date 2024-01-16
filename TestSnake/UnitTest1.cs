using Snake;

namespace TestSnake
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestVaAChocarFalseEsquina00()
        {
            //creamos un objeto de la clase posicion
            Posicion pos = new Posicion(0, 0);
            //creamos un objeto de la clase EstadoJuego
            EstadoJuego estado = new EstadoJuego(10, 10);
            //comprobamos que la posicion esta fuera de los limites del tablero
            Assert.IsFalse(condition: estado.Limites(pos));

        }
        [TestMethod]

        //esquina Superior derecha
        public void TestVaAChocarFalseEsquina09()
        {
            //creamos un objeto de la clase posicion
            Posicion pos = new Posicion(0, 9);
            //creamos un objeto de la clase EstadoJuego
            EstadoJuego estado = new EstadoJuego(10, 10);
            //// comprobamos si la posicion esta fuera de los limites del tablero
            Assert.IsFalse(condition: estado.Limites(pos));

        }
        [TestMethod]
        public void TestVaAChocarFalseEsquina90()
        {
            //creamos un objeto de la clase posicion
            Posicion pos = new Posicion(9, 0);
            //creamos un objeto de la clase EstadoJuego
            EstadoJuego estado = new EstadoJuego(10, 10);
            //// comprobamos si la posicion esta fuera de los limites del tablero
            Assert.IsFalse(condition: estado.Limites(pos));

        }
        [TestMethod]
        public void TestVaAChocarFalseEsquina99()
        {
            //creamos un objeto de la clase posicion
            Posicion pos = new Posicion(9, 9);
            //creamos un objeto de la clase EstadoJuego
            EstadoJuego estado = new EstadoJuego(10, 10);
            //comprobamos que la posicion esta fuera de los limites del tablero
            Assert.IsFalse(condition: estado.Limites(pos));

        }


        [TestMethod]
        public void TestVaAChocarTrueEsquina0menos1()
        {
            //creamos un objeto de la clase posicion
            Posicion pos = new Posicion(0, -1);
            //creamos un objeto de la clase EstadoJuego
            EstadoJuego estado = new EstadoJuego(10, 10);
            //comprobamos que la posicion esta fuera de los limites del tablero
            Assert.IsTrue(condition: estado.Limites(pos));
        }

        [TestMethod]
        public void TestVaAChocarTrueEsquina00()
        {
            //creamos un objeto de la clase posicion
            Posicion pos = new Posicion(-1, -1);
            //creamos un objeto de la clase EstadoJuego
            EstadoJuego estado = new EstadoJuego(10, 10);
            //comprobamos que la posicion esta fuera de los limites del tablero
            Assert.IsTrue(condition: estado.Limites(pos));

        }
        [TestMethod]
        public void TestVaAChocarTrueEsquinaMenos10()
        {
            //creamos un objeto de la clase posicion
            Posicion pos = new Posicion(-1, 0);
            //creamos un objeto de la clase EstadoJuego
            EstadoJuego estado = new EstadoJuego(10, 10);
            //comprobamos que la posicion esta fuera de los limites del tablero
            Assert.IsTrue(condition: estado.Limites(pos));
        }





        [TestMethod]
        public void TestVaAChocarTrueEsquinaMenos010()
        {
            //creamos un objeto de la clase posicion
            Posicion pos = new Posicion(0, 10);
            //creamos un objeto de la clase EstadoJuego
            EstadoJuego estado = new EstadoJuego(10, 10);
            //comprobamos que la posicion esta fuera de los limites del tablero
            Assert.IsTrue(condition: estado.Limites(pos));
        }



        [TestMethod]
        public void TestVaAChocarTrueEsquina99()
        {
            //creamos un objeto de la clase posicion
            Posicion pos = new Posicion(10, 10);
            //creamos un objeto de la clase EstadoJuego
            EstadoJuego estado = new EstadoJuego(10, 10);
            //comprobamos que la posicion esta fuera de los limites del tablero
            Assert.IsTrue(condition: estado.Limites(pos));

        }

        //esquina inferior izquierda
        [TestMethod]
        public void TestVaAChocarTrueEsquina100()
        {
            //creamos un objeto de la clase posicion
            Posicion pos = new Posicion(10, 0);
            //creamos un objeto de la clase EstadoJuego
            EstadoJuego estado = new EstadoJuego(10, 10);
            //comprobamos que la posicion esta fuera de los limites del tablero
            Assert.IsTrue(condition: estado.Limites(pos));
        }

    }
}