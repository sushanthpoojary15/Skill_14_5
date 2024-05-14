using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboSphere.Common.Model
{
    public class ProjectModel
    {
        public int ProjectId { get; set; }

        public string? ProjectName { get; set; }

        public string? ProjectDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set;}
        public string? Status { get; set; }
        public int? ProjectManagerId { get; set; }
    }
}
