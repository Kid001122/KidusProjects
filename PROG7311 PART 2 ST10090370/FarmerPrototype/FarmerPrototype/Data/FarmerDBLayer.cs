using FarmerPrototype.Models;
using System.Data.SqlClient;
using System.Data;

namespace FarmerPrototype.Data
{
    public class FarmerDBLayer
    {
        private string conString;
        private IConfiguration _config;

        public FarmerDBLayer(IConfiguration configuration)
        {
            _config = configuration;
            conString = _config.GetConnectionString("azureDBConnect");
        }
        public List<Farmer> AllFarmerList()
        {
            List<Farmer> stList = new List<Farmer>();
            SqlConnection myConnection = new SqlConnection(conString);
            SqlDataAdapter myAdapter = new SqlDataAdapter("select * from Farmer", myConnection);
            DataTable myTable = new DataTable();
            DataRow myRow;
            myConnection.Open();
            myAdapter.Fill(myTable);
            string FarmerID, Surname, FirstName,email,password;
            if (myTable.Rows.Count > 0)
            {
                for (int i = 0; i < myTable.Rows.Count; i++)
                {
                    myRow = myTable.Rows[i];

                    stList.Add(new Farmer(FarmerID = (string)myRow[0], FirstName = (string)myRow[1], Surname = (string)myRow[2],email = (string)myRow[3], password = (string)myRow[4]));
                }
            }
            myConnection.Close();
            return stList;
        }
        public Farmer FarmerDetails(string id)
        {
            Farmer em = new Farmer();
            SqlConnection myConnection = new SqlConnection(conString);
            SqlCommand cmdSelect = new SqlCommand($"select * from Farmer where FarmerID='{id}' ", myConnection);

            myConnection.Open();
            using (SqlDataReader reader = cmdSelect.ExecuteReader())
            {
                while (reader.Read())
                {
                    em = new Farmer((string)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4]);
                }
            }
            myConnection.Close();
            return em;
        }
        public void AddFarmer(Farmer fr)
        {
            using (SqlConnection myConnection = new SqlConnection(conString))
            {
                SqlCommand cmdInsert = new SqlCommand($"insert into Farmer values('{fr.FarmerID}','{fr.FirstName}','{fr.Surnmae}','{fr.Email}','{fr.Password}')", myConnection);
                myConnection.Open();
                cmdInsert.ExecuteNonQuery();
            }
        }
        public void UpdateFarmer(string id, Farmer fr)
        {
            using (SqlConnection myCon = new SqlConnection(conString))
            {
                SqlCommand cmdUpdate = new SqlCommand($"update Farmer set FarmerID='{fr.FarmerID}',FarmerName='{fr.FirstName}',FarmerSurname='{fr.Surnmae}',Email='{fr.Email}',Password='{fr.Password}' where FarmerID='{id}'", myCon);
                myCon.Open();
                cmdUpdate.ExecuteNonQuery();
            }
        }
        public void DeleteFarmer(string id)
        {
            using (SqlConnection myconn = new SqlConnection(conString))
            {
                SqlCommand cmdDelete = new SqlCommand($"Delete from Farmer where FarmerID='{id}'", myconn);
                myconn.Open();
                cmdDelete.ExecuteNonQuery();
            }

        }

        public List<Products> AllPRODUCTS()
        {
            List<Products> stList = new List<Products>();
            SqlConnection myConnection = new SqlConnection(conString);
            SqlDataAdapter myAdapter = new SqlDataAdapter($"select * from ProductTbl", myConnection);
            DataTable myTable = new DataTable();
            DataRow myRow;
            myConnection.Open();
            myAdapter.Fill(myTable);

            if (myTable.Rows.Count > 0)
            {
                for (int i = 0; i < myTable.Rows.Count; i++)
                {
                    myRow = myTable.Rows[i];

                    stList.Add(new Products((string)myRow[0], (string)myRow[1], (string)myRow[2], (string)myRow[3], (string)myRow[4], (string)myRow[5], (string)myRow[6]));
                }
            }
            myConnection.Close();
            return stList;
        }

    }
}
