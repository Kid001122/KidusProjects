namespace FarmerPrototype.Models
{
    public class Products
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public string Quantity { get; set; }
        public string ProductPrice { get; set; }
        public string ProductDate { get; set; }
        public string FamrerID { get; set; }

        public Products()
        {

        }
        public Products(string productID, string productName, string producttype, string quantity, string productPrice,string productDate, string famrerID)
        {
            ProductID = productID;
            ProductName = productName;
            ProductType = producttype;
            Quantity = quantity;
            ProductPrice = productPrice;
            ProductDate = productDate;
            FamrerID = famrerID;
        }
    }
}
