using System;
using System.Collections.Generic;

namespace CollaboSphere.DataAccess.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? RoleId { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
