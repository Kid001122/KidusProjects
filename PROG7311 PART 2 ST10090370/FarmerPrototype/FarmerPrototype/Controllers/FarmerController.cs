using FarmerPrototype.Data;
using FarmerPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmerPrototype.Controllers
{
    public class FarmerController : Controller
    {
        FarmerDBLayer FarmerDbHelper;
        ProductsDBLayer ProductDbHelper;
        public FarmerController(IConfiguration CON)
        {

            FarmerDbHelper = new FarmerDBLayer(CON);
            ProductDbHelper = new ProductsDBLayer(CON);
        }
        public ActionResult Index1()
        {
            List<Products> stList =FarmerDbHelper.AllPRODUCTS();
            return View(stList);
        }
        // GET: FarmerController
        public ActionResult Index()
        {
            List<Farmer> stList = FarmerDbHelper.AllFarmerList();
            return View(stList);
        }

        // GET: FarmerController/Details/5
        public ActionResult Details(string Identity)
        {
            Farmer em = FarmerDbHelper.FarmerDetails(Identity);
            return View(em);
        }

        // GET: FarmerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FarmerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                string FarmerID = collection["txtFarmerID"];
                string FirstName = collection["txtFirstName"];
                string Surname = collection["txtSurname"];
                string email = collection["txtEmail"];
                string passowrd = collection["txtPassword"];

                 Farmer farm = new Farmer(FarmerID, FirstName, Surname,email,passowrd);
                 FarmerDbHelper.AddFarmer(farm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FarmerController/Edit/5
        public ActionResult Edit(string Identity)
        {
            Farmer fr = FarmerDbHelper.FarmerDetails(Identity);
            return View(fr);
        }

        // POST: FarmerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string Identity, IFormCollection collection)
        {
            try
            {
                string FarmerID = collection["txtFarmerID"];
                string FirstName = collection["txtFirstName"];
                string Surname = collection["txtSurname"];
                string email = collection["txtEmail"];
                string passowrd = collection["txtPassword"];
                Farmer farm = new Farmer(FarmerID, FirstName, Surname, email, passowrd);
                FarmerDbHelper.UpdateFarmer(Identity, farm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FarmerController/Delete/5
        public ActionResult Delete(string Identity)
        {
            Farmer farm = FarmerDbHelper.FarmerDetails(Identity);
            return View(farm);
            
        }

        // POST: FarmerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string Identity, IFormCollection collection)
        {
            try
            {
                FarmerDbHelper.DeleteFarmer(Identity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
