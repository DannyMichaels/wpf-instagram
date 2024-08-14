using System;
using System.IO;
using System.Windows;
using System.Reflection;
using System.Windows.Media.Imaging;
using WpfInstagram.Models;
using System.Collections.Generic;

namespace WpfInstagram.Database
{
    public class MockDb
    {
        private static string GetResourcePath(string folderName)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string resourcePath = Path.Combine(baseDirectory, folderName);

            if (!Directory.Exists(resourcePath))
            {
                // If not found, try looking in the project directory (for development)
                string projectDirectory = GetProjectDirectory();
                resourcePath = Path.Combine(projectDirectory, folderName);
            }

            return resourcePath;
        }

        public static Uri GetPostVideo()
        {
            string videoPath = Path.Combine(GetResourcePath("Videos"), "cat.mp4");
            if (!File.Exists(videoPath))
            {
                MessageBox.Show($"Video file not found: {videoPath}");
                return null;
            }
            return new Uri(videoPath, UriKind.Absolute);
        }

        public static BitmapImage GetPostPicture()
        {
            string imagesDirectory = GetResourcePath("Images");
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

            Random random = new Random();
            string randomImagePath = imagePaths[random.Next(imagePaths.Length)];

            try
            {
                return new BitmapImage(new Uri(randomImagePath, UriKind.Absolute));
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
            while (!File.Exists(Path.Combine(projectDirectory, "WpfInstagram.csproj")) &&
                   Directory.GetParent(projectDirectory) != null)
            {
                projectDirectory = Directory.GetParent(projectDirectory).FullName;
            }
            return projectDirectory;
        }
    }
}