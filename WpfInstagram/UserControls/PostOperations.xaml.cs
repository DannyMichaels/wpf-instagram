using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WpfInstagram.UserControls
{
  public partial class PostOperations : UserControl
  {
    public bool PostLiked { get; set; }

    public PostOperations()
    {
      InitializeComponent();
    }

    public void LikePost()
    {
      Heart.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/like.png", UriKind.Absolute));
      PostLiked = true;
    }

    public void UnLikePost()
    {
      Heart.Source = new BitmapImage(new Uri("pack://application:,,,/Icons/nolike.png", UriKind.Absolute));
      PostLiked = false;
    }

    private void Heart_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if (!PostLiked)
        LikePost();
      else
        UnLikePost();
    }
  }
}