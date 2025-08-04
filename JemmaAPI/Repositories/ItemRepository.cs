using System.Net;
using AutoMapper;
using JemmaAPI.Constants;
using JemmaAPI.Context;
using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Items;
using JemmaAPI.Entities.Services;
using JemmaAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JemmaAPI.Repositories;

public class ItemRepository(ApplicationDbContext context, IMapper mapper) : IItemRepository
{
    public async Task<Result<Guid>> CreateItem(CreateItemRequest request)
    {
        var existingItem = await context.Items
            .FirstOrDefaultAsync(s => s.Name == request.Name);

        if (existingItem == null)
        {
            return new Result<Guid>(HttpStatusCode.Conflict, Messages.ItemAlreadyExistsMessage);
        }
        
        var item = mapper.Map<Item>(request);
        await context.Items.AddAsync(item);
        await context.SaveChangesAsync();
        
        return new Result<Guid>(HttpStatusCode.Created, Messages.ItemAdded, data:item.Id);
    }

    public async Task<Result<IEnumerable<ItemDto>>> GetItems(int page, int pageSize, string search)
    {
        var query = context.Items.AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(s => s.Name.Contains(search));
        }
        
        return new Result<IEnumerable<ItemDto>>(HttpStatusCode.OK, Messages.ItemsRetrieved,
            data: mapper.Map<IEnumerable<ItemDto>>(await query.ToListAsync()));
    }

    public async Task<Result<ItemDto>> GetItem(Guid id)
    {
        var item = await context.Items
            .FirstOrDefaultAsync(s => s.Id == id);
        return item is null ? 
            new Result<ItemDto>(HttpStatusCode.NotFound,Messages.ItemNotFound,false) :
            new Result<ItemDto>(HttpStatusCode.OK,Messages.ItemRetrieved,true,mapper.Map<ItemDto>(item));
    }

    public async Task<Result<ItemDto>> UpdateItem(Guid id, CreateItemRequest request)
    {
        var item = await context.Items
            .FirstOrDefaultAsync(s => s.Id == id);
        if (item is null) return new Result<ItemDto>(HttpStatusCode.NotFound,Messages.ItemNotFound,false);
        
        mapper.Map(request, item);
        context.Items.Update(item);
        await context.SaveChangesAsync();
        
        return new Result<ItemDto>(HttpStatusCode.NoContent, Messages.ItemUpdated);
        
    }

    public async Task<Result<bool>> DeleteItem(Guid id)
    {
        var item = await context.Items
            .FirstOrDefaultAsync(s => s.Id == id);
        if (item is null) return new Result<bool>(HttpStatusCode.NotFound,Messages.ItemNotFound);
        
        context.Items.Remove(item);
        await context.SaveChangesAsync();
        return new Result<bool>(HttpStatusCode.NoContent, Messages.ItemDeleted);
    }
}