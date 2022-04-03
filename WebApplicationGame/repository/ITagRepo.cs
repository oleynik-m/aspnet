namespace WebApplicationGame.repository
{
    public interface ITagRepo
    {
        public int Create(Tag tag);
        public int Update(Tag tag);
        public void Delete(int id);
        public Tag GetTag(int id);
        public List<Tag> GetAllTags();
        public List<Game> GetAllGamesByTag(int id);

    }
}
