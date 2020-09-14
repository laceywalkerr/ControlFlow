using Microsoft.Data.SqlClient;
using Roommates.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roommates.Repositories
{
    public class RoommateRepository : BaseRepository 
    {
        public RoommateRepository(string connectionString) : base(connectionString) { }

        // GetById is the name of the method, it returns the stuff
        public Roommate GetById(int id)
        {
            using(SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {

                }
            }
        }
    }
}

// namespace Roommates.Repositories
// {
//     class RoomateRepository : BaseRepository
//     {
//         public RoommateRepository(string connectionString) : base(connectionString) { }

//         public List<Roommate> GetAll()
//         {
//             using(SqlConnection conn = Connection)
//             {
//                 conn.Open();

//                 using(SqlCommand cmd = conn.CreateCommand())
//                 {
//                     cmd.CommandText = "SELECT Id Firstname Lastname RentPortion MovedInDate Room FROM Roommate";

//                     SqlDataReader reader = cmd.ExecuteReader();

//                     List<Roommate> roommates = new List<Roommate>();

//                     while (reader.Read())
//                     {
//                         int idColumnPosition = reader.GetOrdinal("Id");

//                         int idValue = reader.GetInt32(idColumnPosition);

//                         int FirstnameColumnPosition = reader.GetOrdinal("Firstname");
//                         string FirstnameValue = reader.GetString(FirstnameColumnPosition);

//                         int LastnameColumnPosition = reader.GetOrdinal("Lastname");
//                         string LastnameValue = reader.GetString(LastnameColumnPosition);

//                         int RentPortionColumnPosition = reader.GetOrdinal("RentPortion");
//                         string RentPortionValue = reader.GetInt32(RentPortionColumnPosition);

//                         int MovedInDateColumnPosition = reader.GetOrdinal("MovedInDate");
//                         string MovedInDateValue = reader.GetInt32(MovedInDateColumnPosition);

//                         int RoomValueColumnPosition = reader.GetOrdinal("RoomValue");
//                         string RoomValueValue = reader.GetString(RoomValueColumnPosition);

//                         Roommate roommate = new Roommate
//                         {
//                             Id = idValue,
//                             Firstname = FirstnameValue,
//                             Lastname = LastnameValue,
//                             RentPortion = RentPortionValue,
//                             MovedInDate = MovedInDateValue,
//                             Room = RoomValue,
//                         };

//                         roommates.Add(roommate);
//                     }

//                     reader.Close();

//                     return roommates;
//                 }
//             }
//         }

//         public Roommate GetById(int id)
//         {
//             using(SqlConnection conn = Connection)
//             {
//                 conn.Open();
//                 using(SqlCommand cmd = conn.CreateCommand())
//                 {
//                     cmd.CommandText = "SELECT  Firstname Lastname RentPortion MovedInDate Room FROM Roommate WHERE Id = @id";
//                     cmd.Parameters.AddWithValue("@id", id);
//                     SqlDataReader reader = cmd.ExecuteReader();

//                     Roommate roommate = null;

//                     if (reader.Read())
//                     {
//                         roommate = new Roommate
//                         {
//                             Id = id,
//                             Firstname = reader.GetString(reader.GetOrdinal("Firstame")),
//                             Lastname = reader.GetString(reader.GetOrdinal("LastName")),
//                             RentPortion = reader.GetInt32(reader.GetOrdinal("RentPortion")),
//                             MovedInDate = reader.GetInt32(reader.GetOrdinal("MovedInDate")),
//                             Room = reader.GetString(reader.GetOrdinal("LastName")),
//                         };
//                     }

//                     reader.Close();

//                     return roommate;
//                 }
//             }
//         }
//         public void Delete(int id)
//         {
//             using(SqlConnection conn = Connection)
//             {
//                 conn.Open();
//                 using(SqlCommand cmd = conn.CreateCommand())
//                 {
//                     cmd.CommandText = "DELETE FROM Roommate WHERE Id = @id";
//                     cmd.Parameters.AddWithValue("@id", id);
//                     cmd.ExecuteNonQuery();
//                 }
//             }
//         }
//     }
// }