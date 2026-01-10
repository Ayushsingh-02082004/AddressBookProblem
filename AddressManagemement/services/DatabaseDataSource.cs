using AddressManagemement.Entity;
using AddressManagemement.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AddressManagemement.services
{
    public class DatabaseDataSource : IAddressBookDataSource
    {
        private readonly string connectionString =
           "Data Source=HEY_AYUSH;Initial Catalog=AdressBook;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        public void Save(List<Contacts> contacts)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            foreach (var c in contacts)
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_AddContact", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = c.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = c.LastName;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 100).Value = c.Address;
                cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = c.City;
                cmd.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = c.State;
                cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar, 10).Value = c.ZipCode;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 15).Value = c.PhoneNumber;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = c.Email;

                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("Data saved to database");
        }

        public List<Contacts> Load()
        {
            List<Contacts> list = new();

            using SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("dbo.sp_GetAllContacts", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Contacts(
                    reader["FirstName"].ToString(),
                    reader["LastName"].ToString(),
                    reader["Address"].ToString(),
                    reader["City"].ToString(),
                    reader["State"].ToString(),
                    reader["ZipCode"].ToString(),
                    reader["PhoneNumber"].ToString(),
                    reader["Email"].ToString()
                ));
            }

            return list;
        }
    }
}
