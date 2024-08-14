using System.ComponentModel;
using System.Windows.Controls;

namespace WpfInstagram.Pages
{
    public partial class UserProfile : Page, INotifyPropertyChanged
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                    OnPropertyChanged(nameof(ProfileTitle));
                }
            }
        }

        public string ProfileTitle => $"{Username}'s Profile";

        public event PropertyChangedEventHandler PropertyChanged;

        public UserProfile(string username)
        {
            InitializeComponent();
            DataContext = this;
            Username = username;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}