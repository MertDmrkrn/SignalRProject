using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//bir istemci oluşturduk bu fonksiyonu kullanarak
            var responseMessage = await client.GetAsync("https://localhost:7166/api/Category"); //verileri listelemek için bir method
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //içeriği string formatında oku
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData); //Listeleme yaparken DeserializeObject Ekleme güncelleme yaparken SerializeObject kullanıyoruz
                return View(values);
            }
            return View();
        }

        //Ekleme
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            createCategoryDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//3 parametre alıyor 1.si=gelen data, 2.si=Türkce karakter varsa onu da kullanması için UTF8 i ekledik, 3.sü=medyanın türü
            var responseMessage = await client.PostAsync("https://localhost:7166/api/Category", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }


        //Silme
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7166/api/Category/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }



        //Güncelleme
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7166/api/Category/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7166/api/Category/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
