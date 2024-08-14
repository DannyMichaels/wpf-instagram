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

namespace WpfInstagram.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        Random Generator;

        public HomePage()
        {
            InitializeComponent();

            Generator = new Random(DateTime.Now.Millisecond);

            PostsStackPanel.Children.Add(new VideoPost(new VideoPostModel()));
            PostsStackPanel.Children.Add(new PicturePost(new PicturePostModel()));
            PostsStackPanel.Children.Add(new VideoPost(new VideoPostModel()));
            PostsStackPanel.Children.Add(new PicturePost(new PicturePostModel()));
            PostsStackPanel.Children.Add(new VideoPost(new VideoPostModel()));
            PostsStackPanel.Children.Add(new PicturePost(new PicturePostModel()));
        }

        private void PostsScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.VerticalChange > 0)
            {
                int adjustment = 400;

                if (e.VerticalOffset + e.ViewportHeight + adjustment >= e.ExtentHeight)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (Generator.Next(0,100) < 70)
                        {
                            PostsStackPanel.Children.Add(new PicturePost(new PicturePostModel()));
                            }
                        else
                        {
                            PostsStackPanel.Children.Add(new VideoPost(new VideoPostModel()));
                        }
                    }
                }
            }
        }
    }
}