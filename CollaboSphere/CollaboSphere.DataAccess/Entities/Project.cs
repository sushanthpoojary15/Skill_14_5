using System;
using System.Collections.Generic;

namespace CollaboSphere.DataAccess.Entities;

public partial class Project
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? ProjectDescription { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Status { get; set; }

    public int? ProjectManagerId { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual User? ProjectManager { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
