using DataApiService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTaskMVC.Models;

namespace TestTaskMVC.Controllers
{
    public class AdminController : Controller
    {
        private const string secretKey = "secret_key";

        private readonly ILogger<AdminController> _logger;
        private readonly IDataManager _dataManager;
        public AdminController(ILogger<AdminController> logger, IDataManager dataManager)
        {
            _logger = logger;
            _dataManager = dataManager;
        }

        public async Task<IActionResult> Index(string key)
        {
            if(key==secretKey) 
            {
                var modelCoin = new CoinsViewModel() { Coins = await _dataManager.GetItems<List<Coin>>("Coin/GetAllCoin") };
                var modelProduct = new ProductsViewModel() { Products = await _dataManager.GetItems<List<Product>>("Product/GetAllProduct") };
                var combinedModel = new CombinedModel { Coins = modelCoin.Coins, Products = modelProduct.Products };

                return View(combinedModel); 
            }
            else 
            { 
                return View("Error"); 
            }
        }

        public async Task<IActionResult> GetEditProduct(Guid id)
        {
            var modelProduct = new ProductsViewModel() { Products = await _dataManager.GetItems<List<Product>>("Product/GetAllProduct") };
            var model=modelProduct.Products.First(x=>x.Id==id);
            return PartialView("EditProduct",model);
        }
        public async Task<IActionResult> EditProduct(Product product)
        {
            await _dataManager.PutRequest<Product>("Product/UpdateProduct", product);

            return RedirectToAction("Index", "Admin");
        }

        public async Task<IActionResult> DeleteProduct(Dictionary<string,string> id)
        {
            await _dataManager.DeleteRequest<Guid>("Product/DeleteProduct", id);

            return RedirectToAction("Index", "Admin");
        }

        public async Task<IActionResult> GetCreateProduct()
        {
            return PartialView("CreateProduct");
        }

        public async Task<IActionResult> CreateProduct(Dictionary<string,string> product)
        {
            await _dataManager.PostRequest<Dictionary<string,string>>("Product/CreateProduct", product);

            return RedirectToAction("Index", "Admin");
        }





        public async Task<IActionResult> GetEditCoin(int id)
        {
            var modelCoin = new CoinsViewModel() { Coins = await _dataManager.GetItems<List<Coin>>("Coin/GetAllCoin") };
            var model = modelCoin.Coins.First(x => x.Id == id);
            return PartialView("EditCoin", model);
        }
        public async Task<IActionResult> EditCoin(Coin coin)
        {
            await _dataManager.PutRequest<Coin>("Coin/UpdateCoin", coin);

            return RedirectToAction("Index", "Admin");
        }

        public async Task<IActionResult> DeleteCoin(Dictionary<string, string> id)
        {
            await _dataManager.DeleteRequest<int>("Coin/DeleteCoin", id);

            return RedirectToAction("Index", "Admin");
        }

        public async Task<IActionResult> GetCreateCoin()
        {
            return PartialView("CreateCoin");
        }

        public async Task<IActionResult> CreateCoin(Coin coin)
        {
            await _dataManager.PostRequest<Coin>("Coin/CreateCoin", coin);

            return RedirectToAction("Index", "Admin");
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
