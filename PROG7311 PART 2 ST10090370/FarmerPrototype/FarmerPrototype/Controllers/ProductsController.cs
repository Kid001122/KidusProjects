using FarmerPrototype.Data;
using FarmerPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmerPrototype.Controllers
{
    public class ProductsController : Controller
    {
        ProductsDBLayer dbHelper;
        public ProductsController(IConfiguration config)
        {
            
            dbHelper = new ProductsDBLayer(config);
        }
        // GET: ProductsController
        public ActionResult Index()
        {
            string ID=HttpContext.Session.GetString("FarmerID");
            List<Products> stList = dbHelper.AllProducts(ID);
            return View(stList);
        }


        // GET: ProductsController/Details/5
        public ActionResult Details(string id)
        {
            Products em = dbHelper.ProductDetails(id);
            return View(em);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                string ProductID = collection["txtProductID"];
                string ProductName = collection["txtProductName"];
                string ProductType = collection["txtType"];
                string Quantity = collection["txtQuantity"];
                string Price = collection["txtProductPrice"];
                string Date = collection["txtDate"];
                string farmerID = collection["txtFarmerID"];

                Products prod = new Products(ProductID, ProductName,ProductType, Quantity, Price,Date, farmerID);
                dbHelper.AddProduct(prod);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(string id)
        {
            Products prod = dbHelper.ProductDetails(id);
            return View(prod);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                string ProductID = collection["txtProductID"];
                string ProductName = collection["txtProductName"];
                string ProductType = collection["txtType"];
                string Quantity = collection["txtQuantity"];
                string Price = collection["txtProductPrice"];
                string Date = collection["txtDate"];
                string farmerID = collection["txtFarmerID"];
                Products prod = new Products(ProductID, ProductName, ProductType, Quantity, Price, Date, farmerID);
                dbHelper.UpdateProducts(id, prod);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(string id)
        {
            Products prod = dbHelper.ProductDetails(id);
            return View(prod);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                dbHelper.DeleteProduct(id);  
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
