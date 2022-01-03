using System;
using System.Collections.Generic;
using System.Text;

namespace VULauncher.Models.Repositories.Common
{
    public abstract class FilesRepository : Repository
    {
        protected FilesRepository()
        {
            Load();
        }

        protected abstract void Load();
    }
}
