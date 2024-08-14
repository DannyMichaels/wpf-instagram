using System;
using System.IO;
using System.Windows;
using System.Reflection;
using System.Windows.Media.Imaging;
using WpfInstagram.Models;

namespace WpfInstagram.Database
{
    public class MockDb
    {
        public static Uri GetPostVideo()
        {
            string projectDirectory = GetProjectDirectory();
            string videoPath = Path.Combine(projectDirectory, "Videos", "cat.mp4");

            if (!File.Exists(videoPath))
            {
                MessageBox.Show($"File not found: {videoPath}");
                return null;
            }

            return new Uri(videoPath, UriKind.Absolute);
        }

        public static BitmapImage GetPostPicture()
        {
            string projectDirectory = GetProjectDirectory();
            string imagesDirectory = Path.Combine(projectDirectory, "Images");

            if (!Directory.Exists(imagesDirectory))
            {
                MessageBox.Show($"Images directory not found: {imagesDirectory}");
                return null;
            }

            string[] imagePaths = Directory.GetFiles(imagesDirectory, "*.jpg");

            if (imagePaths.Length == 0)
            {
                MessageBox.Show("No .jpg files found in the Images directory.");
                return null;
            }

            // Get a random image path
            Random random = new Random();
            string randomImagePath = imagePaths[random.Next(imagePaths.Length)];

            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(randomImagePath, UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                return bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
                return null;
            }
        }

        public static List<string> GetPostLikedBy()
        {
            List<string> usernames = new List<string>();

            for (int i = 0; i < 2; i++)
            {
                usernames.Add(new UserModel().Username);
            }

            return usernames;
        }

        private static string GetProjectDirectory()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = currentDirectory;

            // Navigate up until we find the project root (where the .csproj file is)
            while (!File.Exists(Path.Combine(projectDirectory, "WpfInstagram.csproj")) &&
                   Directory.GetParent(projectDirectory) != null)
            {
                projectDirectory = Directory.GetParent(projectDirectory).FullName;
            }

            return projectDirectory;
        }
    }
}