using System.IO;
using System.Text.RegularExpressions;

namespace AML.Common
{
    public static class FileMatch
    {
        public static string GetFullFileName(string directory, string fileName)
        {
            DirectoryInfo d = new DirectoryInfo(directory);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.*"); //Getting Text files
            var flName = "";
            foreach (FileInfo file in Files)
            {
                var check = Regex.IsMatch(fileName, file.Name);
                if(check)
                {
                    flName = file.Name;
                    break;
                }
            }
            return flName;
        }
    }
}
