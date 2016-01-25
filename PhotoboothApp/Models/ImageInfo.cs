using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;

namespace PhotoboothApp.Models
{
    class ImageInfo
    {
        public StorageFile File { get; set; }
        public StorageItemThumbnail Thumbnail { get; set; }
    }
}
