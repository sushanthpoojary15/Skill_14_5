using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboSphere.Common.Model
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool TaskStatus { get; set; }
        public int AssignedToUserId { get; set; }
        public int ProjectId { get; set; }
    }
}
