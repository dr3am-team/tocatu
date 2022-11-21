using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace tocatu.Providers
{
    public enum Folders
    {
        Images = 0
    }

    public class PathProvider
    {
        private IWebHostEnvironment hostEnviroment;

        public PathProvider(IWebHostEnvironment hostEnviroment)
        {
            this.hostEnviroment = hostEnviroment;
        }

        public string MapPath(string fileName, Folders folder)
        {
            string carpeta = "";

            if (folder == Folders.Images)
            {
                carpeta = "images";
            }

            string path = Path.Combine(this.hostEnviroment.WebRootPath, carpeta, fileName);

            return path;
        }

    }
}