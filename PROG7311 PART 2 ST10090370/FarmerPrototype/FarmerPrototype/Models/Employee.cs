namespace FarmerPrototype.Models
{
    public class Employee
    {
        public string EmpoyeeeID { get; set; }
        public string FarmerName { get; set; }
        public string Surname { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Employee()
        {

        }

        public Employee(string empoyeeeID, string farmerName, string surname, string cell, string email, string password)
        {
            EmpoyeeeID = empoyeeeID;
            FarmerName = farmerName;
            Surname = surname;
            Cell = cell;
            Email = email;
            Password = password;
        }
    }
}
