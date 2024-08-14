using System.Windows;

namespace WpfInstagram.Extensions
{
    public static class TextBlockExtensions
    {
        public static readonly DependencyProperty DataUserNameProperty = 
            DependencyProperty.RegisterAttached("DataUserName", typeof(string), typeof(TextBlockExtensions), new PropertyMetadata(null));

        public static void SetDataUserName(UIElement element, string value)
        {
            element.SetValue(DataUserNameProperty, value);
        }

        public static string GetDataUserName(UIElement element)
        {
            return (string)element.GetValue(DataUserNameProperty);
        }
    }
}