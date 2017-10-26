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
            _userManagerUrl = ConfigurationManager.AppSettings["WarmSideWebAPIUrl"];
        }
        public string WarmSideWebApiUrl
        {
            get
            {
                return _userManagerUrl;
            }
        }
    }
}