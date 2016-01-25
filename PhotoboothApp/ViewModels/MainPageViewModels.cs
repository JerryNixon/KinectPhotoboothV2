using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Utils;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace PhotoboothApp.ViewModels
{
    class MainPageViewModels : ViewModelBase
    {
        Services.FileService.FileService _fileService;

        public MainPageViewModels()
        {
            _fileService = new Services.FileService.FileService();
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var install = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var images = await install.GetFolderAsync("Images");
            var backgrounds = await images.GetFolderAsync("Backgrounds");
            var thumbs = await _fileService.ThumbnailsAsync(backgrounds, 300, ".jpg");
            Thumbs.AddRange(thumbs);
        }

        public ObservableCollection<Models.ImageInfo> Thumbs { get; } = new ObservableCollection<Models.ImageInfo>();
    }
}
