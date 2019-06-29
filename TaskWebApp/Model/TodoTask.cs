using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskWebApp.Model
{
    public class TodoTask
    {
        public int taskid { get; set; }
        public string TaskName { get; set; }
        public string CreatorName { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsFinished { get; set; }

    }
}
