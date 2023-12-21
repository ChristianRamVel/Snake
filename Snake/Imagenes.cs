using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Snake
{
    public static class Imagenes
    {
        public readonly static  ContextStaticAttribute ImageSource Empty = CargarImagen("Empty.png");
        public readonly static ContextStaticAttribute ImageSource Body = CargarImagen("Body.png");
        public readonly static ContextStaticAttribute ImageSource Cabeza = CargarImagen("Cabeza.png");
        public readonly static ContextStaticAttribute ImageSource Comida = CargarImagen("Comida.png");
        public readonly static ContextStaticAttribute ImageSource DeadBody = CargarImagen("DeadBody.png");
        public readonly static ContextStaticAttribute ImageSource DeadHead = CargarImagen("DeadHead.png");

        private static ImageSource CargarImagen(string nombreArchivo)
        {
            

            return new BitmapImage(new Uri($"Imagenes/{nombreArchivo}", UriKind.Relative));
        }
    }
}
