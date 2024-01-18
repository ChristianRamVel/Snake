using System.ComponentModel.DataAnnotations;

namespace Snake
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public int Puntuacion { get; set; }

    }
}