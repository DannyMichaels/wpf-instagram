using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfInstagram.Database;

namespace WpfInstagram.Models
{
    public class VideoPostModel
    {
        private Uri _videoPlayerSource;

        public VideoPostModel()
        {
            _videoPlayerSource = MockDb.GetPostVideo();
        }

        public Uri VideoPlayerSource
        {
            get => _videoPlayerSource;
            set => _videoPlayerSource = value;
        }
    }
}