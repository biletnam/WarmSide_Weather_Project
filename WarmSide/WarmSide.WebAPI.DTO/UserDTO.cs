using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarmSide.WebAPI.DTO
{
    public class UserDTO
    {
        public string UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isGoogle { get; set; }
    }
}
