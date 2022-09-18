﻿using System.ComponentModel.DataAnnotations;

namespace ApiBackEnd.Models.DataModels
{
    public class UserLogin
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
