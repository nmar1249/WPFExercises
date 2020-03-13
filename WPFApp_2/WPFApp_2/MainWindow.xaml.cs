﻿using System;
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


        #region Folder Expanded
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

            #region Get Folders
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
                    Header = GetFileFolderName(directoryPath),
                    //set tag as full path
                    Tag = directoryPath
                };

                //add dummy items
                subItem.Items.Add(null);

                subItem.Expanded += Folder_Expanded;

                item.Items.Add(subItem);
            });

            #endregion

            #region Get Files

            //create blank list
            var files = new List<string>();


            //try and get files from folder
            //ignore issues 
            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    files.AddRange(fs);
            }
            catch { }

            //for each directory
            files.ForEach(filePath =>
            {
                //create directory item
                var subItem = new TreeViewItem()
                {
                    //set header as folder name
                    Header = GetFileFolderName(filePath),
                    //set tag as full path
                    Tag = filePath
                };

                item.Items.Add(subItem);
            });

            #endregion
        }
        #endregion


        
    }
}
