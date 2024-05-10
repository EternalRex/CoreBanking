using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Application.Command.Create;
using Grpc.Core;

namespace ClientService.Services
{
    public class ClientServices : ClientServicesProto.ClientServicesProtoBase
    {
        private readonly ICreateClientCmd _createClientCmd;

        public ClientServices(ICreateClientCmd createClientCmd)
        {
            _createClientCmd = createClientCmd;
        }

        public override async Task<CreateClientResponse> AddClient(
            CreateClientRequest request,
            ServerCallContext context
        )
        {
            var response = await _createClientCmd.HandleCreateCommand(request);
            return response;
        }
    }
}
