using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.Domain.Repositories
{
    public interface IClientRepository
    {
        public Task<CreateClientResponse> CreateClient(
            CreateClientRequest request,
            List<Task<DocumentDetails>> clientDocumentDetails,
            List<Task<DocumentDetails>> spouseDocumentDetails,
            List<Task<DocumentDetails>> dependantDocumentDetails
        );
    }
}
