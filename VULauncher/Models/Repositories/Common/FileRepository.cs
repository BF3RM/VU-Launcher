namespace VULauncher.Models.Repositories.Common
{
    public abstract class FileRepository : Repository
    {
        protected void Initialize()
        {
            Load();
        }

        public abstract void Load();
    }
}
