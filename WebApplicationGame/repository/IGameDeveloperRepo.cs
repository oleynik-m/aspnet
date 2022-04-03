namespace WebApplicationGame.repository
{
    public interface IGameDeveloperRepo
    {
        public int Create(GameDeveloper GameDeveloper);
        public int Update(GameDeveloper GameDeveloper);
        public void Delete(int id);
        public GameDeveloper GetGameDeveloper(int id);
        public List<GameDeveloper> GetAllDevelopers();

    }
}
