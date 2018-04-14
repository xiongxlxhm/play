using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using System.Net.Http;
using Windows.Storage.Search;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Media.Playback;
using Windows.Media.Core;
using Windows.Web.Http;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace play
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class load : Page
    {
        public load()
        {
            this.InitializeComponent();
        }



        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StorageFile LoadFile = await Load();
            MediaPlayer MyMediaPlayer = new MediaPlayer();
            if (LoadFile != null)
            {
                var mediaSource = MediaSource.CreateFromStorageFile(LoadFile);
                MyMediaPlayer.Source = mediaSource;
                MyMedia.SetMediaPlayer(MyMediaPlayer);
                MyMediaPlayer.Play();
            }
        }

        public async Task<StorageFile> Load()
        {
            try

            {
                var httpClient = new Windows.Web.Http.HttpClient();
                var buffer = await httpClient.GetBufferAsync(new Uri("http://www.neu.edu.cn/indexsource/neusong.mp3"));
                if (buffer != null && buffer.Length > 0u)
                {
                    var file = await KnownFolders.MusicLibrary.CreateFileAsync("neusong.mp3", CreationCollisionOption.ReplaceExisting);
                    using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        await stream.WriteAsync(buffer);
                        await stream.FlushAsync();
                    }
                    return file;
                }
            }
            catch { }
            return null;
        }




    }
}
