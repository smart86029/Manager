﻿using System;

namespace MatchaLatte.Identity.App.Commands.Users
{
    public class RoleDto
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
}