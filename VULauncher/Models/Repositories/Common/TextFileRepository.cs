using System.IO;

namespace VULauncher.Models.Repositories.Common
{
    public abstract class TextFileRepository : Repository
    {
        private readonly string _filePath;
        public string FileContent { get; private set; }
        public string[] FileContentLines { get; private set; }

        protected TextFileRepository(string filePath)
        {
            _filePath = filePath;
            FileContent = File.ReadAllText(_filePath);
            FileContentLines = File.ReadAllLines(_filePath);
        }

        protected void OverwriteFile(string fileContent)
        {
			File.WriteAllText(_filePath, fileContent);
        }
    }
}
