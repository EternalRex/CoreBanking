using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.Application.Query.List
{
    public interface IQueryList
    {
        public Task<MasterFileResponse> GetMasterFileData(MasterFileRequest request);
        public Task<GetAddressResponse> GetAddressMasterFileData(GetAddressRequest request);
    }
}
