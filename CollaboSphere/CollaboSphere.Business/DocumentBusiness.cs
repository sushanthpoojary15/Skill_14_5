using CollaboSphere.Common.Model;
using CollaboSphere.DataAccess.Contracts;
using CollaboSphere.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboSphere.Business
{
    public class DocumentBusiness
    {
        private readonly IDocumentRepository _documentRepository;
        public DocumentBusiness(IDocumentRepository documentRepository)
        {
            this._documentRepository = documentRepository;
        }

        public void AddDocument(DocumentModel documentModel)
        {
            Document document = new Document();
            document.DocumentId = documentModel.DocumentId;
            document.DocumentName = documentModel.DocumentName;
            document.UploadDate = documentModel.UploadDate;
            document.UploadedByUserId = documentModel.UploadedByUserId;
            document.ProjectId = documentModel.ProjectId;

            this._documentRepository.AddDocument(document);
            this._documentRepository.SaveChanges();
        }

        public void DeleteDocument(int documentId)
        {
            this._documentRepository.DeleteDocument(documentId);
            this._documentRepository.SaveChanges();
        }

        public DocumentModel GetDocument(int documentId)
        {
            var document = this._documentRepository.GetDocument(documentId);
            if (document != null)
            {
                return new DocumentModel
                {

                    DocumentId = documentId,
                    DocumentName = document.DocumentName,
                    UploadDate = document.UploadDate,
                    UploadedByUserId = document.UploadedByUserId,
                    ProjectId = document.ProjectId,
                };

            }
            return null;

        }

        public List<DocumentModel> GetDocuments()
        {
            var documents = this._documentRepository.GetDocuments();

            var documentModels = from document in documents
                                 select new DocumentModel
                                 {

                                     DocumentId = document.DocumentId,
                                     DocumentName = document.DocumentName,
                                     UploadDate = document.UploadDate,
                                     UploadedByUserId = document.UploadedByUserId,
                                     ProjectId = document.ProjectId
                                 };
            return documentModels.ToList();
        }

        public void UpdateDocument(DocumentModel documentModel)
        {
            Document document = new Document();
            document.DocumentId = documentModel.DocumentId;
            document.DocumentName = documentModel.DocumentName;
            document.UploadDate = documentModel.UploadDate;
            document.UploadedByUserId = documentModel.UploadedByUserId;
            document.ProjectId = documentModel.ProjectId;

            this._documentRepository.UpdateDocument(document);
            this._documentRepository.SaveChanges();
        }
    }
}

