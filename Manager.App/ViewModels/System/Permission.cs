﻿namespace Manager.App.ViewModels.System
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
    }
}