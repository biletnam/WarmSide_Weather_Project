using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarmSide.WebFace.Models
{
    public class User
    {
        public string UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsGoogle { get; set; }
        public string FavoriteCity { get; set; }
    }
}
