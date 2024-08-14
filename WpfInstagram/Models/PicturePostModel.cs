using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WpfInstagram.Database;

namespace WpfInstagram.Models
{
    public class PicturePostModel
    {
        private BitmapImage? _postImage;
        public BitmapImage PostImage
        {
            get
            {
                if (_postImage == null)
                {
                    return MockDb.GetPostPicture();
                }
                return _postImage;
            }

            set { _postImage = value; }
        }    
    }
}
