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
                    cmd.CommandText = @"SELECT	rm.Id,
		                                        rm.FirstName,
		                                        rm.LastName,
		                                        rm.RentPortion,
		                                        rm.MoveInDate,
		                                        rm.RoomId AS RoommateRoomId,
		                                        r.id AS RoomId,
		                                        r.Name,
		                                        r.MaxOccupancy

                                        FROM Roommate rm LEFT JOIN Room r ON r.id = rm.RoomId
                                        WHERE rm.id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Roommate roommate = null;
                    Room room = null;

                    if (reader.Read())
                    {
                        room = new Room()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("RoomId")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            MaxOccupancy = reader.GetInt32(reader.GetOrdinal("MaxOccupancy")),
                        };

                        roommate = new Roommate()
                        {
                            Id = id,
                            Firstname = reader.GetString(reader.GetOrdinal("FirstName")),
                            Lastname = reader.GetString(reader.GetOrdinal("LastName")),
                            RentPortion = reader.GetInt32(reader.GetOrdinal("RentPortion")),
                            MovedInDate = reader.GetDateTime(reader.GetOrdinal("MoveInDate")),
                            RoomId = reader.GetInt32(reader.GetOrdinal("RoomId")),
                            Room = room
                        };
                    }
                    reader.Close();
                    return roommate;
                }
            }

        }

        public void Insert(Roommate roommate)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {


                    cmd.CommandText = $@"INSERT INTO Roommate
                                            (FirstName, LastName, RentPortion, MoveInDate, RoomId)
                                            OUTPUT INSERTED.Id
                                            VALUES
                                            ( '{roommate.Lastname}', '{roommate.Firstname}', '{roommate.RentPortion}',
                                              '{roommate.MovedInDate}', '{roommate.RoomId}' )";


/*                                            (@FirstName, @LastName, @RentPortion, @MoveInDate, @RoomId)";
                    cmd.Parameters.AddWithValue("@LastName", roommate.Lastname);
                    cmd.Parameters.AddWithValue("@FirstName", roommate.Firstname);
                    cmd.Parameters.AddWithValue("@RentPortion", roommate.RentPortion);
                    cmd.Parameters.AddWithValue("@MoveInDate", roommate.MovedInDate);
                    cmd.Parameters.AddWithValue("@RoomId", roommate.RoomId);
*/
                    int id = (int)cmd.ExecuteScalar();

                    roommate.Id = id;
                }
            }

            // when this method is finished we can look in the database and see the new room.
        }

        public void Update(Roommate roommate)
        {

            using (SqlConnection conn = Connection)
            {

                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = @"UPDATE Roommate 
                                           SET FirstName = @Firstname,
                                               LastName = @Lastname,
                                               RentPortion = @RentPortion,
		                                       MoveInDate = @MovedInDate
		                                       RoomId = @RoomId

                                         WHERE id = @id";

                    cmd.Parameters.AddWithValue("@FirstName", roommate.Firstname);
                    cmd.Parameters.AddWithValue("@LastName", roommate.Lastname);
                    cmd.Parameters.AddWithValue("@RentPortion", roommate.RentPortion);
                    cmd.Parameters.AddWithValue("@MoveInDate", roommate.MovedInDate);
                    cmd.Parameters.AddWithValue("@RoomId", roommate.RoomId);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = @"DELETE FROM Roommate WHERE id = @id";
                                         cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

      
                  
    }
}

