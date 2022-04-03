namespace WebApplicationGame.repository
{
    public class GameDeveloperRepo : IGameDeveloperRepo
    {
        ApplicationContext db;
        public GameDeveloperRepo(ApplicationContext db)
        {
            this.db = db;
        }

        public int Create(GameDeveloper GameDeveloper)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                transaction.CreateSavepoint("BeforeCreate");
                var newGame = db.GameDevelopers.Add(GameDeveloper);
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
                GameDeveloper GameDevelopers = db.GameDevelopers.Where(g => g.Id == id).FirstOrDefault();
                db.GameDevelopers.Remove(GameDevelopers);
                db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.RollbackToSavepoint("BeforeDelete");
                // Console.Error(e);
            }
        }

        public List<GameDeveloper> GetAllDevelopers()
        {
            return db.GameDevelopers.ToList();
        }

        public GameDeveloper GetGameDeveloper(int id)
        {
            try
            {
                GameDeveloper gameDeveloper = db.GameDevelopers.Where(g => g.Id == id).FirstOrDefault();
                return gameDeveloper;
            }
            catch (Exception e)
            {
                // Console.Error(e);
            }
            return null;
        }

        public int Update(GameDeveloper GameDeveloper)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                transaction.CreateSavepoint("BeforeUpdate");
                var newGameDeveloper = db.GameDevelopers.Update(GameDeveloper);
                db.SaveChanges();
                transaction.Commit();
                return newGameDeveloper.Entity.Id;
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
