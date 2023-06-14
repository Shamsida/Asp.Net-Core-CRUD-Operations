using DemoProject.Data;
using DemoProject.Models;
using DemoProject.Models.Dto;
using DemoProject.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Repository
{
    public class ItemService : IItemService
    {
        private readonly DataContext _dataContext;

        public ItemService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<ItemModel>> Get()
        {
            try
            {
                var items = await _dataContext.ItemModels.ToListAsync();
                return items;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ItemModel> Get(int Itemid)
        {
            try
            {
                var items = _dataContext.ItemModels.FirstOrDefault(e => e.ItemCode == Itemid);
                if (items == null)
                {
                    throw new Exception("Invalid entry");
                }
                return items;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }
        }

        public async Task<ItemModel> Post(ItemModel item)
        {
            try
            {
                if (item == null)
                {
                    throw new Exception("Invalid entry");
                }
                _dataContext.ItemModels.Add(item);
                await _dataContext.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }
        }

        public async Task<ItemModel> Put(int Id, ItemModel item)
        {
            try
            {
                if (item == null)
                {
                    throw new Exception("Invalid entry");
                }
                var itm = _dataContext.ItemModels.FirstOrDefault(x => x.ItemCode == Id);
                if (itm == null)
                {
                    throw new Exception("Not Found");
                }
                itm.ItemCode = item.ItemCode;
                itm.ItemName = item.ItemName;
                itm.Price = item.Price;
                await _dataContext.SaveChangesAsync();
                return itm;

            }
            catch (Exception ex)
            {
                throw;
                return null;
            }
        }

        public async Task<bool> Delete(int Id)
        {
            try
            {
                var itm = _dataContext.ItemModels.FirstOrDefault(x => x.ItemCode == Id);
                if (itm == null)
                {
                    throw new Exception("Not Found");
                }
                _dataContext.ItemModels.Remove(itm);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
                return false;
            }
        }
    }
}
