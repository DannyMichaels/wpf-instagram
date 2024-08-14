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
using WpfInstagram.UserControls;

namespace WpfInstagram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainStackPanel.Children.Add(new VideoPost(new VideoPostModel()));
            MainStackPanel.Children.Add(new PicturePost(new PicturePostModel()));
            MainStackPanel.Children.Add(new VideoPost(new VideoPostModel()));
            MainStackPanel.Children.Add(new PicturePost(new PicturePostModel()));
            MainStackPanel.Children.Add(new VideoPost(new VideoPostModel()));
            MainStackPanel.Children.Add(new PicturePost(new PicturePostModel()));
        }

        private void MainScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.VerticalChange > 0)
            {
                int adjustment = 400;

                if (e.VerticalOffset + e.ViewportHeight + adjustment >= e.ExtentHeight)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        PicturePost picturePost = new PicturePost(new PicturePostModel());
                        MainStackPanel.Children.Add(picturePost);

                        //VideoPost videoPost = new VideoPost(new VideoPostModel());
                        //MainStackPanel.Children.Add(videoPost);
                    }
                }
            }
        }
    }
}