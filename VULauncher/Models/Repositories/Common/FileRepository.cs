namespace VULauncher.Models.Repositories.Common
{
    public abstract class FileRepository
    {
        protected void Initialize()
        {
            Load();
        }

        public abstract void Load();
    }
}
