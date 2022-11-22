﻿using System;
using System.Collections.Generic;

namespace GolfMaxWebApi.Models.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}