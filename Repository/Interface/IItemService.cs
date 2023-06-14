using DemoProject.Models;

namespace DemoProject.Repository.Interface
{
    public interface IItemService
    {
        Task<IEnumerable<ItemModel>> Get();
        Task<ItemModel> Get(int id);
        Task<ItemModel> Post(ItemModel item);
        Task<ItemModel> Put(int Id, ItemModel item);
        Task<bool> Delete(int Id);
    }
}
