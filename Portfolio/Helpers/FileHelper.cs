using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Helpers
{
    public static class FileHelper
    {
        public static bool DeleteImg(string root,string folder,string filename)
        {
            string path = Path.Combine(root, folder, filename);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return true;
            }
            return false;
        }
    }
}
