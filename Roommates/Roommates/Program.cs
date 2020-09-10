using System;
using System.Collections.Generic;
using Roommates.Models;
using Roommates.Repositories;

namespace Roommates
{
    class Program
    {
        /// <summary>
        ///  This is the address of the database.
        ///  We define it here as a constant since it will never change.
        /// </summary>
        private const string CONNECTION_STRING = @"server=localhost\SQLExpress;database=Roommates;integrated security=true";

        static void Main(string[] args)
        {
            RoomRepository roomRepo = new RoomRepository(CONNECTION_STRING);

            Console.WriteLine("Getting All Rooms:");
            Console.WriteLine();

            List<Room> allRooms = roomRepo.GetAll();

            foreach (Room room in allRooms)
            {
                Console.WriteLine($"{room.Id} {room.Name} {room.MaxOccupancy}");
            }
            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Room with Id 1");

            //Room singleRoom = roomRepo.GetById(1);

            //Console.WriteLine($"{singleRoom.Id} {singleRoom.Name} {singleRoom.MaxOccupancy}");

            Room bathroom = new Room
            {
                Name = "Bathroom",
                MaxOccupancy = 1
            };

            roomRepo.Insert(bathroom);

            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Added the new Room with id {bathroom.Id}");

            Console.WriteLine("-------------------------------");

            bathroom.MaxOccupancy = 3;
            roomRepo.Update(bathroom);

            Room bathroomFromDb = roomRepo.GetById(bathroom.Id);

            Console.WriteLine($"{bathroomFromDb.Id} {bathroomFromDb.Name} {bathroomFromDb.MaxOccupancy}");

            Console.WriteLine("-------------------------------");
            roomRepo.Delete(bathroom.Id);

            allRooms = roomRepo.GetAll();

            foreach (Room room in allRooms)
            {
                Console.WriteLine($"{room.Id} {room.Name} {room.MaxOccupancy}");
            }

            //***********************************************************************************

            RoommateRepository roommateRepo = new RoommateRepository(CONNECTION_STRING);

            Console.WriteLine("Getting All Roommates:");
            Console.WriteLine();

            List<Room> allRoommates = roommateRepo.GetAll();

            foreach (Roommate roommate in allRoommates)
            {
                Console.WriteLine($"{roommate.Id} {roommate.Firstname} {roommate.Lastname}");
            }
            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Roommate with Id 1");

            Roommate Gus = new Roommate
            {
                Firstname = "Gus",
                Lastname = "Herring",
                RentPortion = 500,
                MovedInDate = 090920,
                Room = "GuestRoom"

            };

            roommateRepo.Insert(Gus);

            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Added the new Room with id {Gus.Id}");

            Console.WriteLine("-------------------------------");

            Gus.RentPortion = 600;
            roommateRepo.Update(Gus);

            Roommate GusFromDb = roommateRepo.GetById(Gus.Id);

            Console.WriteLine($"{GusFromDb.Id} {GusFromDb.Firstname} {GusFromDb.RentPortion}");

            Console.WriteLine("-------------------------------");
            roommateRepo.Delete(Gus.Id);

            allRoommates = roommateRepo.GetAll();

            foreach (Roommate roommate in allRoommates)
            {
                Console.WriteLine($"{roommate.Id} {roommate.Firstname} {roommate.RentPortion}");
            }
        }
    }
}