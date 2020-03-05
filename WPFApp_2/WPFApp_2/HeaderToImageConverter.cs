using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;


namespace WPFApp_2
{
    /// <summary>
    /// convert a full path to a specific image type of a drive, folder or 
    /// </summary>
    
     [ValueConversion(typeof(string), typeof(BitmapImage))]
     class HeaderToImageConverter : IValueConverter
     {
         public static HeaderToImageConverter Instance = new HeaderToImageConverter();
 
         object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
         {
            var path = (string)value;

            // if path is null
            if (path == null)
                return null;

            //get name of file/folder
            var name = MainWindow.GetFileFolderName(path);
            //by default, assume file image
            var image = "Images/file.png";

            if (string.IsNullOrEmpty(name))
                image = "Images/drive.png";
            else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
                image = "Images/folder-closed.png";

            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
         }
 
         object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
         {
             throw new NotImplementedException();
         }
     }
}
