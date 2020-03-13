using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp_2
{
    //information about a directory item such as a drive, file or folder
    class DirectoryItem
    {
        //type of item
        public DirectoryItemType Type { get; set; }

        //name of the directory item
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

        //absolute path to this item
        public string FullPath { get; set; }
    }
}
