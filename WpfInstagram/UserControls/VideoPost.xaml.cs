using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;
using WpfInstagram.Models;

namespace WpfInstagram.UserControls
{
    /// <summary>
    /// Interaction logic for VideoPost.xaml
    /// </summary>
    public partial class VideoPost : UserControl
    {
        public VideoPost(VideoPostModel videoPostModel)
        {
            InitializeComponent();
            VideoPlayer.Source = videoPostModel.VideoPlayerSource;

            // Add error handling
            VideoPlayer.MediaFailed += VideoPlayer_MediaFailed;
        }

        private void VideoPlayer_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show($"Media failed to load. Error: {e.ErrorException.Message}");
        }


        private void ContentControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (PostOps.PostLiked)
                PostOps.UnLikePost();
            else
                PostOps.LikePost();
        }
    }
}
