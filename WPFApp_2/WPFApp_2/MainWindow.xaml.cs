using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace WPFApp_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();

            
        }

        #endregion

        #region On Loaded
        /// <summary>
        /// When first app opens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //get every logical drive
            foreach (var drive in Directory.GetLogicalDrives())
            {
                //create new item for it
                var item = new TreeViewItem();

                //set header and path
                item.Header = drive;
                item.Tag = drive;

                //dummy item
                item.Items.Add(null);

                // listen for item expansion event
                item.Expanded += Folder_Expanded;

                //add to folderview
                FolderView.Items.Add(item);
            }
        }

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;

            //if only item is dummy data
            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            //clear dummy data
            item.Items.Clear();

            //get full path
            var fullPath = (string)item.Tag;

            //create blank list
            var directories = new List<string>();


            //try and get directories from folder
            //ignore issues 
            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    directories.AddRange(dirs);
            }
            catch { }

            //for each directory
            directories.ForEach(directoryPath =>
            {
                //create directory item
                var subItem = new TreeViewItem()
                {
                    //set header as folder name
                    Header = Path.GetDirectoryName(directoryPath),
                    //set tag as full path
                    Tag = directoryPath
                };

                //add dummy items
                subItem.Items.Add(null);

                subItem.Expanded += Folder_Expanded;

                item.Items.Add(subItem);
            });
        }
        #endregion


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
