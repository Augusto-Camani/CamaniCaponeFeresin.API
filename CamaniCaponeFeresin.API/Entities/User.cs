﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamaniCaponeFeresin.API.Entities
{
    public abstract class User //Definición de clase abstracta, ya que de ella heredaran todos los tipos de usuarios.
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [Required]
        public string UserType { get; set; }
    }
}
