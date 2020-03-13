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

        //gets all logical drives from computer
        public static List<DirectoryItem> GetLogicalDrives()
        {
            //get every logical drive
           return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }

        //get directories top-level content
        public static List<DirectoryItem> GetDirectoryContent(string fullPath)
        {
            var items = new List<DirectoryItem>();

            #region Get Folders

            //try and get directories from folder
            //ignore issues 
            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
            }
            catch { }
            #endregion

            #region Get Files

            //try and get files from folder
            //ignore issues 
            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
            }
            catch { }

            return items;

            #endregion
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
