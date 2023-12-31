﻿using System.ComponentModel.DataAnnotations;

namespace UrlPrieto.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string User { get; set; }

        [Required]
        public string Password { get; set; }

        public int Restantes { get; set; } = 10;

        public IEnumerable<Url> urls { get; set; }

    }
}
