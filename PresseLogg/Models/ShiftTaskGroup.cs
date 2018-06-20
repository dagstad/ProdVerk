using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresseLogg.Models
{
    public class ShiftTaskGroup
    {
        public int ShiftTaskGroupId { get; set; }
        public string ShiftTaskGroupName { get; set; }
        public int ShiftTaskId { get; set; }

        public virtual ICollection<ShiftTask> ShiftTasks { get; set; }
    }
}