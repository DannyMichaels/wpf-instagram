using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfInstagram.Models
{
    public class UserModel
    {
        private string? _username;

        public string Username {
            get {
                if (_username == null)
                {
                    return Faker.Internet.UserName();
                }

                return _username;
            }

            set { _username = value; }
        }
    }
}
