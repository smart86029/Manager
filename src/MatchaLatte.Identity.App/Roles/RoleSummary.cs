using System;

namespace MatchaLatte.Identity.App.Roles
{
    public class RoleSummary
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsEnabled { get; set; }
    }
}