using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace PhotoboothApp.Converters
{
    class ThumbnailToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                throw new NullReferenceException(nameof(value));
            var thumbnail = (StorageItemThumbnail)value;
            if (thumbnail == null)
                throw new NullReferenceException(nameof(StorageItemThumbnail));
            if (targetType != typeof(ImageSource))
                throw new InvalidCastException(nameof(ImageSource));
            var image = new BitmapImage();
            image.SetSource(thumbnail);
            return (image);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
