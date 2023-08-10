namespace FarmerPrototype.Models
{
    public class Farmer
    {
        public string FarmerID { get; set; }
        public string FirstName { get; set; }
        public string Surnmae { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Farmer() { }
        public Farmer(string farmerID, string firstName, string surnmae, string email, string password)
        {
            FarmerID = farmerID;
            FirstName = firstName;
            Surnmae = surnmae;
            Email = email;
            Password = password;
        }
    }

}
