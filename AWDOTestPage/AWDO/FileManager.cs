
using System;
using System.IO;

namespace AWDO 
{
    public class FileManager
    {
        String userName, pageName;
        public FileManager(String userName, String pageName) {
            this.userName = userName;
            this.pageName = pageName;
        }
        public void MakeUserDirectory()
        {
            string PathString = Directory.GetCurrentDirectory();
            PathString = Path.Combine(PathString, userName);
            System.IO.Directory.CreateDirectory(PathString);
            
        }

        public void MakeUserViewsDirectory()
        {
            string PathString = Directory.GetCurrentDirectory();
            PathString = Path.Combine(PathString, userName, pageName);
            System.IO.Directory.CreateDirectory(PathString);
        }
        public void MakeFile(String HTMLString, String extension)
        {
            string PathString = Directory.GetCurrentDirectory();
            PathString = Path.Combine(PathString, userName, pageName, pageName+extension);
            System.IO.File.WriteAllText(PathString, HTMLString);
        }
    }
}