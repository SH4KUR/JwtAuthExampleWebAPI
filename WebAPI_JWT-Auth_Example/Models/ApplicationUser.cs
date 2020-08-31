using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI_JWT_Auth_Example.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
