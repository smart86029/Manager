using System.Collections.Generic;

namespace MatchaLatte.Identity.App.ViewModels.User
{
    public class UserDetail
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<RoleDetail> Roles { get; set; } = new List<RoleDetail>();
    }
}