using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApplication.Data;
using TodoApplication.Models;
using TodoApplication.Services;
using TodoApplication.Utilities.Loggers;

namespace TodoApplication.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService _service;
        private readonly IKodluyoruzLogger _logger;


        public TodoController(ITodoItemService service,
            IKodluyoruzLogger logger) //constructor based dependency injection (constructor injection)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<TodoItem> items = await _service.GetIncompleteItemsAsync();

            // Gelen değerleri yeni modele koy
            TodoViewModel vm = new TodoViewModel {Items = items}; //design decision

            ViewBag.Title = "Yapılacaklar Listesini Yönet";

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.AddItemAsync(newItem);
            if (!result)
            {
                return BadRequest(new {error = "Could not add item"});
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var successfull = await _service.MarkDoneAsync(id);
            if (!successfull) return BadRequest();
            return Ok();
        }
    }
}