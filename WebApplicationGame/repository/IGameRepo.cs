namespace WebApplicationGame.repository
{
    public interface IGameRepo
    {
        public int Create(Game game);
        public int Update(Game game);
        public void Delete(int id);
        public Game GetGame(int id);
        public List<Game> GetAllGame();

    }
}
