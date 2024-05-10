using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

namespace ClientService.Domain.Entity
{
    public class Document : BaseEntity
    {
        public DocumentId DocumentId { get; private set; }
        public string DocumentName { get; private set; }
        public string DocumentType { get; private set; }
        public string DocumentPath { get; private set; }
        public string DocumentExtension { get; private set; }

        /*Foreign Key*/
        public ClientId? ClientId { get; private set; }
        public SpouseId? SpouseId { get; private set; }
        public DependantId? DependantId { get; private set; }

        /*Navigator*/
        public Client? Client { get; private set; }
        public Spouse? Spouse { get; private set; }
        public Dependant? Dependant { get; private set; }

        public Document()
        {
            DocumentId = new(Guid.NewGuid());
            ClientId = new(Guid.NewGuid());
            DocumentName = string.Empty;
            DocumentType = string.Empty;
            DocumentPath = string.Empty;
            DocumentExtension = string.Empty;
        }

        public Document Create(
            ClientId? clientId,
            SpouseId? spouseId,
            DependantId? dependantId,
            string documentName,
            string documentType,
            string documentPath,
            string documentExtension
        )
        {
            DocumentId documentId = new(Guid.NewGuid());
            Document document =
                new()
                {
                    ClientId = clientId,
                    SpouseId = spouseId,
                    DependantId = dependantId,
                    DocumentId = documentId,
                    DocumentName = documentName,
                    DocumentType = documentType,
                    DocumentExtension = documentExtension,
                    DocumentPath = documentPath,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                };
            return document;
        }
    }

    public record DocumentId(Guid Value);
}
