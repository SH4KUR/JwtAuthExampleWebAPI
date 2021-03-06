﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAuthExample.Core.Entities;
using JwtAuthExample.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthExample.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        // GET: api/items
        [HttpGet]
        public async Task<IReadOnlyList<Item>> GetItems() => await _itemService.GetAllAsync();

        // GET: api/items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _itemService.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.ItemId)
            {
                return BadRequest();
            }
            
            try
            {
                await _itemService.UpdateAsync(item);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/items
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            await _itemService.AddAsync(item);
            return CreatedAtAction("GetItem", new { id = item.ItemId }, item);
        }

        // DELETE: api/items/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItem(int id)
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            await _itemService.DeleteAsync(item);
            return item;
        }

        private async Task<bool> ItemExists(int id)
        {
            var items = await _itemService.GetAllAsync();
            return items.Any(x => x.ItemId == id);
        }
    }
}
