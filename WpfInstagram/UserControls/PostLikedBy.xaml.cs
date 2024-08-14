using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfInstagram.Database;
using WpfInstagram.Extensions;
using WpfInstagram.Pages;

namespace WpfInstagram.UserControls
{
    public partial class PostLikedBy : UserControl
    {
        Random Generator;
        public UserProfile UserProfilePage;

        public PostLikedBy()
        {
            InitializeComponent();
            Generator = new Random(DateTime.Now.Millisecond);
            PopulatePostLikedByData();
        }

        private void PopulatePostLikedByData()
        {
            List<string> usernames = MockDb.GetPostLikedBy();
            CloseFriend1.Text = usernames[0] + ",";
            TextBlockExtensions.SetDataUserName(CloseFriend1, usernames[0]);
            CloseFriend2.Text = usernames[1];
            TextBlockExtensions.SetDataUserName(CloseFriend2, usernames[1]);
            OtherFriends.Text = $"and {Generator.Next(1, 100)} others";
        }

        private void CloseFriend_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBlock textBlock)
            {
                string selectedUsername = TextBlockExtensions.GetDataUserName(textBlock);
                UserProfilePage = new UserProfile(selectedUsername);
                ((MainWindow)Application.Current.MainWindow).MainWindowFrame.Navigate(UserProfilePage);
            }
        }
    }
}