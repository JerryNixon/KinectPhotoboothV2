using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Utils;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Search;
using Windows.UI.Xaml.Media.Imaging;

namespace PhotoboothApp.Services.FileService
{
    class FileService
    {
        /// <param name="filter">".jpg"</param>
        public async Task<List<Models.ImageInfo>> ThumbnailsAsync(StorageFolder folder, uint requestedSize = 190, params string[] filter)
        {
            var options = new QueryOptions(CommonFileQuery.OrderByName, filter);
            var query = folder.CreateFileQueryWithOptions(options);
            var files = (await query.GetFilesAsync() as IReadOnlyList<StorageFile>).ToList();
            var scale = ThumbnailOptions.UseCurrentScale;
            var mode = ThumbnailMode.PicturesView;
            var result = new List<Models.ImageInfo>();
            foreach (var file in files)
            {
                var thumbnail = await file.GetThumbnailAsync(mode, requestedSize, scale);
                result.Add(new Models.ImageInfo { File = file, Thumbnail = thumbnail });
            }
            return result;
        }
    }
}
