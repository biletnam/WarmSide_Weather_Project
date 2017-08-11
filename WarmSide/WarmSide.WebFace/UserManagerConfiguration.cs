using System;
using System.Configuration;
using WarmSide.WebFace.Interfaces;

namespace WarmSide.WebFace
{
    public class UserManagerConfiguration : IUserManagerConfiguration
    {
        private readonly string _userManagerUrl;

        public UserManagerConfiguration()
        {
            _userManagerUrl = ConfigurationManager.AppSettings["UserManagerAPIUrl"];
        }
        public string UserManagerUrl
        {
            get
            {
                return _userManagerUrl;
            }
        }
    }
}