            //***********************************************************************************

            // RoommateRepository roommateRepo = new RoommateRepository(CONNECTION_STRING);

            // Console.WriteLine("Getting All Roommates:");
            // Console.WriteLine();

            // List<Room> allRoommates = roommateRepo.GetAll();

            // foreach (Roommate roommate in allRoommates)
            // {
            //     Console.WriteLine($"{roommate.Id} {roommate.Firstname} {roommate.Lastname}");
            // }
            // Console.WriteLine("----------------------------");
            // Console.WriteLine("Getting Roommate with Id 1");

            // Roommate Gus = new Roommate
            // {
            //     Firstname = "Gus",
            //     Lastname = "Herring",
            //     RentPortion = 500,
            //     MovedInDate = 090920,
            //     Room = "GuestRoom"

            // };

            // roommateRepo.Insert(Gus);

            // Console.WriteLine("-------------------------------");
            // Console.WriteLine($"Added the new Room with id {Gus.Id}");

            // Console.WriteLine("-------------------------------");

            // Gus.RentPortion = 600;
            // roommateRepo.Update(Gus);

            // Roommate GusFromDb = roommateRepo.GetById(Gus.Id);

            // Console.WriteLine($"{GusFromDb.Id} {GusFromDb.Firstname} {GusFromDb.RentPortion}");

            // Console.WriteLine("-------------------------------");
            // roommateRepo.Delete(Gus.Id);

            // allRoommates = roommateRepo.GetAll();

            // foreach (Roommate roommate in allRoommates)
            // {
            //     Console.WriteLine($"{roommate.Id} {roommate.Firstname} {roommate.RentPortion}");
            // }