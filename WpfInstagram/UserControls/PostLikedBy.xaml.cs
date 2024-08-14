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
using WpfInstagram.Database;

namespace WpfInstagram.UserControls
{
  /// <summary>
  /// Interaction logic for PostLikedBy.xaml
  /// </summary>
  public partial class PostLikedBy : UserControl
  {
        Random Generator;

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
        CloseFriend2.Text = usernames[1];

        OtherFriends.Text = $"and {Generator.Next(1, 100)} others";
    }
  }
}
