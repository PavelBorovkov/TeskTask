using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTaskMVC.Models;
using DataApiService;

namespace TestTaskMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataManager _dataManager;
        public HomeController(ILogger<HomeController> logger, IDataManager dataManager)
        {
            _logger = logger;
            _dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
            var modelCoin = new CoinsViewModel() { Coins = await _dataManager.GetItems<List<Coin>>("Coin/GetAllCoin") };
            var modelProduct = new ProductsViewModel() { Products = await _dataManager.GetItems<List<Product>>("Product/GetAllProduct") };
            var combinedModel=new CombinedModel { Coins=modelCoin.Coins, Products=modelProduct.Products };
            
            return View(combinedModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}