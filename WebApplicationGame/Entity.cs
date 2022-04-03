using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationGame
{
    public abstract class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }

    public class Game : Entity
    {
       
        public string Name { get; set; }

        [NotMapped]
        public List<int> Tag { get; set; } = new List<int>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
       // [NotMapped]
        public int GameDeveloperId { get; set; }
       // public GameDeveloper GameDeveloper { get; set; }
    }

     public class GameDeveloper : Entity
     {
     
         public string Name { get; set; }
         public List<Game> Games { get; set; } = new List<Game>();
     }

     public class Tag : Entity
     {

         public string Name { get; set; }
         public List<Game> Games { get; set; } = new List<Game>();
     }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = ""; // имя пользователя
        public int Age { get; set; } // возраст пользователя
    }
}
