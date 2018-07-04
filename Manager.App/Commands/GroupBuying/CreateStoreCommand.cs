using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.App.Commands.GroupBuying
{
    public class CreateStoreCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
    }
}
