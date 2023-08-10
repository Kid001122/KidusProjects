using FarmerPrototype.Data;
using FarmerPrototype.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace FarmerPrototype.Controllers
{

    public class LoginController : Controller
    {
        public string ConString;

        public LoginController(IConfiguration CON)
        {
            ConString = CON.GetConnectionString("azureDBConnect");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    connection.Open();

                    
                    string farmerQuery = "SELECT COUNT(*) FROM Farmer WHERE EMAIL = @Email AND PASSWORD = @Password";
                    using (SqlCommand farmerCommand = new SqlCommand(farmerQuery, connection))
                    {
                        farmerCommand.Parameters.AddWithValue("@Password", loginModel.Password);
                        int Count = (int)farmerCommand.ExecuteScalar();
                        farmerCommand.Parameters.AddWithValue("@Email", loginModel.Username);
                       
                        if (Count > 0)
                        {
                            string farmerID = GetID(loginModel.Username);
                            HttpContext.Session.SetString("FarmerID", farmerID);

                            
                            return RedirectToAction("Index", "Products");
                        }
                    }

                    
                    string employeeQuery = "SELECT COUNT(*) FROM Emplloyee WHERE EMAIL = @Email AND PASSWORD = @Password";
                    using (SqlCommand employeeCommand = new SqlCommand(employeeQuery, connection))
                    {
                        employeeCommand.Parameters.AddWithValue("@Password", loginModel.Password);
                        int eCount = (int)employeeCommand.ExecuteScalar();
                        employeeCommand.Parameters.AddWithValue("@Email", loginModel.Username);
                        

                        if (eCount > 0)
                        {
                         
                            return RedirectToAction("Index", "Farmer");
                        }
                    }

                    // Invalid login, show error message
                    ViewBag.ErrorMessage = "Please check email or password";
                    return View();
                }
            }

            return View();
        }
        private string GetID(string email)
        {
            string ID = "";

            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();

                string query = "SELECT FARMERID FROM Farmer WHERE EMAIL = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    ID = (string)command.ExecuteScalar();
                }
            }

            return ID;
        }
    }
}

