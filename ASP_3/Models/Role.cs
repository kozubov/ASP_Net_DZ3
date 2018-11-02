using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_3.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Role(string name)
        {
            Name = name;
        }

        public void Edit_Role(string name)
        {
            Name = name;
        }
    }
}