using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string CreatedOn { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
