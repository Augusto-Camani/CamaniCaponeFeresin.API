﻿using CamaniCaponeFeresin.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace CamaniCaponeFeresin.API.Models
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
