using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTaskMVC.Models;
using DataApiService;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public async Task<IActionResult> UpdateCoin(Coin coin)
        {
            await _dataManager.PutRequest<Coin>("Coin/UpdateCoin", coin);

            var modelCoin = new CoinsViewModel() { Coins = await _dataManager.GetItems<List<Coin>>("Coin/GetAllCoin") };
            var modelProduct = new ProductsViewModel() { Products = await _dataManager.GetItems<List<Product>>("Product/GetAllProduct") };
            var combinedModel = new CombinedModel { Coins = modelCoin.Coins, Products = modelProduct.Products };

            return PartialView("CoinPanelPartialView", combinedModel) ;
        }



        public async Task<IActionResult> UpdateProduct(Product product)
        {
            await _dataManager.PutRequest<Product>("Product/UpdateProduct", product);

            var modelCoin = new CoinsViewModel() { Coins = await _dataManager.GetItems<List<Coin>>("Coin/GetAllCoin") };
            var modelProduct = new ProductsViewModel() { Products = await _dataManager.GetItems<List<Product>>("Product/GetAllProduct") };
            var combinedModel = new CombinedModel { Coins = modelCoin.Coins, Products = modelProduct.Products };

            return PartialView("ProductPanelPartialView", combinedModel);
        }

        public async Task<string> GiveChange(int totalChange)
         {

            var coins = await _dataManager.GetItems<List<Coin>>("Coin/GetAllCoin");
            string result=null;

            while (totalChange > 0)
            {
                Coin maxCoin = null;
                foreach (Coin coin in coins)
                {
                    if(coin.Value<=totalChange&&(maxCoin==null||coin.Value>maxCoin.Value)&&coin.Quantity>0)
                    {
                        maxCoin = coin; 
                    }
                }
                totalChange -= maxCoin.Value;
                maxCoin.Quantity -= 1;
                await _dataManager.PutRequest<Coin>("Coin/UpdateCoin", maxCoin);
                result= result+" "+ maxCoin.Value.ToString();
                
            }

            return result;
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