using Microsoft.EntityFrameworkCore;


namespace WebApplicationGame.repository
{
    public class GameRepo : IGameRepo
    {
        ApplicationContext db;
        public GameRepo (ApplicationContext db)
        {
            this.db = db;
        } 

        public int Create(Game game)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                transaction.CreateSavepoint("BeforeCreate");
                var newGame = db.Game.Add(game);
                db.SaveChanges();
                transaction.Commit();
                return newGame.Entity.Id;
            }
            catch (Exception e)
            {
                transaction.RollbackToSavepoint("BeforeCreate");
               // Console.Error(e);
            }

            return 0;
            
        }

        public void Delete(int id)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                transaction.CreateSavepoint("BeforeDelete");
                Game game = db.Game.Where(g => g.Id == id).FirstOrDefault();
                db.Game.Remove(game);
                db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.RollbackToSavepoint("BeforeDelete");
                 Console.WriteLine(e);
            }

        }

        public List<Game>? GetAllGame()
        {
            return db.Game.ToList();
        }

  

        public Game GetGame(int id)
        {
            try
            {
                Game game = db.Game.Include(g => g.Tags).Where(g => g.Id == id).FirstOrDefault();
                return game;
            }
            catch (Exception e)
            {
                // Console.Error(e);
            }
            return null;
        }

        public int Update(Game game)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                transaction.CreateSavepoint("BeforeUpdate");                
                var newGame = db.Game.Update(game);
                db.SaveChanges();
                transaction.Commit();
                return newGame.Entity.Id;
            }
            catch (Exception e)
            {
                transaction.RollbackToSavepoint("BeforeUpdate");
                // Console.Error(e);
            }

            return 0;
        }
    }
}
