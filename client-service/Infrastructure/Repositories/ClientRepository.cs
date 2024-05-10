using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AutoMapper;
using ClientService.Domain.Entity;
using ClientService.Domain.Repositories;
using ClientService.Infrastructure.Data;
using Microsoft.VisualBasic;
using Document = ClientService.Domain.Entity.Document;

namespace ClientService.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ILogger<ClientRepository> _logger;

        public ClientRepository(
            IMapper mapper,
            DataContext context,
            ILogger<ClientRepository> logger
        )
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<CreateClientResponse> CreateClient(
            CreateClientRequest request,
            List<Task<DocumentDetails>> clientDocumentDetails,
            List<Task<DocumentDetails>> spouseDocumentDetails,
            List<Task<DocumentDetails>> dependantDocumentDetails
        )
        {
            try
            {
                /*Mapping client information*/
                var clientDetails = request.ClientDetails;

                var clientPersonEntity = _mapper.Map<Person>(clientDetails);

                var clientEntity = _mapper.Map<Client>(
                    request,
                    options =>
                    {
                        options.Items["PersonId"] = clientPersonEntity.PersonId;
                    }
                );

                /*Converting client document details back to a non awaitable variable*/
                var awaitedClientDocuments = await Task.WhenAll(clientDocumentDetails);
                var clientDocumentsEntities = _mapper.Map<List<Document>>(
                    request,
                    options =>
                    {
                        /*Identifies this document mapping is for client*/
                        var identifier = "CLIENT";

                        /*Converting the array back into a list*/
                        options.Items["ListOfDocuments"] = awaitedClientDocuments.ToList();
                        options.Items["ClientId"] = clientEntity.ClientId;
                        options.Items["IDENTIFIER"] = identifier;
                    }
                );

                /*Mapping spouse information*/
                var spouseDetails = request.SpouseDetails;
                var spousePersonEnities = _mapper.Map<List<Person>>(
                    request,
                    options =>
                    {
                        var identifier = "SPOUSE";
                        var spousePerson = spouseDetails
                            .Select(prop => prop.PersonDetails)
                            .ToList();

                        options.Items["ListOfSpousePersonDetails"] = spousePerson;
                        options.Items["IDENTIFIER"] = identifier;
                    }
                );

                var spouseEntities = _mapper.Map<List<Spouse>>(
                    request,
                    options =>
                    {
                        var spousePersonId = spousePersonEnities
                            .Select(prop => prop.PersonId)
                            .ToList();
                        options.Items["ListOfPersonId"] = spousePersonId;
                        options.Items["ClientId"] = clientEntity.ClientId;
                    }
                );

                /*Converting spouse document details back to a non awaitable variable*/
                var awaitedSpouseDocuments = await Task.WhenAll(spouseDocumentDetails);
                var spouseDocumentEntities = _mapper.Map<List<Document>>(
                    request,
                    options =>
                    {
                        var spouseId = spouseEntities.Select(prop => prop.SpouseId).ToList();
                        /*Identifies that this document mapping is for spouse*/
                        var identifier = "SPOUSE";

                        options.Items["ListOfDocuments"] = awaitedSpouseDocuments.ToList();
                        options.Items["SpouseIdList"] = spouseId;
                        options.Items["IDENTIFIER"] = identifier;
                    }
                );

                /*Mapping dependant information*/
                var dependantDetails = request.DependantDetails;
                var dependantPersonEnities = _mapper.Map<List<Person>>(
                    request,
                    options =>
                    {
                        var identifier = "DEPENDANT";
                        var dependantPerson = dependantDetails
                            .Select(prop => prop.PersonDetails)
                            .ToList();

                        options.Items["ListOfDependantPersonDetails"] = dependantPerson;
                        options.Items["IDENTIFIER"] = identifier;
                    }
                );

                var dependantEntities = _mapper.Map<List<Dependant>>(
                    request,
                    options =>
                    {
                        var dependantPersonId = dependantPersonEnities
                            .Select(prop => prop.PersonId)
                            .ToList();
                        options.Items["ListOfPersonId"] = dependantPersonId;
                        options.Items["ClientId"] = clientEntity.ClientId;
                    }
                );

                /*Converting dependant document details back to a non awaitable variable*/
                var awaitDependantDocuments = await Task.WhenAll(dependantDocumentDetails);
                var dependantDocumentEntities = _mapper.Map<List<Document>>(
                    request,
                    options =>
                    {
                        var dependantId = dependantEntities
                            .Select(prop => prop.DependantId)
                            .ToList();
                        var identifier = "DEPENDANT";

                        options.Items["ListOfDocuments"] = awaitDependantDocuments.ToList();
                        options.Items["DependantIdListId"] = dependantId;
                        options.Items["IDENTIFIER"] = identifier;
                    }
                );

                /*Mapping Business information*/
                var businessEntities = _mapper.Map<List<Business>>(
                    request,
                    opts =>
                    {
                        opts.Items["ClientId"] = clientEntity.ClientId;
                    }
                );

                /*Explicit declaration of DbSets*/
                await _context.Person.AddAsync(clientPersonEntity!);
                await _context.Client.AddAsync(clientEntity);
                await _context.Document.AddRangeAsync(clientDocumentsEntities);

                await _context.Person.AddRangeAsync(spousePersonEnities);
                await _context.Spouse.AddRangeAsync(spouseEntities);
                await _context.Document.AddRangeAsync(spouseDocumentEntities);

                await _context.Person.AddRangeAsync(dependantPersonEnities);
                await _context.Dependant.AddRangeAsync(dependantEntities);
                await _context.Document.AddRangeAsync(dependantDocumentEntities);

                await _context.Business.AddRangeAsync(businessEntities);

                await _context.SaveChangesAsync();
                return new CreateClientResponse() { Result = "Client Registered Successfully" };
            }
            catch (Exception e)
            {
                _logger.LogError("Failed operation in Infrastructure's client repository", e);
                return new CreateClientResponse() { Result = "Client registration failed" };
            }
        }
    }
}
