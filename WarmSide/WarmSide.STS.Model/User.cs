﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarmSide.STS.Models
{
    public class User
    {
        public string UserID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Password { get; set; }
        public string Username { get; set; }
    }
}