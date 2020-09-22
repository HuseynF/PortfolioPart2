using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Extentions
{
    public static class IFormFileExtention
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }
        public static bool LessThan(this IFormFile file,int mb)
        {
            return file.Length / 1024 / 1024 > mb;
        }
        public async static Task<string> SavePhoto(this IFormFile file,string root,string folder)
        {
            string path = Path.Combine(root, folder);
            string filename = Guid.NewGuid().ToString() + file.FileName;
            string resultPath = Path.Combine(path, filename);
            using(FileStream fileStream=new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return filename;
        }
    }
}
