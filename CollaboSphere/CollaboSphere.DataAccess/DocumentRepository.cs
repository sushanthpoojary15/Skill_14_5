using CollaboSphere.DataAccess.Contracts;
using CollaboSphere.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboSphere.DataAccess
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly CollaboSphereContext _collaboSphereContext;

        public DocumentRepository(CollaboSphereContext collaboSphereContext)
        {
            this._collaboSphereContext = collaboSphereContext;
        }
        public void AddDocument(Document document)
        {
            this._collaboSphereContext.Documents.Add(document);
        }

        public void DeleteDocument(int documentId)
        {
            var document = _collaboSphereContext.Documents.FirstOrDefault(r => r.DocumentId == documentId);
            if (document != null)
            {

               _collaboSphereContext.Documents.Remove(document);
                _collaboSphereContext.SaveChanges();

            }
        }

        public Document GetDocument(int documentId)
        {
            return _collaboSphereContext.Documents.FirstOrDefault(r => r.DocumentId == documentId);
        }

        public List<Document> GetDocuments()
        {
            return this._collaboSphereContext.Documents.ToList();
        }

        public int SaveChanges()
        {
            return this._collaboSphereContext.SaveChanges();
        }

        public void UpdateDocument(Document document)
        {
            var entityToUpdate = this._collaboSphereContext.Documents.Find(document.DocumentId);
            if (entityToUpdate != null)
            {
                entityToUpdate.DocumentName = document.DocumentName;
                entityToUpdate.UploadDate = document.UploadDate;
                entityToUpdate.UploadedByUserId = document.UploadedByUserId;
                entityToUpdate.ProjectId = document.ProjectId;

            }
        }
    }
}

