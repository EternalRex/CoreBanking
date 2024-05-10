using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.Application.Command.Create
{
    public interface ICreateClientCmd
    {
        public Task<CreateClientResponse> HandleCreateCommand(CreateClientRequest request);
        public Task<AddMasterFileResponse> HandleAddMasterFileCommand(AddMasterFileRequest request);
    }
}
