using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Application.Command.Create;
using ClientService.Application.Query.List;
using Grpc.Core;

namespace ClientService.Services
{
    public class MasterFileServices : MasterFileOperation.MasterFileOperationBase
    {
        private readonly IQueryList _queryList;
        private readonly ILogger<MasterFileServices> _logger;
        private readonly ICreateClientCmd _createClientCmd;

        public MasterFileServices(
            IQueryList queryList,
            ILogger<MasterFileServices> logger,
            ICreateClientCmd createClientCmd
        )
        {
            _queryList = queryList;
            _logger = logger;
            _createClientCmd = createClientCmd;
        }

        //Get MasterFile
        public override async Task<MasterFileResponse> GetMasterFile(
            MasterFileRequest request,
            ServerCallContext contex
        )
        {
            try
            {
                var response = await _queryList.GetMasterFileData(request);
                return response;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Failed to Retrieve {request}");
                throw new ArgumentException($"{exception}");
            }
        }

        //Get the Address master file
        public override async Task<GetAddressResponse> GetAddressMasterFile(
            GetAddressRequest request,
            ServerCallContext context
        )
        {
            try
            {
                var response = await _queryList.GetAddressMasterFileData(request);
                return response;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Failed to Retrieve {request}");
                throw new ArgumentException($"{exception}");
            }
        }

        //Add Master File
        public override async Task<AddMasterFileResponse> AddNewMasterFileData(
            AddMasterFileRequest request,
            ServerCallContext context
        )
        {
            try
            {
                /*Pass the request data to the add master file command*/
                var response = await _createClientCmd.HandleAddMasterFileCommand(request);
                return response;
            }
            catch (Exception e)
            {
                /*A response to return whenever the adding of new master file failed*/
                AddMasterFileResponse addMasterFileResponse = new AddMasterFileResponse()
                {
                    AddResponse = "Failed adding new masterfile"
                };
                /*logs the error*/
                _logger.LogError($"Failed operation in AddMasterFileService AddNewMasterFile", e);
                return addMasterFileResponse;
            }
        }
    }
}
