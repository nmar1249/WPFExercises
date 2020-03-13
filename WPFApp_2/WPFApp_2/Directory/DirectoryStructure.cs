using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp_2
{
    //helper class to query information about directories
    class DirectoryStructure
    {

        public static List<DirectoryItem> GetLogicalDrives()
        {
            //get every logical drive
           return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }
        public static string GetFileFolderName(string path)
        {
            // c:\something\a folder
            // c:\something\a file.png

            //return empty if no path
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            //normalized slashes, make them blackslashes
            var normalizedPath = path.Replace('/', '\\');

            //find last blackslash
            var lastIndex = normalizedPath.LastIndexOf('\\');

            //if we dont find a backslash, return the path
            if (lastIndex <= 0)
                return path;

            //return string after last backslash
            return path.Substring(lastIndex + 1);
        }
    }
}
