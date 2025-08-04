using System.Net;
using AutoMapper;
using JemmaAPI.Constants;
using JemmaAPI.Context;
using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Services;
using JemmaAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JemmaAPI.Repositories;

public class ServiceRepository(ApplicationDbContext context, IMapper mapper) : IServiceRepository
{
    public async Task<Result<Guid>> CreateService(CreateServiceRequest request)
    {
        var existingService = await context.Services
            .FirstOrDefaultAsync(s => s.Name == request.Name);

        if (existingService == null)
        {
            return new Result<Guid>(HttpStatusCode.Conflict, Messages.ServiceAlreadyExistsMessage);
        }
        
        var service = mapper.Map<Service>(request);
        await context.Services.AddAsync(service);
        await context.SaveChangesAsync();
        
        return new Result<Guid>(HttpStatusCode.Created, Messages.ServiceAdded, data:service.Id);
    }

    public async Task<Result<IEnumerable<ServiceDto>>> GetAllServices(int page, int pageSize, string search)
    {
        var query = context.Services.AsQueryable();
        return new Result<IEnumerable<ServiceDto>>(HttpStatusCode.OK, Messages.ServicesRetrieved,
            data: mapper.Map<IEnumerable<ServiceDto>>(await query.ToListAsync()));
    }

    public async Task<Result<ServiceDto>> GetService(Guid id)
    {
       var service = await context.Services
            .FirstOrDefaultAsync(s => s.Id == id);
       
       return service == null ? new Result<ServiceDto>(HttpStatusCode.NotFound, Messages.ServiceNotFound)
           : new Result<ServiceDto>(HttpStatusCode.OK, Messages.ServiceFound, data: mapper.Map<ServiceDto>(service));
    }

    public async Task<Result<ServiceDto>> UpdateService(Guid id, CreateServiceRequest request)
    {
        var  service = await context.Services
            .FirstOrDefaultAsync(s => s.Id == id);
        
        if (service == null)
        {
            return new Result<ServiceDto>(HttpStatusCode.NotFound, Messages.ServiceNotFound);
        }
        
        mapper.Map(request, service);
        context.Services.Update(service);
        await context.SaveChangesAsync();
        
        return new Result<ServiceDto>(HttpStatusCode.OK, Messages.ServiceUpdated, data: mapper.Map<ServiceDto>(service));
    }

    public async Task<Result<bool>> DeleteService(Guid id)
    {
        var service = await context.Companies.FirstOrDefaultAsync(s => s.Id == id);
        if (service == null)
        {
            return new Result<bool>(HttpStatusCode.NotFound,Messages.ServiceNotFound);
        }
        
        context.Companies.Remove(service);
        await context.SaveChangesAsync();
        return new Result<bool>(HttpStatusCode.OK, Messages.ServiceDeleted);
    }
}