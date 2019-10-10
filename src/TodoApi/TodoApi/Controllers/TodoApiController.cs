using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Contracts.Models;
using TodoApi.Contracts.Service;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoApiController : Controller
    {
        private readonly ITodoService service;

        public TodoApiController(ITodoService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<IReadOnlyCollection<TodoItemModel>>> Get()
        {
            return Json(await service.Get());
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<TodoItemModel>> Get(long id)
        {
            var todoItem = await service.Get(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return Json(todoItem);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(TodoItemModel newItem)
        {
            await service.Add(newItem);

            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(TodoItemModel item)
        {
            await service.Update(item);

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await service.Delete(id);

            return Ok();
        }
    }
}