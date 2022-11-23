using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Test1()
        {
            return View();
        }

        [HttpPost]
        public List<Test1> NextItems(int lastItemId)
        {
            var list = GetListOfItems().OrderBy(i => i.ID);

            if (lastItemId >= list.Last().ID)
            {
                return new List<Test1>();
            }

            var result = list.Where(i => i.ID > lastItemId).Take(2).ToList();

            return result;
        }

        public IActionResult Test2()
        {
            return View(new ViewModel());
        }

        [HttpPost]
        public ActionResult Test2(ViewModel model)
        {
            var service = new PaymentService(new InputParams { CountPeople = model.PlayersNumber, InitAmount = model.StartAmount });
            var result = service.Start().Result;
            ViewBag.Result = result;
            return View(new ViewModel());
        }

        private List<Test1> GetListOfItems()
        {
            List<Test1> Items = new List<Test1>();
            Items.Add(new Test1() { ID = 1, Title = "Title 1", Data1 = "Data1 1", Data2 = "Data2 1", Data3 = "Data3 1", Data4 = "Data4 1", OtherTypeValue = new Test1.OtherType() { ID = 1, Title = "Ot1" } });
            Items.Add(new Test1() { ID = 2, Title = "Title 2", Data1 = "Data1 2", Data2 = "Data2 2", Data3 = "Data3 2", Data4 = "Data4 2", OtherTypeValue = new Test1.OtherType() { ID = 2, Title = "Ot2" } });
            Items.Add(new Test1() { ID = 3, Title = "Title 3", Data1 = "Data1 3", Data2 = "Data2 3", Data3 = "Data3 3", Data4 = "Data4 3", OtherTypeValue = new Test1.OtherType() { ID = 3, Title = "Ot3" } });
            Items.Add(new Test1() { ID = 4, Title = "Title 4", Data1 = "Data1 4", Data2 = "Data2 4", Data3 = "Data3 4", Data4 = "Data4 4", OtherTypeValue = new Test1.OtherType() { ID = 4, Title = "Ot4" } });
            Items.Add(new Test1() { ID = 5, Title = "Title 5", Data1 = "Data1 5", Data2 = "Data2 5", Data3 = "Data3 5", Data4 = "Data4 5", OtherTypeValue = new Test1.OtherType() { ID = 5, Title = "Ot5" } });
            Items.Add(new Test1() { ID = 6, Title = "Title 6", Data1 = "Data1 6", Data2 = "Data2 6", Data3 = "Data3 6", Data4 = "Data4 6", OtherTypeValue = new Test1.OtherType() { ID = 6, Title = "Ot6" } });
            Items.Add(new Test1() { ID = 7, Title = "Title 7", Data1 = "Data1 7", Data2 = "Data2 7", Data3 = "Data3 7", Data4 = "Data4 7", OtherTypeValue = new Test1.OtherType() { ID = 7, Title = "Ot7" } });

            return Items;
        }
    }
}