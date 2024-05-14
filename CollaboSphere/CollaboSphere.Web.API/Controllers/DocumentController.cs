using CollaboSphere.Business;
using CollaboSphere.Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollaboSphere.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly DocumentBusiness _documentBusiness;
        public DocumentController(DocumentBusiness documentBusiness)
        {
            this._documentBusiness = documentBusiness;
        }

        [HttpPost]
        public void AddOrUpdateDocument(DocumentModel documentModel)
        {
            if (documentModel.DocumentId == 0)
            {
                this._documentBusiness.AddDocument(documentModel);
            }
            else
            {
                this._documentBusiness.UpdateDocument(documentModel);
            }
        }
        [HttpGet]
        public List<DocumentModel> GetDocuments()
        {
            return this._documentBusiness.GetDocuments();
        }

        [HttpGet("{documentId:int}")]
        public DocumentModel Getdocument(int documentId)
        {
            return this._documentBusiness.GetDocument(documentId);
        }

        [HttpDelete]
        public void DeleteDocument(int documentId)
        {
            this._documentBusiness.DeleteDocument(documentId);
        }

    }
}
