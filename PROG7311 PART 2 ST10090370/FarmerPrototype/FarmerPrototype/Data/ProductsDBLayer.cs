using FarmerPrototype.Models;
using System.Data.SqlClient;
using System.Data;

namespace FarmerPrototype.Data
{
    public class ProductsDBLayer
    {
        private string conString;
        private IConfiguration _config;

        public ProductsDBLayer(IConfiguration configuration)
        {
            _config = configuration;
            conString = _config.GetConnectionString("azureDBConnect");
        }
      
        public Products ProductDetails(string id)
        {
            Products em = new Products();
            SqlConnection myConnection = new SqlConnection(conString);
            SqlCommand cmdSelect = new SqlCommand($"select * from ProductTbl where ProductID='{id}' ", myConnection);

            myConnection.Open();
            using (SqlDataReader reader = cmdSelect.ExecuteReader())
            {
                while (reader.Read())
                {
                    em = new Products((string)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4], (string)reader[5], (string)reader[6]);
                }
            }
            myConnection.Close();
            return em;
        }
        public void AddProduct(Products pd)
        {
            using (SqlConnection myConnection = new SqlConnection(conString))
            {
                SqlCommand cmdInsert = new SqlCommand($"insert into ProductTbl values('{pd.ProductID}','{pd.ProductName}','{pd.ProductType}','{pd.Quantity}','{pd.ProductPrice}','{pd.ProductDate}','{pd.FamrerID}')", myConnection);
                myConnection.Open();
                cmdInsert.ExecuteNonQuery();
            }
        }
        public void UpdateProducts(string id, Products pd)
        {
            using (SqlConnection myCon = new SqlConnection(conString))
            {
                SqlCommand cmdUpdate = new SqlCommand($"update ProductTbl set ProductID='{pd.ProductID}'," +
                    $"ProductName='{pd.ProductName}',ProductType='{pd.ProductType}',Quantity='{pd.Quantity}',ProductPrice='{pd.ProductPrice}'," +
                    $"ProductDate='{pd.ProductDate}',FarmerID='{pd.FamrerID}' where ProductID='{id}'", myCon);
                myCon.Open();
                cmdUpdate.ExecuteNonQuery();
            }
        }
        public void DeleteProduct(string id)
        {
            using (SqlConnection myconn = new SqlConnection(conString))
            {
                SqlCommand cmdDelete = new SqlCommand($"Delete from ProductTbl where ProductID='{id}'", myconn);
                myconn.Open();
                cmdDelete.ExecuteNonQuery();
            }

        }
        public List<Products> AllProducts(string id)
        {
            List<Products> stList = new List<Products>();
            SqlConnection myConnection = new SqlConnection(conString);
            SqlDataAdapter myAdapter = new SqlDataAdapter($"select * from ProductTbl where FarmerID='{id}'", myConnection);
            DataTable myTable = new DataTable();
            DataRow myRow;
            myConnection.Open();
            myAdapter.Fill(myTable);
            
            if (myTable.Rows.Count > 0)
            {
                for (int i = 0; i < myTable.Rows.Count; i++)
                {
                    myRow = myTable.Rows[i];

                    stList.Add(new Products((string)myRow[0], (string)myRow[1], (string)myRow[2], (string)myRow[3], (string)myRow[4], (string)myRow[5],(string)myRow[6]));
                }
            }
            myConnection.Close();
            return stList;
        }
       
    } 
    }




