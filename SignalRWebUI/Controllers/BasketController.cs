using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            TempData["id"] = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7166/api/Baskets/BasketListByMenuTableWithProductName?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        //Silme
        public async Task<IActionResult> DeleteBasket(int id, int id2)
        {
            id2 = int.Parse(TempData["id"].ToString());
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7166/api/Baskets/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                //return RedirectToAction("Index");
                return new RedirectResult($"~/Basket/Index/{id2}");
            }
            return NoContent();
        }

    }
}
