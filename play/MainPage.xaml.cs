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



// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace play
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage Current;//这句
        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(yy));
            Current = this;//这句
            RecommendListBoxItem.IsSelected = true;
        }
       
     
           
        

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("http://www.neu.edu.cn/indexsource/neusong.mp3"));
        }

        private void ListBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuSplitView.IsPaneOpen = !MenuSplitView.IsPaneOpen;
        }



        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecommendListBoxItem.IsSelected)
            {
                MyFrame.Navigate(typeof(yy));
            }
            else
            {
                if (VideoListBoxItem.IsSelected)
                {
                    MyFrame.Navigate(typeof(wy));
                }
                else if(MomentsListBoxItem.IsSelected)
                {
                    MyFrame.Navigate(typeof(load));
                }
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var myPictures = await Windows.Storage.StorageLibrary.GetLibraryAsync(Windows.Storage.KnownLibraryId.Pictures);
            Windows.Storage.StorageFolder savePicturesFolder = myPictures.SaveFolder;
            Windows.Storage.StorageFolder newFolder = await myPictures.RequestAddFolderAsync();

            QueryOptions queryOption = new QueryOptions
                (CommonFileQuery.OrderByTitle, new string[] { ".mp3", ".mp4", ".wma" });

            queryOption.FolderDepth = FolderDepth.Deep;

            Queue<IStorageFolder> folders = new Queue<IStorageFolder>();

            var files = await KnownFolders.MusicLibrary.CreateFileQueryWithOptions
              (queryOption).GetFilesAsync();

        


        }


 


    }



}
