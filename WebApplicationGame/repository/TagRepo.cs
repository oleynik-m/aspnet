namespace WebApplicationGame.repository
{
    public class TagRepo : ITagRepo
    {
        ApplicationContext db;
        public TagRepo(ApplicationContext db)
        {
            this.db = db;
        }
        public int Create(Tag tag)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                transaction.CreateSavepoint("BeforeCreate");
                var newGame = db.Tags.Add(tag);
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
                Tag tag = db.Tags.Where(g => g.Id == id).FirstOrDefault();
                db.Tags.Remove(tag);
                db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.RollbackToSavepoint("BeforeDelete");
                // Console.Error(e);
            }
        }

        public List<Tag> GetAllTags()
        {
            return db.Tags.ToList();
        }

        public Tag GetTag(int id)
        {
          
            return db.Tags.Where(g => g.Id == id).FirstOrDefault();           

        }

        public int Update(Tag tag)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                transaction.CreateSavepoint("BeforeUpdate");
                var newTag = db.Tags.Update(tag);
                db.SaveChanges();
                transaction.Commit();
                return newTag.Entity.Id;
            }
            catch (Exception e)
            {
                transaction.RollbackToSavepoint("BeforeUpdate");
                // Console.Error(e);
            }

            return 0;
        }

        public List<Game> GetAllGamesByTag(int id)
        {
            return db.Tags.Where(g => g.Id == id).FirstOrDefault().Games;
        }
    }
}
