using DemoProject.Data;
using DemoProject.Models;
using DemoProject.Repository;
using DemoProject.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly IItemService itemService;

        public ItemController (IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet("GetItems")]
        public async Task<IActionResult>Get()
        {
            var itm = await itemService.Get();
            if (itm == null)
            {
                return BadRequest();
            }
            return Ok(itm);
        }

        [HttpGet("GetItemsById")]
        public async Task<IActionResult> Get(int Itemid)
        {
            var itm = await itemService.Get(Itemid);
            if (itm == null)
            {
                return BadRequest("Inavlid Credential");
            }
            return Ok(itm);
        }

        [Authorize]
        [HttpPost("PostItems")]
        public async Task<IActionResult> Post(ItemModel item)
        {
            var itm = await itemService.Post(item);
            if (itm == null)
            {
                return BadRequest();
            }
            return Ok(itm);
        }

        [HttpPut("PutItems")]
        public async Task<IActionResult> Put(int Id, ItemModel item)
        {
            var itm = await itemService.Put(Id, item);
            if (itm == null)
            {
                return BadRequest("Inavlid Credential");
            }
            return Ok(itm);
        }

        [HttpDelete("DeleteItems")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var itm = await itemService.Delete(Id);
                if (!itm)
                {
                    return BadRequest("Error");
                }
                return Ok("Removed Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[HttpGet]
        //[Route("GetItems")]
        //public IEnumerable<ItemModel> Get()
        //{
        //    return _dataContext.ItemModels;
        //}

        //[HttpGet]
        //[Route("GetItemById")]
        //public IEnumerable<ItemModel> Get(int Itemid)
        //{
        //    return _dataContext.ItemModels.Where(e=>e.ItemCode == Itemid);
        //}

        //[Authorize]
        //[HttpPost]
        //[Route("PostItem")]
        //public IActionResult Post(ItemModel item)
        //{
        //    _dataContext.ItemModels.Add(item);
        //    _dataContext.SaveChanges();
        //    return Ok(item);
        //}

    }
}
