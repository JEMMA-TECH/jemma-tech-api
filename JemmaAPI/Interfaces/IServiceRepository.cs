using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Services;

namespace JemmaAPI.Interfaces;

public interface IServiceRepository
{
    Task<Result<Guid>> CreateService(CreateServiceRequest request);
    Task<Result<IEnumerable<ServiceDto>>> GetAllServices(int page, int pageSize, string search);
    Task<Result<ServiceDto>> GetService(Guid id);
    Task<Result<ServiceDto>> UpdateService(Guid id, CreateServiceRequest request);
    Task<Result<bool>> DeleteService(Guid id);
}