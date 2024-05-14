using CollaboSphere.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboSphere.DataAccess.Contracts
{
    public interface IDocumentRepository
    {
        List<Document> GetDocuments();

        Document? GetDocument(int documentId);

        void AddDocument(Document document);

        void UpdateDocument(Document document);

        void DeleteDocument(int documentId);

        int SaveChanges();
    }
}
