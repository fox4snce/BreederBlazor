using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BreederBlazor.Models.Auth
{
    public class User
    {
        public string Username { get; set; } = "";
        public string Key { get; set; } = "";
        public string Name { get; set; } = "";


    }
}
