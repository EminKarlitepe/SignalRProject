using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using System.Text;
using System.Globalization;

namespace SignalRWebUI.Controllers
{
    public class BasketsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BasketsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int id)
        {
            TempData["id"] = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/Basket/BasketListByMenuTableWithProductName?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteBasket(int id)
        {
            var tableId = TempData["id"];
            TempData.Keep("id");
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7000/api/Basket/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                if (tableId != null)
                {
                    return RedirectToAction("Index", new { id = (int)tableId });
                }
                return RedirectToAction("Index");
            }
            return NoContent();
        }

        public async Task<IActionResult> CompleteOrder(int tableId, decimal finalTotalPrice)
        {
            var client = _httpClientFactory.CreateClient();

            string amountString = finalTotalPrice.ToString(CultureInfo.InvariantCulture);

            await client.PostAsync($"https://localhost:7000/api/Orders/CompleteOrder?tableNumber={tableId}&totalPrice={amountString}", null);

            await client.PostAsync($"https://localhost:7000/api/MoneyCases/AddTotalMoneyCaseAmount?amount={amountString}", null);

            await client.DeleteAsync($"https://localhost:7000/api/Basket/DeleteBasketByMenuTableID/{tableId}");

            await client.GetAsync($"https://localhost:7000/api/MenuTables/ChangeMenuTableStatusToFalse?id={tableId}");

            return RedirectToAction("TableListByStatus", "Default");
        }
    }
}