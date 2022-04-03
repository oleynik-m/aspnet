namespace WebApplicationGame.repository
{
    public class Repository
    {
       public IGameDeveloperRepo GameDeveloperRepo;
       public ITagRepo TagRepo;
       public IGameRepo GameRepo;

        public Repository (ApplicationContext context)
        {
            GameRepo = new GameRepo(context);
            GameDeveloperRepo = new GameDeveloperRepo(context);
            TagRepo = new TagRepo(context);

        }


    }
}
