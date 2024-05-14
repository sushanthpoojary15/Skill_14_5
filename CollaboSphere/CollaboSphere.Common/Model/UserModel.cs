using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboSphere.Common.Model
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = "";

        public string Email { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? RoleId { get; set; }

        public DateTime? LastLogin { get; set; }

        public bool? IsActive { get; set; }

        public virtual ICollection<DocumentModel> Documents { get; set; } = new List<DocumentModel>();

        public virtual ICollection<ProjectModel> Projects { get; set; } = new List<ProjectModel>();
        public string PasswordHash { get; set; } = "";
    }
}
