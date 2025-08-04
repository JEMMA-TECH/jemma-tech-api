using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Companies;
using JemmaAPI.Entities.Items;

namespace JemmaAPI.Interfaces;

public interface IItemRepository
{
    Task<Result<Guid>> CreateItem(CreateItemRequest request);
    Task<Result<IEnumerable<ItemDto>>> GetItems(int page, int pageSize, string search);
    Task<Result<ItemDto>> GetItem(Guid id);
    Task<Result<ItemDto>> UpdateItem(Guid id,  CreateItemRequest request);
    Task<Result<bool>> DeleteItem(Guid id);
}