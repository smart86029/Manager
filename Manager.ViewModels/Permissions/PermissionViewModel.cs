using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.ViewModels.Permissions
{
    public class PermissionViewModel
    {
        public int PermissionId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
    }
}
