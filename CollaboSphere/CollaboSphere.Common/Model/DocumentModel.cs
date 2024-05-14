using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboSphere.Common.Model
{
    public class DocumentModel
    {
        public int DocumentId { get; set; }

        public string DocumentName { get; set; } = null!;

        public DateTime UploadDate { get; set; }

        public int UploadedByUserId { get; set; }

        public int ProjectId { get; set; }

        //public virtual Project Project { get; set; }

        //public virtual User UploadedByUser { get; set; }
    }
}
