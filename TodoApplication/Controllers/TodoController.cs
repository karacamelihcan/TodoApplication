using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
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


        public TodoController(ITodoItemService service, IKodluyoruzLogger logger) //constructor based dependency injection (constructor injection)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Database'den değerleri getir
            //IEnumerable<TodoItem> items = service.GetIncompleteItemsAsync().Result;
            IEnumerable<TodoItem> items = await _service.GetIncompleteItemsAsync();

            // Gelen değerleri yeni modele koy
            TodoViewModel vm = new TodoViewModel {Items = items}; //design decision

            ViewBag.Title = "Yapılacaklar Listesini Yönet";

            // Modeli Görünyüye ekle ve sayfayı göster.
            //logger.Write();
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result =await _service.AddItemAsync(newItem);
            if (!result)
            {
                return BadRequest(new {error = "Could not add item"});
            }

            return Ok();
        }
    }
}