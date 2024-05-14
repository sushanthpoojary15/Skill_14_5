using System;
using System.Collections.Generic;

namespace CollaboSphere.DataAccess.Entities;

public partial class Task
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public string? TaskDescription { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? DueDate { get; set; }

    public string? Status { get; set; }

    public int? AssignedToUserId { get; set; }

    public int? ProjectId { get; set; }

    public virtual User? AssignedToUser { get; set; }

    public virtual Project? Project { get; set; }
}
