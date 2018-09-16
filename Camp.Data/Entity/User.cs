using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Camp.Data.Entity
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ImgPath { get; set; }

        public string Fullname => Firstname + " " + Lastname;
    }
}
