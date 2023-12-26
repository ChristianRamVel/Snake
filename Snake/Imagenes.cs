using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Snake
{
    public static class Imagenes
    {
        public readonly static   ImageSource Empty = CargarImagen("Assets/Empty.png");
        public readonly static ImageSource Body = CargarImagen("Assets/Body.png");
        public readonly static  ImageSource Cabeza = CargarImagen("Assets/Head.png");
        public readonly static  ImageSource Comida = CargarImagen("Assets/Food.png");
        public readonly static  ImageSource DeadBody = CargarImagen("Assets/DeadBody.png");
        public readonly static  ImageSource DeadHead = CargarImagen("Assets/DeadHead.png");

        private static ImageSource CargarImagen(string nombreArchivo)
        {
            

            return new BitmapImage(new Uri($"Imagenes/{nombreArchivo}", UriKind.Relative));
        }
    }
}
